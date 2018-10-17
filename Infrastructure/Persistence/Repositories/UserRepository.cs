using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kanban.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context)
            : base(context)
        {
        }
        /*
        public IEnumerable<User> GetUserByRole(string role);
        {
        }
        */
        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}