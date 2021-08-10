using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rubin2000.Services.ForCategories;
using Rubin2000.Services.ForCategories.Models;
using System;
using System.Collections.Generic;

namespace Rubin2000.Web.Controllers
{
    public class PricesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMemoryCache cache;

        public PricesController(ICategoryService categoryService, IMemoryCache cache)
        {
            this.categoryService = categoryService;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            const string pricesCacheKey = "PricesCache";

            var categoriesWithProcedures = this.cache.Get<IEnumerable<CategoryWithProceduresServiceModel>>(pricesCacheKey);

            if (categoriesWithProcedures == null)
            {
                categoriesWithProcedures = categoryService.GetAllCategoriesWithProcedures();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.cache.Set(pricesCacheKey, categoriesWithProcedures, cacheOptions);
            }

            return View(categoriesWithProcedures);
        }
    }
}
