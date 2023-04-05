using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;
using User.Data.Interface;

namespace User.Data.Repository
{
    public class TransactionRepository : ITransaction
    {

        List<Transaction> lisTransact = new List<Transaction>
        {
            new Transaction{Id = 0, Value=100,Title="Transf 0",Description = "test",Type = "income", DateTransaction = new DateTime(), Attachment = "", fkUserID= "bruno@" },
            new Transaction{Id = 1, Value=250,Title="Transf 1",Description = "test1",Type = "expense", DateTransaction = new DateTime(), Attachment = "", fkUserID= "bruno@" },
            new Transaction{Id = 2, Value=100,Title="Transf 2",Description = "test2",Type = "income", DateTransaction = new DateTime(), Attachment = "", fkUserID= "bruno2@" },
            new Transaction{Id = 3, Value=2550,Title="Transf 3",Description = "test3",Type = "income", DateTransaction = new DateTime(), Attachment = "", fkUserID= "bruno@" },
        };

        //getTransac
        public Transaction GetTransactionByID(int id)
        {
            return lisTransact.FirstOrDefault(x => x.Id == id);
        }

        //deleteTransaction
        public Transaction DeleteTransactionByID(int idTransaction)
        {

            lisTransact.Remove(lisTransact.FirstOrDefault(x => x.Id == idTransaction));

            return lisTransact.FirstOrDefault(x => x.Id == idTransaction);
           
        }

        //updateTransac
        public Transaction UpdateTransactionByID(int idTransaction, decimal newValue,string newDescription,string newTitle,string newType ,DateTime newDataTime)
        {
            var transaction = GetTransactionByID(idTransaction);
            transaction.Type = (newType == null) ? transaction.Type : newType;
            transaction.Value = newValue;
            transaction.DateTransaction = newDataTime;
            transaction.Description = newDescription;
            transaction.Title = newTitle;


            //ternario para bypass em exeçoes nullas e permitir modificar apenas os campos que o utilizador quer
            //ternario não esta funcionando


            return transaction;
        }

        //getIncomes expense or all
        public List<Transaction> GetTransactTypeByUserId(string userId, string type) 
        {
            List<Transaction> transactionSearch = new List<Transaction>();
            foreach (var transact in lisTransact)
            {
             
                if (transact.Type == type & transact.fkUserID == userId)
                {
                    transactionSearch.Add(transact);
                }
                else if (type.ToUpper() == "ALL" & transact.fkUserID == userId){
                    transactionSearch.Add(transact);
                }

            }
            return transactionSearch;
        }

    }
}