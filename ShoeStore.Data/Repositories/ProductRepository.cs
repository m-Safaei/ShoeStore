using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShoeStoreDbContext _context;
    public ProductRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public async Task<List<Product>> GetListOfProductsAsync(CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> !p.IsDelete).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int Id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task<Product?> GetProductByIdAsync(int Id,CancellationToken cancellation)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId,int count , CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> p.ProductCategoryId == categoryId && !p.IsDelete)
            .Select(p=> new ProductPostDTO() { ProductId=p.Id, Name=p.Name,Price=p.Price,DiscountPercentage = p.DiscountPercentage,ProductImage=p.ProductImage})
            .Take(count).ToListAsync(cancellation);

    }

    public async Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count,CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> !p.IsDelete).OrderByDescending(p=> p.Id).Take(count)
            .Select(p=> new ProductPostDTO() { ProductId=p.Id,DiscountPercentage=p.DiscountPercentage,Name=p.Name,Price=p.Price,ProductImage=p.ProductImage})
            .ToListAsync(cancellation);
    }

    public async Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count,CancellationToken cancellation)
    {
        return await _context.Products.Where(p => !p.IsDelete && p.DiscountPercentage > 0)
            .Take(count).Select(p=>new ProductPostDTO() { ProductId=p.Id,Name=p.Name,ProductImage=p.ProductImage,Price=p.Price,DiscountPercentage=p.DiscountPercentage})
            .ToListAsync(cancellation);
    }


    public async Task<(ICollection<ProductPostDTO>?, int TotalCount)> GetProductDTOsAndCountForCategoryPageByChildCategory(int childCategoryId
        ,int pageNumber,string order,CancellationToken cancellation)
    {
        var products = _context.Products.Where(p => p.ProductCategoryId == childCategoryId && !p.IsDelete)
            .AsQueryable();

        switch (order)
        {
            case "New":
                products = products.OrderByDescending(p => p.Id).AsQueryable();
                break;
            case "Cheap":
                products = products.OrderBy(p=> p.Price).AsQueryable();
                break;
            case "Expensive":
                products = products.OrderByDescending(p => p.Price).AsQueryable();
                break;
            default: break;
        }

        int totalCount = await products.CountAsync();

        return (await products.Skip((pageNumber - 1) * 12).Take(12)
            .Select(p=> new ProductPostDTO() { ProductId=p.Id,Name=p.Name,ProductImage=p.ProductImage,Price=p.Price,DiscountPercentage=p.DiscountPercentage})
            .ToListAsync(cancellation),totalCount);

    }



    public async Task<(ICollection<ProductPostDTO>?,int TotalCount)> GetProductDTOsAndCountForCategoryPageByParentCategory(int parentCategoryId
        , int pageNumber, string order, CancellationToken cancellation)
    {
        var childCategoryIds = await _context.ProductCategories.Where(p => p.ParentId == parentCategoryId && !p.IsDelete)
            .Select(p => p.Id).ToListAsync(cancellation);

        var products = _context.Products.Where(p => childCategoryIds.Contains(p.ProductCategoryId)  && !p.IsDelete)
            .AsQueryable();

        switch (order)
        {
            case "New":
                products = products.OrderByDescending(p => p.Id).AsQueryable();
                break;
            case "Cheap":
                products = products.OrderBy(p => p.Price).AsQueryable();
                break;
            case "Expensive":
                products = products.OrderByDescending(p => p.Price).AsQueryable();
                break;
            default: break;
        }

        int totalCount = await products.CountAsync(cancellation);

        return (await products.Skip((pageNumber - 1) * 12).Take(12)
            .Select(p => new ProductPostDTO() { ProductId = p.Id, Name = p.Name, ProductImage = p.ProductImage, Price = p.Price, DiscountPercentage = p.DiscountPercentage })
            .ToListAsync(cancellation),totalCount);
    }


    public async Task<ICollection<ProductListDTO>?> GetProductListDTOs(CancellationToken cancellation)
    {
        return await _context.Products.Where(p => !p.IsDelete)
            .Select(p => new ProductListDTO() { ProductId = p.Id, Name = p.Name, Price = p.Price, DiscountPercentage = p.DiscountPercentage, ProductCategoryName = p.ProductCategory.Title, ProductImage=p.ProductImage })
            .ToListAsync(cancellation);
    }


    public async Task<int> GetProductIdByProduct(Product product, CancellationToken cancellation)
    {
        return await _context.Products.Where(p => p.Name == product.Name && p.CreateDate == product.CreateDate && !p.IsDelete).Select(p=> p.Id).SingleOrDefaultAsync();
    }


    public async Task<ProductDetailsDTO?> GetProductDetailsDTO(int productId, CancellationToken cancellation)
    {
        var model = await _context.Products.Where(p => p.Id == productId && !p.IsDelete)
            .Select(p => new ProductDetailsDTO() { ProductId = p.Id, ProductName = p.Name, Description = p.Description, Price = p.Price, DiscountPercentage = p.DiscountPercentage, ProductCategoryId = p.ProductCategoryId, ProductCategoryName = p.ProductCategory.Title, ProductImage = p.ProductImage, })
            .SingleOrDefaultAsync(cancellation);

        if(model == null) { return null; }

        model.ProductItemDTOs = await _context.ProductItems.Where(p => p.ProductId == model.ProductId && !p.IsDelete)
            .Select(p=> new ProductItemAdminSideDTO() { Id=p.Id,Count=p.Count,ProductId=p.ProductId,SizeId=p.SizeId, SizeNumber = p.Size.SizeNumber})
            .ToListAsync(cancellation);
        model.ProductFeatureDTOs = await _context.ProductFeatures.Where(p => p.ProductId == model.ProductId)
            .Select(p => new ProductFeatureAdminSideDTO() { Id = p.Id, FeatureTitle = p.FeatureTitle, FeatureDescription = p.FeatureDescription, ProductId = p.ProductId })
            .ToListAsync(cancellation);

        return model;
    }


    public async Task<bool> ProductExistsById(int productId,CancellationToken cancellation)
    {
        return await _context.Products.Where(p => p.Id == productId && !p.IsDelete).SingleOrDefaultAsync(cancellation) != null;
    }


    public async Task<CreateProductDTO?> GetCreateProductDTOById(int productId,CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> p.Id==productId && !p.IsDelete)
            .Select(p=> new CreateProductDTO() { Id=p.Id,Name=p.Name,OldProductImage=p.ProductImage,ProductCategoryId=p.ProductCategoryId,Price=p.Price,DiscountPercentage=p.DiscountPercentage,Description=p.Description})
            .SingleOrDefaultAsync(cancellation);
    }
}
