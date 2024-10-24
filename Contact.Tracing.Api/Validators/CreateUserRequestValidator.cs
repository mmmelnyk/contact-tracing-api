using Contact.Tracing.Api.Interaction.Requests;
using FluentValidation;
using System.Text.RegularExpressions;
using Contact.Tracing.Api.Configuration;

namespace Contact.Tracing.Api.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
            .NotNull().WithMessage(Constants.PhoneVerification.PhoneNumberRequired)
            .MinimumLength(10).WithMessage(Constants.PhoneVerification.PhoneNumberMinLength)
            .MaximumLength(20).WithMessage(Constants.PhoneVerification.PhoneNumberMaxLength)
            .Matches(new Regex(Constants.PhoneVerification.PhoneVerificationRegex)).WithMessage(Constants.PhoneVerification.PhoneNumberErrorMsg);
    }
}
