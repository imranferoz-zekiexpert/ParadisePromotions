using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models.ReportsModels
{
    [Table("qryBuyingHistory",Schema = "dbo")]
    public class BuyingHistory
    {
        public int? id { get; set; }
        public int? Fronter { get; set; }
        public int? Closer { get; set; }
        public DateTime? SGI_Type_Date { get; set; }
        public int? Customer_ID { get; set; }
        public DateTime? Sale_Date { get; set; }
        public string Invoice_ID { get; set; }
        public decimal? Total { get; set; }
        public string Card_Number { get; set; }
        public string CreditCardLastFourDigits { get; set; }
    }
}