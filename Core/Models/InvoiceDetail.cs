using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("Invoice_Details", Schema = "dbo")]
    public class InvoiceDetail
    {
        public int? ID { get; set; }
        public string? Invoice_ID { get; set; }
        public string? Product { get; set; }
        public decimal? Price { get; set; }
        public string? Color1 { get; set; }
        public string? Color_Type1 { get; set; }
        public string? Color2 { get; set; }
        public string? Color_Type2 { get; set; }
        public string? Color3 { get; set; }
        public string? Color_Type3 { get; set; }
        public string? Color4 { get; set; }
        public string? Color_Type4 { get; set; }
        public string? Color5 { get; set; }
        public string? Color_Type5 { get; set; }
        public double? Cost { get; set; }
        public double? Par_Value { get; set; }
        public double? Quantity { get; set; }
        public double? Shipping { get; set; }
        public double? Logo { get; set; }
        public double? Real_Pro_Cost { get; set; }
        public double? Total_Comm { get; set; }
        public double? Fronter_Comm { get; set; }
        public double? Closer_Comm { get; set; }
        public string? AdCopy { get; set; }
        public int? PreviousQtyEntered { get; set; }
        public byte[]? Upsize_Ts { get; set; }
    }

}
