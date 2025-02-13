using AutoMapper;
using CreditCard.Core.Application.Features.Transaction.Queries.GetbyClient;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Dtos;
using CreditCard.Core.Exceptions;
using CreditCard.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.CreditCard.Queries.GetAll
{
    public class GetCreditCardAllQuery : IRequest<BaseResponse<IEnumerable<CreditCardDTO>>>
    {
    }

    public class GetCreditCardAllHandler : IRequestHandler<GetCreditCardAllQuery, BaseResponse<IEnumerable<CreditCardDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCreditCardAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CreditCardDTO>>> Handle(GetCreditCardAllQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<CreditCardDTO>>();

            // Llamar al repositorio para obtener la información de la cuenta
            var result = await unitOfWork.CreditCardRepository.GetCreditCardAsync();

            if (result == null)
            {
                throw new BusinessException("no se encuentran datos");
            }

            // Mapear las entidades a DTOs
            response.IsSuccess = true;
            response.Message = "Operación exitosa";
            response.Data = mapper.Map<IEnumerable<CreditCardDTO>>(result);
            return response;
        }
    }
}
