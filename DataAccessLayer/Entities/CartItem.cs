using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CartItem
    {
        public int cart_item_id { get; set; }
        public int cart_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price_each { get; set; }
    }
}
