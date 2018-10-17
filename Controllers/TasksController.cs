using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using System.Web.Http.Cors;

namespace Kanban.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        private TaskDomain domain = new TaskDomain();

        //Creating a method to return Json data   
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = domain.GetAllTasks();
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            var result = domain.TestPost();
            return Ok(result);
        }
    }
}