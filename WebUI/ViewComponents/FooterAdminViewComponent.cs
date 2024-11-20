using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
   
    public class FooterAdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}