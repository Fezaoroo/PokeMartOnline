using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Entities
{
    [Table("Order_Items")]
    public class OrderItem
    {
        [Key] 
        [Column("order_item_id")]
        public int order_item_id { get; set; }

        [Column("order_id")]
        public int order_id { get; set; }

        [Column("product_id")]
        public int product_id { get; set; }

        [Column("quantity")]
        public int quantity { get; set; }

        [Column("price_each")]
        public decimal price_each { get; set; }

        [Column("subtotal")]
        public decimal subtotal { get; set; }
    }
}
