/// <summary>
/// Represents a model(DTO) for user response data.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="UserName">The user's chosen username.</param>
/// <param name="FirstName">The user's first name</param>
/// <param name="LastName">The user's last name</param>
/// <param name="Email">The user's email</param>
/// <param name="PhoneNumber">The user's phone number</param>
/// <param name="UserRole">The user's role. Defaults to <see cref="UserRole.User"/>.</param>
public record class UserResponseModel(int Id, string UserName, string? FirstName, string? LastName, string Email, string? PhoneNumber, UserRole UserRole = UserRole.User);