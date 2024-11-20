 using FluentValidation.Results;
using WebUI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.Controllers
{
    [Authorize("Authorization")]
    public class BaseController : Controller
    {
        public string CultureCookie { get; private set; }


        // Constructor chấp nhận IHttpContextAccessor
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            var cultureCookie = httpContextAccessor.HttpContext?.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            if (cultureCookie != null)
            {
                var requestCulture = CookieRequestCultureProvider.ParseCookieValue(cultureCookie);
                CultureCookie = requestCulture.Cultures.FirstOrDefault().Value;
            }
            else
            {
                CultureCookie = "vi-VN";
            }
        }

        public Response<T> AddStateErrors<T>(Response<T> response)
        {
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }
            return response;
        }
    }
}
