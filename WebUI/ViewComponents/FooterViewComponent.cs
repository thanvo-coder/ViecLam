
using Microsoft.AspNetCore.Mvc;
namespace WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        //private readonly IDanhMucService _danhMucService;
        //public FooterViewComponent(IHT_MenuRepository hT_MenuRepo, IUserService userService, ILanguageService languageService, IDanhMucService danhMucService)
        //{
        //    _danhMucService = danhMucService;
        //}
        public IViewComponentResult Invoke()
        {
          //  var categoys = _danhMucService.ListCategoryLanguage();
            return View();
        }
    }
}