
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
using Microsoft.AspNetCore.Authentication;
using WebUI.Common;
using WebUI.Configs;
using System.Text;
using System.Security.Claims;
using System.Text.Json;



namespace WebUI.Controllers
{


    public class SystemController : BaseController
    {

       

        public SystemController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Logout";
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CheckLogin(string uname, string passw)
        {


            using var httpClient = new HttpClient();

            // URL API
            var url = "https://staging.cvidpro.net/api/v1/auth/login";

            // Header
            httpClient.DefaultRequestHeaders.Add("accept", "*/*");         

            // Body (JSON)
            var requestBody = new
            {
                username = uname,
                password = passw
            };

            // Serialize body thành JSON
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                // Gửi POST request
                var response = await httpClient.PostAsync(url, jsonContent);

                // Đọc kết quả phản hồi
                var responseContent = await response.Content.ReadAsStringAsync();

                // Hiển thị kết quả
               // Console.WriteLine($"Status Code: {response.StatusCode}");
               // Console.WriteLine($"Response: {responseContent}");

                if(response.IsSuccessStatusCode)
                {
                    var jsonDocument = JsonDocument.Parse(responseContent);
                    var root = jsonDocument.RootElement;

                    string id = root.GetProperty("data").GetProperty("id").GetInt32()+"";
                    string accessToken = root.GetProperty("data").GetProperty("accessToken").GetString()+"";
                    string fullName = root.GetProperty("data").GetProperty("fullName").GetString()+"";


                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id,ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Name, uname),
                new Claim(ClaimTypes.Hash, accessToken),
                new Claim(ClaimTypes.GivenName, fullName)
            };





                var claimsIdentity = new ClaimsIdentity(
                    claims, cvidproStatic.CookieScheme);


                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(5),

                };

                await HttpContext.SignInAsync(cvidproStatic.CookieScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                    return new JsonResult(new { Result = 0 })
                    {
                    };
                }

            }
            catch (Exception ex)
            {
                // Xử lý lỗi
               // Console.WriteLine($"Error: {ex.Message}");
            }
            return new JsonResult(new { Result = 1 })
            {
            };
        }
        [AllowAnonymous]
        [Route("/Account/Login")]
        public IActionResult Login1(string returnUrl)
        {
            ViewData["Title"] = "Login";

            if (Url.IsLocalUrl(returnUrl))
            {
                ViewData["returnUrl"] = returnUrl;
            }
            else
            {
                ViewData["returnUrl"] = "/";
            }


            
            return View("Login");
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["Title"] = "Login";
            if (Url.IsLocalUrl(returnUrl))
            {
                ViewData["returnUrl"] = returnUrl;
            }
            else
            {
                ViewData["returnUrl"] = "/";
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewData["Title"] = "Forgot Password";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewData["Title"] = "Reset Password";
            return View();
        }



    }
}
