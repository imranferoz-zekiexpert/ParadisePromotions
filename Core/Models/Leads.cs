using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models
{
    [Table("Leads")]
    public class Lead
    {
        public int? Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Comments { get; set; }
        public string? Phone1 { get; set; }
        public int? CustomerId { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? AssignDate { get; set; }
        public int? CycleId { get; set; }
        public int? TimeZoneId { get; set; }
        public DateTime? CallBackDate { get; set; }
        public int? LastDispositionId { get; set; }
        public DateTime? DispDateTime { get; set; }
        public DateTime? LastSaleDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
