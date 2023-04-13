using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using User.Data.DTOs;
using User.Data.Interface;
using User.Data.Models;

namespace User.Data.Factory
{
    //dependencies injections 

    public interface IDTOFactory
    {
        DTODashboard GetDashboardDTO(AccountEntity account,List<TransactionEntity> listTrans);
        TransactionEntity CreateTransaction(DTOAddTransaction dtoTransaction);
    }

    public class DTOFactory : IDTOFactory
    {
        private readonly IDTOFactory _DTOFactory;

        public DTODashboard GetDashboardDTO(AccountEntity account, List<TransactionEntity> lisTrans)
        {
            var timeFrameTransactionsDto = lisTrans.Select( t => new DTOTransaction() 
            { 

                userId = t.userId,
                Title = t.Title,
                Attachment = t.Attachment,
                Created = t.Created,
                Description = t.Description,
                Type = t.Type,
                Value = (decimal)t.Value,

            }).ToList();
            
            var lastTransactions = lisTrans.OrderByDescending(t => t.Created).Take(3).Select(t => new DTOTransaction()
            {
                userId = t.userId,
                Title = t.Title,
                Attachment = t.Attachment,
                Created = t.Created,
                Description = t.Description,
                Type = t.Type,
                Value = (decimal)t.Value
            }).ToList();

            return new DTODashboard()
            {
                income = account.Incomes,
                expense = account.Expense,
                balance = account.Incomes - account.Expense,
                Fname = account.FirstName,
                Lname = account.LastName,
                idUser = account.userId,
                LastTransac = lastTransactions,
                timeFrameTransaction = timeFrameTransactionsDto

            };
        }




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
            return transaction;
        }




        //public string idUser { get; set; }
        //public string Fname { get; set; }
        //public string Lname { get; set; }
        //public decimal income { get; set; }
        //public decimal expense { get; set; }
        //public decimal balance { get; set; }
        //public List<DTOTransaction> LastTransac { get; set; }
        //public List<DTOTransaction> timeFrameTransaction { get; set; }








    }
}
