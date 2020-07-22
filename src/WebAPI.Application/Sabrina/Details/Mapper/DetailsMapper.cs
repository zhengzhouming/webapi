
using AutoMapper;
using WebAPI.Sabrina.Details;
using WebAPI.Sabrina.Details.Dtos;

namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置Details的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// DetailsDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	internal static class DetailsMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <CONDetails,DetailsListDto>();
            configuration.CreateMap <DetailsListDto,CONDetails>();

            configuration.CreateMap <DetailsEditDto,CONDetails>();
            configuration.CreateMap <CONDetails,DetailsEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
