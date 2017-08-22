using System.ComponentModel.DataAnnotations;

namespace EX.Presentation.WebSite.Models.Home
{
    public class Pin : Index
    {
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        [RegularExpression(@"\d+")]
        public string PinNumber { get; set; }
    }
}