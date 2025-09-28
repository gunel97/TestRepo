using ECommerceProject.DA.DataContext;
using ECommerceProject.DA.DataContext.Repositories;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.DA
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("Default"), options =>
           {
               options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
           }));

            services.AddScoped<DataInitializer>();

            services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>(); 
            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddScoped<IBioRepository, BioRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();

            return services;
        }
    }
}
