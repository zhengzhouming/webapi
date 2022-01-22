
using AutoMapper;
using WebAPI.Sabrina.MesWorkTagScanReceipt;
using WebAPI.Sabrina.MesWorkTagScanReceipt.Dtos;

// ReSharper disable once CheckNamespace
namespace WebAPI.CustomDtoAutoMapper
{

	/// <summary>
    /// 配置MesWorkTagScanReceipt的AutoMapper映射
	/// 前往 <see cref="WebAPIApplicationModule"/>的AbpAutoMapper配置方法下添加以下代码段
    /// MesWorkTagScanReceiptDtoAutoMapper.CreateMappings(configuration);
    /// </summary>
	public static class MesWorkTagScanReceiptMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <MesWorkTagScanReceipt,MesWorkTagScanReceiptListDto>();
            configuration.CreateMap <MesWorkTagScanReceiptListDto,MesWorkTagScanReceipt>();

            configuration.CreateMap <MesWorkTagScanReceiptEditDto,MesWorkTagScanReceipt>();
            configuration.CreateMap <MesWorkTagScanReceipt,MesWorkTagScanReceiptEditDto>();
					 
							//// custom codes
									
							

							//// custom codes end
        }
	}
}
