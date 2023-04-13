using Microsoft.AspNetCore.Mvc;
using User.Data.DTOs;
using User.Data.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Entityes;

namespace ApiBanco.Controllers
{
    public interface IDashboard 
    {
        public DTODashboard GetDashboard(int id, TimeFrame timeFrame);

    }


    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IGenericRepository<AccountEntity> _AccountRepo;
        private readonly IGenericRepository<TransactionEntity> _TransactionRepo;
        private readonly IDTOFactory _dtoFactory;
        
        public DashboardController(IGenericRepository<AccountEntity> AccountRepository, IGenericRepository<TransactionEntity> TransactionRepository) 
        { 
           _AccountRepo = AccountRepository;
           _TransactionRepo = TransactionRepository;


        }

        [Route("getdashboardbyuserid/{userId}")]
        [HttpGet]
        public ActionResult <DTODashboard> GetDashboardByUserId(string userId, TimeFrame timeFrame) 
        { 
            var account = _AccountRepo.FindByUserId(userId);
            var transaction = _TransactionRepo.FindByUserIdAndTimeframe(userId, timeFrame);

            var DTODash = _dtoFactory.GetDashboardDTO(account, transaction);

            return DTODash;
        }







        //[Route("adduser")]
        //[HttpPost]
        //public ActionResult<bool> adduser([FromBody] AccountEntity account)
        //{
        //    //Converter o dto em entidade
        //    AccountEntity accountEntity = new AccountEntity()
        //    {
        //        Id = account.Id,
        //        Balance = account.Balance,
        //        LastName = account.LastName,
        //        userId = account.userId,
        //        Incomes = account.Incomes,
        //        Expense = account.Expense,
        //        Created = account.Created,
        //        Updated = account.Updated,
        //        FirstName = account.FirstName,


        //    };


        //    //Chamar o repositório para adicionar
        //    _AccountRepo.Add(accountEntity);
        //    _AccountRepo.Save();

        //    return true;
        //}




        //public void UpdateTransaction(int id, decimal newValue, string newDescription, string newTitle, TransactionType newType, DateTime newDataTime)
        //{
        //    var transaction = GetByID(id);
        //    transaction.Type = (newType == null) ? transaction.Type : newType;
        //    transaction.Value = (newValue == null) ? transaction.Value : newValue;
        //    transaction.DateTransaction = (newDataTime == null) ? transaction.DateTransaction : newDataTime;
        //    transaction.Description = (newDescription == null) ? transaction.Description : newDescription;
        //    transaction.Title = (newTitle == null) ? transaction.Title : newTitle;
        //    //ternario para bypass em exeçoes nullas e permitir modificar apenas os campos que o utilizador quer
        //}


        //public DashboardController(_Transaction genericRepository, IDTOFactory dtoFactory)
        //{
        //    _genericRepository = genericRepository;
        //    _dtoFactory = dtoFactory;
        //}


        //endpoint to search user by ID 
        //[HttpGet]
        //[Route("getdashboardbyid/{userId}/{timeframe}")]
        //public ActionResult<DTODashboard> GetDashBoardByUserId(string? userId, TimeFrame timeframe) 
        //{
        //    //Get account
        //    var account = _genericRepository.GetUserByID(userId);
        //    //getTransaction
        //    var transactions = _genericRepository.GetTransactionByUserIdAndTimeFrame(userId, timeframe);
        //    //converter em dto
        //    return _dtoFactory.GetDashboardDTO(account, transactions);
        //}



        //public AccountEntity GetUserByID(string? UserId)
        //{

        //    return lisUsers.FirstOrDefault(x => x.UserId == UserId);

        //}

        //public List<TransactionEntity> GetTransactionByUserIdAndTimeFrame(string userId, TimeFrame timeframe)
        //{
        //    //TODO: Filter by range of dates and time frames


        //    return lisTransact.Where(i => i.FkUserID == userId).ToList();
        //}


    }
}
