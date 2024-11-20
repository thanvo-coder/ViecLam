
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Configs
{
    public static class NavigationIndicatorHelper
    {
        private static bool flag;

      


        public static string CheckIsChange(object o1,object o2)
        {
            return o1+"" != o2+"" ? "IsChange" : "";
        }

    }
}