using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using User.Data.DTOs;
using User.Data.Models;

namespace User.Data.Infrastructure.AutoMapper
{
    public class TransactionMapperProfile : Profile
    {
        public TransactionMapperProfile()
        {
            CreateMap<TransactionEntity, DTOAddTransaction>()
                .ReverseMap();
        }
    }
}