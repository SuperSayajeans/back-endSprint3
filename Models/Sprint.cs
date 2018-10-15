using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class Sprint
    {
        [Key]
        public int sprintId { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }
        public int totalHours { get; set; }
        //Adding Foreign Key Constraints for Task  
        public int projectId { get; set; }
        public Project Project { get; set; }
    }
}