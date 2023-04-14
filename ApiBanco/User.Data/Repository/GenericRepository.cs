using User.Data.Entityes;
using User.Data.Interface;
using Microsoft.EntityFrameworkCore;


namespace User.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly ApiBancoContext _dbContext;
        protected DbSet<TEntity> Entities  { get; init; }

        public GenericRepository(ApiBancoContext dbcontext)
        { _dbContext = dbcontext; 
          Entities = _dbContext.Set<TEntity>();
        }


        public IQueryable<TEntity> PrepareQuery() =>
            Entities.AsQueryable();

        public TEntity FindById(int id)
            => PrepareQuery().AsNoTracking().SingleOrDefault(x => x.Id == id);

        public TEntity FindByUserId(string userId)
            => PrepareQuery().AsNoTracking().SingleOrDefault(x => x.userId == userId);

        public List<TEntity> FindAListByUserId(string userId)
        {
            return PrepareQuery().AsNoTracking().Where(i => i.userId == userId ).ToList();
        }

        public List<TEntity> FindByUserIdAndTimeframe(string userId, TimeFrame timeframe)
        {
            var dataInicio =  DateTime.Now;
            var dataFim = DateTime.Now;
            if (timeframe == TimeFrame.Weekly)
            {
                dataFim = dataInicio.AddDays(-7);
            }
            else if(timeframe == TimeFrame.Monthly)
            {
                dataFim = dataInicio.AddMonths(-1);
            }
            else
            {
                dataFim = dataInicio.AddYears(-1);
            }


            //TODO: Filter by range of dates and time frames
            return PrepareQuery().AsNoTracking().Where(i => i.userId == userId && i.Created <= dataInicio && i.Created >= dataFim).ToList();
        }


        public void Add(TEntity entity) =>
            Entities.Add(entity);

        public void Delete(TEntity entity) =>
            Entities.Remove(entity);

        public int Save()
            => _dbContext.SaveChanges();
        public void Update(TEntity entity) =>
            Entities.Update(entity);

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

        //public Users UpdateUserByID(string id, decimal balance, decimal income, decimal expense)
        //{
        //    var user = GetUserByID(id);
        //    return user;
        //}


    }
}

