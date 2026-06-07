using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int user_id { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        [Column("role")]
        public string role { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
