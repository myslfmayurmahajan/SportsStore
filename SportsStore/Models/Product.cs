

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {

        public long ProductId { get; set; }
        [Required (ErrorMessage ="Please enter a Product Name")]
        public string ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a Product Description")]
        public string ProductDescription { get; set; } =string.Empty;

        [Column (TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify Product Category")]
        public string ProductCategory { get; set; } = string.Empty;
    }
}
