using Microsoft.AspNetCore.Mvc;
using Papiashvili.Vstupenky.Web.Models;
using Papiashvili.Vstupenky.Web.Vstupenky.Abstraction;
using Papiashvili.Vstupenky.Web.Vstupenky.Application.ViewModels;
using System.Diagnostics;

namespace Papiashvili.Vstupenky.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            CarouselConcertViewModel viewModel = _homeService.GetHomeViewModel();
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}