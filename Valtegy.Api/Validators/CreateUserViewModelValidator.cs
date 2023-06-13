using Valtegy.Domain.Constants;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using FluentValidation;
using Alender.User.Api.Validators.Extensions;

namespace Alender.User.Api.Validators
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        private readonly IUsersService _userService;

        public CreateUserViewModelValidator(IUsersService userService)
        {
            _userService = userService;

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(ErrorMessage.InputUser.RequiredField)
                .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
                .MaximumLength(40).WithMessage(ErrorMessage.InputUser.MaxLength40UserName)
                //.EmailAddress().WithMessage(ErrorMessage.InputUser.BadUserName)
                .Custom((value, context) =>
                {
                    if (_userService.ExistsUserName(value))
                    {
                        context.AddFailure(string.Format(ErrorMessage.InputUser.DuplicateUserName, value));
                    }
                });

            //RuleFor(x => x.PhoneNumber)
            //    //.NotEmpty().WithMessage(ErrorMessage.InputUser.RequiredField)
            //    .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
            //    //.Matches(Regex.TenDigits).WithMessage(ErrorMessage.InputUser.Only10DigitsPhoneNumber)
            //    .Custom((value, context) =>
            //    {
            //        if (_userService.ExistsPhoneNumber(value))
            //        {
            //            context.AddFailure(string.Format(ErrorMessage.InputUser.DuplicatePhoneNumber, value));
            //        }
            //    });

            RuleFor(x => x.Password)
                .Password();

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
                .MaximumLength(100).WithMessage(ErrorMessage.InputUser.MaxLength100PeopleName);

            RuleFor(x => x.MiddleName)
                .MaximumLength(100).WithMessage(ErrorMessage.InputUser.MaxLength100PeopleName);

            RuleFor(x => x.LastName1)
                .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField)
                .MaximumLength(100).WithMessage(ErrorMessage.InputUser.MaxLength100PeopleLastName);

            RuleFor(x => x.LastName2)
                .MaximumLength(100).WithMessage(ErrorMessage.InputUser.MaxLength100PeopleLastName);

            RuleFor(x => x.BirthdayDate)
                .NotEmpty().WithMessage(ErrorMessage.InputUser.RequiredField)
                .NotNull().WithMessage(ErrorMessage.InputUser.RequiredField);       
        }
    }
}
