using Microsoft.AspNetCore.Mvc;
using RedeSocial.Backend.HTTPClient;
using RedeSocial.Models;
using System.Collections.Generic;
using static RedeSocial.Models.PublicacaoModel;

namespace RedeSocial.Controllers
{
    public class FeedController : Controller
    {

        APIHttpClient client;

        private static readonly string URLBaseAnuncio = "http://grupo1.neurosky.com.br/api/";
        private static readonly string URLBaseStories = "http://grupo2.neurosky.com.br/api/";
        private static readonly string URLBaseUsuario = "http://grupo3.neurosky.com.br/api/";
        private static readonly string URLBaseCurtidaComentario = "http://grupo4.neurosky.com.br/api/";
        private static readonly string URLBasePublicacao = "http://grupo5.neurosky.com.br/api/";

        [HttpGet]
        public IActionResult Index()
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseUsuario);
            UsuarioModel usuarioLogado = client.Get<UsuarioModel>($"Usuario/{userId}");

            ViewBag.Publicacoes = listaPublicacoes(userId);
            ViewBag.Anuncios = listaAnuncios();
            ViewBag.Stories = listaStories();
            ViewBag.Usuario = usuarioLogado;

            return View();
        }

        [HttpGet]
        private List<PublicacaoModel> listaPublicacoes(string? userId)
        {
            List<PublicacaoModel> todasPublicacoes = new List<PublicacaoModel>();

            client = new APIHttpClient(URLBaseUsuario);
            UsuarioModel usuarioLogado = client.Get<UsuarioModel>($"Usuario/{userId}");

            client = new APIHttpClient(URLBasePublicacao);
            List<PublicacaoModel> publicacoesUsuarioLogado = client.Get<List<PublicacaoModel>>($"Publicacao?idUsuario={userId}");

            foreach (var publicacao in publicacoesUsuarioLogado)
            {
                publicacao.NomeUsuario = usuarioLogado.Nome;
                publicacao.FotoUsuario = usuarioLogado.FotoPerfil;
                todasPublicacoes.Add(publicacao);
            }

            foreach (var amigo in usuarioLogado.Amigos)
            {
                client = new APIHttpClient(URLBasePublicacao);
                List<PublicacaoModel> publicacoesAmigos = client.Get<List<PublicacaoModel>>($"Publicacao?idUsuario={amigo.Id}");

                foreach (var publicacaoAmigo in publicacoesAmigos)
                {
                    publicacaoAmigo.NomeUsuario = amigo.Nome;
                    publicacaoAmigo.FotoUsuario = amigo.FotoPerfil;
                    todasPublicacoes.Add(publicacaoAmigo);
                }
                   
            }


            foreach (var publicacao in todasPublicacoes)
            {
                publicacao.QuantidadeLikes = listaCurtidasPost(publicacao.Id).Count;

                List<ComentarioModel> comentarios = listaComentariosPost(publicacao.Id);
                publicacao.QuantidadeComentarios = comentarios.Count;

                publicacao.UsuarioLogadoCurtiuPost = usuarioLogadoCurtiuPost(publicacao.Id);

                /*foreach (var comentario in comentarios)
                {
                    
                }*/
            }

            return todasPublicacoes;
        }

        [HttpGet]
        private List<StoryModel> listaStories()
        {
            APIHttpClient client;
            client = new APIHttpClient(URLBaseStories);
            List<StoryModel> stories = client.Get<List<StoryModel>>("Storie");

            foreach (var story in stories)
            {
                client = new APIHttpClient(URLBaseUsuario);
                UsuarioModel usuario = client.Get<UsuarioModel>($"Usuario/{story.IdUsuario}");
                // story.NomeUsuario = usuario.Nome;
                // story.FotoUsuario = usuario.FotoPerfil;
                 story.NomeUsuario = "usuario.Nome";
                story.FotoUsuario = "usuario.FotoPerfil";
                
            }

            return stories;
        }

        [HttpGet]
        private List<AnuncioModel> listaAnuncios()
        {
            APIHttpClient client;
            client = new APIHttpClient(URLBaseAnuncio);
            List<AnuncioModel> anuncios = client.Get<List<AnuncioModel>>("Anuncio");

            foreach (var anuncio in anuncios)
            {
                anuncio.QuantidadeLikes = listaCurtidasAnuncio(anuncio.Id).Count;

                anuncio.UsuarioLogadoCurtiuAnuncio = usuarioLogadoCurtiuAnuncio(anuncio.Id);
            }

            return anuncios;
        }

        [HttpPost]
        private IActionResult adicionaStory()
        {
            APIHttpClient client;
            client = new APIHttpClient(URLBaseAnuncio);
            //List<AnuncioModel> anuncios = client.Get<List<AnuncioModel>>("Anuncio");

            //return anuncios;

            return Json(new { sucesso = true  });
        }

        [HttpGet]
        private List<Guid> listaCurtidasPost(Guid postId)
        {
            client = new APIHttpClient(URLBaseCurtidaComentario);
            List<Guid> curtidasPost = client.Get<List<Guid>>($"likes/post/{postId}");

            return curtidasPost;
        }

        [HttpGet]
        private List<ComentarioModel> listaComentariosPost(Guid postId)
        {
            client = new APIHttpClient(URLBaseCurtidaComentario);
            List<ComentarioModel> comentariosPost = client.Get<List<ComentarioModel>>($"comentarios/post/{postId}");

            return comentariosPost;
        }

        [HttpPost]
        public IActionResult CurtirPost(Guid postId)
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseCurtidaComentario);
            client.Post($"likes/post/{postId}/{userId}");

            return Json(new { sucesso = true, quantidadeLikes = listaCurtidasPost(postId).Count });
        }

        [HttpDelete]
        public IActionResult DescurtirPost(Guid postId)
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseCurtidaComentario);
            client.Delete($"likes/post/{postId}/{userId}");

            return Json(new { sucesso = true, quantidadeLikes = listaCurtidasPost(postId).Count });
        }

        [HttpPost]
        public bool usuarioLogadoCurtiuPost(Guid anuncioId)
        {
            var userId = Request.Cookies["UserId"];

            List<Guid> usuariosCurtiramPost = listaCurtidasPost(anuncioId);

            bool curtiu = usuariosCurtiramPost.Any(u => u.ToString() == userId);

            return curtiu;
        }

        [HttpGet]
        private List<Guid> listaCurtidasAnuncio(Guid anuncioId)
        {
            client = new APIHttpClient(URLBaseCurtidaComentario);
            List<Guid> curtidasAnuncio = client.Get<List<Guid>>($"likes/anuncio/{anuncioId}");

            return curtidasAnuncio;
        }

        [HttpPost]
        public IActionResult CurtirAnuncio(Guid anuncioId)
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseCurtidaComentario);
            client.Post($"likes/anuncio/{anuncioId}/{userId}");

            // return Json(new { sucesso = true, quantidadeLikes = listaCurtidasAnuncio(anuncioId).Count });
            return Json(new { sucesso = true, quantidadeLikes = 1 });
        }

        [HttpDelete]
        public IActionResult DescurtirAnuncio(Guid anuncioId)
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseCurtidaComentario);
            client.Delete($"likes/anuncio/{anuncioId}/{userId}");

            return Json(new { sucesso = true, quantidadeLikes = listaCurtidasAnuncio(anuncioId).Count });
        }

        [HttpPost]
        public bool usuarioLogadoCurtiuAnuncio(Guid anuncioId)
        {
            var userId = Request.Cookies["UserId"];

            List<Guid> usuariosCurtiramAnuncio = listaCurtidasAnuncio(anuncioId);

            //bool curtiu = usuariosCurtiramAnuncio.Any(u => u.ToString() == userId);
            bool curtiu = true;
            return curtiu;
        }




    }

    }
