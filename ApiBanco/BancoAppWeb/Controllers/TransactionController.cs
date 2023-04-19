using ApiBanco.Bussines.Services;
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
        public TransactionController(ILogger<DashboardController> logger, ITransactionService transactionService, IViewFactory viewFactory)
        {
            _logger = logger;
            _viewFactory = viewFactory;
            _transactionService = transactionService;
        }

        public IActionResult Index(string UID, TransactionType transactionType)
        {

            var listTransact = _transactionService.GetTransactionsByUID(UID, transactionType);
            var model = new ViewModelTrasaction(listTransact);
            return View("Transaction",model);
        }

        public IActionResult Dashboard()
        {
            return View("Index");
        }
        public IActionResult AddIncome()
        {
            return View("AddIncome");
        }

        public IActionResult AddIncomeTransaction(ViewModelAddTransaction modelAddTransaction)
        {
            modelAddTransaction.userId = "bruno2@";
            modelAddTransaction.Attachment = "string";
            modelAddTransaction.Type = TransactionType.Income;
            var dtotrans = _viewFactory.ViewTransToDTOTransact(modelAddTransaction);
            _transactionService.AddTransaction(dtotrans);

            return RedirectToAction("Index");
        }

        public IActionResult AddTransaction(ViewModelAddTransaction viewModelAdd)
        {
            var viewTranDTO = _viewFactory.ViewTransToDTOTransact(viewModelAdd);
            _transactionService.AddTransaction(viewTranDTO);
            return RedirectToAction("Index");
        }


        public IActionResult AddExpense()
        {
            return View("AddExpense");
        }


        public IActionResult AddExpenseTransaction(ViewModelAddTransaction modelAddTransaction)
        {
            modelAddTransaction.userId = "bruno2@";
            modelAddTransaction.Attachment = "string";
            modelAddTransaction.Type = TransactionType.Expense;
            var dtotrans = _viewFactory.ViewTransToDTOTransact(modelAddTransaction);
            _transactionService.AddTransaction(dtotrans);

            return RedirectToAction("Index");
        }

        public IActionResult EditTransaction(int id)
        {
            return View("EditTransaction",id);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}