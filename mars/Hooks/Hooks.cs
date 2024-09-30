using AngleSharp.Text;
using Mars.Pages;
using Mars.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Mars.Hooks
{
    [Binding]
    public sealed class Hooks: BaseTest
    {
        //We will use the [BeforeFeature] and [AfterFeature] hooks to manage WebDriver initialization and login only once for the entire feature. 

       
        public readonly FeatureContext _featureContext;

        public Hooks(FeatureContext featureContext) : base(featureContext) { }

        [BeforeScenario("@LoginRequired")]
        public void BeforeScenarioWithLogin()
        {
            

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
           

        }
        [BeforeScenario]
        public void BeforeScenario()
        {
         
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Initialize WebDriver only once for the entire feature
            GetWebDriver();
            string url = GetApplictionConfig("url");
            driver.Navigate().GoToUrl(url);
            HomePage homePage = new HomePage();
            homePage.ClickSignInLink(driver);
           

            // Check if the feature has the @NoBeforeFeature tag
            bool skipBeforeFeature = featureContext.FeatureInfo.Tags.Contains("NoBeforeFeature");
            if (skipBeforeFeature) {

                Console.WriteLine(" Skipping BeforeFeature hook fo this feature");
                return;
            }

            // Log in only once for the entire feature
            BaseTest baseTestInstance = new BaseTest(featureContext);
            if (!baseTestInstance.IsUserLoggedIn())
            {
                PerformLogin();
                baseTestInstance.SetUserLoggedIn(true);
            }


        }
        [AfterFeature]
        public static void AfterFeature()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}