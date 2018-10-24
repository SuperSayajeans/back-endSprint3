﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kanban.DatabaseModels;
using Kanban.Infrastructure.Repositories;
using Kanban.Persistence;
using Kanban.Infrastructure;
using Kanban.Context;
using Ninject;
using System.Reflection;

namespace Kanban.Domain
{
    public class SprintDomain
    {
        StandardKernel kernel = new StandardKernel();
        IUnitOfWork unitOfWork;

        public SprintDomain()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            unitOfWork = kernel.Get<IUnitOfWork>();
        }

        public IEnumerable<Sprint> GetAllSprints()
        {
            return unitOfWork.Sprints.GetAll();
        }

        public Sprint GetSprintById(int id)
        {
            return unitOfWork.Sprints.Get(id);
        }

        public string AddSprint(Sprint sprint)
        {
            unitOfWork.Sprints.Add(sprint);
            unitOfWork.Complete();
            return "Success";
        }

        public string UpdateSprintById(int id, int hours)
        {
            Sprint sprint = unitOfWork.Sprints.Get(id);
            sprint.TotalHours = hours;
            unitOfWork.Complete();
            return "Success";
        }

        public string DeleteSprintById(int id)
        {
            Sprint sprint = unitOfWork.Sprints.Get(id);
            unitOfWork.Sprints.Remove(sprint);
            unitOfWork.Complete();
            return "Success";
        }
    }
}