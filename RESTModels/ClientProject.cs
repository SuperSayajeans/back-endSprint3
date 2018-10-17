using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.InterfaceModels;

namespace Kanban.RESTModels
{
    public class ClientProject : IProject
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int Master { get; set; }
        public int PO { get; set; }
    }
}