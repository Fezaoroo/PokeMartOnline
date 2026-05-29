using Microsoft.AspNetCore.Mvc;

namespace PokeMartOnline.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
