using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class CurrencyViewModel
    {
        public string CurrencyName { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string IconName { get; set; } = null!;
    }

    public class CurrencyCreateViewModel { }

    public class CurrencyUpdateViewModel { }
}
