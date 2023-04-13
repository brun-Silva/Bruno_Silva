using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using User.Data.DTOs;
using User.Data.Entityes;
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
        private readonly IGenericRepository<TransactionEntity> _transactionReposity;
        private readonly IGenericRepository<AccountEntity> _accountRepository;
        private readonly IDTOFactory _DTOFactory;
        public TransactionController(IGenericRepository<TransactionEntity> transactionReposity, IDTOFactory DTOFactory, IGenericRepository<AccountEntity> accountRepository)
        {
            _transactionReposity = transactionReposity;
            _DTOFactory = DTOFactory;
            _accountRepository = accountRepository;
        }



        //add transaction
        [Route("addtransaction")]
        [HttpPost]
        public ActionResult<bool> AddTransaction([FromBody]DTOAddTransaction transaction)
        {
            //Converter o dto em entidade
            TransactionEntity transactionEntity = _DTOFactory.CreateTransaction(transaction);
            
            //Chamar o repositório para adicionar
            _transactionReposity.Add(transactionEntity);
            _transactionReposity.Save();


            return true;
        }



        //gettransaction
        [Route("gettransactionbytype/{uid}/{transactiontype}")]
        [HttpGet]
        public List<DTOTransaction> GetTransactionByTypeOrAll( string uid, TransactionType transactiontype) 
        {
            //Get Incomes Expenses Or All

            List<TransactionEntity> transactionsbytype = new List<TransactionEntity>();
            transactionsbytype = _transactionReposity.FindAListByUserId(uid);
            
            return _DTOFactory.GetIncomesExpensesOrAll(transactionsbytype, transactiontype);

        }


        //DELET TRANSACTION 
        [Route("deltransactionbyuidid")]
        [HttpDelete]
        public bool DelTransactionbyId( int id)

        {
            var transact = _transactionReposity.FindById(id);
            var value = transact.Value;
            var uid = transact.userId;
            var boo = false;
            try
            {
                _transactionReposity.Delete(transact);
                _transactionReposity.Save();
                 boo = true;
            }
            catch (Exception ex)
            {
                 boo = false;
            }
            var user = _accountRepository.FindByUserId(uid);

            if (boo == true && transact.Type == TransactionType.Expense)
            {
                user.Balance += value;
                user.Expense -= value;
            }
            else if (boo == true && transact.Type == TransactionType.Income)
            {

                user.Balance -= value;
                user.Incomes -= value;
            }

            _accountRepository.Save();
            return boo;
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


