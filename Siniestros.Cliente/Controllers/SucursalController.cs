using Microsoft.AspNetCore.Mvc;
using Siniestros.Cliente.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SiniestroCentralizadoGtoApi.Modelos;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Siniestros.Cliente.Controllers
{
    public class SucursalController : Controller
    {
        private readonly HttpClient _httpClient;

        public SucursalController(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("API");
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var respuesta = await _httpClient.GetAsync("api/Sucursal/ListadoSucursales");

            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var sucursales = JsonConvert.DeserializeObject<IEnumerable<SucursalVista>>(content);
                return View("Index", sucursales);

            }
            return View(new List<SucursalVista>());
        }
        [HttpGet]
        public IActionResult Alta()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Alta(Sucursal sucursal)
        {

            var nombreConcatenado = "HDI SEGUROS SUCURSAL ";
            sucursal.Nombre = nombreConcatenado + sucursal.Nombre;

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(sucursal);
                var content = new StringContent(json,Encoding.UTF8, "application/json");

                var respuesta = await _httpClient.PostAsync("/api/Sucursal/AltaSucursal", content);

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la sucursal");
                }
            }
            return View(sucursal);
        }
    }
}
