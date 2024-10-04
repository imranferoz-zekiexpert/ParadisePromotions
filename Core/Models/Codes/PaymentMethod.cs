using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParadisePromotions.Core.Models.Codes
{
    [Table("Payment_Methods")]
    public class PaymentMethod
    {
        public int ID { get; set; }
        public string Method { get; set; }
    }
}
