﻿using System.Linq.Expressions;
using TaskEntity = TaskManagement.Domain.Entities.Task.TaskEntity;
using TaskManagement.Common.Infrastructure.Extensions.Lambda;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class TaskListSpecification
    {
        private Expression<Func<TaskEntity, bool>> BaseExpression { get; } = u => u.IsDeleted == false;

        private readonly GetTaskListQuery _filter;
        public TaskListSpecification(GetTaskListQuery filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public Expression<Func<TaskEntity, bool>> GetFilterExpression()
        {
            var result = BaseExpression;

            if (_filter.StartDate.HasValue && _filter.EndDate.HasValue)
            {
                Expression<Func<TaskEntity, bool>> dateFilter = task =>
                    task.CreatedAt >= _filter.StartDate && task.CreatedAt <= _filter.EndDate;

                result = result.And(dateFilter);
            }


            if (!string.IsNullOrEmpty(_filter.SearchQuery))
            {
                var searchQuery = _filter.SearchQuery.Trim();
                Expression<Func<TaskEntity, bool>> searchFilter = task =>
                    (task.Title != null && task.Title.Contains(searchQuery)) ||
                    (task.Description != null && task.Description.Contains(searchQuery));

                result = result.AndAlso(searchFilter);
            }

            // Filter by multiple TaskLevelIds
            if (_filter.TaskLevelIds != null && _filter.TaskLevelIds.Any())
            {
                Expression<Func<TaskEntity, bool>> taskLevelFilter = task =>
                    _filter.TaskLevelIds.Contains(task.TaskLevelId);

                result = result.AndAlso(taskLevelFilter);
            }

            // Filter by multiple TaskStatusIds
            if (_filter.TaskStatusIds != null && _filter.TaskStatusIds.Any())
            {
                Expression<Func<TaskEntity, bool>> taskLevelFilter = task =>
                    _filter.TaskStatusIds.Contains(task.TaskStatusId);

                result = result.AndAlso(taskLevelFilter);
            }

            return result;
        }
    }
}
