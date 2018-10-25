using System.ComponentModel.DataAnnotations;
using Kanban.InterfaceModels;

namespace Kanban.DatabaseModels
{
    public class Task : ITask
    {
        [Key]
        public int TaskId { get; set; }
        public int Status { get; set; }
        public int Tracking { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        //Adding Foreign Key Constraints for Task  
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}