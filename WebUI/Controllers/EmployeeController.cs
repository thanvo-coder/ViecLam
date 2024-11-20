
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


    public class EmployeeController : BaseController
    {

       

        public EmployeeController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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
        public IActionResult Employee_intro()
        {
            ViewData["Title"] = "Employee_intro";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Calendar()
        {
            ViewData["Title"] = "Calendar";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Skill()
        {
            ViewData["Title"] = "Skill";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Resume()
        {
            ViewData["Title"] = "Resume";
            return View();
        }



    }
}
