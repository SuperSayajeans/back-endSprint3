using System;
using System.Linq;
using System.Web.Http;
using Kanban.Context;
using Kanban.Domain;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Kanban.DatabaseModels;

namespace Kanban.Controllers
{
    /// <summary>
    /// Acces users of the database
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        private UserDomain domain = new UserDomain();

        //Creating a method to return Json data   
        /// <summary>
        /// Get all users of the database
        /// </summary>
        /// <remarks>
        /// Returns all users in the database
        /// </remarks>
        /// <model>
        /// User
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int page, int size)
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = domain.GetAllUsers(page, size);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get user of the database by id
        /// </summary>
        /// <remarks>
        /// Returns a user matching the id given as argument
        /// </remarks>
        /// <model>
        /// User
        /// </model>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = domain.GetUserById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        /// <summary>
        /// Add user of the database
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <model>
        /// User
        /// </model>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            var result = domain.AddUser(user);
            return Ok(result);
        }

        /// <summary>
        /// Update the email of a task of the database
        /// </summary>
        /// <remarks>
        /// Use the id of the task to locate the desired task
        /// </remarks>
        /// <model>
        /// Task
        /// </model>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(int id, string email)
        {
            var result = domain.UpdateUserById(id, email);
            return Ok(result);
        }

        /// <summary>
        /// Deletes user of the database by id
        /// </summary>
        /// <remarks>
        /// Deletes a user matching the id given as argument
        /// </remarks>
        /// <model>
        /// User
        /// </model>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = domain.DeleteUserById(id);
            return Ok(result);
        }

    }
}