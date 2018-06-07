using MortgageCalculator.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace MortgageCalculator.Web.Services
{
    public class MortgageService
    {
        public async Task<List<Mortgage>> GetAllMortgagesAsync()
        {
            string baseUrl = "http://hostedadmin.clamond/";
            ObjectCache cache = MemoryCache.Default;

            if (cache.Get("MortgageData") is List<Mortgage> mortgageData)
            {
                return mortgageData;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync("api/Mortgage");

                if (response.IsSuccessStatusCode)
                {
                    var mortgageResponse = response.Content.ReadAsStringAsync().Result;
                    mortgageData = JsonConvert.DeserializeObject<List<Mortgage>>(mortgageResponse);

                    //Cache mortgageData for 24 hours
                    CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddHours(24) };
                    cache.Add("MortgageData", mortgageData, policy);

                    return mortgageData;
                }
                return null;
            }
        }

    }
}