using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;
using System.Runtime.Intrinsics.Arm;

namespace RedeSocial.Controllers
{
    public class PerfilController : Controller
    {
        private static readonly string URLBasePublicacao = "http://grupo5.neurosky.com.br/api/";
        private static readonly string URLBaseUsuario = "http://grupo3.neurosky.com.br/";

        [HttpGet("/Perfil/{UserId}")]
        public IActionResult Index(string UserId)
        {
            var usuarioJson = HttpContext.Session.GetString("Usuario");
            var usuario = JsonConvert.DeserializeObject<UsuarioModel>(usuarioJson);
            ViewBag.Usuario = usuario;

            ViewBag.Usuario = usuario;
            ViewBag.Publicacoes = listaPublicacoes(UserId);
            ViewBag.CurrentId = UserId;

            return View();
        }

        public IActionResult Editar()
        {
            return RedirectToAction("Index", "EditarPerfil");
        }

        [HttpGet]
        private List<PublicacaoModel> listaPublicacoes(string? userId)
        {
            APIHttpClient client;
            client = new APIHttpClient(URLBasePublicacao);
            List<PublicacaoModel> publicacoes = client.Get<List<PublicacaoModel>>("Publicacao?idUsuario=" + userId);

            client = new APIHttpClient(URLBaseUsuario);
            UsuarioModel usuario;
            foreach (var publicacao in publicacoes)
            {
                usuario = client.Get<UsuarioModel>($"api/Usuario/{publicacao.Usuario}");
                publicacao.NomeUsuario = usuario.Nome;
                publicacao.FotoUsuario = usuario.FotoPerfil;
            }
            return publicacoes;
        }

    }
}
