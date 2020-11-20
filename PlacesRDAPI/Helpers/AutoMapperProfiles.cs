using AutoMapper;
using PlacesRDAPI.DTOs;
using PlacesRDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacesRDAPI.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<Place, PlaceDTO>().ReverseMap();

            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<PlaceCreation, Place>()
                .ForMember(x => x.Photo, options => options.Ignore());
            CreateMap<ProvinceCreation, Province>();
        }
    }
}
