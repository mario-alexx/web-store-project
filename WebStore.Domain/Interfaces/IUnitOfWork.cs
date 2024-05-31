/// <summary>
/// Unit of Work interface for coordinating changes across multiple repositories.
/// </summary>
public interface IUnitOfWork : IDisposable{
    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The number of state entries written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    // Repositories
    IUserRepository Users{ get; }
}