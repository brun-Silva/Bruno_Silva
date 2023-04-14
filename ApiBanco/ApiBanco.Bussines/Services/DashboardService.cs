using System.Runtime.InteropServices;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Factory;
using User.Data.Interface;
using User.Data.Models;

namespace ApiBanco.Bussines.Services
{

    public interface IDashboardService
    {
        DTODashboard GetDashboardByUserId(string userId, TimeFrame timeFrame);
    }

    public class DashboardService : IDashboardService
    {


        private readonly IGenericRepository<AccountEntity> _AccountRepo;
        private readonly IGenericRepository<TransactionEntity> _TransactionRepo;
        private readonly IDTOFactory _dtoFactory;

        public DashboardService(IGenericRepository<AccountEntity> AccountRepository, IGenericRepository<TransactionEntity> TransactionRepository, IDTOFactory DTOFac)
        {
            _AccountRepo = AccountRepository;
            _TransactionRepo = TransactionRepository;
            _dtoFactory = DTOFac;

        }

        public DTODashboard GetDashboardByUserId(string userId, TimeFrame timeFrame)
        {
            var account = _AccountRepo.FindByUserId(userId);
            var transaction = _TransactionRepo.FindByUserIdAndTimeframe(userId, timeFrame);

            return _dtoFactory.GetDashboardDTO(account, transaction);
        }
    }
}