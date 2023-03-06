namespace MultiBackend.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }  

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public bool EmailVerified { get; set; } 
        public string? CardInformation { get; set; } 
        public string? Address { get; set; } 
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
