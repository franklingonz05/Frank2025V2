using AutoMapper;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Dtos;
using CreditCard.Core.Exceptions;
using CreditCard.Core.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.Transaction.Queries.GetbyClient
{
    public class GetTransactionByQuery : IRequest<BaseResponse<IEnumerable<TransactionDTOList>>>
    {
        public string CardNumber { get; set; }
    }

    public class GetTransactionByHandler : IRequestHandler<GetTransactionByQuery, BaseResponse<IEnumerable<TransactionDTOList>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetTransactionByHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<TransactionDTOList>>> Handle(GetTransactionByQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<TransactionDTOList>>();

            // Llamar al repositorio para obtener la información de la cuenta
            var result = await unitOfWork.TransactionRepository.GetTransactionsByCardForCurrentMonthAsync(request.CardNumber);

            if (result == null)
            {
                throw new BusinessException("no se encuentran datos");
            }

            // Mapear las entidades a DTOs
            response.IsSuccess = true;
            response.Message = "Operación exitosa";
            response.Data = mapper.Map<IEnumerable<TransactionDTOList>>(result);

            return response;
        }
    }
}
