using Microsoft.EntityFrameworkCore;
using WEB.AUTH.Domain;
using WEB.AUTH.Domain.DTO;

namespace WEB.AUTH.DAL;

public class ApplicationBdContext : DbContext
{
    public ApplicationBdContext(DbContextOptions<ApplicationBdContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<UserEntity> User { get; set; }
}