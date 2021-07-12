using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Models;
using Entities.ModelsDto;

namespace TestApplication.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ReturnProductDto>();
            CreateMap<CreateProductDto, Product>();

            CreateMap<Kind, ReturnKindDto>();
            CreateMap<CreateKindDto, Kind>();
            CreateMap<UpdateKindDto, Kind>();



            CreateMap<UserForRegistrationDto, User>();
        }

    }
}
