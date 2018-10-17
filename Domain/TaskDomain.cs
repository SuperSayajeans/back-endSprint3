using System;
using System.Collections.Generic;
using Kanban.DatabaseModels;
using Kanban.Persistence;
using Kanban.Infrastructure;
using Kanban.Context;
using Ninject;
using System.Reflection;

namespace Kanban.Domain
{
    public class TaskDomain
    {
        StandardKernel kernel = new StandardKernel();
        IUnitOfWork unitOfWork;

        public TaskDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return unitOfWork.Tasks.GetAll();
        }

        public Boolean TestPost()
        {
            Task T = new Task();
            T.Description = "Testando";
            T.Status = 1;
            T.Tracking = 1;
            T.Hours = 4;
            T.UserId = 1;
            T.ProjectId = 1;
            T.SprintId = 1;
            unitOfWork.Tasks.Add(T);
            return true;
        }

    }
}
