using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Backend.Models
{
    public class PublicacaoModelBack
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<string> Midias { get; set; }

        public PublicacaoModelBack() { }
        public PublicacaoModelBack(Guid id, string usuario, string descricao, DateTime dataPublicacao, List<string> midias)
        {
          Id = id;
          Usuario = usuario;
          Descricao = descricao;
          DataPublicacao = dataPublicacao;
          Midias = midias;
        }
    }
}
