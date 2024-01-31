using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementDbContext _context;
        private ITaskRepository _taskRepository;
        private ITeamRepository _teamRepository;
        private ITeamMembersRepository _teamMembersRepository;
        private ICommentRepository _commentRepository;
        public IContentRepository _contentRepository;
        public ILanguageRepository _languageRepository;

        public UnitOfWork(
            TaskManagementDbContext context,
            ITaskRepository taskRepository,
            ITeamRepository teamRepository,
            ITeamMembersRepository teamMembersRepository,
            ICommentRepository commentRepository,
            IContentRepository contentRepository,
            ILanguageRepository languageRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
            _teamRepository = teamRepository;
            _teamMembersRepository = teamMembersRepository;
            _commentRepository = commentRepository;
            _contentRepository = contentRepository;
            _languageRepository = languageRepository;
        }

        public ITaskRepository TaskRepository =>
          _taskRepository ??= new TaskRepository(_context);

        public ITeamRepository TeamRepository =>
          _teamRepository ??= new TeamRepository(_context);

        public ITeamMembersRepository TeamMembersRepository =>
          _teamMembersRepository ??= new TeamMembersRepository(_context);

        public ICommentRepository CommentRepository =>
          _commentRepository ??= new CommentRepository(_context);

        public IContentRepository ContentRepository =>
         _contentRepository ??= new ContentRepository(_context);

        public ILanguageRepository LanguageRepository =>
         _languageRepository ??= new LanguageRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async ValueTask Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
