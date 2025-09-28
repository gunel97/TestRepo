using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IProductService:ICrudService<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel> { }

}
