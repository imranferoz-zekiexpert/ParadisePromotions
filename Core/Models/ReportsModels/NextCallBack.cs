using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models.ReportsModels
{
    [Table("QryNextCallBack", Schema ="dbo")]
    public class NextCallBack
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CallDateTime { get; set; }
        public DateTime? CallBackDateTime { get; set; }
        public string? Comment { get; set; }
    }
}
