using System.Threading.Tasks;
using WebAPI.Configuration.Dto;

namespace WebAPI.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
