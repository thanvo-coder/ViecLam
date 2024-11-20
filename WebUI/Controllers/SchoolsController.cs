
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


    public class SchoolsController : BaseController
    {

       

        public SchoolsController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
           

        }


        



    }
}
