using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Cart_Items")]
    public class CartItem
    {
        [Key]
        [Column("cart_item_id")]
        public int CartItemId { get; set; }

        [Column("cart_id")]
        public int cart_id { get; set; }

        [Column("product_id")]
        public int product_id { get; set; }

        [Column("quantity")]
        public int quantity { get; set; }

        [Column("price_each")]
        public decimal price_each { get; set; }
    }
}
