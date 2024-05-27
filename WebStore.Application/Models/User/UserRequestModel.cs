/// <summary>
/// Represents a model(DTO) for user registration or update requests.
/// </summary>
/// <param name="UserName">The user's chosen username.</param>
/// <param name="FirstName">The user's first name</param>
/// <param name="LastName">The user's last name</param>
/// <param name="Email">The user's email</param>
/// <param name="Password">The user's password</param>
/// <param name="PhoneNumber">The user's phone number</param>
/// <param name="UserRole">The user's role. Defaults to <see cref="UserRole.User"/>.</param>
public record class UserRequestModel(string UserName, string FirstName, string LastName, string Email, string Password, int PhoneNumber, UserRole UserRole = UserRole.User);