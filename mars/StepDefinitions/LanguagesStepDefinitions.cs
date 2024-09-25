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

        [Given(@"user login the system")]
        public void GivenUserLoginTheSystem()
        {
            string url = GetApplictionConfig("url");
            driver.Navigate().GoToUrl(url);
            homePage = new HomePage();
            homePage.ClickSignInLink(driver);

            string email = GetApplictionConfig("username");
            string password = GetApplictionConfig("password");
            loginPage = new LoginPage();
            loginPage.ClickLoginButton(driver, email, password);
        }

        [Given(@"navigate to the language tab")]
        public void GivenNavigateToTheLanguageTab()
        {
            profilePage = new ProfilePage();
            profilePage.NavigateToLanguageTab(driver);
        }

        [Given(@"click the Add New Button")]
        public void GivenClickTheAddNewButton()
        {
         profilePage.ClickAddNewButton(driver);
        }


        [When(@"input the  valid information and click the add button")]
        public void WhenInputTheValidInformationAndClickTheAddButton(Table table)
        {
            try
            {
                foreach (TableRow row in table.Rows)
                {
                    profilePage.AddNewLanguage(driver, row[0], row[1]);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"a new language is created")]
        public void ThenANewLanguageIsCreated(Table table)
        {
            
        }


    }
}
