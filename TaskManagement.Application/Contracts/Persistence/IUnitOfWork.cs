namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }
        ITeamRepository TeamRepository { get; }
        ITeamMembersRepository TeamMembersRepository { get; }
        ValueTask Save();
    }
}
