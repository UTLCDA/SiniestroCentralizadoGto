using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siniestros.Cliente.Models;
using System.Diagnostics;
using System.Net.Http;

namespace Siniestros.Cliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login(LoginSolicitudVistaModelo model)
        {
            // Aquí puedes ajustar el endpoint que valide usuario y password
            var response = await _httpClient.PostAsJsonAsync($"api/usuario/login",model);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<UsuarioLoginVistaModelo>(content);

                if (usuario != null)
                {
                    // Aquí puedes guardar datos en sesión si lo necesitas
                    HttpContext.Session.SetString("Usuario", model.NumeroEmpleado);

                    return RedirectToAction("Dashboard", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
            return View(model);
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(usuario))
            {
                // Puedes agregar un log o debugeo aquí
                Debug.WriteLine("El valor de 'Usuario' es nulo o vacío.");
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
                return RedirectToAction("Login");

            // Obtener el nombre del usuario desde la sesión
            usuario = HttpContext.Session.GetString("Usuario");

            var viewModel = new DashboardVistaModelo
            {
                Usuario = usuario
            };

            return View(viewModel); // Pasas el viewModel a la vista

        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Elimina todo lo de sesión
            return RedirectToAction("Login");
        }
    }
}
