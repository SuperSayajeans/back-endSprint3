using System.Collections.Generic;
using Kanban.DatabaseModels;
using Kanban.Infrastructure;
using Ninject;
using System.Reflection;
using PagedList;
using Kanban.Domain.Interfaces;

namespace Kanban.Domain
{
    public class UserDomain: IUserDomain
    {
        StandardKernel kernel = new StandardKernel();
        IUnitOfWork unitOfWork;

        public UserDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<User> GetAllUsers(int page, int size)
        {
            return unitOfWork.Users.GetAll().ToPagedList(page, size);
        }

        public User GetUserById(int id)
        {
            return unitOfWork.Users.Get(id);
        }

        public string AddUser(User user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();
            return "Success";
        }

        public string UpdateUserById(int id, string email)
        {
            User user = unitOfWork.Users.Get(id);
            user.Email = email;
            unitOfWork.Complete();
            return "Success";
        }

        public string DeleteUserById(int id)
        {
            User user = unitOfWork.Users.Get(id);
            unitOfWork.Users.Remove(user);
            unitOfWork.Complete();
            return "Success";
        }

    }
}