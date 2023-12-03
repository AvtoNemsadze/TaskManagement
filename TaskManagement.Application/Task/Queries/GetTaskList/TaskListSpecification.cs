using System.Linq.Expressions;
using TaskEntity = TaskManagement.Domain.Entities.TaskEntity;
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

            /// სტატუსები და პრიორიტები უნდა იყოს int - ებად ბაზაში  !!!   
            //if (_filter.TaskStatusStrings != null && _filter.TaskStatusStrings.Any())
            //{
            //    result = result.And(e => _filter.TaskStatusStrings.Contains(e.Status));
            //}

            return result;
        }
    }
}
