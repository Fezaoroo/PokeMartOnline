using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PokeMartOnline.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Required]
        [Column("ProductName")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Column("condition")]
        public string Condition { get; set; }

        [Column("grade")]
        public string Grade { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; }

        [Column("QuantityAvailable")]
        public int? StockQuantity { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
