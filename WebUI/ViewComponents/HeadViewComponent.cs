using Microsoft.AspNetCore.Mvc;
using WebUI.Configs;

namespace WebUI.ViewComponents
{
    public class HeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewData["SiteName"] = SiteConfig.SITENAME;
            return View();
        }
    }
}