using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.InterfaceModels;

namespace Kanban.RESTModels
{
    public class ClientSprint : ISprint
    {
        public int SprintId { get; set; }
        public int ProjectId { get; set; }
    }
}