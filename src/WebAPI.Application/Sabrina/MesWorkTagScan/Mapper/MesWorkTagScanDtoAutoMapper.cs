
using AutoMapper;
using WebAPI.Sabrina.MesWorkTagScan;
using WebAPI.Sabrina.MesWorkTagScan.Dtos;

// ReSharper disable once CheckNamespace
namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置MesWorkTagScan的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// MesWorkTagScanDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class MesWorkTagScanDtoAutoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <MesWorkTagScan,MesWorkTagScanListDto>();
            configuration.CreateMap <MesWorkTagScanListDto,MesWorkTagScan>();

            configuration.CreateMap <MesWorkTagScanEditDto,MesWorkTagScan>();
            configuration.CreateMap <MesWorkTagScan,MesWorkTagScanEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
