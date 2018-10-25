using System;
using System.ComponentModel.DataAnnotations;
using Kanban.InterfaceModels;

namespace Kanban.DatabaseModels
{
    public class User : IUser
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
    }
}