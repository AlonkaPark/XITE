using OpenQA.Selenium;

namespace AutoTestPrimeNumber
{
     internal class BasePage
    {
        //Base class for chrome driver definition
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}