using System.Diagnostics.Metrics;
using AutoMapper;
using _2704.Dto;
using _2704.Models;

namespace _2704.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<WeatherForecast, WeatherForecastDto>();
            CreateMap<WeatherForecastDto, WeatherForecast>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<SearchHistoryDto, SearchHistory>();
            CreateMap<SearchHistory, SearchHistoryDto>();

    
        }
    }
}
