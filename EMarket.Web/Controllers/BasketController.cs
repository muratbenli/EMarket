using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMarket.Web.Interfaces;
using EMarket.Web.Services;
using EMarket.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Web.Controllers
{
    public class BasketController : Controller
    {
        IBasketViewModelService _basketViewModelService;
        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToBasket(int productId, int quantity = 1)
        {
            _basketViewModelService.AddToBasket(productId, quantity);

            var vm = new HeaderBasketViewModel
            {
                HeaderBasketHtml = "buralar değerlenecek",
                TotalItems = _basketViewModelService.TotalItems()
            };

            return Json(vm); // toplam oge sayisi ve sepet hmtl'ini dondur
        }
    }
}