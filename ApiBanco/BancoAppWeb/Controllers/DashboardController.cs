using ApiBanco.Bussines.Services;
using BancoAppWeb.Factory;
using BancoAppWeb.Models;
using BancoAppWeb.Models.Shared;
using BancoAppWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Diagnostics;
using User.Data.DTOModel;
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



        public IActionResult Login()
        {

            return View("Login");
        }

        public IActionResult Loginfinal(ViewModelLogin login)
        {

            var user = _dashboardService.GetDashboardByUserId(login.idUser, TimeFrame.Weekly);

            if (user.idUser == "empty")
            {
                _dashboardService.AddUser(new DTOAccount
                {
                    userId = login.idUser,
                    Fname  = login.fName,
                    Lname = login.lName,
                });

                user = _dashboardService.GetDashboardByUserId(login.idUser, TimeFrame.Weekly);
            }

            return RedirectToAction("Index", new { UID = user.idUser, timeFrame = TimeFrame.Weekly });
        }


        public IActionResult Index(string UID, TimeFrame timeFrame)
        {

           var user = _dashboardService.GetDashboardByUserId(UID, timeFrame);

            var viewuser = _viewFactory.ViewModelDashboard(user);

            return View(viewuser);

        }
        public IActionResult AddTransaction(ViewModelAddTransaction viewModelAdd)
        {
            var viewTranDTO = _viewFactory.ViewTransToDTOTransact(viewModelAdd);
            _transactionService.AddTransaction(viewTranDTO);
            return RedirectToAction("Index", new { uid = viewModelAdd.userId, timeFrame = TimeFrame.Weekly });
        }

        public IActionResult RemoveTransaction(int Id)
        {
            var trasactiondto = _transactionService.GetTransactionByID(Id);
            var uid = trasactiondto.userId;
            _transactionService.DeleteTransactionbyId(Id);

            return RedirectToAction("Index", new { uid = uid, timeFrame = TimeFrame.Weekly });
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}