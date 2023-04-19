using Microsoft.AspNetCore.Mvc;
using User.Data.DTOs;
using User.Data.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Entityes;
using ApiBanco.Bussines.Services;

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

    }
}
