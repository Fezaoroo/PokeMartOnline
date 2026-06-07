using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Data;
using System;
using System.Linq;
using DataAccessLayer.Entities;


namespace PokeMartOnline.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PokeMartDbContext _context;

        public ProductsController(PokeMartDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var products = _context.Products?.ToList() ?? new List<Product>();

            return View(products);
        }
    }
}
