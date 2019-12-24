using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.ApplicationCore.Entities
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public void AddItem(int productId, string productName, decimal unitPrice, string imagePath, int quantity = 1)
        {
            if (!Items.Any(x => x.ProductId == productId))
            {
                Items.Add(new BasketItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    ImagePath = imagePath

                });
                return;
            }
            Items.FirstOrDefault(x => x.ProductId == productId).Quantity += quantity;
        }

        public void RemoveItem(int productId)
        {
            Items.RemoveAll(x => x.ProductId == productId);
        }
    }
}
