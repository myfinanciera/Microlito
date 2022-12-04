using FluentValidation;

namespace Siigo.Microservice.Application.Queries.Bank.Validators
{
    public sealed class BankQueryByIdRequestValidator : AbstractValidator<BankQueryByIdRequest>
    {
        public BankQueryByIdRequestValidator()
        {
            RuleFor(request => request.BankId)
                .NotEmpty()
                .NotNull()
                .WithMessage("The BankId must not be empty!");
            
            
        }

       
    }
}