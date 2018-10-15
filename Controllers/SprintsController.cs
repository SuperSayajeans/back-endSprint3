using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;

namespace Kanban.Controllers
{
    public class SprintsController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();

        //Creating a method to return Json data   
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = from sprint in db.Sprints
                             select new
                             {
                                 sprint.sprintId,
                                 sprint.projectId
                             };
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