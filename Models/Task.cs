using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class Task
    {
        [Key]
        public int taskId { get; set; }
        public int status { get; set; }
        public int tracking { get; set; }
        public int hours { get; set; }
        public string description { get; set; }
        //Adding Foreign Key Constraints for Task  
        public int projectId { get; set; }
        public Project Project { get; set; }
        public int sprintId { get; set; }
        public Sprint Sprint { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}