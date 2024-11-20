
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Configs;

namespace WebUI.ViewComponents
{

    public class HT_Menu
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string MaMenuCha { get; set; }
        public string TenAction { get; set; }
        public string TenController { get; set; }
      //  public string TenArea { get; set; }
        public int ThuTu { get; set; }
        public bool HienThi { get; set; }
        public HT_Menu Parent { get; set; }
        public ICollection<HT_Menu> Children { get; set; }
        public string Icon { get; set; }
    }

    public class LeftNavViewComponent : ViewComponent
    {
        //private readonly IHT_MenuRepository _hT_MenuRepo;
        //private readonly IUserService _userService;

        //public LeftNavViewComponent(IHT_MenuRepository hT_MenuRepo, IUserService userService)
        //{
        //    _hT_MenuRepo = hT_MenuRepo;
        //    _userService = userService;
        //}

        List<HT_Menu> lstMenu = new List<HT_Menu>();



        public async Task<IViewComponentResult> InvokeAsync()
        {
            lstMenu.Add(
                new HT_Menu()
                {
                    HienThi = true,
                    Icon = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""14"" height=""14"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-credit-card avatar-icon font-medium-3""><rect x=""1"" y=""4"" width=""22"" height=""16"" rx=""2"" ry=""2""></rect><line x1=""1"" y1=""10"" x2=""23"" y2=""10""></line></svg>",
                    MaMenuCha = "",
                    ID = "",
                    Children = new List<HT_Menu>(),
                    MoTa = "",
                    Parent = new HT_Menu(),
                    Ten = "Trường",
                    TenAction = "Schools",
                    TenController = "Admin",
                    ThuTu = 1
                }
                
                );
 lstMenu.Add(
                 new HT_Menu()
                 {
                     HienThi = true,
                     Icon = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""14"" height=""14"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-credit-card avatar-icon font-medium-3""><rect x=""1"" y=""4"" width=""22"" height=""16"" rx=""2"" ry=""2""></rect><line x1=""1"" y1=""10"" x2=""23"" y2=""10""></line></svg>",
                     MaMenuCha = "",
                     ID = "",
                     Children = new List<HT_Menu>(),
                     MoTa = "",
                     Parent = new HT_Menu(),
                     Ten = "Loại trình độ",
                     TenAction = "EducationTypes",
                     TenController = "Admin",
                     ThuTu = 2
                 }

                );

 lstMenu.Add(
                 new HT_Menu()
                 {
                     HienThi = true,
                     Icon = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""14"" height=""14"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-credit-card avatar-icon font-medium-3""><rect x=""1"" y=""4"" width=""22"" height=""16"" rx=""2"" ry=""2""></rect><line x1=""1"" y1=""10"" x2=""23"" y2=""10""></line></svg>",
                     MaMenuCha = "",
                     ID = "",
                     Children = new List<HT_Menu>(),
                     MoTa = "",
                     Parent = new HT_Menu(),
                     Ten = "Loại hình làm việc",
                     TenAction = "WorkTypes",
                     TenController = "Admin",
                     ThuTu = 3
                 }

                );


 lstMenu.Add(
                 new HT_Menu()
                 {
                     HienThi = true,
                     Icon = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""14"" height=""14"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-credit-card avatar-icon font-medium-3""><rect x=""1"" y=""4"" width=""22"" height=""16"" rx=""2"" ry=""2""></rect><line x1=""1"" y1=""10"" x2=""23"" y2=""10""></line></svg>",
                     MaMenuCha = "",
                     ID = "",
                     Children = new List<HT_Menu>(),
                     MoTa = "",
                     Parent = new HT_Menu(),
                     Ten = "Trình độ học vấn",
                     TenAction = "Educations",
                     TenController = "Admin",
                     ThuTu = 4
                 }

                );


            //var items = await _hT_MenuRepo.GetMenuItemsAsync(HttpContext.User);
            //if (!User.Identity.IsAuthenticated)
            //{
            //    ViewBag.avatar = "app-assets/images/avatars/none-avatar.jpg";
            //    ViewBag.vaitro = "User";
            //}
            //else
            //{
            //    ViewBag.avatar = _userService.GetUserById(User.GetUserId()).Avatar;
            //    ViewBag.vaitro = _userService.GetUserById(User.GetUserId()).VaiTro;
            //}

            return View("Default", lstMenu);
        }
    }
}