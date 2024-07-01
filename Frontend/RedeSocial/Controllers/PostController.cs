using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index(Guid postId)
        {
            APIHttpClient publicacaoClient = new APIHttpClient("http://grupo5.neurosky.com.br/api");
            APIHttpClient usuarioClient = new APIHttpClient("http://grupo3.neurosky.com.br/api");
            APIHttpClient comentariosClient = new APIHttpClient("http://grupo4.neurosky.com.br/api");

            List<ComentarioModel> comentarios = comentariosClient.Get<List<ComentarioModel>>("/comentarios/post/" + postId);
            foreach  (ComentarioModel comentario in comentarios) {
                comentario.Usuario = usuarioClient.Get<UsuarioModel>("/Usuario/" + comentario.UsuarioId);
            }
            ViewBag.Comentarios = comentarios;
            
            List<string> publicacaoLikes = comentariosClient.Get<List<string>>("/likes/post/" + postId);
            foreach  (ComentarioModel comentario in comentarios) {
                comentario.Usuario = usuarioClient.Get<UsuarioModel>("/Usuario/" + comentario.UsuarioId);
            }

            PublicacaoModelBack publicacaoBack = publicacaoClient.Get<PublicacaoModelBack>("/Publicacao/" + postId);
            UsuarioModel usuario = usuarioClient.Get<UsuarioModel>("/Usuario/" + publicacaoBack.Usuario);
            
            PublicacaoModel publicacao = new Publicacao(
                publicacaoBack.Id,
                usuario,
                publicacaoBack.Descricao,
                publicacaoBack.DataPublicacao,
                publicacaoBack.Midias
            )
            publicacao.QuantidadeComentarios = comentarios.Count;
            publicacao.QuantidadeLikes = publicacaoLikes.Count;
            ViewBag.Publicacao = publicacao;

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

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api");
            client.Post("/comentarios/post/"+postId, comentario);

            comentarios.Add(comentario);

            ViewBag.Comentarios = comentarios;

            return View("Index");
        }

        [HttpPost]
        public IActionResult InserirLikePost(int postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api");
            client.Post("/likes/post/" + postId + "/",usuarioId);

            List<string> likes = client.Get<List<string>>("/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });
        }

        [HttpDelete]
        public IActionResult RemoverLikePost(int postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api");
           client.Delete("/likes/post/" + postId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });

        }

        [HttpPut]
        public IActionResult InserirLikeComentario(int comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api");
            client.Post("/likes/comentario/" + comentarioId + "/" + usuarioId);
           
            List<string> likes = client.Get<List<string>>("/likes/comentario/" + postId);

            return Json(new { sucesso = true, likeComment = likes.Count });
        }

        [HttpDelete]
        public IActionResult RemoverLikeComentario(int comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            client.Delete("likes/comentario/" + comentarioId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("/likes/comentario/" + postId);

            return Json(new { sucesso = true, likeComment = likes.Count });
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
