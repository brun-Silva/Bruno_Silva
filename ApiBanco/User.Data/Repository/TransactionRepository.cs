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
            new Transaction{Id = 0, Value=0,Title="Teste trans",Description = "test", DateTransaction = new DateTime(), Attachment = "", fkUserID= "bruno@" }
        };




    }
}