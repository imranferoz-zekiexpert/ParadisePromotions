using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Product_Colors")]
    public class ProductColor
    {
        public int? ID { get; set; }
        public string? Color { get; set; }
    }
}
