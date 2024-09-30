using Mars.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Mars.Support
{
    public class BaseTest
    {
        public static IWebDriver driver;
        private readonly FeatureContext _featureContext;
        public BaseTest(FeatureContext featureContext)
        {

            _featureContext = featureContext;
        }

        public static IWebDriver GetWebDriver() 
        { 
            if(driver ==null)
            {
                GetNewWebDriver(); 
            }
            return driver; 
        }

        public static void GetNewWebDriver()
        {
            string browserType = GetApplictionConfig("browserType");
            switch (browserType.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig()) ;
                    driver = new ChromeDriver() ;
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver(); 
                    break;
                default: 
                    driver = new ChromeDriver(); 
                    break;

            }
            driver.Manage().Window.Maximize();
        }
        public static string GetApplictionConfig(string key)
        {
            //get AppConfig.json directory

            string configPath = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName
                  + "\\Config\\AppConfig.json";
            string jsonContent = File.ReadAllText(configPath);
            JObject jsonData = JObject.Parse(jsonContent);
            return jsonData[key].ToString();
        }

        public bool IsUserLoggedIn()
        {
            return _featureContext.ContainsKey("IsLoggedIn") && (bool)_featureContext["IsLoggedIn"];

        }

        public void SetUserLoggedIn(bool isLoggedIn)
        {
            _featureContext["IsLoggedIn"] = isLoggedIn;
        }

        public static void PerformLogin()
        {
            string email = GetApplictionConfig("username");
            string password = GetApplictionConfig("password");
            LoginPage loginPage = new LoginPage();
            loginPage.ClickLoginButton(driver, email, password);
        }
    }
}
