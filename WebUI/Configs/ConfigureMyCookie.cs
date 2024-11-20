using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Configs
{
    internal class ConfigureMyCookie : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        private readonly string _cookieScheme;

        // Constructor để nhận tên scheme từ bên ngoài (nếu cần)
        public ConfigureMyCookie(string cookieScheme)
        {
            _cookieScheme = cookieScheme ?? throw new ArgumentNullException(nameof(cookieScheme));
        }

        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Chỉ cấu hình scheme cụ thể
            if (name == _cookieScheme)
            {
                options.LoginPath = "/TaiKhoan/DangNhap";
                // Uncomment nếu cần
                // options.AccessDeniedPath = "/Home/Error";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Thời gian tồn tại của cookie
                options.SlidingExpiration = true; // Gia hạn cookie tự động
            }
        }

        public void Configure(CookieAuthenticationOptions options)
            => Configure(Options.DefaultName, options);
    }
}
