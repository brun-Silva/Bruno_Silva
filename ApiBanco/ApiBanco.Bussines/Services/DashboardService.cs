using AutoMapper;
using System.Runtime.InteropServices;
using User.Data.DTOModel;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Infrastructure.Factory;
using User.Data.Interface;
using User.Data.Models;

namespace ApiBanco.Bussines.Services
{

    public interface IDashboardService
    {
        DTODashboard GetDashboardByUserId(string userId, TimeFrame timeFrame);
        bool AddUser(DTOAccount newaccount);

    }

    public class DashboardService : IDashboardService
    {


        private readonly IGenericRepository<AccountEntity> _AccountRepo;
        private readonly IGenericRepository<TransactionEntity> _TransactionRepo;
        private readonly IDTOFactory _dtoFactory;
        private readonly IMapper _mapper;

        public DashboardService(IGenericRepository<AccountEntity> AccountRepository, IGenericRepository<TransactionEntity> TransactionRepository, IDTOFactory DTOFac, IMapper mapper)
        {
            _AccountRepo = AccountRepository;
            _TransactionRepo = TransactionRepository;
            _dtoFactory = DTOFac;
            _mapper = mapper;

        }

        public DTODashboard GetDashboardByUserId(string userId, TimeFrame timeFrame)
        {
            var account = _AccountRepo.FindByUserId(userId);
            var transaction = _TransactionRepo.FindByUserIdAndTimeframe(userId, timeFrame);

            return _dtoFactory.GetDashboardDTO(account, transaction);
        }

        public bool AddUser(DTOAccount newaccount)
        {

            AccountEntity accountEntity =  _mapper.Map<AccountEntity>(newaccount);
            _AccountRepo.Add(accountEntity);
            _AccountRepo.Save();


            return true;
        }
    }
}