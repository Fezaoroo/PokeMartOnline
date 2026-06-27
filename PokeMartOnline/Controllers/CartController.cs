using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using PokeMartOnline.Models;
using System.Linq;

namespace PokeMartOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly PokeMartDbContext _context;

        public CartController(PokeMartDbContext context)
        {
            _context = context;
        }


        //Viewing Cart
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = _context.Cart
                .FirstOrDefault(c => c.user_id == userId);

            if (cart == null)
            {
                return View(new List<PokeMartOnline.Models.CartItem>());
            }

            var items = (from ci in _context.CartItems
                         join p in _context.Products
                         on ci.product_id equals p.product_id
                         where ci.cart_id == cart.CartId
                         select new PokeMartOnline.Models.CartItem
                         {
                             ProductId = p.product_id,
                             Name = p.ProductName,
                             Price = ci.price_each,
                             Quantity = ci.quantity,
                             ImageUrl = p.ImageUrl
                         }).ToList();

            return View(items);
        }


        //Adding to cart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "Account");

            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var product = _context.Products
                .FirstOrDefault(p => p.product_id == productId);

            if (product == null)
                return NotFound();

            int stock = product.QuantityAvailable;

            var cart = _context.Cart.FirstOrDefault(c => c.user_id == userId);

            if (cart == null)
            {
                cart = new DataAccessLayer.Entities.Cart
                {
                    user_id = userId,
                    created_at = System.DateTime.Now,
                    updated_at = System.DateTime.Now
                };

                _context.Cart.Add(cart);
                _context.SaveChanges();
            }

            var existingItem = _context.CartItems
                .FirstOrDefault(i => i.cart_id == cart.CartId &&
                                     i.product_id == productId);

            int currentQtyInCart = existingItem?.quantity ?? 0;
            int newTotalQty = currentQtyInCart + quantity;

            //Stock Check
            if (newTotalQty > stock)
            {
                TempData["Error"] = $"Only {stock - currentQtyInCart} item(s) left in stock.";
                return RedirectToAction("Details", "Products", new { id = productId });
            }

            if (existingItem != null)
            {
                existingItem.quantity = newTotalQty;
            }
            else
            {
                _context.CartItems.Add(new DataAccessLayer.Entities.CartItem
                {
                    cart_id = cart.CartId,
                    product_id = productId,
                    quantity = quantity,
                    price_each = product.price
                });
            }

            cart.updated_at = System.DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult OrderHistory()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var orders = _context.Orders
                .Where(o => o.user_id == userId)
                .OrderBy(o => o.order_date)
                .ToList();

            var result = orders.Select((o, index) => new OrderHistoryModel
            {
                DisplayOrderNumber = index + 1,   
                OrderId = o.order_id,
                OrderDate = o.order_date,
                TotalAmount = o.total_amount,

                Items = (from oi in _context.OrderItems
                         join p in _context.Products
                         on oi.product_id equals p.product_id
                         where oi.order_id == o.order_id
                         select new OrderItemModel
                         {
                             ProductName = p.ProductName,
                             Quantity = oi.quantity,
                             PriceEach = oi.price_each
                         }).ToList()
            }).ToList();

            return View(result);
        }

        //Removing from cart
        public IActionResult Remove(int productId)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = _context.Cart.FirstOrDefault(c => c.user_id == userId);

            if (cart == null)
                return RedirectToAction("Index");

            var item = _context.CartItems.FirstOrDefault(i =>
                i.cart_id == cart.CartId &&
                i.product_id == productId);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "Account");

            return View(new PokeMartOnline.Models.CheckoutModel());
        }

        [HttpPost]
        public IActionResult Checkout(PokeMartOnline.Models.CheckoutModel model)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(model);

            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = _context.Cart.FirstOrDefault(c => c.user_id == userId);

            if (cart == null)
                return RedirectToAction("Index");

            var cartItems = _context.CartItems
                .Where(ci => ci.cart_id == cart.CartId)
                .ToList();

            if (!cartItems.Any())
                return RedirectToAction("Index");

            decimal total = 0;

            var order = new DataAccessLayer.Entities.Order
            {
                user_id = userId,
                order_date = DateTime.Now,
                created_at = DateTime.Now,
                status = "Completed",
                shipping_address = $"{model.FullName}, {model.Address}, {model.City}, {model.State}, {model.ZipCode}",
                total_amount = 0
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.product_id == item.product_id);

                if (product == null) continue;

                decimal subtotal = product.price * item.quantity;
                total += subtotal;

                _context.OrderItems.Add(new DataAccessLayer.Entities.OrderItem
                {
                    order_id = order.order_id,
                    product_id = item.product_id,
                    quantity = item.quantity,
                    price_each = product.price,
                    subtotal = subtotal
                });

                product.QuantityAvailable -= item.quantity;
            }

            order.total_amount = total;

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("OrderHistory");
        }
    }
}
