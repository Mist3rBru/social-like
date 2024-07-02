namespace RedeSocial.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string DataComemorativa { get; set; }
        public int Sexo { get; set; } // 0 - masculino, 1 - feminino
        public string Biografia { get; set; }
        public string FotoPerfil { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; } // AC, AL, AP, etc.
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public int Tipo { get; set; } // 1 - Física, 2 - Jurídica

        public List<UsuarioModel> Amigos { get; set; }
        public UsuarioModel(string nome, Guid id, List<UsuarioModel> amigos, string sobrenome, string senha, string dataComemorativa, int sexo, string biografia,
                       string fotoPerfil, string cidade, string uf, string telefone, string documento, int tipo)
        {
            Id=id;
            Nome = nome;
            Sobrenome = sobrenome;
            Senha = senha;
            DataComemorativa = dataComemorativa;
            Sexo = sexo;
            Biografia = biografia;
            FotoPerfil = fotoPerfil;
            Cidade = cidade;
            Uf = uf;
            Telefone = telefone;
            Documento = documento;
            Tipo = tipo;
            Amigos = amigos;
        }
    }

}
