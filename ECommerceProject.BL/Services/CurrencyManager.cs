using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class CurrencyManager:CrudManager<Currency, CurrencyViewModel, CurrencyCreateViewModel, CurrencyUpdateViewModel>,
        ICurrencyService
    {
        public CurrencyManager(IRepository<Currency> repository, IMapper mapper)
            :base(repository, mapper)
        {
            
        }
    }
}
