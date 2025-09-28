using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class ProductManager :CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>,
        IProductService
    {
        public ProductManager(IRepository<Product> repository, IMapper mapper) 
            : base(repository, mapper)
        {
            
        }
    }
}
