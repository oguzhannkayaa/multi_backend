namespace MultiBackend.Entities
{
    public class Product : BaseEntity
    {
        public int StoreId { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public ICollection<Order> Orders { get; set; } 
        public Category Category { get; set; } 

        public Store Store { get; set; }


    }
}
