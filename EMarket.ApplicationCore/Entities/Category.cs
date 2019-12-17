using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.ApplicationCore.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}
