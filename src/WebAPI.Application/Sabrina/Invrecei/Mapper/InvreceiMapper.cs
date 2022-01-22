
using AutoMapper;
using WebAPI.Sabrina.Invrecei;
using WebAPI.Sabrina.Invrecei.Dtos;

namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Invrecei的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// InvreceiDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class InvreceiMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Invrecei,InvreceiListDto>();
            configuration.CreateMap <InvreceiListDto,Invrecei>();

            configuration.CreateMap <InvreceiEditDto,Invrecei>();
            configuration.CreateMap <Invrecei,InvreceiEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
