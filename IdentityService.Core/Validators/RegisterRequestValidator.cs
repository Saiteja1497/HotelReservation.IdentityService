using FluentValidation;
using IdentityService.Core.DTO;

namespace IdentityService.Core.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(temp=>temp.Email)
                .NotEmpty().WithMessage("Email Can't be blank")
                .EmailAddress().WithMessage("Invalid Email Address format");
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password Can't be blank");
            RuleFor(temp => temp.UserName)
                .NotEmpty().WithMessage("User Name Can't be blank");
            RuleFor(temp => temp.Gender)
                .IsInEnum().WithMessage("Gender must be either Male or Female or Others")
                .NotEmpty().WithMessage("Gender Can't be empty");
                
           
        }
    }
}
