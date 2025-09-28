using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class SocialViewModel
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
        public string Url { get; set; } = null!;
    }

    public class SocialCreateViewModel { }

    public class SocialUpdateViewModel { }
}
