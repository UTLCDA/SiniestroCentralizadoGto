using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Cliente.Models;
using System.Diagnostics;
using System.Net.Http;

namespace Cliente.Controllers
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
            // Validar que el modelo no sea null y que tenga datos
            if (model == null || string.IsNullOrWhiteSpace(model.NumeroEmpleado) || string.IsNullOrWhiteSpace(model.Contrasena))
            {
                ModelState.AddModelError(string.Empty, "Por favor, ingresa usuario y contraseña.");
                return View(model);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuario/login", model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<UsuarioLoginVistaModelo>(content);

                    if (usuario != null)
                    {
                        HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales incorrectas.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Puedes loguear el error aquí si tienes un logger
                ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar iniciar sesión. Intenta nuevamente.");
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario"); // Si lo necesitas

            if (!HttpContext.Session.GetInt32("IdUsuario").HasValue)
            {
                return RedirectToAction("Login");
            }

            var viewModel = new DashboardVistaModelo
            {
                Usuario = idUsuario
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
