using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            var userId = Request.Cookies["UserId"];

            APIHttpClient client;
            client = new APIHttpClient("http://grupo3.neurosky.com.br/");
            UsuarioModel usuario = client.Get<UsuarioModel>("api/Usuario/" + userId);

            ViewBag.Usuario = usuario;

            return View();
        }


    }

    }
