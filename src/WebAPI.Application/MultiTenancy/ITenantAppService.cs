using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WebAPI.MultiTenancy.Dto;

namespace WebAPI.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

