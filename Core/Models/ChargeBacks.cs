using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("ChargeBacks")]
    public class ChargeBack
    {
        public int? ID { get; set; }
        public string? Invoice_ID { get; set; }
        public string? Employee { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string? Company_Name { get; set; }
    }


}
