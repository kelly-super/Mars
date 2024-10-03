using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Support
{
    public static class ExtentReport
    {
        public static ExtentReports _extentReports;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;

        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestReport");
        public static ExtentTest test;
        public static void InitializeReport()
        {
            Console.WriteLine("Current Dir:" + dir);
            var htmlReporter = new ExtentSparkReporter(testResultPath+ "\\extent-report.html");
            htmlReporter.Config.ReportName = "Mars Test Report";
            htmlReporter.Config.DocumentTitle = "Mars Test Report";
            htmlReporter.Config.Theme = Theme.Standard;
           

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "MVP-Mars");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();

        }
        public static void CreateTest(string testName)
        {
            test = _extentReports.CreateTest(testName);
        }

        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            string filePath = dir.Replace("bin\\Debug\\net6.0", "TestReport");

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(filePath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
    }
}
