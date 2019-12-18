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
    public class HomeIndexViewModelService : IHomeIndexViewModelService
    {
        private readonly IRepository<Category> _categoryRepository;

        private readonly IRepository<Product> _productRepository;

        public HomeIndexViewModelService(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public HomeIndexViewModel GetHomeIndexViewModel(int? categoryId)
        {
            var products = _productRepository.GetAll();

            if (categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }

            var vm = new HomeIndexViewModel
            {
                Categories = _categoryRepository.GetAll()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    ProductCount = x.Products.Count
                })
                .ToList(),
                Products = products.ToList()
            };

            return vm;
        }
    }
}
