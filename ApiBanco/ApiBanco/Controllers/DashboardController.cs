using Microsoft.AspNetCore.Mvc;
using User.Data.DTOs;
using User.Data.Infrastructure.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Entityes;
using ApiBanco.Bussines.Services;
using User.Data.DTOModel;

namespace ApiBanco.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashBoardService;
        
        public DashboardController(IDashboardService dashBoardService) 
        {
            _dashBoardService = dashBoardService;
        }

        [Route("getdashboardbyuserid/{userId}")]
        [HttpGet]
        public ActionResult <DTODashboard> GetDashboardByUserId(string userId, TimeFrame timeFrame) => _dashBoardService.GetDashboardByUserId(userId, timeFrame);


        [Route("adduser")]
        [HttpPost]
        public ActionResult<bool> AddUser([FromBody] DTOAccount account) => _dashBoardService.AddUser(account);

    }
}
