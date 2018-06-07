using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Services;
using System.Runtime.Caching;
using System;

namespace MortgageCalculator.Api.Controllers
{
    public class MortgageController : ApiController
    {
        // GET: api/Mortgage
        public IEnumerable<Dto.Mortgage> Get()
        {
            return GetFromCache();
        }

        // GET: api/Mortgage/5
        public Dto.Mortgage Get(int id)
        {
            return GetFromCache().FirstOrDefault(x => x.MortgageId == id);
        }

        private IEnumerable<Dto.Mortgage> GetFromCache()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Get("MortgageData") is List<Dto.Mortgage> mortgageData)
            {
                return mortgageData;
            }

            var mortgageService = new MortgageService();
            mortgageData = mortgageService.GetAllMortgages();
            //Cache mortgageData for 24 hours
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddHours(24) };
            cache.Add("MortgageData", mortgageData, policy);

            return mortgageData;
        }
    }
}
