using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AngleSharp.Dom;

namespace Mars.Support
{
    public class Wait
    {
        public static void WaitToBeClickable(IWebDriver driver, By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            /* switch (locatorType.ToLower())
             {
                 case "xpath": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue))); break;
                 case "id": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue))); break;
                 case "css": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue))); break;

             }*/
        }
        public static void WaitToBeVisible(IWebDriver driver, By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
           /* switch (locatorType.ToLower())
            {
                case "xpath": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue))); break;
                case "id": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue))); break;
                case "css": wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue))); break;

            }*/
        }

    }
}