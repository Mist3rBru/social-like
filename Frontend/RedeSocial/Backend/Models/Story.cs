namespace RedeSocial.Backend.Models
{
    public class Story
    {
        public class User
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
        }

      
            public Guid Id { get; set; }
            public Guid IdUsuario { get; set; }
            public User Usuario { get; set; }
            public string Conteudo { get; set; }
            public DateTime DataEnvio { get; set; }
            public int NumVisualizacao { get; set; }
            public int Situacao { get; set; }
        
    }
}
