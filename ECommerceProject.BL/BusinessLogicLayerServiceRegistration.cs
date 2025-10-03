using ECommerceProject.BL.Mapping;
using ECommerceProject.BL.Services;
using ECommerceProject.BL.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL
{
    public static class BusinessLogicLayerServiceRegistration
    {
        public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
            services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudManager<,,,>));

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductVariantService, ProductVariantManager>();
            services.AddScoped<IBioService, BioManager>();
            services.AddScoped<ISocialService, SocialManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<IAddressService, AddressManager>();
            //services.AddScoped<IAccountService, AccountManager>();
            //services.AddScoped<IWishlistService, WishlistManager>();
            
            services.AddScoped<IHomeService, HomeManager>();
            services.AddScoped<IShopService, ShopManager>();
            services.AddScoped<IHeaderService, HeaderManager>();
            services.AddScoped<IFooterService, FooterManager>();

            services.AddScoped<BasketManager>();

            return services;
        }
    }
}
