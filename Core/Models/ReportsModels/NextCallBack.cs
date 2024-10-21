using System.ComponentModel.DataAnnotations.Schema;

namespace ParadisePromotions.Core.Models.ReportsModels
{
    [Table("QryNextCallBack", Schema ="dbo")]
    public class NextCallBack
    {
        public int? Id { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? CallBackDateTime { get; set; }
        public DateTime? CallBackDate { get; set; }
    }
}
