using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Backend.Models;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class PostController : Controller
    {
        [HttpGet("/Post/{postId}")]
        public IActionResult Index(string postId)
        {
            APIHttpClient publicacaoClient = new APIHttpClient("http://grupo5.neurosky.com.br");
            APIHttpClient usuarioClient = new APIHttpClient("http://grupo3.neurosky.com.br");
            APIHttpClient comentariosClient = new APIHttpClient("http://grupo4.neurosky.com.br");

            List<Models.ComentarioModel> comentarios = comentariosClient.Get<List<Models.ComentarioModel>>("api/comentarios/post/" + postId);
            foreach (var comentario in comentarios)
            {
                comentario.Usuario = usuarioClient.Get<UsuarioModel>("api/Usuario/" + comentario.IdUsuario);
            }
            ViewBag.Comentarios = comentarios;

            List<string> publicacaoLikes = comentariosClient.Get<List<string>>("api/likes/post/" + postId);

            PublicacaoModelBack publicacaoBack = publicacaoClient.Get<PublicacaoModelBack>("api/Publicacao/" + postId);
            UsuarioModel usuario = usuarioClient.Get<UsuarioModel>("api/Usuario/" + publicacaoBack.Usuario);

            PublicacaoModel publicacao = new PublicacaoModel(
                publicacaoBack.Id,
                usuario,
                publicacaoBack.Descricao,
                publicacaoBack.DataPublicacao,
                publicacaoBack.Midias
            );
            publicacao.QuantidadeComentarios = comentarios.Count;
            publicacao.QuantidadeLikes = publicacaoLikes.Count;
            ViewBag.Publicacao = publicacao;

            return View("Index");
        }

        [HttpPost("/Post/InserirPostComentario/{postId}")]
        public IActionResult InserirPostComentario(string postId, string conteudo) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];
            Models.ComentarioModel comentario = new Models.ComentarioModel
            {
                IdUsuario = Guid.Parse(usuarioId),
                Conteudo = conteudo,
                DataEdicao = DateTime.Now,
                DataCriacao = DateTime.Now,
                QuantidadeLikes = 0
            };

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br");
            client.Post("api/comentarios/post/" + postId, comentario);

            return Index(postId);
        }

        [HttpPut]
        public IActionResult InserirLikePost(string postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br");
            client.Post("api/likes/post/" + postId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("api/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });
        }

        [HttpPut]
        public IActionResult RemoverLikePost(string postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br");
            client.Delete("api/likes/post/" + postId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("api/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });

        }

        [HttpPut]
        public IActionResult InserirLikeComentario(string comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br");
            client.Post("api/likes/comentario/" + comentarioId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("api/likes/comentario/" + comentarioId);

            return Json(new { sucesso = true, likeComment = likes.Count });
        }

        [HttpDelete]
        public IActionResult RemoverLikeComentario(string comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            client.Delete("likes/comentario/" + comentarioId + "/" + usuarioId);

            List<string> likes = client.Get<List<string>>("/likes/comentario/" + comentarioId);

            return Json(new { sucesso = true, likeComment = likes.Count });
        }

        [HttpGet]
        public IActionResult ListarPostComentarios(Models.ComentarioModel comentario) //Precisa incluir chamada no front
        {
            //MOCK:
            Guid postId = Guid.NewGuid();

            List<Backend.Models.ComentarioModel> comentariosResponse;
            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");

            List<Models.ComentarioModel> comentarios = client.Get<List<Models.ComentarioModel>>("/comentarios/post/" + postId);

            ViewBag.Comentarios = comentarios;

            return View("Index");

        }

        [HttpGet]
        public IActionResult ListarComentarioRespostas(string comentarioId) //Precisa incluir chamada no front
        {
            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            List<Models.ComentarioModel> respostas = client.Get<List<Models.ComentarioModel>>("/comentarios/resposta/" + comentarioId);

            return Json(respostas);
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
