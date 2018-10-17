using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using System.Web.Http.Cors;

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
    }
}