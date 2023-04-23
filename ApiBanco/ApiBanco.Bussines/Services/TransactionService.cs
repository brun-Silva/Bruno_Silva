using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using User.Data.DTOs;
using User.Data.Infrastructure.Factory;
using User.Data.Interface;
using User.Data.Models;

namespace ApiBanco.Bussines.Services
{
    public interface ITransactionService
    {
        bool AddTransaction(DTOAddTransaction transaction);
        List<DTOTransaction> GetTransactionsByUID(string uid, TransactionType transactiontype);
        DTOTransaction GetTransactionByID(int id);
        bool DeleteTransactionbyId(int id);
        bool UpdateTransactionById(DTOEditTransaction transactDTO);

    }
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<TransactionEntity> _transactionReposity;
        private readonly IGenericRepository<AccountEntity> _accountRepository;
        private readonly IDTOFactory _DTOFactory;
        public readonly IMapper _mapper;

        public TransactionService(IGenericRepository<TransactionEntity> transactionReposity, IDTOFactory DTOFactory, IGenericRepository<AccountEntity> accountRepository, IMapper mapper) 
        {
            _transactionReposity = transactionReposity;
            _DTOFactory = DTOFactory;
            _accountRepository = accountRepository;
            _mapper = mapper;

        }

        //add transaction
        public bool AddTransaction(DTOAddTransaction transaction)
        {
            //Converter o dto em entidade
            TransactionEntity transactionEntity = _DTOFactory.CreateTransaction(transaction);

            //Chamar o repositório para adicionar
            _transactionReposity.Add(transactionEntity);
            _transactionReposity.Save();
            return true;
        }

        //gettransactions
        public List<DTOTransaction> GetTransactionsByUID(string uid, TransactionType transactiontype)
        {
            //Get Incomes Expenses Or All

            List<TransactionEntity> transactionsbytype = new List<TransactionEntity>();
            transactionsbytype = _transactionReposity.FindAListByUserId(uid);

            return _DTOFactory.GetIncomesExpensesOrAll(transactionsbytype, transactiontype);

        }


        //gettransaction
        public DTOTransaction GetTransactionByID(int id)
        {
            //Get one transaction by ID
            var transactEntity = _transactionReposity.FindById(id);
            return _DTOFactory.GetTransactionDTO(transactEntity);

        }


        //DELET TRANSACTION 
        public bool DeleteTransactionbyId(int id)

        {
            var transact = _transactionReposity.FindById(id);
            var value = transact.Value;
            var uid = transact.userId;
            var boo = false;
            try
            {
                _transactionReposity.Delete(transact);
                _transactionReposity.Save();
                boo = true;
            }
            catch (Exception ex)
            {
                boo = false;
            }
            var user = _accountRepository.FindByUserId(uid);

            if (boo == true && transact.Type == TransactionType.Expense)
            {

                user.Expense -= value;
            }
            else if (boo == true && transact.Type == TransactionType.Income)
            {
                user.Income -= value;
            }
            _accountRepository.Update(user);
            _accountRepository.Save();

            return boo;
        }

        //Update transaction
        public bool UpdateTransactionById(DTOEditTransaction transactDTO)
        {
            var transactEntity = _transactionReposity.FindById(transactDTO.Id);
            var boo = false;
            var user = _accountRepository.FindByUserId(transactEntity.userId);
            if (transactEntity != null)
            {
                //atualizando um income, (RECEBENDO $$)
                if (transactEntity.Type == TransactionType.Income)
                {
                    //se o valor for igual, ignora, se for diferente segue
                    if (transactEntity.Value != transactDTO.Value)
                    {
                        //Checar se o valor novo é menor que o antigo
                        if (transactDTO.Value < transactEntity.Value)
                        {
                            var diferenca = transactEntity.Value - transactDTO.Value;
                            user.Income -= diferenca;
                        }
                        //Checar se o valor novo é meaior que o antigo
                        else if (transactDTO.Value > transactEntity.Value)
                        {
                            var diferenca = transactDTO.Value - transactEntity.Value;
                            user.Income += diferenca;
                        }

                    }
                }
                //Atualizando ecspense $$
                else
                {
                    //se o valor for igual, ignora, se for diferente segue
                    if (transactEntity.Value != transactDTO.Value)
                    {
                        //Checar se o valor novo é menor que o antigo
                        if (transactDTO.Value < transactEntity.Value)
                        {
                            var diferenca = transactEntity.Value - transactDTO.Value;
                            user.Expense -= diferenca;
                        }
                        //Checar se o valor novo é meaior que o antigo
                        else
                        {
                            var diferenca = transactDTO.Value - transactEntity.Value;
                            user.Expense += diferenca;
                        }

                    }
                }
                //var newtransact = _mapper.Map<TransactionEntity>(transactDTO);

                transactEntity.Description = transactDTO.Description;
                transactEntity.Value = transactDTO.Value;
                transactEntity.Title = transactDTO.Title;

            }


            _transactionReposity.Update(transactEntity);
            _accountRepository.Update(user);
            _transactionReposity.Save();
            _accountRepository.Save();

            return true;
        }



    }
}
