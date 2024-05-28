/// <summary>
/// Unit of Work implementation for coordinating changes across multiple repositories.
/// </summary>
public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private IGenericRepository<User> _UserRepository;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">Database context</param>
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public IGenericRepository<User> UserRepository => _UserRepository ??= new GenericRepository<User>(_context);

    /// <inheritdoc />
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _context.Dispose();
    }
}