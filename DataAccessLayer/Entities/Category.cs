using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string category_name { get; set; }
        public string category_type { get; set; }
    }
}
