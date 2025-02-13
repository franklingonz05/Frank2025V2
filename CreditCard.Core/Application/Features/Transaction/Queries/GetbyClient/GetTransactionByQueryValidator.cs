using CreditCard.Core.Application.Features.AccountStatements.Queries.GetById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.Transaction.Queries.GetbyClient
{

    public class GetTransactionByQueryValidator : AbstractValidator<GetTransactionByQuery>
    {

        public GetTransactionByQueryValidator()
        {
            RuleFor(x => x.CardNumber)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio Test.");
        }

    }
}
