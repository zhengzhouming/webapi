
using AutoMapper;
using WebAPI.Sabrina.Countrecei;
using WebAPI.Sabrina.Countrecei.Dtos;

namespace WebAPI.Sabrina.Countrecei.Mapper
{

	/// <summary>
    /// 配置CountRecei的AutoMapper
    /// </summary>
	internal static class CountReceiMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Countrecei, CountReceiListDto>();
            configuration.CreateMap <CountReceiListDto, Countrecei>();

            configuration.CreateMap <CountReceiEditDto, Countrecei>();
            configuration.CreateMap <Countrecei, CountReceiEditDto>();

        }
	}
}
