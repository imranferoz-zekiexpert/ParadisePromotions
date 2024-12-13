namespace ParadisePromotions.Core.Models
{
    public class SalesFilter
    {
        public string? UserID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    
    public class LeadsFilter
    {
        public string? UserID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
