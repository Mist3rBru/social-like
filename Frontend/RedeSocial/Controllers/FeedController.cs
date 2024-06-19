using Microsoft.AspNetCore.Mvc;

namespace RedeSocial.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
