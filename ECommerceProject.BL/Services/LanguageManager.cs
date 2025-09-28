using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class LanguageManager : CrudManager<Language, LanguageViewModel, LanguageCreateViewModel, LanguageUpdateViewModel>,
        ILanguageService
    {
        public LanguageManager(IRepository<Language> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
