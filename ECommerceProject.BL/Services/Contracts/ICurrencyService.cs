using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface ICurrencyService:ICrudService<Currency, CurrencyViewModel, CurrencyCreateViewModel, CurrencyUpdateViewModel> { };
}
