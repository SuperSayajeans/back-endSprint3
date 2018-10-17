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
    public class UserDomain
    {
        StandardKernel kernel = new StandardKernel();
        IUnitOfWork unitOfWork;

        public UserDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return unitOfWork.Users.GetAll();
        }
    }
}