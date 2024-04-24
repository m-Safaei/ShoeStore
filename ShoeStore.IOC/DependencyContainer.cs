using Microsoft.Extensions.DependencyInjection;
using ShoeStore.Application.Services.Implementation;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Data.Repositories;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.IOC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IContactUsRepository, ContactUsRepository>();
        services.AddScoped<IContactUsService, ContactUsService>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductItemRepository, ProductItemRepository>();
        services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IHomeService, HomeService>();

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ISizeService, SizeService>();

        services.AddScoped<IFavoriteProductRepository, FavoriteProductRepository>();
        services.AddScoped<IFavoriteProductService, FavoriteProductService>();
    }
}

