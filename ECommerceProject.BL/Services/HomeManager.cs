using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.Services
{
    public class HomeManager : IHomeService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeManager(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

 
        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync(predicate:x=>!x.IsDeleted);
            var products = await _productService.GetAllAsync(predicate: x => !x.IsDeleted
              , include: x => x
              .Include(pv => pv.ProductVariants).ThenInclude(i => i.ProductImages)
              .Include(pv => pv.ProductVariants).ThenInclude(c => c.Color!)
            );

            var homeViewModel = new HomeViewModel
            {
                Categories = categories.ToList(),
                Products = products.ToList(),
            };

            return homeViewModel;
        }
    }
}
