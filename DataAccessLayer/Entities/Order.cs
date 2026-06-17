using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        [Key] 
        [Column("order_id")]
        public int order_id { get; set; }

        [Column("user_id")]
        public int user_id { get; set; }

        [Column("order_date")]
        public DateTime order_date { get; set; }

        [Column("status")]
        public string status { get; set; }

        [Column("total_amount")]
        public decimal total_amount { get; set; }

        [Column("shipping_address")]
        public string shipping_address { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }
    }
}
