using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("qryBLANKSALE_PrintGreenSheetMain", Schema = "dbo")]
    public class QryBlankSalePrintGreenSheetMain
    {
        public int? ID { get; set; }
        public string? Invoice_ID { get; set; }
        public int? Customer_ID { get; set; }
        public DateTime? Sale_Date { get; set; }
        public string? Name { get; set; }
        public int? Staff_ID { get; set; }
        public string? Print_Location { get; set; }
        public string? First_Name { get; set; }
        public string? Trouble { get; set; }
        public string? Cancel { get; set; }
        public decimal? Total { get; set; }
        public decimal? VerifiedAmount { get; set; }
        public string? CardNumber { get; set; }
        public bool? Rush { get; set; }
        public string? Payment_Method { get; set; }
        public bool? RushBlue { get; set; }
        public string? ImprintInstructions { get; set; }
        public DateTime? Verified_Date { get; set; }
        public string? VerifierNotes { get; set; }
        public string? ComputerProof { get; set; }
        public string? TypeProof { get; set; }
        public string? Typeset { get; set; }
        public string? PressProof { get; set; }
        public string? Printed { get; set; }
        public string? Zip { get; set; }
        public string? OrderNotes { get; set; }
        public string? Last_Name { get; set; }
        public string? ShipToName { get; set; }
        public string? ShipToAddressLine1 { get; set; }
        public string? ShipToAddressLine2 { get; set; }
        public string? ShipToCity { get; set; }
        public string? ShipToState { get; set; }
        public string? ShipToZip { get; set; }
        public string? ShipToPhone1 { get; set; }
        public string? ShipToPhone2 { get; set; }
        public string? Product { get; set; }
        public string? Color1 { get; set; }
        public string? Color2 { get; set; }
        public int? Quantity { get; set; }
        public int? InvoiceDetailID { get; set; }
        public string? AdCopy { get; set; }
        public string? AdditionalNotes { get; set; }
        public decimal? GreenSheetTotal { get; set; }
    }

}
