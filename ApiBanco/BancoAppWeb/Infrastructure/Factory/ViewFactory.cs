using AutoMapper;
using BancoAppWeb.Infrastructure.AutoMapper;
using BancoAppWeb.Models.Shared;
using BancoAppWeb.Models.ViewModel;
using User.Data.DTOs;

namespace BancoAppWeb.Factory
{

    public interface IViewFactory
    {
        ViewModelDashboard ViewModelDashboard(DTODashboard dashboard);
        DTOAddTransaction ViewTransToDTOTransact(ViewModelAddTransaction transaction);
        ViewModelTrasaction ViewModelTrasaction(List<DTOTransaction> lisDTOTRansactions);
        ViewModelTrasaction ViewModelEditTransaction(DTOEditTransaction transaction);
    }
        public class ViewFactory : IViewFactory
        {

        private readonly IMapper _mapper;
            public ViewFactory(IMapper mapper)
            {
                _mapper = mapper;
            }

        public DTOAddTransaction ViewTransToDTOTransact(ViewModelAddTransaction transaction)
        {
            var dtoTransaction = _mapper.Map<DTOAddTransaction>(transaction);

            return dtoTransaction;
        }

        public ViewModelDashboard ViewModelDashboard(DTODashboard dashboard)
        {

            var dashboardViewModel = _mapper.Map<ViewModelDashboard>(dashboard);
            
            return dashboardViewModel;
        }

        public ViewModelTrasaction ViewModelTrasaction(List<DTOTransaction> lisDTOTRansactions)
        {
            var transactionview = _mapper.Map<ViewModelTrasaction>(lisDTOTRansactions);
            return transactionview;

        }

        public ViewModelTrasaction ViewModelEditTransaction(DTOEditTransaction dtotransaction)
        {
            var edittransactionView = _mapper.Map<ViewModelTrasaction>(dtotransaction);



            return edittransactionView;

        }



    }
    
}
