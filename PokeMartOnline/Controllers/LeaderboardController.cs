using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Data;
using PokeMartOnline.Models;


namespace PokeMartOnline.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly PokeMartDbContext _context;

        public LeaderboardController(PokeMartDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leaderboard = _context.Users
                .Select(u => new LeaderboardModel
                {
                    CustomerName = u.FullName,

                    TotalOrders = _context.Orders
                        .Count(o => o.user_id == u.user_id),

                    TotalItemsPurchased = (
                        from o in _context.Orders
                        join oi in _context.OrderItems
                        on o.order_id equals oi.order_id
                        where o.user_id == u.user_id
                        select oi.quantity
                    ).Sum(),

                    TotalSpent = (
                        from o in _context.Orders
                        where o.user_id == u.user_id
                        select o.total_amount
                    ).Sum()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ToList();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                leaderboard[i].Rank = i + 1;
            }

            return View(leaderboard);
        }
    }
}
