namespace MultiBackend.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string? CardInformation { get; set; }
        public string? Address { get; set; }

    }
}
