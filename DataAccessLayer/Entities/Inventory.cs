using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int product_id { get; set; }
        public int quantity_on_hand { get; set; }
        public DateTime last_updated { get; set; }
    }
}
