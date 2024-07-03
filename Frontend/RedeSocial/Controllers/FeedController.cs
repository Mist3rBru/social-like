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

        public IActionResult Index()
        {
            var userId = Request.Cookies["UserId"];
        
            ViewBag.Publicacoes = listaPublicacoes(userId);
            ViewBag.Anuncios = listaAnuncios();
            ViewBag.Stories = listaStories();

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
        private IActionResult CurtirPost(Guid postId)
        {
            var userId = Request.Cookies["UserId"];

            client = new APIHttpClient(URLBaseCurtidaComentario);
            client.Post<string>($"likes/post/{postId}/{userId}","");
            return Json(new { sucesso = true });
        }

    }

    }
