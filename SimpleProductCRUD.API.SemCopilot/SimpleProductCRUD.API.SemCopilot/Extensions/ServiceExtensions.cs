using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.SemCopilot.Context;
using SimpleProductCRUD.API.SemCopilot.Interfaces;
using SimpleProductCRUD.API.SemCopilot.Mappings;
using SimpleProductCRUD.API.SemCopilot.Repositories;
using SimpleProductCRUD.API.SemCopilot.Services;

namespace SimpleProductCRUD.API.SemCopilot.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddAutoMapper(typeof(EntityToDTOMappingProfile));

        return services;
    }
}