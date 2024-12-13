using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? Active { get; set; }
    }
}
public class RoleMngResponse
{
    public bool Success { get; set; }
    public string message { get; set; }
  
}