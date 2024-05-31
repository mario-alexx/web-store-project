/// <summary>
/// Interface for user repository.
/// </summary>
public interface IUserRepository : IGenericRepository<User> {
    /// <summary>
    /// Gets a user by email.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <returns>The user entity.</returns>
    Task<User> GetUserByEmailAsync(string email);
    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    /// <param name="Id">The ID of the user.</param>
    /// <returns>The user entity.</returns>
    Task<User> GetUserByIdAsync(int Id);

    /// <summary>
    /// Checks if an email already exists.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <returns>True if the email exists, otherwise false.</returns>
    Task<bool> EmailExistAsync(string email);
}