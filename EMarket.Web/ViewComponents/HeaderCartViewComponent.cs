using EMarket.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.ViewComponents
{
    public class HeaderCartViewComponent : ViewComponent
    {
        IBasketViewModelService _basketViewModelService;

        public HeaderCartViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_basketViewModelService.GetHeaderCartViewModel());
        }

    }
}
