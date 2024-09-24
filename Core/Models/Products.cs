namespace ParadisePromotions.Core.Models
{
    public class Products
    {
    public int ID { get; set; }
    public string ProductID { get; set; }
	public string ProductName { get; set; }
	public decimal ParValue { get; set; }
	public decimal ProCost { get; set; }
	public bool Active { get; set; }
    }
}
