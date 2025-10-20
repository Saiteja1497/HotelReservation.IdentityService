using FluentValidation;
using IdentityService.Core.DTO;

namespace IdentityService.Core.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() {
            RuleFor(temp=>temp.Email)
                .NotEmpty().WithMessage("Email Can't be empty")                
                .EmailAddress().WithMessage("Invalid Email Address format");
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password Can't be empty");
                
        }

    }
}
