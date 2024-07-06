namespace RedeSocial.Models
{
    public class ComentarioModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }

        public int QuantidadeLikes { get; set; }
        public int QuantidadeComentarios{ get; set; }

        public bool UsuarioLogadoCurtiuComentario { get; set; }

        public ComentarioModel() { }
        public ComentarioModel(Guid idUsuario, DateTime dataCriacao, DateTime dataEdicao, string conteudo, int quantidadeLikes, bool UsuarioLogadoCurtiuComentario)
        {
            IdUsuario = idUsuario;
            DataCriacao = dataCriacao;
            DataEdicao = dataEdicao;
            Conteudo = conteudo;
            QuantidadeLikes = quantidadeLikes;
            UsuarioLogadoCurtiuComentario = UsuarioLogadoCurtiuComentario;
        }
    }
}
