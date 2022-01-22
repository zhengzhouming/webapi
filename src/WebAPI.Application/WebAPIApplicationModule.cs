using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebAPI.Authorization;
using WebAPI.CustomDtoAutoMapper;
using WebAPI.Sabrina.barcodeScan.Authorization;
using WebAPI.Sabrina.barcodeScan.Mapper;
using WebAPI.Sabrina.Conppr.Authorization;
using WebAPI.Sabrina.Conppr.Mapper;
using WebAPI.Sabrina.Locations.Authorization;
using WebAPI.Sabrina.Locations.Mapper;

namespace WebAPI
{
    [DependsOn(
        typeof(WebAPICoreModule),
        typeof(AbpAutoMapperModule))]
    public class WebAPIApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {  
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                invMapper.CreateMappings(configuration);
                ConPprMapper.CreateMappings(configuration);
                LocationsMapper.CreateMappings(configuration);
                DetailsMapper.CreateMappings(configuration);
                CountReceiDtoAutoMapper.CreateMappings(configuration);
                InvreceiMapper.CreateMappings(configuration);
 
                MesDeptMapper.CreateMappings(configuration);
                MesWorkTagScanDtoAutoMapper.CreateMappings(configuration);
                MesWorkTagScanReceiptMapper.CreateMappings(configuration);
                ReceiDtoAutoMapper.CreateMappings(configuration);
                MesUserMapper.CreateMappings(configuration);
            });

            Configuration.Authorization.Providers.Add<WebAPIAuthorizationProvider>();           
            Configuration.Authorization.Providers.Add<ConPprAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<LocationsAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DetailsAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CountReceiAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<InvreceiAuthorizationProvider>(); 
            Configuration.Authorization.Providers.Add<MesDeptAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<MesWorkTagScanAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<MesWorkTagScanReceiptAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ReceiAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<MesUserAuthorizationProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebAPIApplicationModule).GetAssembly());
        }
    }
}