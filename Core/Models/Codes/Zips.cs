using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Zips")]
    public class Zips
    {
        public int? ID { get; set; }

        public int? Zip { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
