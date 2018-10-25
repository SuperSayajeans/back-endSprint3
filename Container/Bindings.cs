using Ninject.Modules;
using Kanban.Infrastructure;
using Kanban.Persistence;
using Kanban.Infrastructure.Repositories;
using Kanban.Persistence.Repositories;
using Kanban.Context;
using Kanban.Domain.Interfaces;
using Kanban.Domain;

namespace Kanban.Container
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<ISprintRepository>().To<SprintRepository>();
            Bind<ITaskRepository>().To<TaskRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IDatabaseContext>().To<DatabaseContext>();
            Bind<IProjectDomain>().To<ProjectDomain>();
            Bind<ISprintDomain>().To<SprintDomain>();
            Bind<ITaskDomain>().To<TaskDomain>();
        }
    }
}