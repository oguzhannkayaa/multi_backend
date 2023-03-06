namespace MultiBackend.Dtos
{
    public class UserLoginDto
    {
        public string Name { get; set; } = string.Empty;
        public string Password  { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }

        public string Token { get; set; }
    }
}
