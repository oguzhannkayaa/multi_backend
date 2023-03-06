namespace MultiBackend.Entities
{
    public class Store :BaseEntity
    {
        public string StoreName { get; set; } = string.Empty;
        public string? Logo { get; set; }
        public string? ContactInformation { get; set; } 
        public string? Links { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}

