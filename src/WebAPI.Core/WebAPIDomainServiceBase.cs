

using Abp.Domain.Services;

namespace WebAPI
{
	public abstract class WebAPIDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected WebAPIDomainServiceBase()
		{
			LocalizationSourceName = WebAPIConsts.LocalizationSourceName;
		}
	}
}
