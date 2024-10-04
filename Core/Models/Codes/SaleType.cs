using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Sale_Types")]
    public class SaleType
    {
        public int ID { get; set; }
        public string Sale_Type { get; set; }
    }
}
