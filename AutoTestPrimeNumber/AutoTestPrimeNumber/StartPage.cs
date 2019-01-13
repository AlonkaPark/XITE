using OpenQA.Selenium;

namespace AutoTestPrimeNumber
{
    internal class StartPage : BasePage
    {
        public StartPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => Driver.Title.Contains("Index - ASP.NET Application");

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://localhost:61057/Number/Index"); //Provide here your localhost if it's needed
        }

        internal ResultPage FillOutFormAndSubmit(int num)
        {
            Driver.FindElement(By.Id("insertedNumber")).SendKeys(num.ToString());
            Driver.FindElement(By.Id("checkButton")).Click();
            return new ResultPage(Driver);
        }
    }
}