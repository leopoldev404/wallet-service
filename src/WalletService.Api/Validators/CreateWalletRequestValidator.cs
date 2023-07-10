using FluentValidation;
using WalletService.Api.Requests;

namespace WalletService.Api.Validators
{
    public class CreateWalletRequestValidator : AbstractValidator<CreateWalletRequest>
    {
        public CreateWalletRequestValidator()
        {
            RuleFor(wallet => wallet.Name).NotNull().NotEmpty();

            RuleFor(wallet => wallet.Currency)
                .NotEmpty().NotNull().Length(3)
                .Must(x => x == "USD" || x == "EUR")
                .WithMessage("Currency must be either USD or EUR");
        }
    }
}