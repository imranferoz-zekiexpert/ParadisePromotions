namespace ParadisePromotions.Core.Models
{
    public class Products
    {
    public int ID { get; set; }
    public string ProductID { get; set; }
	public string ProductName { get; set; }
	public decimal PerValue { get; set; }
	public decimal PerCost { get; set; }
	public bool Active { get; set; }
    }
}
