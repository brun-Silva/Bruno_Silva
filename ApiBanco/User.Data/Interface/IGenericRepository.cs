
using User.Data.Models;
using static User.Data.Repository.GenericRepository;

namespace User.Data.Interface
{
    public interface IGenericRepository 
    {
        //Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense);
        //TransactionEntity GetTransactionByID(int id);
        //TransactionEntity UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, TransactionType newType, DateTime newDateTime);
        //TransactionEntity DeleteTransactionByID(int idTransaction);
        //List<TransactionEntity> GetTransactTypeByUserId(string uid, TransactionType type);
        AccountEntity GetUserByID(string? UserId);
        List <TransactionEntity> GetTransactionByUserIdAndTimeFrame(string  userId, TimeFrame timeframe);


    }
}
