
using AutoMapper;
using WebAPI.Sabrina.MesDept;
using WebAPI.Sabrina.MesDept.Dtos;

// ReSharper disable once CheckNamespace
namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置MesDept的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// MesDeptDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class MesDeptMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <MesDept,MesDeptListDto>();
            configuration.CreateMap <MesDeptListDto,MesDept>();

            configuration.CreateMap <MesDeptEditDto,MesDept>();
            configuration.CreateMap <MesDept,MesDeptEditDto>();

            //// custom codes
           

            //// custom codes end
        }
	}
}
