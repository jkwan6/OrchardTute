using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;

namespace OrchardModule.Controllers
{
    public class HomeController : Controller
    {

        private readonly IStringLocalizer T;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer<HomeController> H;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IStringLocalizer<HomeController> stringLocalizer, 
            INotifier notifier, 
            IHtmlLocalizer<HomeController> html,
            ILogger<HomeController> logger)
        {
            T = stringLocalizer;
            H = html;
            _notifier = notifier;
            _logger = logger;
        }


        public ActionResult Index()
        {
            ViewData["Message"] = T["Hello abcdsadasddefgh World"];
            _notifier.SuccessAsync(H["Hello World!"]);
            _logger.LogError(T["Message"]);
            return View();
        }
    }
}