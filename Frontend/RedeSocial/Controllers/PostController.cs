using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class PostController : Controller
    {
        APIHttpClient client;

        private static readonly APIHttpClient publicacaoClient = new APIHttpClient("http://grupo5.neurosky.com.br");
        private static readonly APIHttpClient usuarioClient = new APIHttpClient("http://grupo3.neurosky.com.br");
        private static readonly APIHttpClient comentariosClient = new APIHttpClient("http://grupo4.neurosky.com.br");

        [HttpGet("/Post/{postId}")]
        public IActionResult Index(string postId)
        {

            var comentarios = comentariosClient.Get<List<ComentarioModel>>("api/comentarios/post/" + postId);
            foreach (var comentario in comentarios)
            {
                comentario.Usuario = usuarioClient.Get<UsuarioModel>("api/Usuario/" + comentario.IdUsuario);
            }
            ViewBag.Comentarios = comentarios;

            var publicacaoLikes = comentariosClient.Get<List<string>>("api/likes/post/" + postId);

            PublicacaoModel publicacao = publicacaoClient.Get<PublicacaoModel>("api/Publicacao/" + postId);
            UsuarioModel usuario = usuarioClient.Get<UsuarioModel>("api/Usuario/" + publicacao.Usuario);
            publicacao.NomeUsuario = usuario.Nome;
            publicacao.FotoUsuario = usuario.FotoPerfil;
            publicacao.QuantidadeComentarios = comentarios.Count;
            publicacao.QuantidadeLikes = publicacaoLikes.Count;
            ViewBag.Publicacao = publicacao;

            return View("Index");
        }

        [HttpPost("/Post/InserirPostComentario/{postId}")]
        public IActionResult InserirPostComentario(string postId, string conteudo) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];
            var comentario = new ComentarioModel
            {
                IdUsuario = Guid.Parse(usuarioId),
                Conteudo = conteudo,
                DataEdicao = DateTime.Now,
                DataCriacao = DateTime.Now,
                QuantidadeLikes = 0
            };

            comentariosClient.Post("api/comentarios/post/" + postId, comentario);

            return Index(postId);
        }

        [HttpPut]
        public IActionResult InserirLikePost(string postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            comentariosClient.Post("api/likes/post/" + postId + "/" + usuarioId);

            var likes = comentariosClient.Get<List<string>>("api/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });
        }

        [HttpPut]
        public IActionResult RemoverLikePost(string postId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            comentariosClient.Delete("api/likes/post/" + postId + "/" + usuarioId);

            var likes = comentariosClient.Get<List<string>>("api/likes/post/" + postId);

            return Json(new { sucesso = true, likePost = likes.Count });

        }

        [HttpPut]
        public IActionResult InserirLikeComentario(string comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            comentariosClient.Post("api/likes/comentario/" + comentarioId + "/" + usuarioId);

            var likes = comentariosClient.Get<List<string>>("api/likes/comentario/" + comentarioId);

            return Json(new { sucesso = true, likeComment = likes.Count });
        }

        [HttpDelete]
        public IActionResult RemoverLikeComentario(string comentarioId) // Chamando no front
        {
            var usuarioId = Request.Cookies["UserId"];

            comentariosClient.Delete("api/likes/comentario/" + comentarioId + "/" + usuarioId);

            var likes = comentariosClient.Get<List<string>>("api/likes/comentario/" + comentarioId);

            return Json(new { sucesso = true, likeComment = likes.Count });
        }

        [HttpGet]
        public IActionResult ListarPostComentarios(ComentarioModel comentario) //Precisa incluir chamada no front
        {
            //MOCK:
            Guid postId = Guid.NewGuid();

            var comentarios = comentariosClient.Get<List<ComentarioModel>>("api/comentarios/post/" + postId);

            ViewBag.Comentarios = comentarios;

            return View("Index");

        }

        [HttpGet]
        public IActionResult ListarComentarioRespostas(string comentarioId) //Precisa incluir chamada no front
        {
            APIHttpClient client = new APIHttpClient("http://grupo4.neurosky.com.br/api/");
            var respostas = client.Get<List<ComentarioModel>>("api/comentarios/resposta/" + comentarioId);

            return Json(respostas);
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
