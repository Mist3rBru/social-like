using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedeSocial.Backend.Adapter;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace RedeSocial.Controllers
{
    public class EditarPerfilController : Controller
    {
        private string URLBase = "http://grupo3.neurosky.com.br/api/";
        public IActionResult Index()
        {
            var userId = Request.Cookies["UserId"];

            APIHttpClient client;
            client = new APIHttpClient("http://grupo3.neurosky.com.br/");
            UsuarioModel usuario = client.Get<UsuarioModel>("api/Usuario/" + userId);

            ViewBag.Usuario = usuario;
            TempData["Usuario"] = JsonConvert.SerializeObject(usuario);

            return View();
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioAlterarModel model)
        {

            var user = JsonConvert.DeserializeObject<UsuarioModelBack>(TempData["Usuario"].ToString());

            model.Id = user.Id;
                model.Senha = user.Senha ?? string.Empty;

                var usuarioAlteradoModel = UsuarioAdapter.ToUsuarioModel(model);
                usuarioAlteradoModel.Amigos = user?.Amigos;
                usuarioAlteradoModel.FotoPerfil ??= user.FotoPerfil;
                new APIHttpClient(URLBase).Put("Usuario", usuarioAlteradoModel);

                var usuarioAlterado = new APIHttpClient(URLBase).Get<RedeSocial.Backend.Models.UsuarioModelBack>($"Usuario/{model.Id}");

                return RedirectToAction("Index", "Perfil");
            

    




        }
    }
}
