using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.InterfaceModels;

namespace Kanban.RESTModels
{
    public class ClientTask : ITask
    {
        public int TaskId { get; set; }
        public int Status { get; set; }
        public int Tracking { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }  
        public string Owner { get; set; }
    }
}