namespace TaskManagement.Application.Models.Identity
{
    public class UserResponseModel
    {
        public int? Id { get; set; } 
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Role { get; set;}
    }
}
