using Microsoft.AspNetCore.Mvc;

namespace RedeSocial.Models
{
    public class PostagemModel
    {
        public Guid Id { get; set; }
        public Guid Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        [BindProperty]
        public List<IFormFile> Midias { get; set; }
    }
}
