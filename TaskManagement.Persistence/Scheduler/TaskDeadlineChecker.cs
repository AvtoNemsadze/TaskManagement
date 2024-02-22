using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagement.Application.Contracts.Persistence;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;

namespace TaskManagement.Persistence.Scheduler
{
    public class TaskDeadlineCheckerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TaskDeadlineCheckerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var taskService = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var currentTime = DateTime.Now;
                    var tasksWithPastDeadlines = await taskService.GetTasksWithPastDeadlinesAsync(currentTime);

                    foreach (var task in tasksWithPastDeadlines)
                    {
                        task.TaskStatusId = (int)TaskStatus.Failed;
                        unitOfWork.TaskRepository.Update(task);
                    }

                    await unitOfWork.Save();
                }

                await Task.Delay(TimeSpan.FromDays(2), stoppingToken);
            }
        }
    }
}
