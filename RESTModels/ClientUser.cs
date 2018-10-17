using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.InterfaceModels;

namespace Kanban.RESTModels
{
    public class ClientUser : IUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}