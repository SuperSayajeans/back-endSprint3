using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.InterfaceModels
{
    public interface IProject
    {
        int ProjectId { get; set; }
        string Name { get; set; }
        int Master { get; set; }
        int PO { get; set; }
    }
}