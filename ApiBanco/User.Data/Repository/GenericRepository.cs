using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Interface;
using User.Data.Models;

namespace User.Data.Repository
{
    public class GenericRepository : IGenericRepository
    {


        public enum TimeFrame
        {
            Weekly = 0,
            Monthly = 1,
            Anualy = 2,
        }



        List<TransactionEntity> lisTransact = new List<TransactionEntity>
        {
            new TransactionEntity{id = 0, Value=100,Title="Transfe 0",Description = "test", Type = TransactionType.Income , DateTransaction = new DateTime(2023, 01, 04), Attachment = "", fkUserID= "bruno@" },
            new TransactionEntity{id = 1, Value=250,Title="Transf 1",Description = "test1", Type = TransactionType.Income, DateTransaction = new DateTime(2023, 04, 01), Attachment = "", fkUserID= "bruno@" },
            new TransactionEntity{id = 2, Value=100,Title="Transf 2",Description = "test2", Type = TransactionType.Income, DateTransaction = new DateTime(2023, 04, 09), Attachment = "", fkUserID= "bruno@" },
            new TransactionEntity{id = 3, Value=2550,Title="Transf 3",Description = "test3", Type = TransactionType.Expense, DateTransaction = new DateTime(2023,04,10), Attachment = "", fkUserID= "bruno@" },
        };

        List<AccountEntity> lisUsers = new List<AccountEntity>
        {
            new AccountEntity{id= 0, UserId="bruno@",Balance=0.0m,FirstName ="Bruno",LastName="Silva",Incomes=0.0m,Expense=.0m}

        };


        //getTransac
        //public TransactionEntity GetTransactionByID(int id)
        //{
        //    return lisTransact.FirstOrDefault(x => x.id == id);
        //}

        ////deleteTransaction
        //public TransactionEntity DeleteTransactionByID(int idTransaction)
        //{

        //    lisTransact.Remove(lisTransact.FirstOrDefault(x => x.id == idTransaction));

        //    return lisTransact.FirstOrDefault(x => x.id == idTransaction);

        //}

        ////updateTransac
        //public TransactionEntity UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, TransactionType newType, DateTime newDataTime)
        //{
        //    var transaction = GetTransactionByID(idTransaction);
        //    transaction.Type = (newType == null) ? transaction.Type : newType;
        //    transaction.Value = (newValue == null) ? transaction.Value : newValue;
        //    transaction.DateTransaction = (newDataTime == null) ? transaction.DateTransaction : newDataTime;  
        //    transaction.Description = (newDescription == null) ? transaction.Description : newDescription; 
        //    transaction.Title = (newTitle == null) ? transaction.Title : newTitle;  


        //    //ternario para bypass em exeçoes nullas e permitir modificar apenas os campos que o utilizador quer
        //    //ternario não esta funcionando


        //    return transaction;
        //}

        ////getIncomes expense or all
        //public List<TransactionEntity> GetTransactTypeByUserId(string userId,  TransactionType type)
        //{
        //    List<TransactionEntity> transactionSearch = new List<TransactionEntity>();
        //    foreach (var transact in lisTransact)
        //    {

        //        if (transact.Type == type & transact.fkUserID == userId)
        //        {
        //            transactionSearch.Add(transact);
        //        }
        //        else if (type == (TransactionType.all) & transact.fkUserID == userId)
        //        {
        //            transactionSearch.Add(transact);
        //        }

        //    }
        //    return transactionSearch;
        //}


        //Func to search user in the list "lisUsers"
        public AccountEntity GetUserByID( string? UserId)
        {   

                return lisUsers.FirstOrDefault(x => x.UserId == UserId);
           
        }

        public List<TransactionEntity> GetTransactionByUserIdAndTimeFrame(string userId, TimeFrame timeframe)
        {
            //TODO: Filter by range of dates and time frames


            return lisTransact.Where(i => i.fkUserID == userId).ToList();
        }

   





        //public Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense)
        //{
        //    var user = GetUserByID(id);
        //    return user;
        //}

    }



}

