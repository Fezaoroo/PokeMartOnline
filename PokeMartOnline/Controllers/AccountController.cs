using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Data;
using System;
using System.Linq;

namespace PokeMartOnline.Controllers
{
    public class AccountController : Controller
    {
        private readonly PokeMartDbContext _context;

        public AccountController(PokeMartDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.role = "Customer";
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login() => View();
        [HttpPost]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("User", user.email);
                HttpContext.Session.SetString("UserId", user.user_id.ToString());
                HttpContext.Session.SetString("Role", user.role);

                return RedirectToAction("Index", "Products");
            }

            ViewBag.Error = "Invalid login";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
