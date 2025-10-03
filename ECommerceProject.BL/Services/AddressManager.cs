using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class AddressManager :CrudManager<Address, AddressViewModel, AddressCreateViewModel, AddressUpdateViewModel>,
        IAddressService
    {
        public AddressManager(IRepository<Address> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
