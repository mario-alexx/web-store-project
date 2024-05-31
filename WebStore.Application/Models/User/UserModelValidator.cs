using System.Data;
using FluentValidation;

/// <summary>
/// Validator for user model(DTO).
/// </summary>
public class UserModelValidator : AbstractValidator<UserRequestModel> {

    /// <summary>
    /// Initializes a new instance of the <see cref="UserModelValidator"/> class.
    /// </summary>
    public UserModelValidator()
    {
        RuleFor(u => u.UserName).NotEmpty().WithMessage("Username is required.");
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(n => n.PhoneNumber).NotEmpty().MinimumLength(10).WithMessage("Valid phone number is required");
    }
}