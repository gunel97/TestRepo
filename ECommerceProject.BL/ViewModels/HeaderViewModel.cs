namespace ECommerceProject.BL.ViewModels
{
    public class HeaderViewModel
    {
        public List<SocialViewModel> Socials { get; set; } = [];
        public List<CurrencyViewModel> Currencies { get; set; } = [];
        public List<LanguageViewModel> Languages { get; set; } = [];
    }

}
