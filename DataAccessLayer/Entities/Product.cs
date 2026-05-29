using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int product_id { get; set; }
        public int category_id { get; set; }
        public string ProductName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string condition { get; set; }
        public string grade { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
