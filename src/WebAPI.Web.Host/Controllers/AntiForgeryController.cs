using Microsoft.AspNetCore.Antiforgery;
using WebAPI.Controllers;

namespace WebAPI.Web.Host.Controllers
{
    public class AntiForgeryController : WebAPIControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
