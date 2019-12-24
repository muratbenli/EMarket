using EMarket.ApplicationCore.Entities;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Infrastructure.Extension;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.Infrastructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Basket _basket;

        public BasketService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _basket = _httpContextAccessor.HttpContext.Session.Get<Basket>("basket");

            if (_basket == null)
            {
                _basket = new Basket();
                SaveBasketToSession();
            }
        }


        public IReadOnlyCollection<BasketItem> BasketItems => _basket.Items.AsReadOnly();

        public void AddItemToBasket(int productId, string productName, decimal unitPrice, string imagePath, int quantity = 1)
        {
            _basket.AddItem(productId, productName, unitPrice, imagePath, quantity);
            SaveBasketToSession();

        }

        public void EmptyBasket()
        {
            _basket = new Basket();
            SaveBasketToSession();
        }

        public int GetBasketItemCount()
        {
            return _basket.Items.Sum(x => x.Quantity);
        }

        public void RemoveItemFromBasket(int productId)
        {
            _basket.RemoveItem(productId);
            SaveBasketToSession();
        }

        private void SaveBasketToSession()
        {
            _httpContextAccessor.HttpContext.Session.Set<Basket>("basket", _basket);
        }
    }
}
