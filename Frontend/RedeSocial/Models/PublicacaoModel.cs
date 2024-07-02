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

        public Guid Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<MidiaModel> Midias { get; set; }

        public string NomeUsuario { get; set; }

        public string FotoUsuario { get; set; }

        public PublicacaoModel()
        {
            Midias = new List<MidiaModel>();
        }

        public PublicacaoModel(Guid usuario, string nomeUsuario, string fotoUsuario, string descricao, DateTime dataPublicacao, List<MidiaModel> midias)
        {
            Usuario = usuario;
            NomeUsuario = nomeUsuario;
            FotoUsuario = fotoUsuario;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Midias = midias;
        }
    }
}
