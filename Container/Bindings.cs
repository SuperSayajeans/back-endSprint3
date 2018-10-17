using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using Kanban.Infrastructure;
using Kanban.Persistence;
using Kanban.Infrastructure.Repositories;
using Kanban.Persistence.Repositories;

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
        }
    }
}