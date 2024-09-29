using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class HomePage
    {
        public readonly By signin_link = By.XPath("//a[text()='Sign In']");
        public readonly By search_input = By.XPath("//input[@placeholder=\"What skill would you like to trade?\"]");
        public readonly By search_button = By.XPath("//button[text()=\"Search\"]");

        public void ClickSignInLink(IWebDriver driver)
        {
            driver.FindElement(signin_link).Click();
        }
        public void ClickSearchButton(IWebDriver driver, string search) 
        {
            driver.FindElement(search_input).SendKeys(search);
            driver.FindElement(search_button).Click();

        }

    }
}
