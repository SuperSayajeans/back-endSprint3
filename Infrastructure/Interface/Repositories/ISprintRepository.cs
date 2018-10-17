using Kanban.DatabaseModels;
using System.Collections.Generic;

namespace Kanban.Infrastructure.Repositories
{
    public interface ISprintRepository : IRepository<Sprint>
    {
        //IEnumerable<Sprint> GetSprintsByProject(int projectId);
        //IEnumerable<Sprint> GetUndoneSprints(int count);
    }
}