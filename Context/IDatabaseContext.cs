using System.Data.Entity;
using Kanban.DatabaseModels;

namespace Kanban.Context
{
    interface IDatabaseContext
    {
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Sprint> Sprints { get; set; }
        DbSet<Project> Projects { get; set; }
    }
}
