using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        IReadOnlyCollection<BasketItem> BasketItems { get; }
        int GetBasketItemCount();
        void AddItemToBasket(int productId, string productName, decimal unitPrice, string imagePath, int quantity = 1);
        void RemoveItemFromBasket(int productId);
        void EmptyBasket();

    }
}
