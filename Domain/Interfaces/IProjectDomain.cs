using System.Collections.Generic;
using Kanban.DatabaseModels;
using Kanban.Infrastructure;
using Ninject;
using System.Reflection;

namespace Kanban.Domain.Interfaces
{
    interface IProjectDomain
    {
        IEnumerable<Project> GetAllProjects();

        Project GetProjectById(int id);

        string AddProject(Project project);

        string UpdateProjectById(int id, string name);

        string DeleteProjectById(int id);
    }
}
