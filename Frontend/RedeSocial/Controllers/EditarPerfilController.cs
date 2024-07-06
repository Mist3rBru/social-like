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
            var usuarioJson = HttpContext.Session.GetString("Usuario");
            var user = JsonConvert.DeserializeObject<UsuarioModel>(usuarioJson);
            ViewBag.Usuario = user;

            return View();
        }

      

        [HttpPost]
        public IActionResult Atualizar(UsuarioAlterarModel model)
        {
            var usuarioJson = HttpContext.Session.GetString("Usuario");
            var user = JsonConvert.DeserializeObject<UsuarioModel>(usuarioJson);

            model.Id = user.Id;
            model.Senha = user.Senha ?? string.Empty;

            var usuarioAlteradoModel = UsuarioAdapter.ToUsuarioModel(model);
            usuarioAlteradoModel.Amigos = user?.Amigos;
            usuarioAlteradoModel.FotoPerfil ??= user.FotoPerfil;
            new APIHttpClient(URLBase).Put("Usuario", usuarioAlteradoModel);

            var usuarioAlterado = new APIHttpClient(URLBase).Get<UsuarioModel>($"Usuario/{model.Id}");

            HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(usuarioAlterado));

            return Redirect($"/Perfil/{model.Id}");
        }

    }
}