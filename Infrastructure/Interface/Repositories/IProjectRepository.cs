using Kanban.DatabaseModels;
using System.Collections.Generic;

namespace Kanban.Infrastructure.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        //IEnumerable<Project> GetDoneProjects(int count);
        //IEnumerable<Project> GetUndoneProjects(int count);
    }
}