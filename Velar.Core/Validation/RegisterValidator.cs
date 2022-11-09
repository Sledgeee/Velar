using FluentValidation;
using Velar.Core.ViewModels;

namespace Velar.Core.Validation
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstNameEmpty")
                .Matches("[a-zA-Zа-яА-Я]").WithMessage("FirstNameMatches");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastNameEmpty")
                .Matches("[a-zA-Zа-яА-Я]").WithMessage("LastNameMatches");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("EmailEmpty")
                .EmailAddress().WithMessage("EmailMatches");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("PhoneEmpty")
                .Matches("[0-9]").WithMessage("PhoneMatches");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("PasswordEmpty")
                .Matches("[0-9a-zA-Z]").WithMessage("PasswordMatches");
            RuleFor(x => x.PasswordRepeat)
                .NotEmpty().WithMessage("PasswordRepeatEmpty") 
                .Equal(x => x.Password).WithMessage("PasswordRepeatFalse");
        }
    }
}