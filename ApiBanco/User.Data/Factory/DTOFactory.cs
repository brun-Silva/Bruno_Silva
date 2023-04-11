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
    }

    public class DTOFactory : IDTOFactory
    {
        private readonly IGenericRepository _genericReposity;
        private readonly IDTOFactory _DTOFactory;

        public DTODashboard GetDashboardDTO(AccountEntity account, List<TransactionEntity> lisTrans)
        {
            var timeFrameTransactionsDto = lisTrans.Select( t => new DTOTransaction() 
            { 

                fkUserID = t.fkUserID,
                Title = t.Title,
                Attachment = t.Attachment,
                DateTransaction = (DateTime) t.DateTransaction,
                Description = t.Description,
                Type = t.Type,
                Value = (decimal)t.Value,

            }).ToList();
            
            var lastTransactions = lisTrans.OrderByDescending(t => t.DateTransaction).Take(3).Select(t => new DTOTransaction()
            {
                fkUserID = t.fkUserID,
                Title = t.Title,
                Attachment = t.Attachment,
                DateTransaction = (DateTime) t.DateTransaction,
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
                idUser = account.UserId,
                LastTransac = lastTransactions,
                timeFrameTransaction = timeFrameTransactionsDto

            };
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
