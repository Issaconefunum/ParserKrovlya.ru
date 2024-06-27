using System.ComponentModel.DataAnnotations;

namespace APIParser.Models.Request
{
    public class ProductsRequest
    {
        [Required(ErrorMessage="The field can not be empty")]
        [MinLength(3, ErrorMessage = "Min length must be bigger than 3")]
        [MaxLength(255, ErrorMessage = "Min length must be smaller than 255")]
        public string SearchPhrase { get; set; } = string.Empty;

     }
}
