using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models
{
    [Table("RoleModules")]
    public class RoleModule
    {
        [Key]
        public int? ID { get; set; }
        public int? RoleID { get; set; }
        public int? ModuleID { get; set; }
        public string? Url { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
