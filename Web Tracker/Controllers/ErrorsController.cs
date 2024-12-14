using Microsoft.AspNetCore.Mvc;
using Webtracker.Repositories;
using WebTracker.Controllers;
using WebTracker.Repositories;

namespace SignalR_Check.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebsiteRepository _websiteRepository;
        IErrorsRepository _errorRepository;
        IWarningRepository _warningRepository;

        public ErrorsController(ILogger<HomeController> logger, IWebsiteRepository websiteRepository, IErrorsRepository errorRepository, IWarningRepository warningRepository)
        {
            _logger = logger;
            _websiteRepository = websiteRepository;
            _errorRepository = errorRepository;
            _warningRepository = warningRepository;
        }
        public IActionResult Index()
        {
            ViewBag.userinfo = HttpContext.Request.Cookies["trackit-username"];
            ViewBag.WebsitesList = _websiteRepository.GetAllWebsites();
            return View();
        }
        public IActionResult ClientErrors(string websiteName)
        {
            ViewBag.userinfo = HttpContext.Request.Cookies["trackit-username"];
            ViewBag.Errors = _errorRepository.GetClientErrors(websiteName);
            return View();
        }
        public IActionResult ClientWarnings(string websiteName)
        {
            ViewBag.userinfo = HttpContext.Request.Cookies["trackit-username"];
            ViewBag.Warnings = _warningRepository.GetClientWarnings(websiteName);
            return View();
        }
    }
}
