using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IColorService : ICrudService<Color, ColorViewModel, ColorCreateViewModel, ColorUpdateViewModel>
    {
        Task<List<SelectListItem>> GetColorSelectListItemsAsync();
    }
}
