using Microsoft.AspNetCore.Mvc;
using RedeSocial.Models;
using System.Diagnostics;
using RedeSocial.Backend.HTTPClient;
using System.Text;
using RedeSocial.Backend.Adapter;
using RedeSocial.Backend.Models;

namespace RedeSocial.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private string URLBase = "http://grupo3.neurosky.com.br/api/";

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

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

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            var apiModel = UsuarioAdapter.ToUsuarioLoginModel(login);
            var retorno = new APIHttpClient(URLBase).Post<UsuarioLoginModel, UsuarioModel>("Usuario/Login", apiModel);
            var retornoCadastroModel = UsuarioAdapter.ToUsuarioCadastroModel(retorno);

            if (retorno is not null)
            {
                ViewBag.Usuario = retornoCadastroModel;
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(7) // Set cookie to expire in 7 days
                };
                Response.Cookies.Append("UserId", retornoCadastroModel.Id.ToString(), cookieOptions);
                return RedirectToAction("Index", "Feed");
            }
            else
            {
                return this.Index();
            }
        }

        public IActionResult Cadastrar(UsuarioCadastroModel usuarioCadastro)
        {
            var usuarioModel = UsuarioAdapter.ToUsuarioModel(usuarioCadastro);
            var request = new APIHttpClient(URLBase).Post("Usuario", usuarioModel);
            var userLoginData = UsuarioAdapter.CadastroToLoginModel(usuarioCadastro);

            return Login(userLoginData);
        }
    }
}
