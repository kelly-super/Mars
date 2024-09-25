using Mars.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Mars.Pages
{
    public class ProfilePage
    {
        public readonly By language_tab = By.XPath("//a[text()=\"Languages\"]");
        public readonly By skill_tab = By.XPath("//a[text()=\"Skills\"]");
        public readonly By languange_question_text = By.XPath("//div[contains(text(), 'How many languages do you speak?')]");

        public readonly By add_language_input = By.XPath("//input[@placeholder=\"Add Language\"]");
        public readonly By language_level_dropdown = By.XPath("//select[@name=\"level\"]");
        
        public readonly By language_addNew_button = By.XPath("//div[@data-tab=\"first\"]//div[@class=\"ui teal button \"]");
        public readonly By add_button =By.XPath("//input[@value=\"Add\"]");
        public readonly By cancel_button = By.XPath("//input[@value=\"Cancel\"]");
        public By language_level_option;
        public By lastrow_Language = By.XPath("//tr[last()]//td[1]");
        public By lastrow_level = By.XPath("//tr[last()]//td[2]");


        public void NavigateToLanguageTab(IWebDriver driver)
        {
            driver.FindElement(language_tab).Click();
        }
        public void ClickAddNewButton(IWebDriver driver)
        {
            //Wait.WaitToBeVisible(driver, language_addNew_button);
            driver.FindElement(language_addNew_button).Click();
        }

        public void AddNewLanguage(IWebDriver driver,string language,string level)
        {

            driver.FindElement(add_language_input).SendKeys(language);
            driver.FindElement(language_level_dropdown).Click();
            language_level_option = By.XPath("//select[@name=\"level\"]//option[text()=\""+level+"\"]");
            driver.FindElement(language_level_option).Click();
            driver.FindElement(add_button).Click();
        }

        public void cancelAdd(IWebDriver driver)
        {
            driver.FindElement(cancel_button).Click();
        }
    }
}