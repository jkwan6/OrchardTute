using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;

namespace DojoCourse.Module.Controllers
{
    public class HomeController : Controller
    {

        private readonly IStringLocalizer T;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            T = stringLocalizer;
        }


        public ActionResult Index()
        {
            ViewData["Message"] = T["Hello abcdsadasddefgh World"];
            return View();
        }
    }
}