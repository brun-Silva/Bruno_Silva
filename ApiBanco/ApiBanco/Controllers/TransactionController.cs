using ApiBanco.Bussines.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Infrastructure.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;

namespace ApiBanco.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //add transaction
        [Route("addtransaction")]
        [HttpPost]
        public ActionResult<bool> AddTransaction([FromBody]DTOAddTransaction transaction) => _transactionService.AddTransaction(transaction);   

        //gettransactions
        [Route("gettransactionsbyuid/{uid}/{transactiontype}")]
        [HttpGet]
        public List<DTOTransaction> GetTransactionsByUID( string uid, TransactionType transactiontype) => _transactionService.GetTransactionsByUID(uid, transactiontype);   

        //gettransaction
        [Route("gettransactionbyid/{id}")]
        [HttpGet]
        public DTOTransaction GetTransactionByID(int id) => _transactionService.GetTransactionByID(id);

        //DELET TRANSACTION 
        [Route("deletetransactionbyid")]
        [HttpDelete]
        public bool DeleteTransactionbyId( int id) => _transactionService.DeleteTransactionbyId(id);
        //Update transaction
        [HttpPut]
        [Route("updatetransactionbyid")]
        public bool UpdateTransactionById( DTOEditTransaction transactDTO) => _transactionService.UpdateTransactionById(transactDTO);

    }
}


