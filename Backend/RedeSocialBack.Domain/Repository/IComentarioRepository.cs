using RedeSocialBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialBack.Domain.Repository
{
    public interface IComentarioRepository
    {
        void InserirPostComentario(Comentario Comentario, Guid IdPost);
        void InserirRespostaComentario(Comentario Resposta, Guid IdComentario);
        void InserirStoryComentario(Comentario Comentario, Guid IdStory);
        void EditarComentario(Comentario Comentario);
        void ExcluirComentario(Guid IdComentario);
        List<Comentario> ListarPostComentarios(Guid IdPost);
        List<Comentario> ListarRespostaComentarios(Guid IdComentario);
        List<Comentario> ListarStoryComentarios(Guid IdStory);
        void InserirLikePost(Guid IdPost, Guid IdUsuario);
        void InserirLikeStory(Guid IdStory, Guid IdUsuario);
        void InserirLikeComentario(Guid IdStory, Guid IdUsuario);
        void InserirLikeAnuncio(Guid IdAnuncio, Guid IdUsuario);
        void RemoverLikePost(Guid IdPost, Guid IdUsuario);
        void RemoverLikeComentario(Guid IdComentario, Guid IdUsuario);
        void RemoverLikeStory(Guid IdStory, Guid IdUsuario);
        void RemoverLikeAnuncio(Guid IdStory, Guid IdUsuario);

    }
}
