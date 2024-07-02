using System.ComponentModel.DataAnnotations;

namespace RedeSocial.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public DateTime DataComemorativa { get; set; }
        public string Biografia { get; set; }
        public TipoSexoModel Sexo { get; set; }
        public string Bio { get; set; }
        public string FotoPerfil { get; set; }
        public string Cidade { get; set; }
        public EstadosBrasilModel Uf { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public List<UsuarioModel> Amigos { get; set; }
        public TipoPessoaModel Tipo { get; set; } // 1 - F�sica, 2 - Jur�dica

        public enum EstadosBrasilModel
        {
            [Display(Name = "Acre")]
            AC,
            [Display(Name = "Alagoas")]
            AL,
            [Display(Name = "Amap�")]
            AP,
            [Display(Name = "Amazonas")]
            AM,
            [Display(Name = "Bahia")]
            BA,
            [Display(Name = "Cear�")]
            CE,
            [Display(Name = "Distrito Federal")]
            DF,
            [Display(Name = "Esp�rito Santo")]
            ES,
            [Display(Name = "Goi�s")]
            GO,
            [Display(Name = "Maranh�o")]
            MA,
            [Display(Name = "Mato Grosso")]
            MT,
            [Display(Name = "Mato Grosso do Sul")]
            MS,
            [Display(Name = "Minas Gerais")]
            MG,
            [Display(Name = "Par�")]
            PA,
            [Display(Name = "Para�ba")]
            PB,
            [Display(Name = "Paran�")]
            PR,
            [Display(Name = "Pernambuco")]
            PE,
            [Display(Name = "Piau�")]
            PI,
            [Display(Name = "Rio de Janeiro")]
            RJ,
            [Display(Name = "Rio Grande do Norte")]
            RN,
            [Display(Name = "Rio Grande do Sul")]
            RS,
            [Display(Name = "Rond�nia")]
            RO,
            [Display(Name = "Roraima")]
            RR,
            [Display(Name = "Santa Catarina")]
            SC,
            [Display(Name = "S�o Paulo")]
            SP,
            [Display(Name = "Sergipe")]
            SE,
            [Display(Name = "Tocantins")]
            TO
        }

        public enum TipoPessoaModel
        {
            Fisica = 0,
            Juridica = 1
        }

        public enum TipoSexoModel
        {
            [Display(Name = "Masculino")]
            Masculino = 0,
            [Display(Name = "Feminino")]
            Feminino = 1
        }
    }

}
