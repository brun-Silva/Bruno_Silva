using AutoMapper;
using BancoAppWeb.Models.Shared;
using BancoAppWeb.Models.ViewModel;
using User.Data.DTOs;

namespace BancoAppWeb.Infrastructure.AutoMapper
{
    public class TransactionMapperProfile : Profile
    {
        public TransactionMapperProfile()
        {
            CreateMap<ViewModelAddTransaction, DTOAddTransaction>()
                .ReverseMap();
            CreateMap<ViewModelEditTransaction, DTOEditTransaction>()
            .ForMember(viewmodeledit => viewmodeledit.Id, dtoedit => dtoedit.MapFrom(dtoedit=> dtoedit.Id))
            .ReverseMap();
            CreateMap<ViewModelEditTransaction, DTOTransaction>()
            .ReverseMap();
        }


    }
}
