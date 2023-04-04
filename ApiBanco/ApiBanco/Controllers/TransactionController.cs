using Microsoft.AspNetCore.Mvc;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;

namespace ApiBanco.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {

        private IUser users = (IUser)new UsersRepository();


        //Update user info
        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<Users> UpdateUserByID(string idUser, decimal balance)
        {
            return users.UpdateUserByID(idUser, balance);
        }

        [HttpPost]
        [Route("PostIncome")]
        public ActionResult<Users> PostIncome(string idUser, decimal balance)
        {
            return users.UpdateUserByID(idUser, balance);
        }

    }
}
