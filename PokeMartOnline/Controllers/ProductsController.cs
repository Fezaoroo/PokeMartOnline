using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Data;
using System;
using System.Linq;
using PokeMartOnline.Models;
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
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var products = _context.Products.ToList();

            var uiProducts = products.Select(p => new PokeMartOnline.Models.Product
            {
                Id = p.product_id,
                Name = p.ProductName,
                Description = p.description,
                Price = p.price,
                ImageUrl = p.ImageUrl,
                StockQuantity = p.QuantityAvailable,
                Condition = p.condition,
                Grade = p.grade
            }).ToList();

            return View(uiProducts);
        }
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = _context.Products
                .FirstOrDefault(p => p.product_id == id);

            if (product == null)
            {
                return NotFound();
            }

            var uiProduct = new PokeMartOnline.Models.Product
            {
                Id = product.product_id,
                Name = product.ProductName,
                Description = product.description,
                Price = product.price,
                ImageUrl = product.ImageUrl,
                StockQuantity = product.QuantityAvailable,
                Condition = product.condition,
                Grade = product.grade,
                CreatedAt = product.CreatedAt
            };

            return View(uiProduct);
        }

        public IActionResult Cards()
        {
            var products = _context.Products
                .Where(p => p.category_id == 1)
                .ToList();

            var uiProducts = products.Select(p => new PokeMartOnline.Models.Product
            {
                Id = p.product_id,
                Name = p.ProductName,
                Description = p.description,
                Price = p.price,
                ImageUrl = p.ImageUrl,
                StockQuantity = p.QuantityAvailable,
                Condition = p.condition,
                Grade = p.grade
            }).ToList();

            return View(uiProducts);
        }

        public IActionResult ETBs()
        {
            var products = _context.Products
                .Where(p => p.category_id == 2)
                .ToList();

            var uiProducts = products.Select(p => new PokeMartOnline.Models.Product
            {
                Id = p.product_id,
                Name = p.ProductName,
                Description = p.description,
                Price = p.price,
                ImageUrl = p.ImageUrl,
                StockQuantity = p.QuantityAvailable,
                Condition = p.condition,
                Grade = p.grade
            }).ToList();

            return View(uiProducts);
        }

        public IActionResult Playmats()
        {
            var products = _context.Products
                .Where(p => p.category_id == 3)
                .ToList();

            var uiProducts = products.Select(p => new PokeMartOnline.Models.Product
            {
                Id = p.product_id,
                Name = p.ProductName,
                Description = p.description,
                Price = p.price,
                ImageUrl = p.ImageUrl,
                StockQuantity = p.QuantityAvailable,
                Condition = p.condition,
                Grade = p.grade
            }).ToList();

            return View(uiProducts);
        }
    }
}
