using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.InterfaceModels
{
    public interface ISprint
    {
        int SprintId { get; set; }
        int ProjectId { get; set; }
    }
}