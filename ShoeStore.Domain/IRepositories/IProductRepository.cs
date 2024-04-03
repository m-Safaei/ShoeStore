using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.IRepositories;

public interface IProductRepository
{
    Task<List<Product>> GetListOfProductsAsync(CancellationToken cancellation);
    Task<Product?> GetProductByIdAsync(int Id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    Task SaveChangesAsync(CancellationToken cancellation);
}
