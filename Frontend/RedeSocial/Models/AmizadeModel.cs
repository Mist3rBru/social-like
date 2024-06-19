namespace RedeSocial.Models
{
    public class AmizadeModel
    {
        public int UsuarioId { get; set; }
        public int UsuarioAmigoId { get; set; }

        // Construtor
        public AmizadeModel(int usuarioId, int usuarioAmigoId)
        {
            UsuarioId = usuarioId;
            UsuarioAmigoId = usuarioAmigoId;
        }
    }

}
