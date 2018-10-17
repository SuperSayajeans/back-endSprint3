using System;
using System.ComponentModel.DataAnnotations;
using Kanban.InterfaceModels;

namespace Kanban.DatabaseModels
{
    public class Project : IProject
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Master { get; set; }
        public int PO { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NOfMembers { get; set; }
    }
}