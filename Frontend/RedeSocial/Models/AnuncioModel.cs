namespace RedeSocial.Models
{
    public class AnuncioModel
    {
        public string Descricao { get; set; }
        public string UrlExterna { get; set; }
        public DateTime DataAnuncio { get; set; }
        public int PublicoAlvoIdadeInicial { get; set; }
        public int PublicoAlvoIdadeFinal { get; set; }
        public string PublicoAlvoGenero { get; set; }

        public AnuncioModel(string descricao, string urlExterna, DateTime dataAnuncio, int publicoAlvoIdadeInicial, int publicoAlvoIdadeFinal, string publicoAlvoGenero)
        {
            Descricao = descricao;
            UrlExterna = urlExterna;
            DataAnuncio = dataAnuncio;
            PublicoAlvoIdadeInicial = publicoAlvoIdadeInicial;
            PublicoAlvoIdadeFinal = publicoAlvoIdadeFinal;
            PublicoAlvoGenero = publicoAlvoGenero;
        }
    }


}
