using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System.Linq;

namespace PokeMartOnline.Controllers
{
    public class AdminProductsController : Controller
    {
        private readonly PokeMartDbContext _context;

        public AdminProductsController(PokeMartDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        //Create
        public IActionResult Create()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Products");

            return View();
        }

        //Create product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Products"); 

            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.Now;

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Products");
            }

            return View(product);
        }

        //Edit 
        public IActionResult Edit(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Products");

            var product = _context.Products.FirstOrDefault(p => p.product_id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }


        //Edit product
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Products");

            var product = _context.Products.FirstOrDefault(p => p.product_id == updatedProduct.product_id);

            if (product == null)
                return NotFound();

            product.ProductName = updatedProduct.ProductName;
            product.description = updatedProduct.description;
            product.price = updatedProduct.price;
            product.ImageUrl = updatedProduct.ImageUrl;
            product.QuantityAvailable = updatedProduct.QuantityAvailable;
            product.condition = updatedProduct.condition;
            product.grade = updatedProduct.grade;

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}
