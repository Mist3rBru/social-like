using RedeSocial.Models;


namespace SocialUniftec.Website.Backend.Adapter
{
    public class PostagemAdapter
    {

        public static PostagemModel ToPostagemModel(PostagemCadastroModel postagemCadastro)
        { 
            List<IFormFile> midias = [];
            midias.Add(postagemCadastro.MidiaPostagem);

            return new()
            {
                Descricao = postagemCadastro.Descricao,
                Midias = midias,
            };
        }
    }
}