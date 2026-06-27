using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PokeMartOnline.Models
{
    public class OrderHistoryModel
    {
        public int DisplayOrderNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItemModel> Items { get; set; }
    }

    public class OrderItemModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }
}
