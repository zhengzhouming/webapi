using System.Threading.Tasks;
using Abp.Application.Services;
using WebAPI.Authorization.Accounts.Dto;

namespace WebAPI.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
