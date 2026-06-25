namespace PokeMartOnline.Models
{
    public class LeaderboardModel
    {
        public int Rank { get; set; }

        public string CustomerName { get; set; }

        public int TotalOrders { get; set; }

        public int TotalItemsPurchased { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
