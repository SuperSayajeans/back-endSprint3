using System;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using Kanban.DatabaseModels;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using Ninject;
using System.Reflection;
using Kanban.Domain.Interfaces;

namespace Kanban.Controllers
{
    /// <summary>
    /// Acces tasks of the database
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        StandardKernel kernel = new StandardKernel();
        private IDatabaseContext db;
        private ITaskDomain domain;

        public TasksController()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            db = kernel.Get<IDatabaseContext>();
            domain = kernel.Get<ITaskDomain>();
        }

        //Creating a method to return Json data   
        /// <summary>
        /// Get all tasks of the database
        /// </summary>
        /// <remarks>
        /// Returns all tasks in the database
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Task))]
        public IHttpActionResult Get(int page, int size)
        {
            try
            {
                var result = domain.GetAllTasks(page, size);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get task of the database by id
        /// </summary>
        /// <remarks>
        /// Returns a task matching the id given as argument
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Task))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = domain.GetTaskById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Add task of the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] Task task)
        {
            var result = domain.AddTask(task);
            return Ok(result);
        }

        /// <summary>
        /// Update the description of a task of the database
        /// </summary>
        /// <remarks>
        /// Use the id of the task to locate the desired task
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(int id, int status)
        {
            var result = domain.UpdateTaskStatusById(id, status);
            return Ok(result);
        }

        /// <summary>
        /// Deletes task of the database by id
        /// </summary>
        /// <remarks>
        /// Deletes a task matching the id given as argument
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = domain.DeleteTaskById(id);
            return Ok(result);
        }

    }
}