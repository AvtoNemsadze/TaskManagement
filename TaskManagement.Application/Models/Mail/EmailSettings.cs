namespace TaskManagement.Application.Models.Mail
{
    public class EmailSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }
}
