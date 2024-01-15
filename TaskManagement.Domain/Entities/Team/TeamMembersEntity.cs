using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Team
{
    public class TeamMembersEntity : BaseEntity
    {
        public int UserId { get; set; }
        public DomainUserEntity? User { get; set; } 
        public int TeamId { get; set; }
        public TeamEntity Team { get; set; } = null!;

        public ICollection<DomainUserEntity>? Users { get; set; } 
    }
}
