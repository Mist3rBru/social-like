namespace RedeSocial.Models
{
    public class PublicacaoModel
    {
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public PublicacaoModel(int usuarioId, string descricao, DateTime dataPublicacao)
        {
            UsuarioId = usuarioId;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
        }
    }
}
