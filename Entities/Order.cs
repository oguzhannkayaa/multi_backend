namespace MultiBackend.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public Customer Customer { get; set; } = new Customer();

    }
}
