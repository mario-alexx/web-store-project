/// <summary>
/// Represents a model(DTO) for user login credentials.
/// </summary>
/// <param name="Email">The user's email address.</param>
/// <param name="Password">The user's password.</param>
public record class LoginModel(string Email, string Password);