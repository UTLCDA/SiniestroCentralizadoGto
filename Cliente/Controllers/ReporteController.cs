using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servidor.Modelos;
using Cliente.Models;
using System.Globalization;
using System.Text;

namespace Cliente.Controllers
{
    public class ReporteController : Controller
    {
        private readonly HttpClient _httpClient;

        public ReporteController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respuesta = await _httpClient.GetAsync("api/Reporte/ListadoReportes");

            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var reportes = JsonConvert.DeserializeObject<IEnumerable<ReporteVistaModelo>>(content);
                return View("Index", reportes);

            }
            return View(new List<ReporteVistaModelo>());
        }

        [HttpGet]
        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Alta(Reporte reporte)
        {
            reporte.AjustadorId = HttpContext.Session.GetInt32("IdUsuario");
            var endPointValidaPoliza = $"api/Poliza/NumeroPolizaLinq?cadena={reporte.PolizaId}";
            var respuestaPoliza = await _httpClient.GetAsync(endPointValidaPoliza);
            var Estatus = String.Empty;
            DateOnly? FechaInicioPoliza = null;
            DateOnly? FechaFinPoliza = null;
            DateOnly? UltimoPago = null;
            bool esVigente = false;
            bool confirmacionReporte = false;
            DateTime FechaSiniestroNow = DateTime.Now;

            

            if (respuestaPoliza.IsSuccessStatusCode)
            {
                var content = await respuestaPoliza.Content.ReadAsStringAsync();
                var polizas = JsonConvert.DeserializeObject<List<PolizaVistaModelo>>(content);
                foreach (var poliza in polizas)
                {
                    Estatus = poliza.Estatus;
                    FechaInicioPoliza = poliza.FechaInicioVigencia;
                    FechaFinPoliza = poliza.FechaFinVigencia;
                    UltimoPago = poliza.UltimoPago;
                }
                if (Estatus.ToUpper() == "PENDIENTE")
                {
                    ViewData["ErrorMessage"] = $"La poliza # {reporte.PolizaId} tiene un pago pendiente, favor de hacer el pago correspondiente, fecha de ultimo pago {UltimoPago}";
                    return View(reporte); // mensaje personalizado de que su poliza 
                    // hace falta el pago correspondiente de su poliza {} su ultima fecha de pago fue {}
                }

                if (FechaInicioPoliza.HasValue && FechaFinPoliza.HasValue && Estatus.ToUpper() == "PAGADO")
                {
                    DateTime inicio = FechaInicioPoliza.Value.ToDateTime(TimeOnly.MinValue);
                    DateTime fin = FechaFinPoliza.Value.ToDateTime(TimeOnly.MaxValue);

                    if (reporte.FechaSiniestro >= inicio && reporte.FechaSiniestro <= fin)
                    {
                        esVigente = true;
                    }
                    if (!esVigente)
                    {
                        ViewData["ErrorMessage"] = $"La poliza # {reporte.PolizaId} esta fuera de rango. Fecha Siniestro {reporte.FechaSiniestro} , Fecha Inicio Poliza {FechaInicioPoliza} Fecha Fin Poliza {FechaFinPoliza}";
                        return View(reporte);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"La poliza {reporte.PolizaId} esta fuera de rango.");
                    ViewData["ErrorMessage"] = $"La poliza # {reporte.PolizaId} esta fuera de rango, Fecha Siniestro {reporte.FechaSiniestro} , Fecha Inicio Poliza {FechaInicioPoliza} Fecha Fin Poliza {FechaFinPoliza}";
                    return View(reporte); 
                }
            }
            else
            {

                ModelState.AddModelError(string.Empty, $"Ocurrio un error al consultar la Poliza {reporte.PolizaId}, comuniquese con el Admon del sistema");
            }

            confirmacionReporte = reporte.EsCorrecto;

            if (ModelState.IsValid)
            {
                if (FechaSiniestroNow.ToString("dd/MM/yyyy") == reporte.FechaSiniestro.ToString("dd/MM/yyyy"))
                {
                    reporte.FechaSiniestro = FechaSiniestroNow;
                }
                var json = JsonConvert.SerializeObject(reporte);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                
                if(confirmacionReporte == true)
                {
                    var respuesta = await _httpClient.PostAsync("/api/Reporte/AltaReporte", content);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Error al crear el reporte";
                        ModelState.AddModelError(string.Empty, "Error al crear el reporte");
                    }
                }
                ViewData["ErrorMessage"] = "Favor de Validar los datos correctamente con el Contratante";
            }
            return View(reporte);
        }


    }
}
