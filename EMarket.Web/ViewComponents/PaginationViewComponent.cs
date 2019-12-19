using EMarket.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PaginationInfoViewModel paginationInfo)
        {
            ViewBag.numbers = PageNumbers(paginationInfo.ActualPage, paginationInfo.TotalPages);

            return View(paginationInfo);
        }

        // https://gist.github.com/kottenator/9d936eb3e4e3c3e02598 (Simple Pagination)
        private int[] PageNumbers(int current, int last)
        {
            int delta = 1, l = 0;

            int left = current - delta;
            int right = current + delta + 1;

            List<int> range = new List<int>();
            List<int> rangeWithDots = new List<int>();

            for (int i = 1; i <= last; i++)
            {
                if (i == 1 || i == last || i >= left && i < right)
                    range.Add(i);
            }

            foreach (var i in range)
            {
                if (l != 0)
                {
                    if (i - l == 2)
                        rangeWithDots.Add(l + 1);
                    else if (i - l != 1)
                        rangeWithDots.Add(-1);
                }
                rangeWithDots.Add(i);
                l = i;
            }

            return rangeWithDots.ToArray();
        }


    }
}
