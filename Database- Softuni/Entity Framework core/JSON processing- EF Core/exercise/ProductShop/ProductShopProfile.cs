using AutoMapper;
using ProductShop.DTO.Product;
using ProductShop.DTO.Users;
using ProductShop.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ProductsInRangeDTO>()
                .ForMember(x => x.SellerName, y => y.MapFrom(x => x.Seller.FirstName + ' ' + x.Seller.LastName));

            this.CreateMap<Product, UsersSoldProductsDTO>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(x => x.Buyer.LastName));

            this.CreateMap<User, UsersWithSoldProductsDTO>()
                .ForMember(x => x.soldProducts, y => y.MapFrom(x => x.ProductsSold.Where(p => p.Buyer != null)));

            this.CreateMap<UserImportDTO, User>();

        }
    }
}
