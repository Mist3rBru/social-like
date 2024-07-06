
using RedeSocial.Backend.Models;
using RedeSocial.Models;

namespace RedeSocial.Backend.Adapter
{
   public static class UsuarioAdapter
    {
        public static UsuarioModel ToUsuarioModel(UsuarioCadastroModel usuarioCadastro)
        {
            return new()
            {
                Nome = usuarioCadastro.Nome,
                Sobrenome = usuarioCadastro.Sobrenome,
                Email = usuarioCadastro.Email,
                Senha = usuarioCadastro.Senha!,
                DataComemorativa = usuarioCadastro.DataComemorativa,
                Sexo = TipoSexoModel.Masculino,
                Bio = string.Empty,
                FotoPerfil = string.Empty,
                Cidade = string.Empty,
                Uf = EstadosBrasilModel.AC,
                Telefone = usuarioCadastro.Telefone,
                Documento = string.Empty,
                Tipo = TipoPessoaModel.Fisica,
                Amigos = []
            };
        }

        public static UsuarioModel ToUsuarioModel(UsuarioAlterarModel usuarioAlterarModel)
        {
            var usuarioModel = new UsuarioModel()
            {
                Id = usuarioAlterarModel.Id,
                Nome = usuarioAlterarModel.Nome,
                Sobrenome = usuarioAlterarModel.Sobrenome,
                Email = usuarioAlterarModel.Email,
                Senha = usuarioAlterarModel.Senha!,
                DataComemorativa = usuarioAlterarModel.DataComemorativa,
                Sexo = usuarioAlterarModel.TipoSexo,
                Bio = usuarioAlterarModel.Bio,
                Cidade = usuarioAlterarModel.Cidade,
                Uf = usuarioAlterarModel.Uf,
                Telefone = usuarioAlterarModel.Telefone,
                Documento = usuarioAlterarModel.Documento,
                Tipo = usuarioAlterarModel.TipoPessoa,
                Amigos = []
            };

            using var ms = new MemoryStream();
            if (usuarioAlterarModel.FotoPerfil is not null)
            {
                usuarioAlterarModel.FotoPerfil.CopyTo(ms);
                usuarioModel.FotoPerfil = Convert.ToBase64String(ms.ToArray());
            }

            return usuarioModel;
        }

        public static UsuarioCadastroModel ToUsuarioCadastroModel(UsuarioModel usuarioModel)
        {
            return new()
            {
                Id = usuarioModel.Id,
                Nome = usuarioModel.Nome,
                Sobrenome = usuarioModel.Sobrenome,
                Email = usuarioModel.Email,
                DataComemorativa = usuarioModel.DataComemorativa
            };
        }

        public static LoginModel CadastroToLoginModel(UsuarioCadastroModel usuarioCadastro)
        {
            return new LoginModel()
            {
                Email = usuarioCadastro.Email,
                Senha = usuarioCadastro.Senha,
            };
        }
        public static UsuarioLoginModel ToUsuarioLoginModel(LoginModel login)
        {
            return new UsuarioLoginModel()
            {
                Email = login.Email,
                Senha = login.Senha,
            };
        }
    }
}
