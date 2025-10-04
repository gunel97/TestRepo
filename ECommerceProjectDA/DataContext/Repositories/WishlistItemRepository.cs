using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class WishlistItemRepository : EFCoreRepository<WishlistItem>, IWishlistItemRepository
    {
        public WishlistItemRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}