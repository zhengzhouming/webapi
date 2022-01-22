
using AutoMapper;
using WebAPI.Sabrina.Countrecei;
using WebAPI.Sabrina.Countrecei.Dtos;

namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置CountRecei的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// CountReceiDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class CountReceiDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Countrecei, CountReceiListDto>();
            configuration.CreateMap <CountReceiListDto, Countrecei>();

            configuration.CreateMap <CountReceiEditDto, Countrecei>();
            configuration.CreateMap <Countrecei, CountReceiEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
