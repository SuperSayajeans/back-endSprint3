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
    public class SprintDomain
    {
        StandardKernel kernel = new StandardKernel();
        IUnitOfWork unitOfWork;

        public SprintDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Sprint> GetAllSprints()
        {
            return unitOfWork.Sprints.GetAll();
        }
    }
}