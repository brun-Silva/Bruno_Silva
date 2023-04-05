using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;

namespace ApiBanco.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {

        private ITransaction transaction = (ITransaction)new TransactionRepository();
        private IUser users = (IUser)new UsersRepository();

        //GetTransaction
        [HttpGet]
        [Route("GetTransactionByID")]
        public ActionResult<Transaction> GetTransactionByID(int Id)
        {
            return transaction.GetTransactionByID(Id);
        }
        //delet transaction
        [HttpDelete]
        [Route("DeleteTransactionByID")]
        public ActionResult<Transaction> DeleteTransactionByID(int Id) { 
            return transaction.DeleteTransactionByID(Id);
        }

        //update transaction by transaction ID
        [HttpPut]
        [Route("UpdateTransactionByID")]
        public ActionResult<Transaction> UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, string? newType, DateTime newDataTime)
        {
            transaction.UpdateTransactionByID(idTransaction,newValue,newDescription,newTitle,newType=(newType == string.Empty) ? "no type" : newType,newDataTime);
            return transaction.GetTransactionByID(idTransaction);
        }

        [HttpGet]
        [Route("GetTransactionsByType")]
        public List<Transaction> GetTransactTypeByUserId(string userId, string type)
        {
            return transaction.GetTransactTypeByUserId(userId,type);
        }

    }
}

