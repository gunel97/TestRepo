using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class SocialManager:CrudManager<Social, SocialViewModel, SocialCreateViewModel, SocialUpdateViewModel>,
        ISocialService
    {
        public SocialManager(IRepository<Social> repository, IMapper mapper)
            :base(repository, mapper) 
        {
            
        }
    }
}
