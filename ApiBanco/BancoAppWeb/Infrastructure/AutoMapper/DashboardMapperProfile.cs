using AutoMapper;
using BancoAppWeb.Models.ViewModel;
using User.Data.DTOs;

namespace BancoAppWeb.Infrastructure.AutoMapper
{
    public class DashboardMapperProfile : Profile
    {
        public DashboardMapperProfile() 
        {
            CreateMap<DTODashboard, ViewModelDashboard>()
                .ForMember(dtodash => dtodash.LastTransac, viewmodels => viewmodels.MapFrom(viewmodel => viewmodel.LastTransac))
                .ForMember(dtodash => dtodash.timeFrameTransaction, viewmodels => viewmodels.MapFrom(viewmodel => viewmodel.timeFrameTransaction))
                .ReverseMap();
        }


    }

}
