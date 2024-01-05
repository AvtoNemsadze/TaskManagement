namespace TaskManagement.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateUserId { get; set; } = string.Empty;
        public string LastModifiedUserId { get; set; } = string.Empty;
    }
}
