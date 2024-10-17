namespace ParadisePromotions.Core.Models
{
    public class TouchLog
    {
        public int? TouchLogID { get; set; }
        public string? Employee { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? TouchDate { get; set; }
        public decimal? AmountOfTime { get; set; }
    }

}
