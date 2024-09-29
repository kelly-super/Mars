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
    public class SearchStepDefinitions: BaseTest
    {
        HomePage homePage;
        SearchPage searchPage;
        public SearchStepDefinitions(FeatureContext featureContext) : base(featureContext)
        {

        }

        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            homePage = new HomePage();
            homePage.ClickSearchButton(driver, "Mandarin Test");

        }

        [When(@"I enter a skill ""([^""]*)"" into the search bar")]
        public void WhenIEnterASkillIntoTheSearchBar(string skill)
        {
           
        }

        [When(@"I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            
        }

        [Then(@"I should see a list of resources matching the entered skill")]
        public void ThenIShouldSeeAListOfResourcesMatchingTheEnteredSkill()
        {
           
        }

        [When(@"I click one resource")]
        public void WhenIClickOneResource()
        {
           
        }

        [Then(@"the results should display relevant languages and skills of the resource")]
        public void ThenTheResultsShouldDisplayRelevantLanguagesAndSkillsOfTheResource()
        {
           
        }



    }
}
