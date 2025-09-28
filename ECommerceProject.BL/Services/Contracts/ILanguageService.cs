using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface ILanguageService:ICrudService<Language, LanguageViewModel, LanguageCreateViewModel, LanguageUpdateViewModel> { }
}
