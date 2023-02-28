namespace OrderStore.Domain.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsDiscountApplied { get; set; }
    }
}
