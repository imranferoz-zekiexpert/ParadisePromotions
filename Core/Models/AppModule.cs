using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models
{
    [Table("AppModules")]
    public class AppModule
    {
        [Key]
        public int? ID { get; set; }
        public string? ModuleName { get; set; }
        public string? SubModuleName { get; set; }
        public string? Url { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? Active { get; set; }
    }
}
