using AutoMapper;

using Entities.Models;
using Entities.ModelsDto;

namespace TestApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ReturnProductDto>().ForMember(x => x.ShipperName, opt => opt.MapFrom(m => m.Shipper.Name));

            //CreateMap<ProductBasket, ReturnProductBasketDto>().ConvertUsing();
            //CreateMap<ReturnProductDto, ReturnProductAndCountDto>().ForMember(x => x.CountPage, x => x.MapFrom(m => m. + " " + m.LastName))
            CreateMap<UserForRegistrationDto, UserForAuthenticationDto>();

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>().ReverseMap();

            CreateMap<Kind, ReturnKindDto>();
            CreateMap<CreateKindDto, Kind>();
            CreateMap<UpdateKindDto, Kind>().ReverseMap();



            CreateMap<Shipper, ReturnShipperDto>();
            CreateMap<CreateShipperDto, Shipper>();
            CreateMap<UpdateShipperDto, Shipper>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>();
        }

    }
}
