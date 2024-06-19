namespace RedeSocial.Models
{
    public class NotificacaoModel
    {
        public int UsuarioId { get; set; }
        public int UsuarioAmigoId { get; set; }
        public int Tipo { get; set; } // 0 - Solicitação Amizade
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime? DataLeitura { get; set; } // Pode ser nulo se ainda não foi lido

        // Construtor
        public NotificacaoModel(int usuarioId, int usuarioAmigoId, int tipo, string mensagem, DateTime dataEnvio, DateTime? dataLeitura)
        {
            UsuarioId = usuarioId;
            UsuarioAmigoId = usuarioAmigoId;
            Tipo = tipo;
            Mensagem = mensagem;
            DataEnvio = dataEnvio;
            DataLeitura = dataLeitura;
        }
    }
}
