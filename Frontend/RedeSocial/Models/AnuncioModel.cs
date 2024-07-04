namespace RedeSocial.Models
{
    public class AnuncioModel
    {
        public Guid Id { get; set; }
        public string UrlImagem { get; set; }
        public string Link { get; set; }
        public string Texto { get; set; }
        public int QuantidadeLikes { get; set; }
        public bool UsuarioLogadoCurtiuAnuncio { get; set; }
    }
}