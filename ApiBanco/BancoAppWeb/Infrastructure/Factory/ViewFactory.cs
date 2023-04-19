using AutoMapper;
using BancoAppWeb.Infrastructure.AutoMapper;
using BancoAppWeb.Models.ViewModel;
using User.Data.DTOs;

namespace BancoAppWeb.Factory
{

    public interface IViewFactory
    {
        ViewModelDashboard ViewModelDashboard(DTODashboard dashboard);

    }
        public class ViewFactory : IViewFactory
        {

        private readonly IMapper _mapper;
            public ViewFactory(IMapper mapper)
            {
                _mapper = mapper;
            }



        public ViewModelDashboard ViewModelDashboard(DTODashboard dashboard)
        {

            var dashboardViewModel = _mapper.Map<ViewModelDashboard>(dashboard);
            
            return dashboardViewModel;
        }
    }
    
}
