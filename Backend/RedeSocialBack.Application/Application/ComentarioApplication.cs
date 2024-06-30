using RedeSocialBack.Application.Adapter;
using RedeSocialBack.Application.Dto;
using RedeSocialBack.Domain.Entities;
using RedeSocialBack.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialBack.Application.Application
{
    public class ComentarioApplication
    {

        private ComentarioRepository comentarioRepository;

        public ComentarioApplication()
        {
            string strConexao = "User ID=jmenzen3;Password='8N9;FLC?;@?I';Host=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen3;";
            this.comentarioRepository = new ComentarioRepository(strConexao);
        }
        public Guid InserirPostComentario(ComentarioDto Comentario, Guid IdPost)
        {
            Comentario comentario = ComentarioAdapter.ToDomain(Comentario);
            comentario.Id = Guid.NewGuid();
            comentarioRepository.InserirPostComentario(comentario, IdPost);
            return comentario.Id;
        }

        public Guid InserirRespostaComentario(ComentarioDto Resposta, Guid IdComentario)
        {
            Comentario comentario = ComentarioAdapter.ToDomain(Resposta);
            comentario.Id = Guid.NewGuid();
            comentarioRepository.InserirRespostaComentario(comentario, IdComentario);
            return comentario.Id;
        }
        public Guid InserirStoryComentario(ComentarioDto Comentario, Guid IdStory)
        {
            Comentario comentario = ComentarioAdapter.ToDomain(Comentario);
            comentario.Id = Guid.NewGuid();
            comentarioRepository.InserirStoryComentario(comentario, IdStory);
            return comentario.Id;
        }
        public Guid EditarComentario(ComentarioDto Comentario)
        {
            Comentario comentario = ComentarioAdapter.ToDomain(Comentario);
            comentario.Id = Guid.NewGuid();
            comentarioRepository.EditarComentario(comentario);
            return comentario.Id;
        }
        public Guid ExcluirComentario(Guid IdComentario)
        {
            comentarioRepository.ExcluirComentario(IdComentario);
            return IdComentario;
        }
        public List<ComentarioDto> ListarPostComentarios(Guid IdPost)
        {
            List<ComentarioDto> comentariosDto = new List<ComentarioDto>();
            var comentarios = comentarioRepository.ListarPostComentarios(IdPost);
            foreach (var coment in comentarios)
            {
                comentariosDto.Add(ComentarioAdapter.ToDto(coment));
            }
            return comentariosDto;
        }
        public List<ComentarioDto> ListarRespostaComentarios(Guid IdComentario)
        {
            List<ComentarioDto> comentariosDto = new List<ComentarioDto>();
            var comentarios = comentarioRepository.ListarRespostaComentarios(IdComentario);
            foreach (var coment in comentarios)
            {
                comentariosDto.Add(ComentarioAdapter.ToDto(coment));
            }
            return comentariosDto;
        }
        public List<ComentarioDto> ListarStoryComentarios(Guid IdStory)
        {
            List<ComentarioDto> comentariosDto = new List<ComentarioDto>();
            var comentarios = comentarioRepository.ListarStoryComentarios(IdStory);
            foreach (var coment in comentarios)
            {
                comentariosDto.Add(ComentarioAdapter.ToDto(coment));
            }
            return comentariosDto;
        }
        public void InserirLikePost(Guid IdPost, Guid IdUsuario)
        {
            comentarioRepository.InserirLikePost(IdPost, IdUsuario);
        }
        public void InserirLikeStory(Guid IdStory, Guid IdUsuario)
        {
            comentarioRepository.InserirLikeStory(IdStory, IdUsuario);
        }
        public void InserirLikeComentario(Guid IdComentario, Guid IdUsuario)
        {
            comentarioRepository.InserirLikeComentario(IdComentario, IdUsuario);
        }
        public void InserirLikeAnuncio(Guid IdAnuncio, Guid IdUsuario)
        {
            comentarioRepository.InserirLikeAnuncio(IdAnuncio, IdUsuario);
        }
        public void RemoverLikePost(Guid IdPost, Guid IdUsuario)
        {
            comentarioRepository.RemoverLikePost(IdPost, IdUsuario);
        }
        public void RemoverLikeComentario(Guid IdComentario, Guid IdUsuario)
        {
            comentarioRepository.RemoverLikeComentario(IdComentario, IdUsuario);
        }
        public void RemoverLikeStory(Guid IdStory, Guid IdUsuario)
        {
            comentarioRepository.RemoverLikeStory(IdStory, IdUsuario);
        }
        public void RemoverLikeAnuncio(Guid IdAnuncio, Guid IdUsuario)
        {
            comentarioRepository.RemoverLikeAnuncio(IdAnuncio, IdUsuario);
        }


        public List<string> ListarLikesPost(Guid IdPost)
        {
            List<string> usuarios = comentarioRepository.ListarLikesPost(IdPost);
            return usuarios;
        }

        public List<string> ListarLikesAnuncio(Guid IdPost)
        {
            List<string> usuarios = comentarioRepository.ListarLikesAnuncio(IdPost);
            return usuarios;
        }

        public List<string> ListarLikesComentario(Guid IdPost)
        {
            List<string> usuarios = comentarioRepository.ListarLikesComentario(IdPost);
            return usuarios;
        }

        public List<string> ListarLikesStory(Guid IdPost)
        {
            List<string> usuarios = comentarioRepository.ListarLikesStory(IdPost);
            return usuarios;
        }
    }
}