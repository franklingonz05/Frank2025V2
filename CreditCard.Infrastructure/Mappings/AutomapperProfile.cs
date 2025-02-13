using AutoMapper;
using CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand;
using CreditCard.Core.Domain.Dtos;
using CreditCard.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AccountStatement, AccountStatementDTO>().ReverseMap();
            CreateMap<Transactions, TransactionDTO>().ReverseMap();
            CreateMap<Transactions, CreateTransactionCommand>().ReverseMap();
            CreateMap<TransactionView, TransactionDTOList>().ReverseMap();
            CreateMap<CreditCardView, CreditCardDTO>().ReverseMap();


            
        }
    }
}
