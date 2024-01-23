using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Scheduler
{
    public class BlockedTeamMembersChecker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public BlockedTeamMembersChecker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var teamMembersService = scope.ServiceProvider.GetRequiredService<ITeamMembersRepository>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var currentTime = DateTime.Now;
                    var teamMemberExpireBlockDate = await teamMembersService.GetBlockedUserWithExpireBlockDateAsync(currentTime);

                    foreach (var teamMember in teamMemberExpireBlockDate)
                    {
                        teamMember.IsBlocked = false;
                        await unitOfWork.TeamMembersRepository.Update(teamMember);
                    }

                    await unitOfWork.Save();
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
