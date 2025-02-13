using AutoMapper;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Entity;
using CreditCard.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand
{
    public class CreateTransactionCommand : IRequest<BaseResponse<int>>
    {
        public int CreditCardID { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }

    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, BaseResponse<int>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();
            var transact=mapper.Map<Transactions>(request);
            var result = await unitOfWork.TransactionRepository.RegisterTransactionAsync(transact);

            response.IsSuccess = true;
            response.Message = "Operación exitosa";
            response.Data = result;
            return response;
        }
    }
}
