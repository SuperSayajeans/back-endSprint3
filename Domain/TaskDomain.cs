using System;
using System.Collections.Generic;
using Kanban.DatabaseModels;
using Kanban.Persistence;
using Kanban.Infrastructure;
using Kanban.Context;
using Ninject;
using System.Reflection;
using System.Linq.Expressions;

namespace Kanban.Domain
{
    public class TaskDomain
    {
        StandardKernel kernel = new StandardKernel();
        public IUnitOfWork unitOfWork;

        public TaskDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return unitOfWork.Tasks.GetAll();
        }

        public virtual Task GetTaskById(int id)
        {
            return unitOfWork.Tasks.Get(id);
        }

        public IEnumerable<Task> GetTasksByProject(int projectId)
        {
            Expression<Func<Task, Boolean>> predicate =  (p => p.ProjectId == projectId);
            return unitOfWork.Tasks.Find(predicate);
        }

        public string AddTask(Task task)
        {
            unitOfWork.Tasks.Add(task);
            unitOfWork.Complete();
            return "Success";
        }

        public string UpdateTaskById(int id, string description)
        {
            Task task = unitOfWork.Tasks.Get(id);
            task.Description = description;
            unitOfWork.Complete();
            return "Success";
        }

        public string UpdateTaskStatusById(int id, int status)
        {
            Task task = unitOfWork.Tasks.Get(id);
            task.Status = status;
            unitOfWork.Complete();
            return "Success";
        }

        public string DeleteTaskById(int id)
        {
            Task task = unitOfWork.Tasks.Get(id);
            unitOfWork.Tasks.Remove(task);
            unitOfWork.Complete();
            return "Success";
        }

    }
}
