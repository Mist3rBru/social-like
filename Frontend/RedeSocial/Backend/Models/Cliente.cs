namespace WebSite.Backend.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }
    }
}
