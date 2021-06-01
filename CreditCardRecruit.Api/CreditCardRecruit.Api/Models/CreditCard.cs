using System.ComponentModel.DataAnnotations;

namespace CreditCardRecruit.Api.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.CreditCard, ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVC number (must be 3 digits).")]
        public string CvcNumber { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(20[0-9]{2})$", ErrorMessage = "Invalid expiry date (mm/yyyy).")]
        public string ExpiryDate { get; set; }
    }
}
