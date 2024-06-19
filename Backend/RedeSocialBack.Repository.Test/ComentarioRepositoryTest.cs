using RedeSocialBack.Domain.Entities;
using RedeSocialBack.Infra.Repository;

namespace RedeSocialBack.Repository.Test
{
    [TestClass]
    public class ComentarioRepositoryTest
    {
        private Comentario CriarComentario() { 
            return new Comentario(Guid.NewGuid(), "lerigou");
        }

        [TestMethod]
        public void InserirPostComentarioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();

                comentarioRepository.InserirPostComentario(comentario, Guid.NewGuid());
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void InserirRespostaComentarioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();
                Comentario respostacomentario = this.CriarComentario();

                comentarioRepository.InserirPostComentario(comentario, Guid.NewGuid());

                comentarioRepository.InserirRespostaComentario(respostacomentario, comentario.Id);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void InserirHistoriaComentarioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();

                comentarioRepository.InserirStoryComentario(comentario, Guid.NewGuid());
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListarComentarioPostTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();
                Guid idpost = Guid.NewGuid();

                comentarioRepository.InserirPostComentario(comentario, idpost);

               List <Comentario> comentarios = comentarioRepository.ListarPostComentarios(idpost);
                

                Assert.IsTrue(comentarios.Count() == 1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListarComentariosRespostaTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();
                Comentario respostacomentario = this.CriarComentario();
       
                comentarioRepository.InserirPostComentario(comentario, Guid.NewGuid());

                comentarioRepository.InserirRespostaComentario(respostacomentario, comentario.Id);

                List<Comentario> comentarios = comentarioRepository.ListarRespostaComentarios(comentario.Id);

                Assert.AreEqual(1, comentarios.Count());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListarComentariosStoryTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();
                Guid idStory = Guid.NewGuid();

                comentarioRepository.InserirStoryComentario(comentario, idStory);

                List<Comentario> comentarios = comentarioRepository.ListarStoryComentarios(idStory);

                Assert.AreEqual(1, comentarios.Count());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void InserirLikePostTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idPost = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikePost(idPost, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void InserirLikeStoryTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idStory = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikeStory(idStory, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void InserirLikeComentarioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idUsuario = Guid.NewGuid();
                Comentario comentario = this.CriarComentario();

                comentarioRepository.InserirPostComentario(comentario, Guid.NewGuid());

                comentarioRepository.InserirLikeComentario(comentario.Id, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void InserirLikeAnuncioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idAnuncio = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikeAnuncio(idAnuncio, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void RemoverLikePostTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idPost = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikePost(idPost, idUsuario);
                comentarioRepository.RemoverLikePost(idPost, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void RemoverLikeComentarioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Comentario comentario = this.CriarComentario();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirPostComentario(comentario, Guid.NewGuid());

                comentarioRepository.RemoverLikeComentario(comentario.Id, idUsuario);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void RemoverLikeStoryTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idStory = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikeStory(idStory, idUsuario);
                comentarioRepository.RemoverLikeStory(idStory, idUsuario);

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void RemoverLikeAnuncioTest()
        {
            string strConexao = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
            var comentarioRepository = new ComentarioRepository(strConexao);
            try
            {
                Guid idAnuncio = Guid.NewGuid();
                Guid idUsuario = Guid.NewGuid();

                comentarioRepository.InserirLikeAnuncio(idAnuncio, idUsuario);

                comentarioRepository.RemoverLikeAnuncio(idAnuncio, idUsuario);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
