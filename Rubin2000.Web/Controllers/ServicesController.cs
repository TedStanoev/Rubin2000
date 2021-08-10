using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Services.ForProcedures.Models;
using System;
using System.Collections.Generic;

namespace Rubin2000.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IProcedureService procedureService;
        private readonly IMemoryCache cache;

        public ServicesController(IProcedureService procedureService, IMemoryCache cache)
        {
            this.procedureService = procedureService;
            this.cache = cache;
        }

        public IActionResult Index() => View();


        public IActionResult Hair()
        {
            const string hairProcedureCacheKey = "HairProcedures";

            var hairProcedures = this.cache.Get<IEnumerable<ProcedureListServiceModel>>(hairProcedureCacheKey);

            if (hairProcedures == null)
            {
                hairProcedures = procedureService.GetHairProcedures();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.cache.Set(hairProcedureCacheKey, hairProcedures, cacheOptions);
            }

            return View(hairProcedures);
        }

        public IActionResult Nails()
        {
            const string nailProcedureCacheKey = "NailProcedures";

            var nailProcedures = this.cache.Get<IEnumerable<ProcedureListServiceModel>>(nailProcedureCacheKey);

            if (nailProcedures == null)
            {
                nailProcedures = procedureService.GetNailsProcedures();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                this.cache.Set(nailProcedureCacheKey, nailProcedures, cacheOptions);
            }

            return View(nailProcedures);
        }

    }
}
