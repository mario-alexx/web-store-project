using FluentValidation;

/// <summary>
/// Validator for register model(DTO).
/// </summary>
public class RegisterModelValidator : AbstractValidator<RegisterModel> {

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterModelValidator"/> class.
    /// </summary>
    public RegisterModelValidator()
    {
        RuleFor(u => u.UserName).NotEmpty().WithMessage("User name is required.");
        RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required."); 
        RuleFor(p => p.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
}