using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class ColorViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HexCode { get; set; }
    }
    public class ColorCreateViewModel
    {
        public string? Name { get; set; }
        public string? HexCode { get; set; }
    }
    public class ColorUpdateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HexCode { get; set; }
    }
}
