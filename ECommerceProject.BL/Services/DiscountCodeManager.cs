using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class DiscountCodeManager : CrudManager<DiscountCode, DiscountCodeViewModel, DiscountCodeCreateViewModel, DiscountCodeUpdateViewModel>,
    IDiscountCodeService
    {
        public DiscountCodeManager(IRepository<DiscountCode> repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}
