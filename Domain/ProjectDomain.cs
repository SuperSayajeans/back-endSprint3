using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Persistence;
using Kanban.Infrastructure;
using Kanban.Context;
using Ninject;
using System.Reflection;

namespace Kanban.Domain
{
    public class ProjectDomain
    {
        StandardKernel kernel = new StandardKernel();
        public IUnitOfWork unitOfWork;

        public ProjectDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return unitOfWork.Projects.GetAll();
        }

        public Project GetProjectById(int id)
        {
            return unitOfWork.Projects.Get(id);
        }

        public string AddProject(Project project)
        {
            unitOfWork.Projects.Add(project);
            unitOfWork.Complete();
            return "Success";
        }

        public string UpdateProjectById(int id, string name)
        {
            Project project = unitOfWork.Projects.Get(id);
            project.Name = name;
            unitOfWork.Complete();
            return "Success";
        }

        public string DeleteProjectById(int id)
        {
            Project project = unitOfWork.Projects.Get(id);
            unitOfWork.Projects.Remove(project);
            unitOfWork.Complete();
            return "Success";
        }
    }
}
