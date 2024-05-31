using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository implementation for users.
/// </summary>
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<bool> EmailExistAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    /// <inheritdoc />
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    /// <inheritdoc />
    public async Task<User> GetUserByIdAsync(int Id)
    {
        return await _context.Users.FindAsync(Id);
    }
}