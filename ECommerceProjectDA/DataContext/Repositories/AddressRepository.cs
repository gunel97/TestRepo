using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class AddressRepository :EFCoreRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext dbContext):base(dbContext) { }
    }
}