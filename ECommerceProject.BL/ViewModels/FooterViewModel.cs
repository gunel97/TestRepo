namespace ECommerceProject.BL.ViewModels
{
    public class FooterViewModel
    {
        public BioViewModel? Bio { get; set; }
        public List<CurrencyViewModel> Currencies { get; set; } = [];
        public List<LanguageViewModel> Languages { get; set; } = [];
        public List<SocialViewModel> Socials { get; set; } = [];
    }
}
