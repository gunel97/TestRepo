using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class SocialRepository : EFCoreRepository<Social>, ISocialRepository
    {
        public SocialRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}