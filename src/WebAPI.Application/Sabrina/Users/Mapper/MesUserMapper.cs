
using AutoMapper;
using WebAPI.Sabrina.Users;
using WebAPI.Sabrina.Users.Dtos;

// ReSharper disable once CheckNamespace
namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置MesUser的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// MesUserDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class MesUserMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <MesUser,MesUserListDto>();
            configuration.CreateMap <MesUserListDto,MesUser>();

            configuration.CreateMap <MesUserEditDto,MesUser>();
            configuration.CreateMap <MesUser,MesUserEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
