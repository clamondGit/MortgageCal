using MortgageCalculator.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class SelectMortgageController : Controller
    {
        // GET: SelectMortgage
        public async Task<ActionResult> Index()
        {
            string baseUrl = "http://hostedadmin.clamond/";
            List<Mortgage> mortgageData = new List<Mortgage>();

            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync("api/Mortgage");

                if(response.IsSuccessStatusCode)
                {
                    var mortgageResponse = response.Content.ReadAsStringAsync().Result;
                    mortgageData = JsonConvert.DeserializeObject<List<Mortgage>>(mortgageResponse);
                }

                return View(mortgageData);
            }

        }
    }
}