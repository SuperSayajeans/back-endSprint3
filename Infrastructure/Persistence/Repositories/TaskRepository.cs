using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Kanban.Persistence.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DatabaseContext context)
            : base(context)
        {
        }
        /*
        public  IEnumerable<Task> GetTasksByUser(int userId);
        {
        }

        public IEnumerable<Task> GetTasksBySprint(int sprintId);
        {
        }
        
        public IEnumerable<Task> GetTasksByProject(int projectId);
        {
        }
        */
        public DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}