using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.InterfaceModels
{
    public interface ITask
    {
        int TaskId { get; set; }
        int Status { get; set; }
        int Tracking { get; set; }
        int Hours { get; set; }
        string Description { get; set; }
    }
}