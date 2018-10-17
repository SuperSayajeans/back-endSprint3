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
        IUnitOfWork unitOfWork;

        public ProjectDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return unitOfWork.Projects.GetAll();
        }

        public IQueryable GetProjects(DatabaseContext db)
        {
            var result = from project in db.Projects
                         select new
                         {
                             project.ProjectId,
                             User = from user in db.Users
                                    where user.UserId == project.PO
                                    select new
                                    {
                                        user.UserId,
                                        user.Name
                                    }
                         };
            return result;
        }
    }
}
