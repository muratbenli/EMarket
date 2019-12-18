using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMarket.Web.Models;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Web.Interfaces;

namespace EMarket.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeIndexViewModelService _homeIndexViewModelService;
        public HomeController(IHomeIndexViewModelService homeIndexViewModelService)
        {
            _homeIndexViewModelService = homeIndexViewModelService;
        }

        public IActionResult Index(int? cid)
        {
            return View(_homeIndexViewModelService.GetHomeIndexViewModel(cid));
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
