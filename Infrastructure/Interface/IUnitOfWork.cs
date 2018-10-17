using Kanban.Infrastructure.Repositories;
using System;

namespace Kanban.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        ISprintRepository Sprints { get; }
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        int Complete();
    }
}