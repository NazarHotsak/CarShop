using System.ComponentModel.DataAnnotations;

namespace CheapCars.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        public bool Shipped { get; set; }
    }
}
