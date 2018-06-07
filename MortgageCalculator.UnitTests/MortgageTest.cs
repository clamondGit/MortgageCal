
using System;
using NUnit.Framework;
using MortgageCalculator.Web;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class MortgageTest
    {
        [Test]
        public void TestView()
        {
            var controller = new HomeController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
