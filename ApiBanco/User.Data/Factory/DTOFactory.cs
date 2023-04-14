using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Interface;
using User.Data.Models;

namespace User.Data.Factory
{
    //dependencies injections 

    public interface IDTOFactory
    {
        DTODashboard GetDashboardDTO(AccountEntity account,List<TransactionEntity> listTrans);
        TransactionEntity CreateTransaction(DTOAddTransaction dtoTransaction);
        List<DTOTransaction> GetIncomesExpensesOrAll(List<TransactionEntity> transactionsbytype, TransactionType transactionType);
    }

    public class DTOFactory : IDTOFactory
    {
        private readonly IDTOFactory _DTOFactory;
        private readonly IGenericRepository<TransactionEntity> _transactionRepository;
        private  IGenericRepository<AccountEntity> _accountRepository;

        public DTOFactory(IGenericRepository<AccountEntity> AccountRepository)
        {
            _accountRepository = AccountRepository;

        }


        //get transaction by type
        public List<DTOTransaction> GetIncomesExpensesOrAll(List<TransactionEntity> alltransactions, TransactionType transactionType)
        {
            List<DTOTransaction> transactionbytype = new List<DTOTransaction>();
            
            foreach (TransactionEntity transaction in alltransactions)
            {
                
                if (transaction.Type == transactionType) 
                {
                    transactionbytype.Add(new DTOTransaction()
                    {
                        Attachment = transaction.Attachment,
                        Created = transaction.Created,
                        Description = transaction.Description,
                        Id = transaction.Id,
                        Title = transaction.Title,
                        Type = transaction.Type,
                        Updated = transaction.Updated,
                        userId =  transaction.userId,
                        Value = transaction.Value,
                    });

                }
                else if (transactionType == TransactionType.all)
                {
                    transactionbytype.Add(new DTOTransaction()
                    {
                        Attachment = transaction.Attachment,
                        Created = transaction.Created,
                        Description = transaction.Description,
                        Id = transaction.Id,
                        Title = transaction.Title,
                        Type = transaction.Type,
                        Updated = transaction.Updated,
                        userId = transaction.userId,
                        Value = transaction.Value,
                    });


                }
            }
            return transactionbytype;

        }
        //getDashboard
        public DTODashboard GetDashboardDTO(AccountEntity account, List<TransactionEntity> lisTrans)
        {
            var timeFrameTransactionsDto = lisTrans.Select(t => new DTOTransaction()
            {
                Id = t.Id,
                userId = t.userId,
                Title = t.Title,
                Attachment = t.Attachment,
                Created = t.Created,
                Updated = t.Updated,
                Description = t.Description,
                Type = t.Type,
                Value = (decimal)t.Value,

            }).ToList();

            var lastTransactions = lisTrans.OrderByDescending(t => t.Created).Take(3).Select(t => new DTOTransaction()
            {
                Id = t.Id,
                userId = t.userId,
                Title = t.Title,
                Attachment = t.Attachment,
                Created = t.Created,
                Updated = t.Updated,
                Description = t.Description,
                Type = t.Type,
                Value = (decimal)t.Value

            }).ToList();


            return new DTODashboard()
            {

                income = account.Income,
                expense = account.Expense,
                balance = account.Income - account.Expense,
                Fname = account.FirstName,
                Lname = account.LastName,
                idUser = account.userId,
                LastTransac = lastTransactions,
                timeFrameTransaction = timeFrameTransactionsDto

            };
        }
        //create transaction
        public TransactionEntity CreateTransaction(DTOAddTransaction dtoTransaction)
        {
            var transaction = new TransactionEntity()
            {
                userId = dtoTransaction.userId,
                Title = dtoTransaction.Title,
                Value = dtoTransaction.Value,
                Description = dtoTransaction.Description,
                Type = dtoTransaction.Type,
                Attachment = dtoTransaction.Attachment,

            };

            var user = _accountRepository.FindByUserId(transaction.userId);

            if (user == null)
            {
                user = new AccountEntity()
                {

                    Expense = 0,
                    FirstName = "new",
                    Income = 0,
                    LastName = "user",
                    userId = transaction.userId,
                };

                _accountRepository.Add(user);
                _accountRepository.Save();
            }

            if (transaction.Type == TransactionType.Expense)
            {
                user.Expense += transaction.Value;
            }
            else if (transaction.Type == TransactionType.Income)
            {
                user.Income += transaction.Value;
            }
            _accountRepository.Update(user);
            _accountRepository.Save();
            return transaction;
        }
    }
}
