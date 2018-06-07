using MortgageCalculator.Web.Models;
using MortgageCalculator.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MortgageService mortgageService = new MortgageService();

            //var mortgageData = mortgageService.GetAllMortgagesAsync();

            var mortgageData = new List<Mortgage>
            {
                new Mortgage
                {
                    MortgageId = 1,
                    Name = "Fixed Home Loan (Interest Only)",
                    MortgageType = MortgageType.Fixed,
                    InterestRepayment = InterestRepayment.InterestOnly,
                    EffectiveStartDate = new DateTime(2018,06,04,16,25,52),
                    EffectiveEndDate = new DateTime(2018,06,04,16,25,52),
                    TermsInMonths = 12,
                    CancellationFee = 259.99M,
                    EstablishmentFee = 259.99M,
                    InterestRate = 4.99M
                },
                new Mortgage
                {
                    MortgageId = 2,
                    Name = "Fixed Home Loan (Principal and Interest)",
                    MortgageType = MortgageType.Fixed,
                    InterestRepayment = InterestRepayment.PrincipalAndInterest,
                    EffectiveStartDate = new DateTime(2018,06,04,16,25,52),
                    EffectiveEndDate = new DateTime(2018,06,04,16,25,52),
                    TermsInMonths = 12,
                    CancellationFee = 259.99M,
                    EstablishmentFee = 259.99M,
                    InterestRate = 4.81M

                },
                new Mortgage
                {
                    MortgageId = 3,
                    Name = "Variable Home Loan (Interest Only)",
                    MortgageType = MortgageType.Variable,
                    InterestRepayment = InterestRepayment.InterestOnly,
                    EffectiveStartDate = new DateTime(2018,06,04,16,25,52),
                    EffectiveEndDate = new DateTime(2018,06,04,16,25,52),
                    TermsInMonths = 12,
                    CancellationFee = 259.99M,
                    EstablishmentFee = 259.99M,
                    InterestRate = 5.24M
                }
            };

            //Order Mortgage by Type then by Interest Rate
            var sortedMortgage = mortgageData.OrderBy(x => x.MortgageType).ThenBy(x => x.InterestRate);

            return View(sortedMortgage);
        }
    }
}