using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using Kanban.DatabaseModels;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace Kanban.Controllers
{
    /// <summary>
    /// Acces tasks of the database
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SprintManagerController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        private TaskDomain domain = new TaskDomain();

        /// <summary>
        /// Get all tasks within project of the database by id
        /// </summary>
        /// <remarks>
        /// Returns all tasks matching the id of the project given as argument
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Task))]
        public IHttpActionResult Get(int projectId)
        {
            try
            {
                var result = domain.GetTasksByProject(projectId);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}