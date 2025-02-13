using CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.AccountStatements.Queries.GetById
{
    public class GetAccountStatementByIdQueryValidator : AbstractValidator<GetAccountStatementByIdQuery>
    {

        public GetAccountStatementByIdQueryValidator()
        {
            RuleFor(x => x.CardNumber)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio Test.");
        }

    }
}
