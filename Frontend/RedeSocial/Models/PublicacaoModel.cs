using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace RedeSocial.Models
{
    public class MidiaModel
    {
        public string FileContents { get; set; }
        public string ContentType { get; set; }
        public string FileDownloadName { get; set; }
    }

    public class PublicacaoModel
    {
        public Guid Id { get; set; }
        public Guid Usuario { get; set; }
        public string NomeUsuario { get; set; }
        public string FotoUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<MidiaModel> Midias { get; set; }
        public int QuantidadeLikes { get; set; }
        public int QuantidadeComentarios { get; set; }
        public bool UsuarioLogadoCurtiuPost { get; set; }
    }
}