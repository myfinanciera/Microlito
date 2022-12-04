using FluentValidation;
using Siigo.Microservice.Application.Commands.Bank;

namespace Siigo.Microservice.Application.Commands.Bank.Validators
{
    public sealed class BankCommandRequestValidator : AbstractValidator<CreateBankCommandRequest>
    {
        public BankCommandRequestValidator()
        {
            RuleFor(request => request.Bank.Order.idcustomer)
                .NotEmpty()
                .WithMessage("The code must not be empty!");

            RuleFor(request => request.Bank.Order.email)
                .NotEmpty()
                .WithMessage("The name must not be empty");
        }
    }
}

