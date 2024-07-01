using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
