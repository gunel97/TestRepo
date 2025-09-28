using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class ProductVariantManager : CrudManager<ProductVariant, ProductVariantViewModel, ProductVariantCreateViewModel, ProductVariantUpdateViewModel>,
        IProductVariantService
    {
        public ProductVariantManager(IRepository<ProductVariant> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
