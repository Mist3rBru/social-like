using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class PostController : Controller
    {
        List<Backend.Models.ComentarioModel> comentarios = [];

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InserirPostComentario(string conteudo) // Chamando no front
        {

            //MOCK. Ver como passar na view:
            Guid postId = Guid.NewGuid();


            Backend.Models.ComentarioModel comentario = new Backend.Models.ComentarioModel
            {
               Conteudo = conteudo,
               DataEdicao = DateTime.Now,
               DataCriacao = DateTime.Now,
               UsuarioId = Guid.NewGuid(),
               QuantidadeLikes = 0
           };

            comentarios.Add(comentario);

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            client.Post("comentarios/post/"+postId, comentario);

            comentarios.Add(comentario);

            ViewBag.Comentarios = comentarios;

            return View("Index");
        }

        [HttpPost]
        public IActionResult InserirLikePost(int postId) // Chamando no front
        {

            //MOCK:
            Guid usuarioId = Guid.NewGuid();
            int quantidadeLikes = 0;

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            client.Post("likes/post/" + postId + "/",usuarioId);

            return Json(new { sucesso = true, likePost = quantidadeLikes++ });

        }

        [HttpDelete]
        public IActionResult RemoverLikePost(int postId) // Chamando no front
        {
            //MOCK:
            Guid usuarioId = Guid.NewGuid();
            int quantidadeLikes = 1;

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
           // client.Delete("likes/post/" + postId + "/" + usuarioId);

            return Json(new { sucesso = true, likePost = quantidadeLikes-- });

        }

        [HttpPut]
        public IActionResult InserirLikeComentario(int comentarioId) // Chamando no front
        {

            //MOCK:
            Guid usuarioId = Guid.NewGuid();
            int quantidadeLikes = 0;

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
           // client.Post("likes/comentario/" + comentarioId + "/" + usuarioId);

            return Json(new { sucesso = true, likeComment = quantidadeLikes++ });
        }

        [HttpDelete]
        public IActionResult RemoverLikeComentario(int comentarioId) // Chamando no front
        {

            //MOCK:
            Guid usuarioId = Guid.NewGuid();
            int quantidadeLikes = 1;

            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
         //   client.Delete("likes/comentario/" + comentarioId + "/" + usuarioId);

            return Json(new { sucesso = true, likeComment = quantidadeLikes-- });
        }

        [HttpGet]
        public IActionResult ListarPostComentarios(Models.ComentarioModel comentario) //Precisa incluir chamada no front
        {


            //MOCK:
            Guid postId = Guid.NewGuid();

            List<Backend.Models.ComentarioModel> comentariosResponse;
            APIHttpClient client;
            client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
           // comentariosResponse = client.Get("comentarios/post/");

           // comentarios.Add(comentariosResponse);

            ViewBag.Comentarios = comentarios;

            return View("Index");

        }


        //Precisa incluir opção para editar comentário nas views
        public IActionResult EditarComentario(Models.ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção para excluir comentário nas views
        public IActionResult ExcluirComentario(Models.ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção de responder comentário nas views
        public IActionResult ListarRespostaComentarios(Models.ComentarioModel comentario) 
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }

        //Precisa incluir opção de responder comentário nas views
        public IActionResult InserirRespostaComentario(Models.ComentarioModel comentario)
        {

            ViewBag.Comment = comentario;

            return View("Index");
        }
    }
}
