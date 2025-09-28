using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IProductVariantService : ICrudService<ProductVariant, ProductVariantViewModel, ProductVariantCreateViewModel, ProductVariantUpdateViewModel> { }

}
