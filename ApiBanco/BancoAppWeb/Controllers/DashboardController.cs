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
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService _dashboardService;
        private readonly ITransactionService _transactionService;
        private readonly IViewFactory _viewFactory;
        public DashboardController(ILogger<DashboardController> logger, IDashboardService dashboardService, IViewFactory viewFactory, ITransactionService transactionService)
        {
            _logger = logger;
            _dashboardService = dashboardService;
            _viewFactory = viewFactory;
            _transactionService = transactionService;
        }

        public IActionResult Index(string UID, TimeFrame timeFrame)
        {

           var user = _dashboardService.GetDashboardByUserId(UID, timeFrame);

            if (user.idUser == "empty")
            {
                user = _dashboardService.GetDashboardByUserId("bruno2@", TimeFrame.Weekly);
            }

            var viewuser = _viewFactory.ViewModelDashboard(user);

            return View(viewuser);

        }
        public IActionResult AddTransaction(ViewModelAddTransaction viewModelAdd)
        {
            var viewTranDTO = _viewFactory.ViewTransToDTOTransact(viewModelAdd);
            _transactionService.AddTransaction(viewTranDTO);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveTransaction(int Id)
        {
            _transactionService.DeleteTransactionbyId(Id);

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}