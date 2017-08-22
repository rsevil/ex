using System.ComponentModel.DataAnnotations;

namespace EX.Presentation.WebSite.Models.Home
{
    public class Index
    {
        [Required]
        [MaxLength(19)]
        [MinLength(19)]
        [RegularExpression(@"\d\d\d\d-\d\d\d\d-\d\d\d\d-\d\d\d\d", ErrorMessage = "The field 'CreditCardNumber' must be a valid credit card number")]
        public string CreditCardNumber { get; set; }
    }
}