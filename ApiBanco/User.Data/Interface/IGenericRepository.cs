
using User.Data.Entityes;
using User.Data.Models;


namespace User.Data.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> PrepareQuery();
        TEntity FindById(int id);
        TEntity FindByUserId(string userId);
        List<TEntity> FindAListByUserId(string userId);
        List<TEntity> FindByUserIdAndTimeframe(string userId, TimeFrame timeframe);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        int Save();

        //Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense);
        //TransactionEntity GetTransactionByID(int id);
        //TransactionEntity UpdateTransactionByID(int idTransaction, decimal newValue, string newDescription, string newTitle, TransactionType newType, DateTime newDateTime);
        //TransactionEntity DeleteTransactionByID(int idTransaction);
        //List<TransactionEntity> GetTransactTypeByUserId(string uid, TransactionType type);
        //AccountEntity GetUserByID(string? UserId);
        //List <TransactionEntity> GetTransactionByUserIdAndTimeFrame(string  userId, TimeFrame timeframe);


    }
}
