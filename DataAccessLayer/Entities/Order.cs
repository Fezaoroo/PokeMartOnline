using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public DateTime order_date { get; set; }
        public string status { get; set; }
        public decimal total_amount { get; set; }
        public string shipping_address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
