using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManagement.Common.Interfaces.Repositories;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;

namespace TaskManagement.Infrastructure.Scheduler
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
                    // Obtain necessary services from the scoped provider
                    var taskService = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var currentTime = DateTime.Now;
                    // Get tasks with past deadlines
                    var tasksWithPastDeadlines = await taskService.GetTasksWithPastDeadlinesAsync(currentTime);

                    foreach (var task in tasksWithPastDeadlines)
                    {
                        // Update the task status to "failed"
                        task.Status = TaskStatus.Failed.ToString();
                        await unitOfWork.TaskRepository.Update(task);
                    }

                    await unitOfWork.Save();
                }

                // Sleep for a certain interval before the next check
                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken); // Adjust the interval as needed
            }
        }
    }
}
