using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kanban.Persistence.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext context)
            : base(context)
        {
        }
        /*
        public IEnumerable<Project> GetDoneProjects(int count)
        {
        }

        public IEnumerable<Project> GetUndoneProjects(int pageIndex, int pageSize = 10)
        {
        }
        */
        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}