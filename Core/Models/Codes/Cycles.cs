using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Cycles")]
    public class Cycles
    {
        public int ID { get; set; }
        public string Cycle { get; set; }  // 'Cycle' might be a reserved keyword, so naming it CycleName to avoid conflicts.
    }
}
