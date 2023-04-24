using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Infrastructure.AutoMapper;
using User.Data.Interface;
using User.Data.Models;

namespace User.Data.Infrastructure.Factory
{
    //dependencies injections 

    public interface IDTOFactory
    {
        DTODashboard GetDashboardDTO(AccountEntity account, List<TransactionEntity> listTrans);
        TransactionEntity CreateTransaction(DTOAddTransaction dtoTransaction);
        List<DTOTransaction> GetIncomesExpensesOrAll(List<TransactionEntity> transactionsbytype, TransactionType transactionType);
        DTOTransaction GetTransactionDTO(TransactionEntity transactionToDTO);
    }

    public class DTOFactory : IDTOFactory
    {
        private readonly IDTOFactory _DTOFactory;
        private readonly IGenericRepository<TransactionEntity> _transactionRepository;
        private IGenericRepository<AccountEntity> _accountRepository;
       
        private readonly IMapper _mapper;

        public DTOFactory(IGenericRepository<AccountEntity> AccountRepository, IMapper mapper)
        {
            _accountRepository = AccountRepository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountMapperProfile>();
                cfg.AddProfile<TransactionMapperProfile>();
            });
            mapper = config.CreateMapper();
            _mapper = mapper;
            

        }


        //get transaction by type
        public List<DTOTransaction> GetIncomesExpensesOrAll(List<TransactionEntity> alltransactions, TransactionType transactionType)
        {
            List<DTOTransaction> transactionbytype = new List<DTOTransaction>();

            foreach (TransactionEntity transaction in alltransactions)
            {

                if (transaction.Type == transactionType)
                {
                    var dtotransaction = _mapper.Map<DTOTransaction>(transaction);
                    
                    transactionbytype.Add(dtotransaction);

                }
                else if (transactionType == TransactionType.all)
                {
                    var dtotransaction = _mapper.Map<DTOTransaction>(transaction);

                    transactionbytype.Add(dtotransaction);


                }
            }
            return transactionbytype;

        }
        //getDashboard
        public DTODashboard GetDashboardDTO(AccountEntity account, List<TransactionEntity> lisTrans)
        {


            var timeFrameTransactionsDto = lisTrans.Select(t => 
            
            _mapper.Map<DTOTransaction>(t) ).ToList();

            var lastTransactions = lisTrans.OrderByDescending(t => t.Created).Take(3).Select(t =>

            _mapper.Map<DTOTransaction>(t) ).ToList();

            var dtoreturn = new DTODashboard();

            if (account == null)
            {
                dtoreturn = new DTODashboard()
                {

                    income = 0.0m,
                    expense = 0.0m,
                    balance = 0.0m,
                    Fname = "empty",
                    Lname = "empty",
                    idUser = "empty",
                    LastTransac = new List<DTOTransaction>(),
                    timeFrameTransaction = new List<DTOTransaction>()

                };
            }
            else
            {
                dtoreturn = _mapper.Map<AccountEntity, DTODashboard>(account, new DTODashboard
                {
                    balance = account.Income - account.Expense,
                   timeFrameTransaction = timeFrameTransactionsDto,
                    LastTransac = lastTransactions
                }); ;
            }



            return dtoreturn;
        }
        //create transaction
        public TransactionEntity CreateTransaction(DTOAddTransaction dtoTransaction)
        {


            var transaction = _mapper.Map<TransactionEntity>(dtoTransaction);


            var user = _accountRepository.FindByUserId(transaction.userId);

            if (user == null)
            {
                user = new AccountEntity()
                {

                    Expense = 0,
                    FirstName = "new",
                    Income = 0,
                    LastName = "user",
                    userId = transaction.userId,
                };

                _accountRepository.Add(user);
                _accountRepository.Save();
            }
            if (transaction.Type == TransactionType.Expense)
            {
                user.Expense += transaction.Value;
            }
            else if (transaction.Type == TransactionType.Income)
            {
                user.Income += transaction.Value;
            }
            _accountRepository.Update(user);
            _accountRepository.Save();
            return transaction;
        }

        public DTOTransaction GetTransactionDTO(TransactionEntity transactionToDTO)
        {

            return _mapper.Map<DTOTransaction>(transactionToDTO);
        }


    }
}
