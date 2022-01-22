
using AutoMapper;
using WebAPI.Sabrina.Recei;
using WebAPI.Sabrina.Recei.Dtos;

namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Recei的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// ReceiDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class ReceiMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Recei,ReceiListDto>();
            configuration.CreateMap <ReceiListDto,Recei>();

            configuration.CreateMap <ReceiEditDto,Recei>();
            configuration.CreateMap <Recei,ReceiEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
