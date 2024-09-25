using Mars.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Mars.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public IWebDriver driver;

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new BaseTest().GetWebDriver();


        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}