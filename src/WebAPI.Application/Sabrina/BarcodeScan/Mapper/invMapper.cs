
using AutoMapper;
using WebAPI.Sabrina.barcodeScan;
using WebAPI.Sabrina.barcodeScan.Dtos;

namespace WebAPI.Sabrina.barcodeScan.Mapper
{

	/// <summary>
    /// 配置inv的AutoMapper
    /// </summary>
	internal static class invMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Inv,invListDto>();
            configuration.CreateMap <invListDto,Inv>();

            configuration.CreateMap <invEditDto,Inv>();
            configuration.CreateMap <Inv,invEditDto>();

        }
	}
}
