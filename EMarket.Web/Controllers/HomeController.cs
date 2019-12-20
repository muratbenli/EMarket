using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMarket.Web.Models;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using EMarket.Web.Extensions;

namespace EMarket.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeIndexViewModelService _homeIndexViewModelService;
        public HomeController(IHomeIndexViewModelService homeIndexViewModelService)
        {
            _homeIndexViewModelService = homeIndexViewModelService;
        }

        public IActionResult Index(int? cid, int? p)
        {
            //HttpContext.Session.SetString("ad", "ali");

            List<string> adlar = new List<string> { "ali", "veli" };

            HttpContext.Session.Set("adlar", adlar);

            return View(_homeIndexViewModelService.GetHomeIndexViewModel(cid, p ?? 1, Constants.ITEMS_PER_PAGE));
        }

        public IActionResult Privacy()
        {
            ViewBag.ad = HttpContext.Session.GetString("adlar");
            List<string> isimler = HttpContext.Session.Get<List<string>>("adlar");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
