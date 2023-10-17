﻿using Microsoft.Extensions.DependencyInjection;
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
                    var taskService = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var currentTime = DateTime.Now;
                    var tasksWithPastDeadlines = await taskService.GetTasksWithPastDeadlinesAsync(currentTime);

                    foreach (var task in tasksWithPastDeadlines)
                    {
                        task.Status = TaskStatus.Failed.ToString();
                        await unitOfWork.TaskRepository.Update(task);
                    }

                    await unitOfWork.Save();
                }

                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken); 
            }
        }
    }
}
