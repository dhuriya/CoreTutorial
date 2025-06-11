using FluentValidation;

namespace CoreActionResult.Models
{
    public class RegistrationValidator:AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").
                Length(5, 30).WithMessage("Username must be between 5 and 30 characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("Valid Email Addresss is required.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is Required.")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");
        }
    }
}
