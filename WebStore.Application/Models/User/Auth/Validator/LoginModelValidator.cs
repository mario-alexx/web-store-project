using FluentValidation;

/// <summary>
/// Validator for login model(DTO).
/// </summary>
public class LoginModelValidator : AbstractValidator<LoginModel> {

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginModelValidator"/> class.
    /// </summary>
    public LoginModelValidator()
    {
        RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
        RuleFor(p => p.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
}