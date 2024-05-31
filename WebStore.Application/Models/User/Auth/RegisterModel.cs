/// <summary>
/// Represents a model(DTO) for register new user.
/// </summary>
/// <param name="UserName">The user's username.</param>
/// <param name="Email">The user's email address.</param>
/// <param name="Password">The user's password.</param>
public record class RegisterModel(string UserName, string Email, string Password);