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

namespace CreditCard.Core.Application.Features.AccountStatements.Queries.GetById
{
    public class GetAccountStatementByIdQuery : IRequest<BaseResponse<AccountStatementDTO>>
    {
        public string CardNumber { get; set; }
    }

    public class GetAccountStatementByIdQueryHandler : IRequestHandler<GetAccountStatementByIdQuery, BaseResponse<AccountStatementDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAccountStatementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<AccountStatementDTO>> Handle(GetAccountStatementByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AccountStatementDTO>();          
            var accountStatements = await unitOfWork.AccountStatementRepository.GetAccountStatementByIdAsync(request.CardNumber);

            if (accountStatements == null)
            {
                throw new BusinessException("no se encuentran estados de cuenta");
            }

            // Mapear las entidades a DTOs
            response.IsSuccess = true;
            response.Message = "Operación exitosa";
            response.Data = mapper.Map<AccountStatementDTO>(accountStatements);

            return response;
        }
    }
}
