using AutoMapper;
using CarsAPI.Models.Dto;
using Microsoft.Identity.Client;
using CarsAPI.Models;

namespace CarsAPI
{
    public class MappingConfing
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CarsDto, Cars>();
                config.CreateMap<Cars, CarsDto>();

            });
            return mappingConfig;
        }
    }
}
