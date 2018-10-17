using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.InterfaceModels
{
    public interface IUser
    {
        int UserId { get; set; }
        string Name { get; set; }
        string Role { get; set; }
    }
}