using Mars.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Pages
{
    public class SkillsPage
    {
        public readonly By active_tab = By.XPath("//div[contains(@class, 'ui bottom attached tab segment') and contains(@class, 'active')]");
        public readonly By skill_tab = By.XPath("//a[text()=\"Skills\"]");
        public readonly By add_skill_input = By.XPath("//input[@placeholder=\"Add Skill\"]");
        public readonly By skill_Level_dropdown = By.XPath("//select[@name=\"level\"]");
        public By level_option;
        public readonly By skill_andnew_button = By.XPath("//div[@data-tab=\"second\"]//div[@class=\"ui teal button\"]");
        public readonly By add_button = By.XPath("//div[@data-tab=\"second\"]//input[@value=\"Add\"]");
        public readonly By cancel_button = By.XPath("//div[@data-tab=\"second\"]//input[@value=\"Cancel\"]");
        public By edit_icon;
        public By delete_icon;
        public readonly By update_button = By.XPath("//div[@data-tab=\"second\"]//input[@value=\"Update\"]");
        public By message_div = By.XPath("//div[@class=\"ns-box-inner\"]");
        public void NavigateToSkillsTab(IWebDriver driver)
        {


            Wait.WaitToBeVisible(driver, skill_tab);
            driver.FindElement(skill_tab).Click();
        }
        public void ClickAddNewButton(IWebDriver driver)
        {
            //Wait.WaitToBeVisible(driver, language_addNew_button);
            driver.FindElement(skill_andnew_button).Click();
        }


        public void InputSkillDetails(IWebDriver driver, string type, string skill, string level)
        {
            if (level == "")
            {
                level = "Choose Skill Level";
            }
            if (type == "new")
            {
                driver.FindElement(add_skill_input).SendKeys(skill);
                driver.FindElement(skill_Level_dropdown).Click();
                level_option = By.XPath("//select[@name=\"level\"]//option[text()=\"" + level + "\"]");
                driver.FindElement(level_option).Click();
            }
            else if (type == "edit")
            {
                driver.FindElement(add_skill_input).Clear();
                driver.FindElement(add_skill_input).SendKeys(skill);
                driver.FindElement(skill_Level_dropdown).Click();
                level_option = By.XPath("//select[@name=\"level\"]//option[text()=\"" + level + "\"]");
                driver.FindElement(level_option).Click();
            }
        }
        public void ClickAddButton(IWebDriver driver)
        {
            driver.FindElement(add_button).Click();
        }
        public void ClickCancelButton(IWebDriver driver)
        {
            driver.FindElement(cancel_button).Click();
        }
        public void ClickEditIcon(IWebDriver driver, string skill)
        {
            edit_icon = By.XPath("//td[text()='" + skill + "']/following-sibling::td[@class='right aligned']//i[@class='outline write icon']");
            Wait.WaitToBeClickable(driver, edit_icon);
            driver.FindElement(edit_icon).Click();
        }
        public void ClickDeleteIcon(IWebDriver driver, string skill)
        {

            delete_icon = By.XPath("//td[text()='" + skill + "']/following-sibling::td[@class='right aligned']//i[@class='remove icon']");
            Wait.WaitToBeClickable(driver, delete_icon);
            driver.FindElement(delete_icon).Click();
        }
        public void ClickUpdateButton(IWebDriver driver)
        {
            driver.FindElement(update_button).Click();
        }

        public int GetSkillCount(IWebDriver driver)
        {
            driver.FindElement(skill_tab).Click();
            IWebElement _active_tab = driver.FindElement(active_tab);
            By row = By.XPath(".//table[contains(@class, 'ui fixed table')]//tbody//tr");
            IReadOnlyCollection<IWebElement> rows = _active_tab.FindElements(row);
            int _count = rows.Count;
            Console.WriteLine($"Row count in the active tab: {_count}");
            return _count;
        }

        public string GetMessage(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, message_div);
            string message = driver.FindElement(message_div).Text;
            Console.WriteLine(message);
            return message;
        }

        public void ClearUpAllTheData(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> remove_icon = driver.FindElements(By.XPath("//div[@data-tab=\"second\"]//i[@class=\"remove icon\"]"));
            foreach (IWebElement icon in remove_icon)
            {
                icon.Click();
            }
            driver.Navigate().Refresh();
        }
    }
}
