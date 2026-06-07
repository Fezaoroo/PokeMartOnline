using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int product_id { get; set; }

        [Column("category_id")]
        public int? category_id { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("price")]
        public decimal price { get; set; }

        [Column("QuantityAvailable")]
        public int QuantityAvailable { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
