using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }
    }
}
