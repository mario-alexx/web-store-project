
using Microsoft.EntityFrameworkCore;

  /// <summary>
/// Represents a generic repository implementation for entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entities managed by the repository.</typeparam>
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Constructor for the GenericRepository class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }


    /// <summary>
    /// Asynchronously retrieves all entities of type TEntity.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a collection of entities.</returns>   
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation that returns the entity, or null if not found.</returns>
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// 
    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>    
    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}