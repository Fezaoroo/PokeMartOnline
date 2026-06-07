using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Leaderboard
    {
        public int LeaderboardId { get; set; }
        public int user_id { get; set; }
        public int total_orders { get; set; }
        public decimal total_spent { get; set; }
        public DateTime last_updated { get; set; }
    }
}
