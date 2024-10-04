using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Disposition")]
    public class Disposition
    {
        public int DispositionID { get; set; }
        public string DispositionCode { get; set; }
        public string DispositionDesc { get; set; }

        public bool? Active { get; set; }

        public int? SortOrder { get; set; }
    }
}
