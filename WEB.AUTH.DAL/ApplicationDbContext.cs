using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WEB.AUTH.Domain;

namespace WEB.AUTH.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<UserEntity> User { get; set; }
    public  DbSet<PostEntity> Post { get; set; }
}