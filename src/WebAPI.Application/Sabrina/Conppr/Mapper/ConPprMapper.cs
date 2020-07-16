
using AutoMapper;
using WebAPI.Sabrina.Conppr;
using WebAPI.Sabrina.Conppr.Dtos;

namespace WebAPI.Sabrina.Conppr.Mapper
{

	/// <summary>
    /// 配置ConPpr的AutoMapper
    /// </summary>
	internal static class ConPprMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ConPpr,ConPprListDto>();
            configuration.CreateMap <ConPprListDto,ConPpr>();

            configuration.CreateMap <ConPprEditDto,ConPpr>();
            configuration.CreateMap <ConPpr,ConPprEditDto>();

        }
	}
}
