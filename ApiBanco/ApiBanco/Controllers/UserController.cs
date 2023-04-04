using Microsoft.AspNetCore.Mvc;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUser users = (IUser) new UsersRepository();

        //endpoint to search user by ID 
        [HttpGet]
        [Route("GetUserByID")]
        public ActionResult<Users> GetUserByID(string id) 
        { 
            return users.GetUserByID(id);
        }



    }
}
