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
        public Guid Id { get; }
        public UsuarioModel Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<MidiaModel> Midias { get; set; }
        public int QuantidadeLikes { get; set; }
        public int QuantidadeComentarios { get; set; }

        public PublicacaoModel() { }

        public PublicacaoModel(Guid id, string descricao, DateTime dataPublicacao, List<MidiaModel> midias)
        {
            Id = id;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Midias = midias;
        }

        public PublicacaoModel(Guid id, UsuarioModel usuario, string descricao, DateTime dataPublicacao, List<MidiaModel> midias)
        {
            Id = id;
            Usuario = usuario;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Midias = midias;
        }
    }
}
