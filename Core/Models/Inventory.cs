namespace ParadisePromotions.Core.Models
{
    public class Inventory
    {
        public int ID { get; set; }

        public string Product { get; set; }

        public string Color { get; set; }

        public int? Quantity { get; set; }

        public int? AvailableQty { get; set; }

        public bool? ViewableProduct { get; set; }

        public byte[] Upsize_TS { get; set; }
    }

}
