using Kanban.DatabaseModels;
using System.Collections.Generic;

namespace Kanban.Infrastructure.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        //IEnumerable<Task> GetTasksByUser(int userId);
        //IEnumerable<Task> GetTasksBySprint(int sprintId);
        //IEnumerable<Task> GetTasksByProject(int projectId);
    }
}