using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;
using System.Reflection;

namespace ShoeStore.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly ISizeRepository _sizeRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    public ProductService(IProductRepository productRepository, IProductItemRepository productItemRepository,
                            IProductFeatureRepository productFeatureRepository, ISizeRepository sizeRepository
                            , IProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _productItemRepository = productItemRepository;
        _productFeatureRepository = productFeatureRepository;
        _sizeRepository = sizeRepository;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<Product?> GetProductByIdAsync(int Id,CancellationToken cancellation)
    {
        return await _productRepository.GetProductByIdAsync(Id,cancellation);
    }


    public async Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _productItemRepository.GetProductItemByIdAsync(Id, cancellation);
    }
    public async Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation)
    {
        var product = await GetProductByIdAsync(productId, cancellation);
        if (product == null) { return null; }
        return new ProductPageDTO()
        {
            ProductId = product.Id,
            Name = product.Name,
            Description = product.Description,
            ProductCategoryId = product.ProductCategoryId,
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            ProductImage = product.ProductImage,
            ProductFeatureDTOs = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId, cancellation),
            SizeDTOs = await _sizeRepository.GetSizeDTOsByProductId(productId, cancellation)
        };
    }


    public async Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId, int count, CancellationToken cancellation)
    {
        return await _productRepository.GetProductPostDTOsByCategoryId(categoryId, count, cancellation);
    }


    public async Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count, CancellationToken cancellation)
    {
        return await _productRepository.GetNewProductDTOs(count, cancellation);
    }


    public async Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count, CancellationToken cancellation)
    {
        return await _productRepository.GetOnSaleProductDTOs(count, cancellation);
    }


    public async Task<(ICollection<ProductPostDTO>?, int TotalCount)> GetProductDTOsAndCountForCategoryPage(int categoryId
        , int pageNumber, string order, CancellationToken cancellation)
    {
        if (pageNumber < 1) pageNumber = 1;

        var isParentCategory = await _productCategoryRepository.IsParentCategory(categoryId, cancellation);

        if (isParentCategory == null) return (null, 0);

        if (isParentCategory == true)
        {
            return await _productRepository.GetProductDTOsAndCountForCategoryPageByParentCategory(categoryId
                    , pageNumber, order, cancellation);
        }
        else
        {
            return await _productRepository.GetProductDTOsAndCountForCategoryPageByChildCategory(categoryId
                    , pageNumber, order, cancellation);
        }
    }

    public async Task<CategoryPageDTO?> GetCategoryPageDTOById(int categoryId, int pageNumber, string order, CancellationToken cancellation)
    {
        var producDTOsAndCount = await GetProductDTOsAndCountForCategoryPage(categoryId, pageNumber, order, cancellation);
        if (producDTOsAndCount.Item1 == null) return null;

        return new CategoryPageDTO()
        {
            ProductPostDTOs = producDTOsAndCount.Item1,
            PageNumber = pageNumber,
            Order = order,
            TotalCount = producDTOsAndCount.TotalCount,
            CategoryId = categoryId,
            CategoryName = await _productCategoryRepository.GetCategoryNameById(categoryId, cancellation)
        };
    }


    public async Task<CategoryPageDTO?> GetCategoryPageDTOByName(string categoryName, int pageNumber, string order, CancellationToken cancellation)
    {
        var categoryId = await _productCategoryRepository.GetProductCategoryIdByNameAsync(categoryName, cancellation);
        if (categoryId == 0) return null;
        return await GetCategoryPageDTOById(categoryId, pageNumber, order, cancellation);
    }


    public async Task<ICollection<ProductListDTO>?> GetProductListDTOs(CancellationToken cancellation)
    {
        return await _productRepository.GetProductListDTOs(cancellation);
    }


    public async Task<int> CreateProduct(CreateProductDTO model, CancellationToken cancellation)
    {
        Product product = new()
        {
            CreateDate = DateTime.Now,
            Name = model.Name,
            ProductCategoryId = model.ProductCategoryId,
            Description = model.Description,
            Price = model.Price,
            DiscountPercentage = model.DiscountPercentage,
        };

        if (model.ProductImageFile != null)
        {
            product.ProductImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.ProductImageFile.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ProductImage", product.ProductImage);
            using (var stream = new FileStream(imagePath, FileMode.Create)) { model.ProductImageFile.CopyTo(stream); }
        }

        _productRepository.AddProduct(product);
        await _productRepository.SaveChangesAsync(cancellation);

        return await _productRepository.GetProductIdByProduct(product, cancellation);
    }


    public async Task<ProductDetailsDTO?> GetProductDetailsDTO(int productId, CancellationToken cancellation)
    {
        return await _productRepository.GetProductDetailsDTO(productId, cancellation);
    }

    public async Task<ICollection<SizeAdminSideDTO>?> GetAvailableSizeDTOs(int productId, CancellationToken cancellation)
    {
        return await _sizeRepository.GetAvailableSizeDTOs(productId, cancellation);
    }


    public async Task<bool> AddProductFeauture(int productId, string featureTitle, string featureDescription, CancellationToken cancellation)
    {
        var productExists = await _productRepository.ProductExistsById(productId, cancellation);
        if (!productExists) return false;
        ProductFeature productFeature = new()
        {
            CreateDate = DateTime.Now,
            FeatureTitle = featureTitle,
            FeatureDescription = featureDescription,
            ProductId = productId,
        };
        _productFeatureRepository.AddProductFeature(productFeature);
        await _productFeatureRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<bool> RemoveProductFeature(int productFeatureId, CancellationToken cancellation)
    {
        var productFeature = await _productFeatureRepository.GetProductFeatureById(productFeatureId, cancellation);
        if (productFeature == null) return false;
        _productFeatureRepository.RemoveProductFeature(productFeature);
        await _productFeatureRepository.SaveChangesAsync(cancellation);
        return true;

    }


    public async Task<bool> AddProductItem(int productId, int sizeId, int count, CancellationToken cancellation)
    {
        var productExists = await _productRepository.ProductExistsById(productId, cancellation);
        if (!productExists) return false;
        ProductItem productItem = new()
        {
            CreateDate = DateTime.Now,
            ProductId = productId,
            SizeId = sizeId,
            Count = count,
        };
        _productItemRepository.AddProductItem(productItem);
        await _productItemRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<bool> RemoveProductItem(int productItemId, CancellationToken cancellation)
    {
        var productItem = await _productItemRepository.GetProductItemByIdAsync(productItemId, cancellation);
        if (productItem == null) return false;
        productItem.IsDelete = true;
        _productItemRepository.UpdateProductItem(productItem);
        await _productItemRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<CreateProductDTO?> GetCreateProductDTOById(int productId, CancellationToken cancellation)
    {
        return await _productRepository.GetCreateProductDTOById(productId, cancellation);
    }


    public async Task<bool> EditProduct(CreateProductDTO productDTO, CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductByIdAsync(productDTO.Id, cancellation);
        if (product == null) return false;

        product.Name = productDTO.Name;
        product.Description = productDTO.Description;
        product.Price = productDTO.Price;
        product.DiscountPercentage = productDTO.DiscountPercentage;
        product.ProductCategoryId = productDTO.ProductCategoryId;
        if (productDTO.ProductImageFile != null)
        {
            product.ProductImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(productDTO.ProductImageFile.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/ProductImage", product.ProductImage);
            using (var stream = new FileStream(imagePath, FileMode.Create)) { productDTO.ProductImageFile.CopyTo(stream); }
        }

        _productRepository.UpdateProduct(product);
        await _productRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<bool> RemoveProductAndItsItemsAndFeatures(int productId, CancellationToken cancellation)
    {
        var product = await _productRepository.GetProductByIdAsync(productId, cancellation);
        if (product == null) return false;
        product.IsDelete = true;
        _productRepository.UpdateProduct(product);

        var productItems = await _productItemRepository.GetListOfProductItemsByProductId(productId, cancellation);
        if (productItems != null)
        {
            foreach (var item in productItems)
            {
                item.IsDelete = true;
                _productItemRepository.UpdateProductItem(item);
            }
        }

        var productFeatures = await _productFeatureRepository.GetProductFeaturesByProductId(productId, cancellation);
        if (productFeatures != null)
        {
            foreach(var item in productFeatures)
            {
                _productFeatureRepository.RemoveProductFeature(item);
            }
        }

        await _productRepository.SaveChangesAsync(cancellation);

        return true;

    }

    public async Task<Product?> GetProductByProductItemId(int id, CancellationToken cancellation)
    {
        return await _productRepository.GetProductByProductItemId(id, cancellation);
    }
}
