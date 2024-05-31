using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/// <summary>
/// Represents the database context for the application.
/// </summary>
public class ApplicationDbContext : DbContext{

    private readonly ILogger _logger;

    /// <summary>
    /// Database context for the application, used to interact with the database.
    /// Inherits from DbContext, an Entity Framework Core class that facilitates mapping between objects and database records data.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    /// <param name="logger">Instance of ILogger to log information.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSet's 
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// This method is called when the model for a context is being created. 
    /// It overrides the base implementation to customize the model creation process.
    /// </summary>
    /// <param name="modelBuilder">Provides a simple API to configure the model for a context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Set the UserRole enum as a string in the database
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });
    }

        /// <summary>
        /// Override method for saving changes to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public override int SaveChanges()
        {
            try
            {
                AddAuditoryAttributes();
                var response = base.SaveChanges();
                return response;
            }
            catch (Exception ex)
            {
                this.ChangeTracker.Clear();                
                throw ex;
            }
        }

    /// <summary>
    /// Adds auditory attributes such as created date and status to entities being added to the database.
    /// </summary>
    private void AddAuditoryAttributes()
    {
        // Detects changes in the entities being tracked by the DbContext.
        this.ChangeTracker.DetectChanges();

        // Retrieves entities that are in the Added state.
        var added = this.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added)
                    .Select(e => e.Entity)
                    .ToArray();

        // Iterates through added entities and sets auditory attributes if applicable.
        foreach (var entity in added)
        {
            // Checks if the entity is derived from BaseEntity.
            if (entity is BaseEntity)
            {
                var track = entity as BaseEntity;
                track.CreatedAt = DateTime.Now;
                track.Status = true;
            }
        }
        // Retrieves entities that are in the Modified state.
        var modified = this.ChangeTracker.Entries()
                        .Where(e => e.State == EntityState.Modified)
                        .Select(e => e.Entity)
                        .ToArray();

        // Iterates through modified entities and updates auditory attributes if applicable.
        foreach (var entity in modified)
        {
            // Checks if the entity is derived from BaseEntity.
            if (entity is BaseEntity)
            {
                // Casts the entity to BaseEntity to access its properties.
                var track = entity as BaseEntity;
                track.UpdatedAt = DateTime.UtcNow;
                track.Status = true;
            }
        }
        
    }
}