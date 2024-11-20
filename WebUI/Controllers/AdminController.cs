
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
using WebUI.Configs;



namespace WebUI.Controllers
{


    public class AdminController : BaseController
    {

       

        public AdminController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
           

        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult Index()
        {
           
            return View();
        }

      

        [HttpGet]
        public IActionResult ListUser()
        {
            ViewData["Title"] = "ListUser";
            return View();
        }

        public IActionResult Schools()
        {
            ViewData["Title"] = "Trường";
            ViewData["Token"] = User.GetUserToken();
            return View();
        } 
        
        public IActionResult EducationTypes()
        {
            ViewData["Title"] = "Loại trình độ";
            ViewData["Token"] = User.GetUserToken();
            return View();
        }
        public IActionResult Educations()
        {
            ViewData["Title"] = "Trình độ học vấn";
            ViewData["Token"] = User.GetUserToken();
            return View();
        }

 public IActionResult WorkTypes()
        {
            ViewData["Title"] = "Loại hình làm việc";
            ViewData["Token"] = User.GetUserToken();
            return View();
        }

    }
}
