using Valtegy.Domain.Constants;
using FluentValidation;

namespace Alender.User.Api.Validators.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                        .NotEmpty().WithMessage(ErrorMessage.InputUser.RequiredField)
                        .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
                        .MinimumLength(8).WithMessage(ErrorMessage.InputUser.MinLength8Password)
                        .MaximumLength(30).WithMessage(ErrorMessage.InputUser.MaxLength30Password)
                        .Matches(Regex.PasswordRequired1Digit)
                            .WithMessage(ErrorMessage.InputUser.PasswordRequired1Digit)
                        .Matches(Regex.PasswordRequiredLower)
                            .WithMessage(ErrorMessage.InputUser.PasswordRequiredLower)
                        .Matches(Regex.PasswordRequiredUpper)
                            .WithMessage(ErrorMessage.InputUser.PasswordRequiredUpper)
                        .Matches(Regex.PasswordSpecialCharacter)
                            .WithMessage(ErrorMessage.InputUser.PasswordSpecialCharacter);

            return options;
        }
    }}
