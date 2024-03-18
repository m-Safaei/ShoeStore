using Microsoft.EntityFrameworkCore;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Data.AppDbContext;

public class ShoeStoreDbContext: DbContext
{
    #region Ctor

    public ShoeStoreDbContext(DbContextOptions<ShoeStoreDbContext> options) : base(options)
    {
        
    }

    #endregion

    #region Db Sets

    public DbSet<User> Users { get; set; }

    #endregion

    #region Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);
    }

    #endregion
}

