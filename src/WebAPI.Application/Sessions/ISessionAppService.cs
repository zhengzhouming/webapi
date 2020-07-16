using System.Threading.Tasks;
using Abp.Application.Services;
using WebAPI.Sessions.Dto;

namespace WebAPI.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
