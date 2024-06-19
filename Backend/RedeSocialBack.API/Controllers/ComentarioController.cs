using Microsoft.AspNetCore.Mvc;
using RedeSocialBack.API.Adapter;
using RedeSocialBack.API.Models;
using RedeSocialBack.Application.Application;
using RedeSocialBack.Domain.Entities;

namespace RedeSocialBack.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        [HttpGet("comentarios/post/{id:Guid}")]
        public IEnumerable<ComentarioModel> GetPostComentarios(Guid id)
        {
            List<ComentarioModel> comentarioModel = new List<ComentarioModel>();
            ComentarioApplication app = new ComentarioApplication();
            var postComentarios = app.ListarPostComentarios(id);
            foreach (var comentario in postComentarios)
            {
                comentarioModel.Add(ComentarioMapping.ToModel(comentario));
            }
            return comentarioModel.ToArray();
        }

        [HttpGet("comentarios/story/{id:Guid}")]
        public IEnumerable<ComentarioModel> GetStoryComentarios(Guid id)
        {
            List<ComentarioModel> comentarioModel = new List<ComentarioModel>();
            ComentarioApplication app = new ComentarioApplication();
            var postComentarios = app.ListarStoryComentarios(id);
            foreach (var comentario in postComentarios)
            {
                comentarioModel.Add(ComentarioMapping.ToModel(comentario));
            }
            return comentarioModel.ToArray();
        }

        [HttpGet("comentarios/resposta/{id:Guid}")]
        public IEnumerable<ComentarioModel> GetRespostaComentarios(Guid id)
        {
            List<ComentarioModel> comentarioModel = new List<ComentarioModel>();
            ComentarioApplication app = new ComentarioApplication();
            var postComentarios = app.ListarRespostaComentarios(id);
            foreach (var comentario in postComentarios)
            {
                comentarioModel.Add(ComentarioMapping.ToModel(comentario));
            }
            return comentarioModel.ToArray();
        }

        [HttpPost("comentarios/resposta/{idComentario:Guid}")]
        public Guid PostRespostaComentario(ComentarioModel comentario, Guid idComentario)
        {
            ComentarioApplication app = new ComentarioApplication();
            return app.InserirRespostaComentario(ComentarioMapping.ToDto(comentario), idComentario);
        }

        [HttpPost("comentarios/post/{idPost:Guid}")]
        public Guid PostPostComentario(ComentarioModel comentario, Guid idPost)
        {
            ComentarioApplication app = new ComentarioApplication();
            return app.InserirPostComentario(ComentarioMapping.ToDto(comentario), idPost);
        }

        [HttpPost("comentarios/story/{idStory:Guid}")]
        public Guid PostStoryComentario(ComentarioModel comentario, Guid idStory)
        {
            ComentarioApplication app = new ComentarioApplication();
            return app.InserirStoryComentario(ComentarioMapping.ToDto(comentario), idStory);
        }

        [HttpPost("likes/story/{idStory:Guid}/{idUsuario:Guid}")]
        public void PostStoryLike(Guid idStory, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.InserirLikeStory(idStory, idUsuario);
        }

        [HttpPost("likes/anuncio/{idAnuncio:Guid}/{idUsuario:Guid}")]
        public void PostAnuncioLike(Guid idAnuncio, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.InserirLikeAnuncio(idAnuncio, idUsuario);
        }

        [HttpPost("likes/comentario/{idComentario:Guid}/{idUsuario:Guid}")]
        public void PostComentarioLike(Guid idComentario, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.InserirLikeComentario(idComentario, idUsuario);
        }

        [HttpPost("likes/post/{idPost:Guid}/{idUsuario:Guid}")]
        public void PostPostagemLike(Guid idPost, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.InserirLikePost(idPost, idUsuario);
        }

        [HttpDelete("likes/post/{idPost:Guid}/{idUsuario:Guid}")]
        public void DeletePostagemLike(Guid idPost, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.RemoverLikePost(idPost, idUsuario);
        }

        [HttpDelete("likes/comentario/{idComentario:Guid}/{idUsuario:Guid}")]
        public void DeleteComentarioLike(Guid idComentario, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.RemoverLikeComentario(idComentario, idUsuario);
        }

        [HttpDelete("likes/anuncio/{idAnuncio:Guid}/{idUsuario:Guid}")]
        public void DeleteAnuncioLike(Guid idAnuncio, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.RemoverLikeAnuncio(idAnuncio, idUsuario);
        }

        [HttpDelete("likes/story/{idStory:Guid}/{idUsuario:Guid}")]
        public void DeleteStoryLike(Guid idStory, Guid idUsuario)
        {
            ComentarioApplication app = new ComentarioApplication();
            app.RemoverLikeStory(idStory, idUsuario);
        }

        [HttpDelete("comentarios/{idComentario:Guid}")]
        public Guid RemoverComentario(Guid idComentario)
        {
            ComentarioApplication app = new ComentarioApplication();
            return app.ExcluirComentario(idComentario);
        }

        [HttpPut("comentarios")]
        public Guid PutComentario(ComentarioModel comentario)
        {
            ComentarioApplication app = new ComentarioApplication();
            return app.EditarComentario(ComentarioMapping.ToDto(comentario));
        }
    }
}
