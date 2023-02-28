using System.ComponentModel.DataAnnotations;

namespace OrderStore.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public string OrderDetails { get; set; }
        public bool IsActive { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
