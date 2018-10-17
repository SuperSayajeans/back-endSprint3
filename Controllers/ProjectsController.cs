using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Kanban.DatabaseModels;
using Kanban.RESTModels;

namespace Kanban.Controllers
{
    /// <summary>
    /// Acces projects of the database
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        private ProjectDomain domain = new ProjectDomain();

        //Creating a method to return Json data   
        /// <summary>
        /// Get all projects of the database
        /// </summary>
        /// <remarks>
        /// Returns all projects in the database
        /// </remarks>
        /// <model>
        /// Project
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(ClientProject))]
        public IHttpActionResult Get()
        {
            try
            {
                //Prepare data to be returned using Linq as follows
                var result = domain.GetProjects(db);
                //var result = domain.GetAllProjects();
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