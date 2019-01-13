using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoTestPrimeNumber
{
    [TestClass]
    public class PrimeNumberTests
    {
        private IWebDriver Driver { get; set; }
        StartPage indexPage;

        [TestInitialize]
        public void SetUp()
        {
            Driver = GetChromeDriver();
            indexPage = new StartPage(Driver);
            indexPage.GoTo();
        }

        [TestMethod]
        [Description("Validate that the index page opens successfully")]
        public void IndexPageIsVisible()
        {
            Assert.IsTrue(indexPage.IsVisible, "Index page did not open seccessfully");
        }
        
        [TestMethod]
        [Description("Validate that the textbox and button display successfully on the index page")]
        public void ElementsAreVisible()
        {
            IWebElement field = Driver.FindElement(By.Id("insertedNumber"));
            IWebElement button = Driver.FindElement(By.Id("checkButton"));
            Assert.IsTrue(field.Displayed, "Text field is not visible on the Index page");
            Assert.IsTrue(button.Displayed, "Button is not visible on the Index page");
        }
       
        [TestMethod]
        [Description("Validate that system gives correct result for a prime number")]
        public void ValidatePrimeNumberResult()
        {
            IWebElement result;
            ResultPage resultPage = indexPage.FillOutFormAndSubmit(1);
            Assert.IsTrue(resultPage.IsVisible, "Result page did not open seccessfully");
            result = Driver.FindElement(By.Id("yesImg"));
            Assert.IsTrue(result.Displayed, "Image is not visible");
        }

        [TestMethod]
        [Description("Validate that system gives correct result for a non prime number")]
        public void ValidateNonPrimeNumberResult()
        {
            IWebElement result;
            var resultPage = indexPage.FillOutFormAndSubmit(10);
            Assert.IsTrue(resultPage.IsVisible, "Result page did not open seccessfully");
            result = Driver.FindElement(By.Id("noImg"));
            Assert.IsTrue(result.Displayed, "Image is not visible");
        }
        
        [TestMethod]
        [Description("Validate that link Back works")]
        public void BackLinkIsClickable()
        {
            IWebElement backlnk;
            var resultPage = indexPage.FillOutFormAndSubmit(10);
            Assert.IsTrue(resultPage.IsVisible, "Result page did not open seccessfully");
            backlnk = Driver.FindElement(By.LinkText("Back"));
            backlnk.Click();
            Assert.IsTrue(indexPage.IsVisible, "Back link does not work as expected");
        }

        [TestCleanup]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
