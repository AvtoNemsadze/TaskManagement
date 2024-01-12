using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class DomainUserEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
