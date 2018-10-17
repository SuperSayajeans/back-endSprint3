using Kanban.DatabaseModels;
using System.Collections.Generic;

namespace Kanban.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        //IEnumerable<User> GetUserByRole(string role);
    }
}