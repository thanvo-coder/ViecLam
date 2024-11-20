
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        //private readonly IClientRespon _gd_Client;

        //public BannerViewComponent(IClientRespon gd_Client)
        //{
        //    _gd_Client = gd_Client;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = await _gd_Client.DSBanner();
            return View("Default");
        }
    }
}