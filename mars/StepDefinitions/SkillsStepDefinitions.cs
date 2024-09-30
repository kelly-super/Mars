using Mars.Pages;
using Mars.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : BaseTest
    {
        LoginPage loginPage;
        HomePage homePage;
        SkillsPage skillsPage;
        ProfilePage profilePage;
        int row_count = 0;

        public SkillsStepDefinitions(FeatureContext featureContext) : base(featureContext)
        {


        }
        [Given(@"navigate to the skills tab")]
        public void GivenNavigateToTheSkillsTab()
        {
            skillsPage = new SkillsPage();
            skillsPage.NavigateToSkillsTab(driver);

        }

        [Given(@"click the AddNew Button")]
        public void GivenClickTheAddNewButton()
        {
            skillsPage.ClickAddNewButton(driver);
        }

        [When(@"input the ""([^""]*)"" and ""([^""]*)"" and click the add button")]
        public void WhenInputTheAndAndClickTheAddButton(string skill, string level)
        {
            skillsPage.InputSkillDetails(driver, "new", skill, level);
            skillsPage.ClickAddButton(driver);
        }


        [When(@"input the ""([^""]*)"" and ""([^""]*)"" and click the cancel button")]
        public void WhenInputTheAndAndClickTheCancelButton(string skill, string level)
        {
            row_count = skillsPage.GetSkillCount(driver);
            skillsPage.InputSkillDetails(driver, "new", skill, level);
            skillsPage.ClickCancelButton(driver);
        }


        [Then(@"no more skill is created")]
        public void ThenNoMoreSkillIsCreated()
        {
            int current_count = skillsPage.GetSkillCount(driver);
            Assert.AreEqual(row_count, current_count);
        }

        [Given(@"click the edit button of a ""([^""]*)""")]
        public void GivenClickTheEditButtonOfA(string skill)
        {
            skillsPage.ClickEditIcon(driver, skill);
        }

        [When(@"change the ""([^""]*)""""([^""]*)"" and click Update button")]
        public void WhenChangeTheAndClickUpdateButton(string skill, string level)
        {
            skillsPage.InputSkillDetails(driver, "edit", skill, level);
            skillsPage.ClickUpdateButton(driver);
        }

        [When(@"click the delete button of a ""([^""]*)""")]
        public void WhenClickTheDeleteButtonOfA(string skill)
        {
            skillsPage.ClickDeleteIcon(driver, skill);
        }

        [Then(@"a ""([^""]*)"" will be displayed to show the result")]
        public void ThenAWillBeDisplayedToShowTheResult(string message)
        {
            profilePage = new ProfilePage();
            string actural_result = profilePage.GetMessage(driver);
            profilePage.ClickMessageCloseButton(driver);
            Assert.That(actural_result.Contains(message));
            
        }

    }
}
