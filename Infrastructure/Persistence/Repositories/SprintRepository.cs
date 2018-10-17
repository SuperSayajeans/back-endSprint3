using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kanban.Persistence.Repositories
{
    public class SprintRepository : Repository<Sprint>, ISprintRepository
    {
        public SprintRepository(DatabaseContext context)
            : base(context)
        {
        }
        /*
        public IEnumerable<Sprint> GetSprintsByProject(int projectId);
        {
        }

        public IEnumerable<Sprint> GetUndoneSprints(int count);
        {
        }
        */
        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}