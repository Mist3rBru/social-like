using RedeSocialBack.API.Models;
using RedeSocialBack.Application.Dto;



namespace RedeSocialBack.API.Adapter
{
    public class ComentarioMapping
    {
        public static ComentarioModel ToModel(ComentarioDto comentario)
        {
            if (comentario == null)
                return null;
            else
            {
                ComentarioModel comentarioModel = new ComentarioModel();
                comentarioModel.DataCriacao = comentario.DataCriacao;
                comentarioModel.DataEdicao = comentario.DataEdicao;
                comentarioModel.Conteudo = comentario.Conteudo;
                comentarioModel.Id = comentario.Id;
                comentarioModel.IdUsuario = comentario.IdUsuario;
                comentarioModel.QuantidadeLikes = comentario.QuantidadeLikes;
                return comentarioModel;
            }
        }
        public static ComentarioDto ToDto(ComentarioModel comentario)
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
