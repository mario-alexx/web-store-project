/// <summary>
/// Interface representing a generic repository for entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entities managed by the repository.</typeparam>
public interface IGenericRepository<TEntity> where TEntity : class {
    /// <summary>
    /// Asynchronously retrieves all entities of type TEntity.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Asynchronously retrieves an entity of type TEntity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation that returns the entity, or null if not found.</returns>
    Task<TEntity> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new entity of type TEntity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Insert(TEntity entity);

    /// <summary>
    /// Updates an existing entity of type TEntity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Deletes an entity of type TEntity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);
}