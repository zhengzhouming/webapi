
using AutoMapper;
using WebAPI.Sabrina.Locations;
using WebAPI.Sabrina.Locations.Dtos;

namespace WebAPI.Sabrina.Locations.Mapper
{

	/// <summary>
    /// 配置Locations的AutoMapper
    /// </summary>
	internal static class LocationsMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Locations,LocationsListDto>();
            configuration.CreateMap <LocationsListDto,Locations>();

            configuration.CreateMap <LocationsEditDto,Locations>();
            configuration.CreateMap <Locations,LocationsEditDto>();

        }
	}
}
