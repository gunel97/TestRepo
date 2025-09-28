using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface ISocialService:ICrudService<Social, SocialViewModel, SocialCreateViewModel, SocialUpdateViewModel> { }
}
