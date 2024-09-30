using Mars.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class LanguagePage
    {
        public readonly By language_tab = By.XPath("//a[text()=\"Languages\"]");

        public readonly By languange_question_text = By.XPath("//div[contains(text(), 'How many languages do you speak?')]");

        public readonly By add_language_input = By.XPath("//input[@placeholder=\"Add Language\"]");
        public readonly By language_level_dropdown = By.XPath("//select[@name=\"level\"]");

        public readonly By language_addNew_button = By.XPath("//div[@data-tab=\"first\"]//div[@class=\"ui teal button \"]");
        public readonly By add_button = By.XPath("//div[@data-tab=\"first\"]//input[@value=\"Add\"]");
        public readonly By cancel_button = By.XPath("//div[@data-tab=\"first\"]//input[@value=\"Cancel\"]");
        public By language_level_option;
        public By lastrow_Language = By.XPath("//tr[last()]//td[1]");
        public By lastrow_level = By.XPath("//tr[last()]//td[2]");

        public By edit_button;// By.XPath("//td[text()='Mandarin']/following-sibling::td[@class='right aligned']//i[@class='outline write icon']");
        public By delete_button;// By.XPath("//td[text()='Mandarin']/following-sibling::td[@class='right aligned']//i[@class='remove icon']");

      

        public By update_button = By.XPath("//div[@data-tab=\"first\"]//input[@value=\"Update\"]");

        public By active_tab = By.XPath("//div[contains(@class, 'ui bottom attached tab segment') and contains(@class, 'active')]");


        public void NavigateToLanguageTab(IWebDriver driver)
        {


            Wait.WaitToBeVisible(driver, language_tab);
            driver.FindElement(language_tab).Click();
        }
        public void ClickAddNewButton(IWebDriver driver)
        {
            //Wait.WaitToBeVisible(driver, language_addNew_button);
            driver.FindElement(language_addNew_button).Click();
        }

        public void InputNewLanguageDetails(IWebDriver driver, string type, string language, string level)
        {
            if (level == "" || level == null)
            {
                level = "Choose Language Level";
            }
            if (type == "new")
            {
                driver.FindElement(add_language_input).SendKeys(language);
                driver.FindElement(language_level_dropdown).Click();
                language_level_option = By.XPath("//select[@name=\"level\"]//option[text()=\"" + level + "\"]");
                driver.FindElement(language_level_option).Click();
            }
            else if (type == "edit")
            {
                driver.FindElement(add_language_input).Clear();
                driver.FindElement(add_language_input).SendKeys(language);
                driver.FindElement(language_level_dropdown).Click();
                language_level_option = By.XPath("//select[@name=\"level\"]//option[text()=\"" + level + "\"]");
                driver.FindElement(language_level_option).Click();
            }

        }

        public void ClickAddButton(IWebDriver driver)
        {
            driver.FindElement(add_button).Click();
        }

        public string getLastRowLanguage(IWebDriver driver)
        {
            return driver.FindElement(lastrow_Language).Text;
        }

        public string getLastRowLevel(IWebDriver driver)
        {
            return driver.FindElement(lastrow_level).Text;
        }
        public void ClickCancelButton(IWebDriver driver)
        {
            driver.FindElement(cancel_button).Click();
        }
        public int GetRowCount(IWebDriver driver, string type)
        {
            driver.FindElement(language_tab).Click();
            IWebElement _active_tab = driver.FindElement(active_tab);
            By row = By.XPath(".//table[contains(@class, 'ui fixed table')]//tbody//tr");
            IReadOnlyCollection<IWebElement> rows = _active_tab.FindElements(row);
            int _count = rows.Count;
            Console.WriteLine($"Row count in the active tab: {_count}");
            return _count;
        }

        public void ClickEditIconOfALanguage(IWebDriver driver, string language)
        {
            edit_button = By.XPath("//td[text()='" + language + "']/following-sibling::td[@class='right aligned']//i[@class='outline write icon']");
            driver.FindElement(edit_button).Click();
        }

        public void ClickDeleteIconOfALanguage(IWebDriver driver, string language)
        {
            delete_button = By.XPath("//td[text()='" + language + "']/following-sibling::td[@class='right aligned']//i[@class='remove icon']");
            driver.FindElement(delete_button).Click();
        }

        public void ClickUpdateButton(IWebDriver driver)
        {
            driver.FindElement(update_button).Click();
        }

        public void ClearUpAllTheData(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> remove_icon = driver.FindElements(By.XPath("//div[@data-tab=\"first\"]//i[@class=\"remove icon\"]"));
            foreach (IWebElement icon in remove_icon)
            {
                icon.Click();
            }
            driver.Navigate().Refresh();
        }

    }
}
