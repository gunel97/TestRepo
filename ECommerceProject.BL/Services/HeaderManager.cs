using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;

namespace ECommerceProject.BL.Services
{
    public class HeaderManager : IHeaderService
    {
        private readonly ILanguageService _languageService;
        private readonly ICurrencyService _currencyService;
        private readonly ISocialService _socialService;

        public HeaderManager(ISocialService socialService, ICurrencyService currencyService, ILanguageService languageService)
        {
            _socialService = socialService;
            _currencyService = currencyService;
            _languageService = languageService;
        }

        public async Task<HeaderViewModel> GetHeaderViewModelAsync()
        {
            var socials = await _socialService.GetAllAsync();
            var currencies = await _currencyService.GetAllAsync(predicate:x=>!x.IsDeleted);
            var languages = await _languageService.GetAllAsync(predicate: x=>!x.IsDeleted);

            var headerViewModel = new HeaderViewModel
            {
                Socials = socials.ToList(),
                Currencies = currencies.ToList(),
                Languages = languages.ToList()
            };

            return headerViewModel;
        }
    }

    public class FooterManager : IFooterService
    {
        private readonly ILanguageService _languageService;
        private readonly ICurrencyService _currencyService;
        private readonly ISocialService _socialService;
        private readonly IBioService _bioService;

        public FooterManager(ISocialService socialService, ICurrencyService currencyService, ILanguageService languageService, IBioService bioService)
        {
            _socialService = socialService;
            _currencyService = currencyService;
            _languageService = languageService;
            _bioService = bioService;
        }

        public async Task<FooterViewModel> GetFooterViewModelAsync()
        {
            var socials = await _socialService.GetAllAsync();
            var currencies = await _currencyService.GetAllAsync(predicate: x => !x.IsDeleted);
            var languages = await _languageService.GetAllAsync(predicate: x => !x.IsDeleted);
            var bio = await _bioService.GetAllAsync(predicate: x=>!x.IsDeleted);

            var footerViewModel = new FooterViewModel
            {
                Socials = socials.ToList(),
                Currencies = currencies.ToList(),
                Languages = languages.ToList(),
                Bio = bio.ToList().FirstOrDefault(),
            };

            return footerViewModel;
        }
    }
}
