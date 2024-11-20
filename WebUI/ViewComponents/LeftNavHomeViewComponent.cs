
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Configs;

namespace WebUI.ViewComponents
{

    public class LeftNavHomeViewComponent : ViewComponent
    {
        //private readonly IHT_MenuRepository _hT_MenuRepo;
        //private readonly IUserService _userService;
        //private readonly IDanhMucService _danhMucService;
        //public LeftnavHomeViewComponent(IHT_MenuRepository hT_MenuRepo, IUserService userService,ILanguageService languageService,IDanhMucService danhMucService)
        //{
        //    _hT_MenuRepo = hT_MenuRepo;
        //    _userService = userService;
        //    _danhMucService = danhMucService;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
           // var categoys = _danhMucService.ListCategoryLanguage();
            return View();
        }
    }
}