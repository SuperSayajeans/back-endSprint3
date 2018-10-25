using System.Data.Entity;
using Kanban.DatabaseModels;

namespace Kanban.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}