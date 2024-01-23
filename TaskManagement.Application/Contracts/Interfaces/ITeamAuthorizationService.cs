using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Contracts.Interfaces
{
    public interface ITeamAuthorizationService
    {
        Task<bool> IsUserTeamAdminAsync(int? userId, int teamId);
    }
}
