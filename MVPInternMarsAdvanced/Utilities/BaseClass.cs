using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPInternMarsAdvanced.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.Net.NetworkInformation;
using MVPInternMarsAdvanced.Data;
using Newtonsoft.Json.Linq;

namespace MVPInternMarsAdvanced.Utilities
{
    public class BaseClass
    {
        private static ExtentTest test;
        private static ExtentReports extent;

        //Initialize the browser
        public static IWebDriver driver { get; set; }
        public string timeStamp;

        public static string text = File.ReadAllText(@"Data\Credentials.json");
        public static JArray credentialsArray = JArray.Parse(text);

        IList<Credentials> credentials = credentialsArray.Select(p => new Credentials
        {
            Username = (string)p["Username"],
            Password = (string)p["Password"]
        }).ToList();

        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();
            TurnOnWait();

            //Maximise the window
            driver.Manage().Window.Maximize();
        }

        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [OneTimeSetUp]
        public static void InitializeReport()
        {
            var sparkReporter = new ExtentSparkReporter(@"Report.html");
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }

        [SetUp]
        public void SignIn()
        {
            Initialize();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            NavigateUrl();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.SigninStep(credentials[0].Username, credentials[0].Password);
            timeStamp = GetTimestamp(DateTime.Now);
        }

        public void Clear()
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.ClearAllLanguageRecords();
            SkillPage skillPageObj = new SkillPage();
            skillPageObj.ClearAllSkillRecords();
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + DateTime.Now.ToString("_dd-MM-yyyy_mss") + ".jpeg";
                    String screenShotPath = CommonMethod.SaveScreenshot(driver, fileName);
                    test.Log(Status.Fail, "Snapshot above: " + test.AddScreenCaptureFromPath(@"Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus);
            Close();
        }

        [OneTimeTearDown]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        //Close the browser
        public void Close()
        {
            driver.Quit();
        }
    }
}
