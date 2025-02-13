using AutoMapper;
using CreditCard.Models.DTOs;
using CreditCard.Models.ViewModel;

namespace CreditCard.Mappings
{

        public class AutomapperProfile : Profile
        {
            public AutomapperProfile()
            {
             CreateMap<CreateTransactionViewModel, CreateTransaction>().ReverseMap();

            }
        }
 }

