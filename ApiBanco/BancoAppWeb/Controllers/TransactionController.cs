using ApiBanco.Bussines.Services;
using AutoMapper;
using BancoAppWeb.Factory;
using BancoAppWeb.Models;
using BancoAppWeb.Models.Shared;
using BancoAppWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Data.DTOs;
using User.Data.Entityes;
using User.Data.Models;

namespace BancoAppWeb.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IViewFactory _viewFactory;
        private readonly IMapper _mapper;
        public TransactionController(ILogger<DashboardController> logger, ITransactionService transactionService, IViewFactory viewFactory, IMapper mapper)
        {
            _logger = logger;
            _viewFactory = viewFactory;
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public IActionResult Index(string UID, TransactionType transactionType)
        {

            var listTransact = _transactionService.GetTransactionsByUID(UID, transactionType);
            var model = new ViewModelTrasaction(listTransact, UID);
            return View("Transaction",model);
        }



        public IActionResult Dashboard()
        {
            return View("Index");
        }
        public IActionResult AddIncome(string uid)
        {
            return View("AddIncome", uid = uid);
        }

        public IActionResult AddIncomeTransaction(ViewModelAddTransaction modelAddTransaction, string uid)
        {
            modelAddTransaction.userId = uid;
            modelAddTransaction.Attachment = "string";
            modelAddTransaction.Type = TransactionType.Income;
            var dtotrans = _viewFactory.ViewTransToDTOTransact(modelAddTransaction);
            _transactionService.AddTransaction(dtotrans);

            return RedirectToAction("Index", new { uid = uid, timeFrame = TimeFrame.Weekly });
        }



        public IActionResult AddExpense(string uid)
        {
            return View("AddExpense", uid);
        }


        public IActionResult AddExpenseTransaction(ViewModelAddTransaction modelAddTransaction, string uid)
        {
            modelAddTransaction.userId = uid;
            modelAddTransaction.Attachment = "string";
            modelAddTransaction.Type = TransactionType.Expense;
            var dtotrans = _viewFactory.ViewTransToDTOTransact(modelAddTransaction);
            _transactionService.AddTransaction(dtotrans);

            return RedirectToAction("Index", new { uid = uid, timeFrame = TimeFrame.Weekly });
        }

        public IActionResult EditTransaction(int modelid)
        {
            var transctDTO = _transactionService.GetTransactionByID(modelid);


            var test = _mapper.Map<ViewModelEditTransaction>(transctDTO);



            return View("EditTransaction", test);
        }
        public IActionResult EditTransactionfinal(ViewModelEditTransaction editTransaction)
        {
            var transctDTO = _mapper.Map<DTOEditTransaction>(editTransaction);
            var transact = _transactionService.GetTransactionByID(editTransaction.Id);
            _transactionService.UpdateTransactionById(transctDTO);


            return RedirectToAction("Index", new { uid = transact.userId, timeFrame = TimeFrame.Weekly } );
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}