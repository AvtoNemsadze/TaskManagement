﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ITeamRepository : IGenericRepository<TeamEntity>
    {
        Task<TeamEntity?> GetTeamWithDetailsAsync(int id, CancellationToken cancellationToken);
    }
}
