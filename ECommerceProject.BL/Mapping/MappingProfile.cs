using AutoMapper;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerceProject.BL.ViewModels.ProductVariantViewModel;

namespace ECommerceProject.BL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryCreateViewModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category == null ? "" : src.Category.Name))
                .ReverseMap();
            CreateMap<Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<Product, ProductUpdateViewModel>().ReverseMap();

            CreateMap<ProductVariant, ProductVariantViewModel>()
                .ForMember(x => x.ColorName, opt => opt.MapFrom(src => src.Color == null ? "" : src.Color.Name))
                .ForMember(x => x.ImageNames, opt => opt.MapFrom(src => src.ProductImages.Select(i => i.ImageName).ToList()))
                .ForMember(x=>x.ColorIconName, opt=>opt.MapFrom(src=>src.Color!.IconName))
                .ReverseMap();
            CreateMap<ProductVariant, ProductVariantCreateViewModel>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantUpdateViewModel>().ReverseMap();

            CreateMap<Bio, BioViewModel>().ReverseMap();
            CreateMap<Bio, BioCreateViewModel>().ReverseMap();
            CreateMap<Bio, BioUpdateViewModel>().ReverseMap();

            CreateMap<Social, SocialViewModel>().ReverseMap();
            CreateMap<Social, SocialCreateViewModel>().ReverseMap();
            CreateMap<Social, SocialUpdateViewModel>().ReverseMap();

            CreateMap<Currency, CurrencyViewModel>().ReverseMap();
            CreateMap<Currency, CurrencyCreateViewModel>().ReverseMap();
            CreateMap<Currency, CurrencyUpdateViewModel>().ReverseMap();

            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<Language, LanguageCreateViewModel>().ReverseMap();
            CreateMap<Language, LanguageUpdateViewModel>().ReverseMap();

            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Address, AddressCreateViewModel>().ReverseMap();
            CreateMap<Address, AddressUpdateViewModel>().ReverseMap();

           // CreateMap<Wishlist, WishlistViewModel>().ReverseMap();
            //CreateMap<Wishlist, WishlistCreateViewModel>().ReverseMap();
            //CreateMap<Wishlist, WishlistUpdateViewModel>().ReverseMap();
        }
    }
}
