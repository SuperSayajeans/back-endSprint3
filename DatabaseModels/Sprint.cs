using System;
using System.ComponentModel.DataAnnotations;
using Kanban.InterfaceModels;

namespace Kanban.DatabaseModels
{
    public class Sprint : ISprint
    {
        [Key]
        public int SprintId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalHours { get; set; }
        //Adding Foreign Key Constraints for Task  
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}