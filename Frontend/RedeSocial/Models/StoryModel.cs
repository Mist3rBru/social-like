namespace RedeSocial.Models
{
    public class StoryModel
    {
        public class UsuarioModel
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
        }

        public string NomeUsuario { get; set; }
        public string FotoUsuario { get; set; }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualizacao { get; set; }
        public int Situacao { get; set; }

        public StoryModel(Guid idUsuario, string nomeUsuario, string fotoUsuario)
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            FotoUsuario = fotoUsuario;
    }
    }

}
