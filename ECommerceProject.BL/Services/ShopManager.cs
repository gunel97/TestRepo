using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.Services
{
    public class ShopManager : IShopService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ShopManager(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<ShopViewModel> GetShopViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync(predicate: x => !x.IsDeleted);
            var products = await _productService.GetAllAsync(predicate: x => !x.IsDeleted
              , include: x => x
              .Include(pv => pv.ProductVariants).ThenInclude(i => i.ProductImages)
              .Include(pv => pv.ProductVariants).ThenInclude(c => c.Color!)
            );
   
            var shopViewModel = new ShopViewModel
            {
                Categories = categories.ToList(),
                Products = products.ToList(),
            };

            return shopViewModel;
        }
    }
}
