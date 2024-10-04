using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Print_Locations")]
    public class PrintLocation
    {
        public int ID { get; set; }
        public string Print_Location { get; set; }
    }
}
