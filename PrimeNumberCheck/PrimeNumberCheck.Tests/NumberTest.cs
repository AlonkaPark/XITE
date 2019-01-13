
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberCheck.Controllers;
using PrimeNumberCheck.Models;
using System.Web.Mvc;

namespace PrimeNumberCheck.Tests
{
    [TestClass]
    public class NumberTest
    {
        private NumberController controller;
        private Number number;

        //Define base settings before every test method
        [TestInitialize]
        public void SetupContext()
        {
            controller = new NumberController();
            number = new Number();
        }

        //Index controller uses correct View method (without parameter)
        [TestMethod]
        public void ValidateIndexView()
        {
            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName, "The returned View is not Index");
        }

        //Index controller uses correct View method (with parameter)
        [TestMethod]
        public void ValidateResultView()
        {
            // Act
            var result = controller.Index(number) as ViewResult;

            // Assert
            Assert.AreEqual("Result", result.ViewName, "The returned View is not Result");
        }

        //System returns result "true" when provided number is prime
        [TestMethod]
        public void ValidateResultIsPrime()
        {
            number.Value = 1;
            // Act
            var result = controller.Index(number) as ViewResult;
            var product = (Number)result.ViewData.Model;

            // Assert
            Assert.AreEqual("True", product.isPrime.ToString(), "The returned value is not as expected");
        }


        //System returns result "false" when provided number is not prime
        [TestMethod]
        public void ValidateResultIsNotPrime()
        {
            number.Value = 12;

            // Act
            var result = controller.Index(number) as ViewResult;
            var product = (Number)result.ViewData.Model;

            // Assert
            Assert.AreEqual("False", product.isPrime.ToString(), "The returned value is not as expected");
        }
    }
}
