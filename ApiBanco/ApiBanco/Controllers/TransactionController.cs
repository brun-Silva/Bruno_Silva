using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using User.Data.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;

namespace ApiBanco.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly IGenericRepository _genericReposity;
        private readonly IDTOFactory _DTOFactory;
        public TransactionController(IGenericRepository genericReposity, IDTOFactory DTOFactory)
        {
            _genericReposity = genericReposity;
            _DTOFactory = DTOFactory;
        }

        ////GetTransaction
        //[HttpGet]
        //[Route("GetTransactionByID")]
        //public ActionResult<TransactionEntity> GetTransactionByID(int Id)
        //{
        //    return _genericReposity.GetTransactionByID(Id);
        //}
        ////delet transaction
        //[HttpDelete]
        //[Route("DeleteTransactionByID")]
        //public ActionResult<TransactionEntity> DeleteTransactionByID(int Id) { 
        //    return _genericReposity.DeleteTransactionByID(Id);
        //}

        ////update transaction by transaction ID
        //[HttpPut]
        //[Route("UpdateTransactionByID")]
        //public ActionResult<TransactionEntity> UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, TransactionType? newType, DateTime newDataTime)
        //{
        //    _genericReposity.UpdateTransactionByID(idTransaction,newValue,newDescription,newTitle,newType=(newType == null) ? TransactionType.Income : newType ,newDataTime);
        //    return _genericReposity.GetTransactionByID(idTransaction);
        //}

        //[HttpGet]
        //[Route("GetTransactionsByType")]
        //public List<TransactionEntity> GetTransactTypeByUserId(string userId, TransactionType type)
        //{
        //    return _genericReposity.GetTransactTypeByUserId(userId,type);
        //}

    }
}

