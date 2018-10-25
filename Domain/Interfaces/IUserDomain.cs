using System.Collections.Generic;
using Kanban.DatabaseModels;

namespace Kanban.Domain.Interfaces
{
    interface IUserDomain
    {
        IEnumerable<User> GetAllUsers(int page, int size);

        User GetUserById(int id);

        string AddUser(User user);

        string UpdateUserById(int id, string email);

        string DeleteUserById(int id);
    }
}
