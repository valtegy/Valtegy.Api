using Valtegy.Domain.Constants;
using Valtegy.Domain.ViewModels;
using FluentValidation;

namespace Valtegy.Api.Validators
{
    public class RequestValidateEmailCodeViewModelValidator : AbstractValidator<RequestValidateEmailCodeViewModel>
    {
        public RequestValidateEmailCodeViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ErrorMessage.InputUser.RequiredField)
                .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
                .EmailAddress().WithMessage(ErrorMessage.InputUser.BadUserName);
        }
    }
}
