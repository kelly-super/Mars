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
        LanguagePage languagePage;
        ProfilePage profilePage;
        int row_count =0;

        public LanguagesStepDefinitions(FeatureContext featureContext) : base(featureContext)
        {

        }
        [Given(@"navigate to the language tab")]
        public void GivenNavigateToTheLanguageTab()
        {
            languagePage = new LanguagePage();
            languagePage.NavigateToLanguageTab(driver);
          //  languagePage.ClearUpAllTheData(driver);
        }
        [Given(@"click the Add New Button")]
        public void GivenClickTheAddNewButton()
        {
            languagePage.ClickAddNewButton(driver);
        }


        [When(@"input the  ""([^""]*)"" and ""([^""]*)"" and click the add button")]
        public void WhenInputTheAndAndClickTheAddButton(string mandarin, string level)
        {
            languagePage.InputNewLanguageDetails(driver,"new", mandarin, level);
            languagePage.ClickAddButton(driver);
        }

        [Given(@"click the edit Button of a ""([^""]*)""")]
        public void GivenClickTheEditButtonOfA(string mandarin)
        {
            languagePage.ClickEditIconOfALanguage(driver, mandarin);
        }

        [When(@"change the ""([^""]*)"" and ""([^""]*)"" and click Update button")]
        public void WhenChangeTheAndAndClickUpdateButton(string mandarin, string basic)
        {

            languagePage.InputNewLanguageDetails(driver, "edit", mandarin, basic);
            languagePage.ClickUpdateButton(driver);

        }


        [When(@"click the delete Button of a ""([^""]*)""")]
        public void WhenClickTheDeleteButtonOfA(string english)
        {
            languagePage.ClickDeleteIconOfALanguage(driver, english);
        }
        [Then(@"a ""([^""]*)"" will be display to show the result")]
        public void ThenAWillBeDisplayToShowTheResult(string result)
        {

            Console.WriteLine(result);
            profilePage = new ProfilePage();
            string actural_result = profilePage.GetMessage(driver);
            Assert.That(actural_result.Contains(result));
            profilePage.ClickMessageCloseButton(driver);

        }

        [When(@"the user has (.*) languages")]
        public void WhenTheUserHasLanguages(string p0)
        {
           row_count = languagePage.GetRowCount(driver, "Languages");
            
        }



        [When(@"the user has less than (.*) languages")]
        public void WhenTheUserHasLessThanLanguages(int p0)
        {
            row_count = languagePage.GetRowCount(driver, "Languages");           
        }

        [Then(@"the button should not be visible")]
        public void ThenTheButtonShouldNotBeVisible()
        {
            bool isButtonDisplayed = driver.FindElement(languagePage.language_addNew_button).Displayed;
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
            bool isButtonDisplayed = driver.FindElement(languagePage.language_addNew_button).Displayed;
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
