namespace RedeSocial.Models
{
    public class ComentarioModel
    {
        public Guid UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public string Conteudo { get; set; }

        public int QuantidadeLikes { get; set; }

        public ComentarioModel(Guid usuarioId, DateTime dataCriacao, DateTime dataEdicao, string conteudo, int quantidadeLikes)
        {
            UsuarioId = usuarioId;
            DataCriacao = dataCriacao;
            DataEdicao = dataEdicao;
            Conteudo = conteudo;
            QuantidadeLikes = quantidadeLikes;
        }
    }
}
