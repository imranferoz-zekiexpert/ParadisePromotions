using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("Invoices", Schema = "dbo")]
    public class Invoice
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
        public string? ShipToFirstName { get; set; }
        public string? ShipToLastName { get; set; }
        public string? AdditionalNotes { get; set; }
        public decimal? GreenSheetTotal { get; set; }
        public DateTime? LastSaveDateTime { get; set; }
        public byte[]? Upsize_ts { get; set; }
        public string? SalesOrOffice { get; set; }
    }

}
