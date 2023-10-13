using System;
using System.Threading.Tasks;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }
        Task Save();
    }
}
