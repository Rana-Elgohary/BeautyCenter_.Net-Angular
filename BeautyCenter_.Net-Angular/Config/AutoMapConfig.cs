﻿using AutoMapper;
using BeautyCenter_.Net_Angular.DTO;
//using BeautyCenter_.Net_Angular.Models;
using BeautyCenter_.Net_Angular.Models;

namespace BeautyCenter_.Net_Angular.Config
{
    public class AutoMapConfig : Profile
    {
        public AutoMapConfig() 
        {
            CreateMap<Userr, User>();
            CreateMap<Package, PackageD>()
                        .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Services.Select(s => s.Name).ToList()));
            CreateMap<User, Userr>();

            CreateMap<PackageUserDTO, PackageUser>();
            CreateMap<PackageUser, PackageUserDTO>();


            CreateMap<serviceD,ServiceResponse>();
            CreateMap<ServiceResponse,serviceD>();

        }
    }
}
