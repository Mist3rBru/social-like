using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.Models;
using RedeSocial.Models;

namespace RedeSocial.Models
{
    public class UsuarioAlterarModel : UsuarioCadastroModel
    {
        public Guid Id { get; set; }
        public string Telefone { get; set; }
        public TipoPessoaModel TipoPessoa { get; set; }
        public TipoSexoModel TipoSexo { get; set; }
        public string Documento { get; set; }
        public string Bio { get; set; }
        public string Cidade { get; set; }
        public EstadosBrasilModel Uf { get; set; }

        [BindProperty]
        public IFormFile FotoPerfil { get; set; }
    }
}
