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
    /// <param name="userId">The ID of the user.</param>
    /// <returns>The user entity.</returns>
    Task<User> GetUserByIdAsync(int userId);
}