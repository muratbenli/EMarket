using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.ApplicationCore.Interfaces
{
    public interface ICategoryService
    {
        List<Category> ListCategories();
    }
}
