using Mars.Pages;
using Mars.Support;
using NUnit.Framework;

namespace Mars.StepDefinitions
{
    [Binding]
    public class LanguagesStepDefinitions: BaseTest
    {

        LoginPage loginPage;
        HomePage homePage;
        ProfilePage profilePage;
        int row_count =0;

        public LanguagesStepDefinitions(FeatureContext featureContext) : base(featureContext)
        {

        }
        [Given(@"navigate to the language tab")]
        public void GivenNavigateToTheLanguageTab()
        {
            profilePage = new ProfilePage();
            profilePage.NavigateToLanguageTab(driver);
            profilePage.ClearUpAllTheData(driver);
        }
        [Given(@"click the Add New Button")]
        public void GivenClickTheAddNewButton()
        {
            profilePage.ClickAddNewButton(driver);
        }


        [When(@"input the  ""([^""]*)"" and ""([^""]*)"" and click the add button")]
        public void WhenInputTheAndAndClickTheAddButton(string mandarin, string basic)
        {
            profilePage.InputNewLanguageDetails(driver,"new", mandarin, basic);
            profilePage.ClickAddButton(driver);
        }

        [Then(@"a ""([^""]*)"" will display to show the result")]
        public void ThenAWillDisplayToShowTheResult(string p0)
        {

           Console.WriteLine(p0);
        }

        [Given(@"click the edit Button of a ""([^""]*)""")]
        public void GivenClickTheEditButtonOfA(string mandarin)
        {
            profilePage.ClickEditIconOfALanguage(driver, mandarin);
        }

        [When(@"change the ""([^""]*)"" and ""([^""]*)"" and click Update button")]
        public void WhenChangeTheAndAndClickUpdateButton(string mandarin, string basic)
        {

            profilePage.InputNewLanguageDetails(driver, "edit", mandarin, basic);
            profilePage.ClickUpdateButton(driver);

        }


        [When(@"click the delete Button of a ""([^""]*)""")]
        public void WhenClickTheDeleteButtonOfA(string english)
        {
            profilePage.ClickDeleteIconOfALanguage(driver, english);
        }
        [Then(@"a ""([^""]*)"" will be display to show the result")]
        public void ThenAWillBeDisplayToShowTheResult(string p0)
        {

            Console.WriteLine(p0);
            string actural_result = profilePage.GetMessage(driver);
            Assert.That(actural_result.Contains(p0));

        }

        [When(@"the user has (.*) languages")]
        public void WhenTheUserHasLanguages(int p0)
        {
           row_count = profilePage.GetRowCount(driver, "Languages");
            
        }



        [When(@"the user has less than (.*) languages")]
        public void WhenTheUserHasLessThanLanguages(int p0)
        {
            row_count = profilePage.GetRowCount(driver, "Languages");           
        }

        [Then(@"the button should not be visible")]
        public void ThenTheButtonShouldNotBeVisible()
        {
            bool isButtonDisplayed = driver.FindElement(profilePage.language_addNew_button).Displayed;
            if (row_count == 4)
            {

                Assert.IsFalse(isButtonDisplayed);
            }
            else
            {
                Assert.IsTrue(isButtonDisplayed);
            }
        }

        [Then(@"the button should be visible")]
        public void ThenTheButtonShouldBeVisible()
        {
            bool isButtonDisplayed = driver.FindElement(profilePage.language_addNew_button).Displayed;
            if (row_count == 4)
            {

                Assert.IsTrue(isButtonDisplayed);
            }
            else
            {
                Assert.IsFalse(isButtonDisplayed);
            }
        }

        
       

      
    }
}
