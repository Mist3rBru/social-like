using System;
using System.Collections.Generic;

namespace RedeSocial.Models
{
    public class PublicacaoModel
    {
        public class MidiaModel
        {
            public string FileContents { get; set; }
            public string ContentType { get; set; }
            public string FileDownloadName { get; set; }
        }
        public Guid Id { get; set; }
        public Guid Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<MidiaModel> Midias { get; set; }

        public string NomeUsuario { get; set; }

        public string FotoUsuario { get; set; }

        public int Curtidas { get; set; }

        public int Comentarios { get; set; }

        public PublicacaoModel()
        {
            Midias = new List<MidiaModel>();
        }

        public PublicacaoModel(Guid id, Guid usuario, int curtidas, int comentarios, string nomeUsuario, string fotoUsuario, string descricao, DateTime dataPublicacao, List<MidiaModel> midias)
        {
            Id = id;
            Usuario = usuario;
            NomeUsuario = nomeUsuario;
            FotoUsuario = fotoUsuario;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Midias = midias;
            Curtidas = curtidas;
            Comentarios = comentarios;
        }
    }
}