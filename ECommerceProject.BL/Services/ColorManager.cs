using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceProject.BL.Services
{
    public class ColorManager : CrudManager<Color, ColorViewModel, ColorCreateViewModel, ColorUpdateViewModel>,
      IColorService
    {
        public ColorManager(IRepository<Color> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }

        public async Task<List<SelectListItem>> GetColorSelectListItemsAsync()
        {
            var colors = await GetAllAsync(predicate: x => !x.IsDeleted);

            return colors.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
        }
    }
}
