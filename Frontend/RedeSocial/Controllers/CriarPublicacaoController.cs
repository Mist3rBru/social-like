using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedeSocial.Backend.Adapter;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;
using SocialUniftec.Website.Backend.Adapter;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace RedeSocial.Controllers
{
    public class CriarPublicacaoController : Controller
    {
        private static readonly string URLBasePublicacao = "http://grupo5.neurosky.com.br/api/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostagemCadastroModel postagemCadastro)
        {
            var postagemModel = PostagemAdapter.ToPostagemModel(postagemCadastro);
            var userId = Request.Cookies["UserId"];
            postagemModel.DataPublicacao = DateTime.Now;
            postagemModel.Usuario = Guid.Parse(userId);

            var id = new APIHttpClient(URLBasePublicacao).Post("Publicacao?Usuario=" + postagemModel.Usuario + "&Descricao=" + postagemModel.Descricao + "&DataPublicacao=" + postagemModel.DataPublicacao.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), postagemModel);

            return Redirect($"/Perfil/{userId}");

        }

    }
}
