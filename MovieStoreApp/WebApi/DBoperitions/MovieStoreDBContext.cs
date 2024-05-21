using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class MovieStoreDBContext : DbContext
{
    public MovieStoreDBContext(DbContextOptions<MovieStoreDBContext> options): base(options)
    {
        
    }
    public DbSet<BaseEntity> baseEntities{ get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Order> Orders { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<BaseEntity>().UseTpcMappingStrategy();
    }

}