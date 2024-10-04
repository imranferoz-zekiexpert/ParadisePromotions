using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Return_Types")]
    public class ReturnType
    {
        public int ID { get; set; }
        public string Return_Type { get; set; }
    }
}
