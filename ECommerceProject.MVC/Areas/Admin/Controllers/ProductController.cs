using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Areas.Admin.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            //var products = await _productService.GetAllAsync(include:
            //    x => x.Include(pv => pv.ProductVariants).ThenInclude(c => c.Color!)
            //    .Include(pv => pv.ProductVariants).ThenInclude(i => i.ProductImages));

            var products = await _productService.GetAllAsync();
            return View(products.ToList());
        }
    }
}
