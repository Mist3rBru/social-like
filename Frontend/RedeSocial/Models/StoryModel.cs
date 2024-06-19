namespace RedeSocial.Models
{
    public class StoryModel
    {
        public object Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public StoryModel(object conteudo, DateTime dataPublicacao, int usuarioId, bool ativo)
        {
            Conteudo = conteudo;
            DataPublicacao = dataPublicacao;
            UsuarioId = usuarioId;
            Ativo = ativo;
        }
    }

}
