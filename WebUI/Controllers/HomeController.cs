
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using System;
using System.Drawing;
using System.IO;

using WebUI.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using System.Linq;



namespace WebUI.Controllers
{


    public class HomeController : BaseController
    {

       

        public HomeController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
           

        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
           
            return View();
        }

      
       
    }
}
