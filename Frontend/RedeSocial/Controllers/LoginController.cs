using Microsoft.AspNetCore.Mvc;
using RedeSocial.Models;
using System.Diagnostics;
using System.Reflection;
using System;
using RedeSocial.Backend.HTTPClient;

namespace RedeSocial.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Autenticar()
        {
          
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7) // Set cookie to expire in 7 days
            };
            Response.Cookies.Append("UserId", "68f63852-a838-49d4-9232-f2d704be2ee9", cookieOptions);
            return RedirectToAction("Index", "Feed");

       
        
        }
    }
}
