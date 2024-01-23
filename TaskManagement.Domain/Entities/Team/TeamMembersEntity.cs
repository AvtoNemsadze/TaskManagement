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
        public int TeamId { get; set; }

        public bool IsBlocked { get; set; }
        public DateTime? BlockedUntil { get; set; }
        public TeamEntity Team { get; set; } = null!;
    }
}
