/// <summary>
/// Defines an interface for a service that generates tokens.
/// </summary>
public interface ITokenService {
    /// <summary>
    /// Generates a token for a given user.
    /// </summary>
    /// <param name="user">The user for whom to generate the token.</param>
    /// <returns>The generated token as a string.</returns>
    string GenerateToken(User user);
}