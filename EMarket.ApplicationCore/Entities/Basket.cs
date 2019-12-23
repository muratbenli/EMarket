using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.ApplicationCore.Entities
{
    public class Basket
    {
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public void AddItem(int productId, string productName, decimal unitPrice, string imagePath, int quantity = 1)
        {
            if (!_items.Any(x => x.ProductId == productId))
            {
                _items.Add(new BasketItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    ImagePath = imagePath

                });
                return;
            }
            _items.FirstOrDefault(x => x.ProductId == productId).Quantity += quantity;
        }

        public void RemoveItem(int productId)
        {
            _items.RemoveAll(x => x.ProductId == productId);
        }
    }
}
