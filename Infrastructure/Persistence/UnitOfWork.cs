using Kanban.DatabaseModels;
using Kanban.Infrastructure;
using Kanban.Infrastructure.Repositories;
using Kanban.Context;
using Kanban.Persistence.Repositories;

namespace Kanban.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Sprints = new SprintRepository(_context);
            Users = new UserRepository(_context);
            Tasks = new TaskRepository(_context);
        }

        public IProjectRepository Projects { get; private set; }
        public ISprintRepository Sprints { get; private set; }
        public IUserRepository Users { get; private set; }
        public ITaskRepository Tasks { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}