namespace MultiBackend.Entities
{
    public class User 
    {
        public int UserId { get; set; }

        public bool IsActive { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EmailVerified { get; set; } = string.Empty;
        public string? CardNumber { get; set; }

        public ICollection<Order>? Orders { get; set; }


    }
}
