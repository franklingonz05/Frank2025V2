using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.Description)
             .NotEmpty().WithMessage("{PropertyName} es obligatorio.")
             .MaximumLength(300).WithMessage("{PropertyName} no debe exceder {MaxLength} caracteres.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("{PropertyName} es obligatorio.");
    
        }
    }
}
