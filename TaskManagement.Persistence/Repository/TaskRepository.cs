using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Persistence.Repository
{
    public class TaskRepository : GenericRepository, ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
