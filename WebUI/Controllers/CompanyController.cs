
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


    public class CompanyController : BaseController
    {

       

        public CompanyController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
           

        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Privacy()
        {
           
            return View();
        }
        [AllowAnonymous]
        public IActionResult Company_intro()
        {
            ViewData["Title"] = "Company_intro";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Company_department()
        {
            ViewData["Title"] = "Company_department";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Company_manage_jobs()
        {
            ViewData["Title"] = "Company_manage_jobs";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Company_staff()
        {
            ViewData["Title"] = "Company_staff";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Company_profile()
        {
            ViewData["Title"] = "Company_profile";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Job_detail()
        {
            ViewData["Title"] = "Job_detail";
            return View();
        }



    }
}
