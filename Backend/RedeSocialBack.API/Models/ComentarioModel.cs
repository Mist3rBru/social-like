namespace RedeSocialBack.API.Models
{
    public class ComentarioModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public int QuantidadeLikes { get; set; }
        public int QuantidadeComentarios{ get; set; }
    }
}
