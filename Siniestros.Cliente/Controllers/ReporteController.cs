using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiniestroCentralizadoGtoApi.Modelos;
using Siniestros.Cliente.Models;
using System.Globalization;
using System.Text;

namespace Siniestros.Cliente.Controllers
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
            reporte.AjustadorId = 1;
                //HttpContext.Session.GetInt32("AjustadorId");
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
                if (Estatus.Contains("Pendiente"))
                {
                    return View(reporte); // mensaje personalizado de que su poliza 
                    // hace falta el pago correspondiente de su poliza {} su ultima fecha de pago fue {}
                }

                if (FechaInicioPoliza.HasValue && FechaFinPoliza.HasValue && Estatus.ToUpper() == "PAGADA")
                {
                    DateTime inicio = FechaInicioPoliza.Value.ToDateTime(TimeOnly.MinValue);
                    DateTime fin = FechaFinPoliza.Value.ToDateTime(TimeOnly.MaxValue);

                    if (reporte.FechaSiniestro >= inicio && reporte.FechaSiniestro <= fin)
                    {
                        esVigente = true;
                    }
                }
                else
                {
                    return View(reporte); // mensaje de que la poliza no esta en el rango y / o no esta pagada
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

                var respuesta = await _httpClient.PostAsync("/api/Reporte/AltaReporte", content);
                if(confirmacionReporte == true)
                {
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al crear el reporte");
                    }
                }
                // mensaje de que faltan corregir los datos.
            }
            return View(reporte);
        }


    }
}
