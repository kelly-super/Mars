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


        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;


        public LoginStepDefinitions(IWebDriver driver, FeatureContext featureContext) : base(driver,featureContext)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
        }

        [Given(@"navigates to the login page")]
        public void GivenNavigatesToTheLoginPage()
        {
            string url = GetApplictionConfig("url");
            _driver.Navigate().GoToUrl(url);
            _homePage.ClickSignInLink();
        }

        [When(@"enter valid credentials and click the login button")]
        public void WhenEnterValidCredentialsAndClickTheLoginButton()
        {
            /* if (!IsUserLoggedIn())
             {
                 PerformLogin();
                 SetUserLoggedIn(true);
                 Console.WriteLine("User logged in successfully.");
             }
             else
             {
                 Console.WriteLine("User is already logged in, skipping login.");
             }*/
            PerformLogin();
        }

        [Then(@"should be redirected to the profile page")]
        public void ThenShouldBeRedirectedToTheProfilePage()
        {

            string profileUrl = GetApplictionConfig("profileUrl");
            string currentUrl = _driver.Url;
            Assert.True(profileUrl.Equals(currentUrl));
           // Assert.IsTrue(IsUserLoggedIn(),"user logged in succeeded");
        }

    }
}
