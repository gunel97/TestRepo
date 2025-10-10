using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface ICategoryService : ICrudService<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>
    {
        Task<CategoryUpdateViewModel> GetCategoryUpdateViewModelAsync(int id);
        Task<List<SelectListItem>> GetCategorySelectListItemsAsync();
    }
}
