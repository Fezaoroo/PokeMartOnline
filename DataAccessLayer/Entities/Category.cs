using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int category_id { get; set; }

        [Column("category_name")]
        public string category_name { get; set; }

        [Column("category_type")]
        public string category_type { get; set; }
    }
}
