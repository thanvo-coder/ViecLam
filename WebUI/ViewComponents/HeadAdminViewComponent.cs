using Microsoft.AspNetCore.Mvc;
using WebUI.Configs;

namespace WebUI.ViewComponents
{
   
    public class HeadAdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewData["SiteName"] = SiteConfig.SITENAME;
            return View();
        }
    }
}