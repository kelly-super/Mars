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


        public void ClickSignInLink(IWebDriver driver)
        {
            driver.FindElement(signin_link).Click();
        }
    }
}
