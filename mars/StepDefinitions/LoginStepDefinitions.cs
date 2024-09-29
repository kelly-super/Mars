using Mars.Pages;
using Mars.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions: BaseTest
    {

        LoginPage loginPage;
        HomePage homePage;


        public LoginStepDefinitions(FeatureContext featureContext) : base(featureContext)
        {

        }

        [Given(@"navigates to the login page")]
        public void GivenNavigatesToTheLoginPage()
        {
            string url = GetApplictionConfig("url");
            driver.Navigate().GoToUrl(url);
            homePage = new HomePage();
            homePage.ClickSignInLink(driver);
        }

        [When(@"enter valid credentials and click the login button")]
        public void WhenEnterValidCredentialsAndClickTheLoginButton()
        {
            if (!IsUserLoggedIn())
            {
                string email = GetApplictionConfig("username");
                string password = GetApplictionConfig("password");
                loginPage = new LoginPage();
                loginPage.ClickLoginButton(driver, email, password);
                SetUserLoggedIn(true);
                Console.WriteLine("User logged in successfully.");
            }
            else
            {
                Console.WriteLine("User is already logged in, skipping login.");
            }
           
        }

        [Then(@"should be redirected to the profile page")]
        public void ThenShouldBeRedirectedToTheProfilePage()
        {

            string profileUrl = GetApplictionConfig("profileUrl");
            string currentUrl = driver.Url;
            Assert.True(profileUrl.Equals(currentUrl));
            Assert.IsTrue(IsUserLoggedIn(),"user logged in succeeded");
        }

    }
}
