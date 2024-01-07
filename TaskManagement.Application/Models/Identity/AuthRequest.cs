namespace TaskManagement.Application.Models.Identity
{
    public class AuthRequest
    {
        private string email = string.Empty;
        private string password = string.Empty;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
