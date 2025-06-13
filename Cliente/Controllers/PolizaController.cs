using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Cliente.Models;

namespace Cliente.Controllers
{
    public class PolizaController : Controller
    {
        private readonly HttpClient _httpClient;

        public PolizaController(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> Index(string valorBusqueda, string tipoBusqueda)
        {
            string endpoint;

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                endpoint = "api/Poliza/ListadoPolizas";
            }
            else
            {
                switch (tipoBusqueda)
                {
                    case "NumeroPoliza":
                        endpoint = $"api/Poliza/NumeroPolizaLinq?cadena={valorBusqueda}";
                        break;
                    case "NombreBeneficiario":
                        endpoint = $"api/Poliza/NombreBeneficiario?nombreLike={valorBusqueda}";
                        break;
                    default:
                        endpoint = "api/Poliza/ListadoPolizas";
                        break;
                }
            }

            var respuesta = await _httpClient.GetAsync(endpoint);

            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();

                var polizas = JsonConvert.DeserializeObject<List<PolizaVistaModelo>>(content);
                return View(polizas);

            }
            return View(new List<PolizaVistaModelo>());
        }
    }
}
