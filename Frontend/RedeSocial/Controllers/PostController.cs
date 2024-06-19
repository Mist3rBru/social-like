using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InserirPostComentario(string conteudo) // Chamando no front
        {
           ComentarioModel comentario = new ComentarioModel{
               Conteudo = conteudo,
               DataEdicao = DateTime.Now,
               DataCriacao = DateTime.Now,
               UsuarioId = Guid.NewGuid(),
               QuantidadeLikes = 0
           };

            ViewBag.ThisUserComment = comentario;

            return View("Index");

            /* Exemplo de como chamar back
            List<Backend.Models.Cliente> clientes;

            APIHttpClient client;
            client = new APIHttpClient("http://localhost:5265/api/");
            clientes = client.Get<List<Cliente>>("cliente");
            return View(ClienteMapping.ToClienteConsulta(clientes));
            */
        }

        [HttpPut]
        public IActionResult InserirLikePost(int postId) // Chamando no front
        {
            return Json(new { sucesso = true, likePost = 1 });

            /* Exemplo de como chamar back
           List<Backend.Models.Cliente> clientes;

           APIHttpClient client;
           client = new APIHttpClient("http://localhost:5265/api/");
           clientes = client.Get<List<Cliente>>("cliente");
           return View(ClienteMapping.ToClienteConsulta(clientes));
           */
        }

        [HttpPut]
        public IActionResult RemoverLikePost(int postId) // Chamando no front
        {
            return Json(new { sucesso = true, likePost = 0 });

            /* Exemplo de como chamar back
           List<Backend.Models.Cliente> clientes;

           APIHttpClient client;
           client = new APIHttpClient("http://localhost:5265/api/");
           clientes = client.Get<List<Cliente>>("cliente");
           return View(ClienteMapping.ToClienteConsulta(clientes));
           */
        }

        [HttpPut]
        public IActionResult InserirLikeComentario(int comentarioId) // Chamando no front
        {

            return Json(new { sucesso = true, likeComment = 1 });

            /* Exemplo de como chamar back
           List<Backend.Models.Cliente> clientes;

           APIHttpClient client;
           client = new APIHttpClient("http://localhost:5265/api/");
           clientes = client.Get<List<Cliente>>("cliente");
           return View(ClienteMapping.ToClienteConsulta(clientes));
           */
        }

        [HttpPut]
        public IActionResult RemoverLikeComentario(int comentarioId) // Chamando no front
        {
            return Json(new { sucesso = true, likeComment = 0 });

            /* Exemplo de como chamar back
           List<Backend.Models.Cliente> clientes;

           APIHttpClient client;
           client = new APIHttpClient("http://localhost:5265/api/");
           clientes = client.Get<List<Cliente>>("cliente");
           return View(ClienteMapping.ToClienteConsulta(clientes));
           */
        }

        public IActionResult ListarPostComentarios(ComentarioModel comentario) //Precisa incluir chamada no front
        {

            ViewBag.Comment = comentario;

            return View("Index");

            /*
            List<Backend.Models.Comentario> comentarios;

            APIHttpClient client;
            client = new APIHttpClient("http://localhost:5265/api/");
            comentarios = client.Get<List<Comentario>>("comentario");
            return View(ComentarioMapping.ToComentario(comentarios));
            */
        }


        //Precisa incluir opção para editar comentário nas views
        public IActionResult EditarComentario(ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção para excluir comentário nas views
        public IActionResult ExcluirComentario(ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção de responder comentário nas views
        public IActionResult ListarRespostaComentarios(ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção de responder comentário nas views
        public IActionResult InserirRespostaComentario(ComentarioModel comentario)
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }
    }
}
