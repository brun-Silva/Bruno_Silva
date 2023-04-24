using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Data.DTOModel;
using User.Data.DTOs;
using User.Data.Models;

namespace User.Data.Infrastructure.AutoMapper
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<AccountEntity, DTODashboard>()
                .ForMember(accountent => accountent.idUser, dtodash => dtodash.MapFrom(dtodash => dtodash.userId))
                .ForMember(accountent => accountent.Fname, dtodash => dtodash.MapFrom(dtodash => dtodash.FirstName))
                .ForMember(accountent => accountent.Lname,dtodash=>dtodash.MapFrom(dtodash=> dtodash.LastName))
                .ForMember(accountent => accountent.income, dtodash => dtodash.MapFrom(dtodash => dtodash.Income))
                .ForMember(accountent => accountent.expense, dtodash => dtodash.MapFrom(dtodash => dtodash.Expense))
                .ReverseMap();
            CreateMap<TransactionEntity, DTOTransaction>()
                .ReverseMap();
            CreateMap<DTOAccount, AccountEntity>()
                .ForMember(accountent => accountent.userId, dtodash => dtodash.MapFrom(dtodash => dtodash.userId))
                .ForMember(accountent => accountent.FirstName, dtodash => dtodash.MapFrom(dtodash => dtodash.Fname))
                .ForMember(accountent => accountent.LastName, dtodash => dtodash.MapFrom(dtodash => dtodash.Lname))
                .ReverseMap(); 


        }



    }



}
