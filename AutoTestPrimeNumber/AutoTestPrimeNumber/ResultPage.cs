using OpenQA.Selenium;

namespace AutoTestPrimeNumber
{
    internal class ResultPage : BasePage
    {
        public ResultPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => Driver.Title.Contains("Result");
    }
}