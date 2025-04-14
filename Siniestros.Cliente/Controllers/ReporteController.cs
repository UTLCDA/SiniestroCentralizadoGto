using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siniestros.Cliente.Models;

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


    }
}
