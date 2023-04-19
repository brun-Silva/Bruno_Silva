using ApiBanco.Bussines.Services;
using BancoAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Data.Entityes;

namespace BancoAppWeb.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ITransactionService _transactionService;
        public TransactionController(ILogger<DashboardController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View("Transaction");
        }

        public IActionResult Dashboard()
        {
            return View("Index");
        }


        public IActionResult AddIncome()
        {
            return View("AddIncome");
        }

        public IActionResult AddExpense()
        {
            return View("AddExpense");
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