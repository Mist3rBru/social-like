using RedeSocialBack.Application.Dto;
using RedeSocialBack.Domain.Entities;


namespace RedeSocialBack.Application.Adapter
{
    public class ComentarioAdapter
    {
        public static Comentario ToDomain(ComentarioDto comentario)
        {
            if (comentario == null)
                return null;
            else
            {
                Comentario comentarioDomain = new Comentario();
                comentarioDomain.DataCriacao = comentario.DataCriacao;
                comentarioDomain.DataEdicao = comentario.DataEdicao;
                comentarioDomain.Conteudo = comentario.Conteudo;
                comentarioDomain.Id = comentario.Id;
                comentarioDomain.IdUsuario = comentario.IdUsuario;
                comentarioDomain.QuantidadeLikes = comentario.QuantidadeLikes;
                return comentarioDomain;
            }
        }
        public static ComentarioDto ToDto(Comentario comentario)
        {
            if (comentario == null)
                return null;
            else
            {
                ComentarioDto comentarioDto = new ComentarioDto();
                comentarioDto.DataCriacao = comentario.DataCriacao;
                comentarioDto.DataEdicao = comentario.DataEdicao;
                comentarioDto.Conteudo = comentario.Conteudo;
                comentarioDto.Id = comentario.Id;
                comentarioDto.IdUsuario = comentario.IdUsuario;
                comentarioDto.QuantidadeLikes = comentario.QuantidadeLikes;
                return comentarioDto;
            }
        }

    }
}