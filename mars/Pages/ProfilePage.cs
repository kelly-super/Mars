using Mars.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Mars.Pages
{
    public class ProfilePage
    {
        public readonly By description_text = By.XPath("");
        public By service_tab = By.XPath("//a[@data-tab=\"first\"]");
        public By language_tab = By.XPath("//a[@data-tab=\"second\"]");
        public By skill_tab = By.XPath("//a[@data-tab=\"third\"]");
        public By message_div = By.XPath("//div[@class=\"ns-box-inner\"]");
        public By message_close_button = By.XPath("//a[@class=\"ns-close\"]");

        public void ClickLanguagesTab(IWebDriver driver) 
        {
            driver.FindElement(language_tab).Click();
        }
        public void ClickSkillsTab(IWebDriver driver)
        {
            driver.FindElement(skill_tab).Click();
        }
        public void ClickServicesTab(IWebDriver driver)
        {
            driver.FindElement(service_tab).Click();
        }
       

        public string GetMessage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, message_div);
            string message = driver.FindElement(message_div).Text;
            Console.WriteLine(message);
            return message;
        }

        public void ClickMessageCloseButton(IWebDriver driver)
        {
            driver.FindElement(message_close_button).Click();
        }
    }
}