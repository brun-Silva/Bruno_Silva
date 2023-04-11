using Microsoft.AspNetCore.Mvc;
using User.Data.DTOs;
using User.Data.Factory;
using User.Data.Interface;
using User.Data.Models;
using User.Data.Repository;
using static User.Data.Repository.GenericRepository;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IDTOFactory _dtoFactory;
        
        public DashboardController(IGenericRepository genericRepository, IDTOFactory dtoFactory) 
        { 
            _genericRepository = genericRepository;
            _dtoFactory = dtoFactory;
        }


        //endpoint to search user by ID 
        [HttpGet]
        [Route("getdashboardbyid/{userId}/{timeframe}")]
        public ActionResult<DTODashboard> GetDashBoardByUserId(string? userId, TimeFrame timeframe) 
        {
            //Get account
            var account = _genericRepository.GetUserByID(userId);
            //getTransaction
            var transactions = _genericRepository.GetTransactionByUserIdAndTimeFrame(userId, timeframe);
            //converter em dto
            return _dtoFactory.GetDashboardDTO(account, transactions);
        }



    }
}
