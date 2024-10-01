using Mars.Pages;
using Mars.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions: BaseTest
    {
        HomePage homePage;
        SearchPage searchPage;
        LoginPage loginPage;
        ProfilePage profilePage;
        ServicePage servicePage;
        private  ScenarioContext _scenarioContext;
        public SearchStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext) : base(featureContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            Log.Information("Navigating to the home page");
            string url = GetApplictionConfig("url");
            driver.Navigate().GoToUrl(url);
            homePage = new HomePage();

        }

        [When(@"I enter a skill ""([^""]*)"" into the search bar")]
        public void WhenIEnterASkillIntoTheSearchBar(string skill)
        {
            homePage.InputSearchString(driver, skill);
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            homePage.ClickSearchButton(driver);
        }

        [Then(@"I should see a list of services matching the entered skill")]
        public void ThenIShouldSeeAListOfServicesMatchingTheEnteredSkill()
        {
            searchPage = new SearchPage();
        }

        [When(@"I click the ""([^""]*)"" infomation and I have logged in the system")]
        public void WhenIClickTheInfomationAndIHaveLoggedInTheSystem(string seller)
        {
            Log.Information("When I click the seller's name and I have logged in the system");
            searchPage.ClickSellerName(driver, seller);
            if (!IsUserLoggedIn())
            {
                string email = GetApplictionConfig("username");
                string password = GetApplictionConfig("password");
                loginPage = new LoginPage();
                loginPage.ClickLoginButton(driver, email, password);
                SetUserLoggedIn(true);
                Console.WriteLine("User logged in successfully.");
            }


        }

        [Then(@"The system should display the seller's details")]
        public void ThenTheSystemShouldDisplayTheSellersDetails()
        {
            profilePage = new ProfilePage();
            profilePage.ClickServicesTab(driver);
            Thread.Sleep(2000);
            profilePage.ClickLanguagesTab(driver);
            Thread.Sleep(2000);
            profilePage.ClickSkillsTab(driver);
        }

        [When(@"I click the ""([^""]*)"" infomation")]
        public void WhenIClickTheInfomation(string service)
        {
            _scenarioContext["service"] = service;
            searchPage.CLickServiceName(driver, service);
        }

        [Then(@"The system should display the details")]
        public void ThenTheSystemShouldDisplayTheDetails()
        {
            servicePage = new ServicePage();
            string display_skill_name = servicePage.GetSkillTitle(driver);
            string _service = _scenarioContext["service"].ToString();
            Assert.IsTrue(_service.Equals(display_skill_name));
        }

          

    }
}
