using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
