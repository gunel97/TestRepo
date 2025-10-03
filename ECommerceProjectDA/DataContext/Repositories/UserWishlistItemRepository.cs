using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class UserWishlistItemRepository : EFCoreRepository<UserWishlistItem>, IUserWishlistItemRepository
    {
        public UserWishlistItemRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}