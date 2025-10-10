using AutoMapper;
using ECommerceProject.BL.Services;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
                .ForMember(x => x.ColorIconName, opt => opt.MapFrom(src => src.Color == null ? "" : src.Color.IconName))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Product == null ? "" : src.Product.Name))
                .ForMember(x => x.Priced, opt => opt.MapFrom(src => src.Product!.BasePrice))
                .ReverseMap();
            CreateMap<ProductVariant, ProductVariantCreateViewModel>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantUpdateViewModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.Discount, opt=>opt.MapFrom(src=>src.DiscountCode == null ? "" : src.DiscountCode.Code))
                .ForMember(x=>x.AppUserName, opt=>opt.MapFrom(src=>src.AppUser == null ? "" : src.AppUser.UserName))
                .ReverseMap();
            CreateMap<Order, OrderCreateViewModel>().ReverseMap();
            CreateMap<Order, OrderUpdateViewModel>().ReverseMap();

            CreateMap<DiscountCode, DiscountCodeViewModel>().ReverseMap();
            CreateMap<DiscountCode, DiscountCodeCreateViewModel>().ReverseMap();
            CreateMap<DiscountCode, DiscountCodeUpdateViewModel>().ReverseMap();

            CreateMap<Bio, BioViewModel>().ReverseMap();
            CreateMap<Bio, BioCreateViewModel>().ReverseMap();
            CreateMap<Bio, ColorUpdateViewModel>().ReverseMap();

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

            CreateMap<WishlistItem, WishlistItemViewModel>().ReverseMap();
            CreateMap<WishlistItem, WishlistItemCreateViewModel>().ReverseMap();
            CreateMap<WishlistItem, WishlistItemUpdateViewModel>().ReverseMap();

            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<Color, ColorCreateViewModel>().ReverseMap();
            CreateMap<Color, ColorUpdateViewModel>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreateViewModel>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailUpdateViewModel>().ReverseMap();

            
        }
    }
}
