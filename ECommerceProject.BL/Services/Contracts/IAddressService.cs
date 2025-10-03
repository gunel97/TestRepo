using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IAddressService 
        : ICrudService<Address, AddressViewModel, AddressCreateViewModel, AddressUpdateViewModel> 
    {
 
    }
}
