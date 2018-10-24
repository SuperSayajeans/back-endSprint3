using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using Kanban.DatabaseModels;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Kanban.Controllers
{
    /// <summary>
    /// Access sprints of the database
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SprintsController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        private SprintDomain domain = new SprintDomain();

        //Creating a method to return Json data   
        /// <summary>
        /// Get all sprints of the database
        /// </summary>
        /// <returns>
        /// All sprints on the database
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(Sprint))]
        public IHttpActionResult Get()
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = domain.GetAllSprints();
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get sprints of the database by id
        /// </summary>
        /// <remarks>
        /// Returns a sprint matching the id given as argument
        /// </remarks>
        /// <model>
        /// Sprint
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(Sprint))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = domain.GetSprintById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Add sprint of the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <model>
        /// Sprint
        /// </model>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] Sprint sprint)
        {
            var result = domain.AddSprint(sprint);
            return Ok(result);
        }

        /// <summary>
        /// Update the description of a sprint of the database
        /// </summary>
        /// <remarks>
        /// Use the id of the sprint to locate the desired sprint
        /// </remarks>
        /// <model>
        /// Sprint
        /// </model>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(int id, int hours)
        {
            var result = domain.UpdateSprintById(id, hours);
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
            var result = domain.DeleteSprintById(id);
            return Ok(result);
        }

    }
}