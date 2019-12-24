using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.Interfaces
{
    public interface IBasketViewModelService
    {
        void AddToBasket(int productId, int quantity = 1);

        IReadOnlyCollection<BasketItem> GetBasketItems();

        int TotalItems();
    }
}
