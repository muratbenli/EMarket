using EMarket.ApplicationCore.Entities;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Web.Interfaces;
using EMarket.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        IBasketService _basketService;
        IRepository<Product> _productRepository;

        public BasketViewModelService(IBasketService basketService, IRepository<Product> productRepository)
        {
            _basketService = basketService;
            _productRepository = productRepository;
        }

        public void AddToBasket(int productId, int quantity = 1)
        {
            var product = _productRepository.GetById(productId);
            _basketService.AddItemToBasket(product.Id, product.ProductName, product.UnitPrice, product.ImagePath, quantity);
        }

        public IReadOnlyCollection<BasketItem> GetBasketItems()
        {
            return _basketService.BasketItems;
        }

        public HeaderCartViewModel GetHeaderCartViewModel()
        {
            var vm = new HeaderCartViewModel
            {
                TotalItems = _basketService.GetBasketItemCount(),
                BasketItems = _basketService.BasketItems,
                TotalPrice = _basketService.BasketItems.Sum(x => x.Quantity * x.UnitPrice)
            };

            return vm;
        }

        public int TotalItems()
        {
            return _basketService.GetBasketItemCount();
        }
    }
}
