using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models
{
    public class TimeZones
    {
        [Key]
        public int? TimeZoneID { get; set; }
        public string? AreaCode { get; set; }
        public string? Prefix { get; set; }
        public string? State { get; set; }
        public int? TimeZone { get; set; }
        public string? DST { get; set; }
        public int? KCOffset { get; set; }
        public string? TimeZoneDesc { get; set; }
    }


}
