using Microsoft.AspNetCore.Mvc;

namespace RedeSocial.Models
{
    public class PostagemCadastroModel
    {
        public string Descricao { get; set; }

        public Guid IdUsuario { get; set; }

        [BindProperty]
        public IFormFile MidiaPostagem { get; set; }
    }
}
