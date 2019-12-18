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
        public HomeIndexViewModel GetHomeIndexViewModel(int? categoryId, int pageIndex, int productPerPage)
        {
            var products = _productRepository.GetAll();

            if (categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId);
            }

            var totalItems = products.Count();


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
                Products = products.Skip((pageIndex - 1) * productPerPage)
                .Take(productPerPage)
                .ToList(),
                PaginationInfo = new PaginationInfoViewModel
                {
                    TotalItems = totalItems,
                    ActualPage = pageIndex,
                    TotalPages = (int)Math.Ceiling((decimal)totalItems / productPerPage)
                }
            };

            vm.PaginationInfo.ItemsPerPage = vm.Products.Count;
            vm.PaginationInfo.Next = vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages ? "passive" : "active";
            vm.PaginationInfo.Previous = vm.PaginationInfo.ActualPage == 1 ? "passive" : "active";

            return vm;
        }
    }
}
