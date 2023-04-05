using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.Models;

namespace User.Data.Interface
{
    public interface ITransaction
    {

        Transaction GetTransactionByID(int Id);
        Transaction UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, string newType, DateTime  newDateTime);
        Transaction DeleteTransactionByID(int idTransaction);
        List <Transaction> GetTransactTypeByUserId(string uid, string type);
    }
}
