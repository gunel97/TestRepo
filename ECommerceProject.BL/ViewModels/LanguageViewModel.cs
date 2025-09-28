using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class LanguageViewModel
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
    }

    public class LanguageCreateViewModel
    {

    }

    public struct LanguageUpdateViewModel { }
}
