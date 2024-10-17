using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("BlankSale", Schema = "dbo")]
    public class BlankSale
    {
        public int? ID { get; set; }
        public string? Invoice_ID { get; set; }
        public int? Customer_ID { get; set; }
        public DateTime? Sale_Date { get; set; }
        public string? Sale_Type { get; set; }
        public string? Payment_Method { get; set; }
        public DateTime? Check_Date { get; set; }
        public decimal? Check_Amount { get; set; }
        public string? Card_Number { get; set; }
        public string? CreditCardLastFourDigits { get; set; }
        public int? Fronter { get; set; }
        public int? Closer { get; set; }
        public int? Verifier { get; set; }
        public DateTime? Verified_Date { get; set; }
        public DateTime? SGI_Rec_Date { get; set; }
        public DateTime? SGI_Type_Date { get; set; }
        public DateTime? Ship_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public string? Return_Type { get; set; }
        public decimal? Return_Amount { get; set; }
        public string? Print_Location { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Input_Date { get; set; }
        public bool? Rush { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Front_Comm { get; set; }
        public decimal? Closer_Comm { get; set; }
        public decimal? Total_Comm { get; set; }
        public string? Trouble { get; set; }
        public string? Cancel { get; set; }
        public string? OrderNotes { get; set; }
        public decimal? VerifiedAmount { get; set; }
        public string? ImprintInstructions { get; set; }
        public string? VerifierNotes { get; set; }
        public string? ComputerProof { get; set; }
        public string? TypeProof { get; set; }
        public string? Typeset { get; set; }
        public string? PressProof { get; set; }
        public string? Printed { get; set; }
        public bool? RushBlue { get; set; }
        public string? ShipToName { get; set; }
        public string? ShipToAddressLine1 { get; set; }
        public string? ShipToAddressLine2 { get; set; }
        public string? ShipToCity { get; set; }
        public string? ShipToState { get; set; }
        public string? ShipToZip { get; set; }
        public string? ShipToPhone1 { get; set; }
        public string? ShipToPhone2 { get; set; }
        public string? AdditionalNotes { get; set; }
        public decimal? GreenSheetTotal { get; set; }
        public string? Owner { get; set; }
        public string? CCNumber { get; set; }
        public string? CCName { get; set; }
        public string? CCExpire { get; set; }
        public string? Product { get; set; }
        public string? Quantity { get; set; }
        public string? ItemColor { get; set; }
        public string? ImprintColor { get; set; }
        public string? AdCopy { get; set; }
        public string? SLSNumber { get; set; }
        public string? SalesPerson { get; set; }
        public string? CCCode { get; set; }
        public string? Company_Name { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone1_Ext { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone2_Ext { get; set; }
        public DateTime? LastSaveDateTime { get; set; }
        public byte[]? upsize_ts { get; set; }
    }


}
