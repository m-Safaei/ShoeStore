using Microsoft.EntityFrameworkCore;
using ShoeStore.Domain.Entities.ProductCategory;
using ShoeStore.Domain.Entities.Color_Size;

using ShoeStore.Domain.Entities.Order;

using ShoeStore.Domain.Entities.ContactUs;

using ShoeStore.Domain.Entities.Product;
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
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> orderItems { get; set; }

    public DbSet<ContactUs> ContactUs { get; set; } 

    

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

