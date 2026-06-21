using System.ComponentModel.DataAnnotations;

namespace PokeMartOnline.Models
{
    public class CheckoutModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
