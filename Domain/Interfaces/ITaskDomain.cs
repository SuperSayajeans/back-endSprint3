using System.Collections.Generic;
using Kanban.DatabaseModels;

namespace Kanban.Domain.Interfaces
{
    interface ITaskDomain
    {
        IEnumerable<Task> GetAllTasks(int page, int size);

        Task GetTaskById(int id);

        IEnumerable<Task> GetTasksByProject(int projectId);

        string AddTask(Task task);

        string UpdateTaskById(int id, string description);

        string UpdateTaskStatusById(int id, int status);

        string DeleteTaskById(int id);
    }
}
