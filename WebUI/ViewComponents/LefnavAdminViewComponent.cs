
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    
    public class LefnavAdminViewComponent : ViewComponent
    {
        //private readonly IHT_MenuRepository _hT_MenuRepo;

        //public LefnavAdminViewComponent(IHT_MenuRepository hT_MenuRepo)
        //{
        //    _hT_MenuRepo = hT_MenuRepo;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
           // var items = await _hT_MenuRepo.GetMenuItemsAsync(HttpContext.User);
            return View("Default");
        }
    }
}