using Mars.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class LoginPage
    {
        public readonly By email_input = By.XPath("//input[@name=\"email\"]");
        public readonly By password_input = By.XPath("//input[@name=\"password\"]");
        public readonly By login_button = By.XPath("//button[text()=\"Login\"]");



        public void ClickLoginButton(IWebDriver driver, string email, string password)
        {
            Wait.WaitToBeVisible(driver,email_input);
            Wait.WaitToBeVisible(driver, password_input);
            driver.FindElement(email_input).SendKeys(email);
            driver.FindElement(password_input).SendKeys(password);
            driver.FindElement(login_button).Click();
        }

    }
}
