using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Domain.Entities
{
    public class DomainUserEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TeamMembersEntity>? TeamMembers { get; set; }
    }
}
