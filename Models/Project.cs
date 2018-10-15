using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class Project
    {
        [Key]
        public int projectId { get; set; }
        public string name { get; set; }
        public int master { get; set; }
        public int pO { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }
        public int nOfMembers { get; set; }
    }
}