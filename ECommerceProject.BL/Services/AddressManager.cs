using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceProject.BL.Services
{
    public class AddressManager : CrudManager<Address, AddressViewModel, AddressCreateViewModel, AddressUpdateViewModel>,
        IAddressService
    {
        public AddressManager(IRepository<Address> repository, IMapper mapper) : base(repository, mapper)
        {

        }


        public async Task SetDefaultAddressOfUser(int addressId, string userId) 
        {
            var addresses = await GetAllAsync(
                predicate: x => x.AppUserId == userId && !x.IsDeleted && x.Id!=addressId);

            if (addresses.Any())
            {
                foreach (var item in addresses)
                {
                    item.IsDefault = false;
                }
            }

            var address = await GetAsync(predicate: x => x.Id == addressId);
            
            if (address != null)
            {
                address.IsDefault = true;
            }

        }

        public async Task<Address> CreateAddressAsync(AddressCreateViewModel createViewModel)
        {
            var address = Mapper.Map<Address>(createViewModel);

            //if (userId != null)
            //{
            //    address.AppUserId = userId;

            //   await  SetDefaultAddressOfUser(address.Id, userId);
            //}

            await Repository.CreateAsync(address);

            return address;
        }

    }
}
