using System.Collections.Generic;
using Kanban.DatabaseModels;
using Kanban.Infrastructure;

namespace Kanban.Domain.Interfaces
{
    interface ISprintDomain
    {
        IEnumerable<Sprint> GetAllSprints();

        Sprint GetSprintById(int id);

        string AddSprint(Sprint sprint);

        string UpdateSprintById(int id, int hours);

        string DeleteSprintById(int id);
    }
}
