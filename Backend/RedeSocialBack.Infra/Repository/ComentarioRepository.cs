using Npgsql;
using RedeSocialBack.Domain.Entities;
using RedeSocialBack.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialBack.Infra.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private string strConexao;
        public ComentarioRepository(string strConexao = null)
        {
            this.strConexao = strConexao;
        }
        public void EditarComentario(Comentario Comentario)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE public.comentario SET conteudo=@conteudo, atualizadoem=@atualizadoem WHERE id=@id";
                    cmd.Parameters.AddWithValue("conteudo", Comentario.Conteudo);
                    cmd.Parameters.AddWithValue("atualizadoem", Comentario.DataEdicao);
                    cmd.Parameters.AddWithValue("id", Comentario.Id.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirPostComentario(Comentario comentario, Guid IdPost)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.comentario (id, idusuario, conteudo, criadoem, atualizadoem) VALUES (@id, @idUsuario, @conteudo, @criadoEm, @atualizadoEm)";
                    cmd.Parameters.AddWithValue("id", comentario.Id);
                    cmd.Parameters.AddWithValue("idUsuario", comentario.IdUsuario);
                    cmd.Parameters.AddWithValue("conteudo", comentario.Conteudo);
                    cmd.Parameters.AddWithValue("criadoEm", comentario.DataCriacao);
                    cmd.Parameters.AddWithValue("atualizadoEm", comentario.DataEdicao);
                    cmd.ExecuteNonQuery();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.comentarioPostagem (idpostagem, idcomentario) VALUES (@idPostagem, @idComentario)";
                    cmd.Parameters.AddWithValue("idPostagem", IdPost);
                    cmd.Parameters.AddWithValue("idComentario", comentario.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirRespostaComentario(Comentario Resposta, Guid IdComentario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.comentario (id, idusuario, conteudo, criadoem, atualizadoem) VALUES (@id, @idusuario, @conteudo, @criadoEm, @atualizadoem)";
                    cmd.Parameters.AddWithValue("id", Resposta.Id);
                    cmd.Parameters.AddWithValue("idusuario", Resposta.IdUsuario);
                    cmd.Parameters.AddWithValue("conteudo", Resposta.Conteudo);
                    cmd.Parameters.AddWithValue("criadoem", Resposta.DataCriacao);
                    cmd.Parameters.AddWithValue("atualizadoem", Resposta.DataEdicao);
                    cmd.ExecuteNonQuery();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.resposta (idresposta, idcomentario) VALUES (@idresposta, @idcomentario)";
                    cmd.Parameters.AddWithValue("idresposta", Resposta.Id);
                    cmd.Parameters.AddWithValue("idcomentario", IdComentario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirStoryComentario(Comentario Comentario, Guid IdStory)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.comentario (id, idusuario, conteudo, criadoem, atualizadoem) VALUES (@id, @idusuario, @conteudo, @criadoem, @atualizadoem)";
                    cmd.Parameters.AddWithValue("id", Comentario.Id);
                    cmd.Parameters.AddWithValue("idusuario", Comentario.IdUsuario);
                    cmd.Parameters.AddWithValue("conteudo", Comentario.Conteudo);
                    cmd.Parameters.AddWithValue("criadoem", Comentario.DataCriacao);
                    cmd.Parameters.AddWithValue("atualizadoem", Comentario.DataEdicao);
                    cmd.ExecuteNonQuery();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.comentariohistoria (idhistoria, idcomentario) VALUES (@idhistoria, @idcomentario)";
                    cmd.Parameters.AddWithValue("idhistoria", IdStory);
                    cmd.Parameters.AddWithValue("idcomentario", Comentario.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirComentario(Guid id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM public.comentario WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", id.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Comentario> ListarPostComentarios(Guid idPost)
        {
            List<Comentario> comentarioPostagens = new List<Comentario>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT c.id, c.idusuario, c.conteudo, c.criadoem, c.atualizadoem, cp.idpostagem, COUNT(cc.idcomentario) AS quantidadelikes,
                                                              (SELECT COUNT(*) FROM public.resposta r WHERE r.idcomentario = c.id) AS quantidadeComentarios
                                                       FROM public.comentario c
                                                       JOIN public.comentariopostagem cp ON c.id = cp.idcomentario
                                                       LEFT JOIN public.curtidacomentario cc ON c.id = cc.idcomentario
                                                       WHERE cp.idpostagem = @id
                                                       GROUP BY c.id, c.idusuario, c.conteudo, c.criadoem, c.atualizadoem, cp.idpostagem;", conexao))
                {
                    cmd.Parameters.AddWithValue("id", idPost.ToString());
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comentarioPostagens.Add(new Comentario
                            (
                                Guid.Parse(reader["id"].ToString()),
                                Guid.Parse(reader["idusuario"].ToString()),
                                reader["conteudo"].ToString(),
                                DateTime.Parse(reader["criadoem"].ToString()),
                                DateTime.Parse(reader["atualizadoem"].ToString()),
                                Convert.ToInt32(reader["quantidadelikes"].ToString())
                                Convert.ToInt32(reader["quantidadeComentarios"].ToString())
                            ));
                        }
                    }
                }
            }

            return comentarioPostagens;
        }


        public List<Comentario> ListarRespostaComentarios(Guid IdComentario)
        {
            List<Comentario> comentarioPostagens = new List<Comentario>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(@"
                                                              SELECT 
                                                                  r.idresposta, 
                                                                  c.id, 
                                                                  c.idusuario, 
                                                                  c.conteudo, 
                                                                  c.criadoem, 
                                                                  c.atualizadoem, 
                                                                  COUNT(cc.idcomentario) AS quantidadelikes
                                                              FROM 
                                                                  public.resposta r
                                                              JOIN 
                                                                  public.comentario c ON r.idresposta = c.id
                                                              LEFT JOIN 
                                                                  public.curtidacomentario cc ON c.id = cc.idcomentario
                                                              WHERE 
                                                                  r.idcomentario = @id
                                                              GROUP BY 
                                                                  r.idresposta, c.id, c.idusuario, c.conteudo, c.criadoem, c.atualizadoem;", conexao))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("id", IdComentario.ToString()));

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comentarioPostagens.Add(new Comentario
                            (
                                Guid.Parse(reader["idresposta"].ToString()),
                                Guid.Parse(reader["idusuario"].ToString()),
                                reader["conteudo"].ToString(),
                                DateTime.Parse(reader["criadoem"].ToString()),
                                DateTime.Parse(reader["atualizadoem"].ToString()),
                                Convert.ToInt32(reader["quantidadelikes"].ToString())
                            ));
                        }
                    }
                }
            }

            return comentarioPostagens;
        }

        public List<Comentario> ListarStoryComentarios(Guid IdStory)
        {
            List<Comentario> comentarioPostagens = new List<Comentario>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT c.id, c.idusuario, c.conteudo, c.criadoem, c.atualizadoem, cp.idhistoria, COUNT(cc.idcomentario) AS quantidadelikes
                                                       FROM public.comentario c
                                                       JOIN public.comentariohistoria cp ON c.id = cp.idcomentario
                                                       LEFT JOIN public.curtidacomentario cc ON c.id = cc.idcomentario
                                                       WHERE cp.idhistoria = @id
                                                       GROUP BY c.id, c.idusuario, c.conteudo, c.criadoem, c.atualizadoem, cp.idhistoria;", conexao))
                {
                    cmd.Parameters.AddWithValue("id", IdStory.ToString());
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comentarioPostagens.Add(new Comentario
                            (
                                Guid.Parse(reader["id"].ToString()),
                                Guid.Parse(reader["idUsuario"].ToString()),
                                reader["conteudo"].ToString(),
                                DateTime.Parse(reader["criadoem"].ToString()),
                                DateTime.Parse(reader["atualizadoem"].ToString()),
                                Convert.ToInt16(reader["quantidadelikes"].ToString())
                            ));
                        }
                    }
                }
            }

            return comentarioPostagens;
        }

        public void InserirLikePost(Guid IdPost, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.curtidapostagem (idpostagem, idusuario) VALUES (@idpostagem, @idusuario)";
                    cmd.Parameters.AddWithValue("idpostagem", IdPost.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirLikeStory(Guid IdStory, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.curtidahistoria (idhistoria, idusuario) VALUES (@idHistoria, @idUsuario)";
                    cmd.Parameters.AddWithValue("idHistoria", IdStory.ToString());
                    cmd.Parameters.AddWithValue("idUsuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirLikeComentario(Guid IdComentario, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.curtidacomentario (idcomentario , idusuario) VALUES (@idcomentario , @idusuario)";
                    cmd.Parameters.AddWithValue("idcomentario", IdComentario.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirLikeAnuncio(Guid IdAnuncio, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "INSERT INTO public.curtidaanuncio (idanuncio , idusuario) VALUES (@idanuncio , @idusuario)";
                    cmd.Parameters.AddWithValue("idanuncio", IdAnuncio.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void RemoverLikePost(Guid IdPost, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM public.curtidapostagem WHERE idpostagem=@idpostagem AND idusuario=@idusuario";
                    cmd.Parameters.AddWithValue("idpostagem", IdPost.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoverLikeComentario(Guid IdComentario, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM public.curtidacomentario WHERE idcomentario=@idcomentario AND idusuario=@idusuario";
                    cmd.Parameters.AddWithValue("idcomentario", IdComentario.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoverLikeStory(Guid IdHistoria, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM public.curtidahistoria WHERE idhistoria=@idhistoria AND idusuario=@idusuario";
                    cmd.Parameters.AddWithValue("idhistoria", IdHistoria.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoverLikeAnuncio(Guid IdAnuncio, Guid IdUsuario)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "DELETE FROM public.curtidaanuncio WHERE idanuncio=@idanuncio AND idusuario=@idusuario";
                    cmd.Parameters.AddWithValue("idanuncio", IdAnuncio.ToString());
                    cmd.Parameters.AddWithValue("idusuario", IdUsuario.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<string> ListarLikesPost(Guid IdPost)
        {
            List<string> usuarios = new List<string>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT idusuario 
                                                               FROM public.curtidapostagem 
                                                               WHERE idpostagem = @idPostagem;", conexao))
                {
                    cmd.Parameters.AddWithValue("idPostagem", IdPost.ToString());

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(reader["idusuario"].ToString());
                        }
                    }
                }
            }
            return usuarios;
        }

        public List<string> ListarLikesAnuncio(Guid IdAnuncio)
        {
            List<string> usuarios = new List<string>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT idusuario 
                                                               FROM public.curtidaanuncio 
                                                               WHERE idanuncio = @idAnuncio;", conexao))
                {
                    cmd.Parameters.AddWithValue("idAnuncio", IdAnuncio.ToString());

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(reader["idusuario"].ToString());
                        }
                    }
                }
            }
            return usuarios;
        }

        public List<string> ListarLikesStory(Guid IdStory)
        {
            List<string> usuarios = new List<string>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT idusuario 
                                                               FROM public.curtidahistoria 
                                                               WHERE idhistoria = @idStory;", conexao))
                {
                    cmd.Parameters.AddWithValue("idStory", IdStory.ToString());

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(reader["idusuario"].ToString());
                        }
                    }
                }
            }
            return usuarios;
        }

        public List<string> ListarLikesComentario(Guid IdComentario)
        {
            List<string> usuarios = new List<string>();

            using (NpgsqlConnection conexao = new NpgsqlConnection(strConexao))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT idusuario 
                                                               FROM public.curtidacomentario 
                                                               WHERE idcomentario = @IdComentario;", conexao))
                {
                    cmd.Parameters.AddWithValue("IdComentario", IdComentario.ToString());

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(reader["idusuario"].ToString());
                        }
                    }
                }
            }
            return usuarios;
        }
    }
}