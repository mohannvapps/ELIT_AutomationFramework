using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Status = AventStack.ExtentReports.Status;
using NUnit.Framework;

namespace ELIT_AutomationFramework.BaseClass
{
    public class ReportsGenerationClass : IDisposable
    {
        public ExtentReports _extent;
        public ExtentTest _test;
        public IWebDriver _driver;
        public string TestcaseNumber { get; set; }  // Property to store Testcase Number

        [OneTimeSetUp]
        public void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(Path.Combine(projectPath, "Reports"));
            DateTime time = DateTime.Now;
            String fileName = this.GetType().Name;
            var reportPath = Path.Combine(projectPath, "Reports", fileName + "--" + time.ToString("dd_MMM_yyyy_hh_mm") + ".html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "ELIT");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "Mohan");
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
        }
        [SetUp]
        public void BeforeTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArguments("disable-infobars");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("start-maximized");

            _driver = new ChromeDriver(@"D:\1.ELIT_AutomationFramework\ELIT_AutomationFramework\Driver\chromedriver.exe", options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Include Testcase Number in the test log
            _test = _extent.CreateTest($"{TestcaseNumber} - {TestContext.CurrentContext.Test.Name}");
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;

                    DateTime time = DateTime.Now;
                    String fileName = this.GetType().Name + "-" + time.ToString("dd_MMM_yyyy_hh_mm") + ".png";
                    String screenShotPath = CaptureScreenshot(_driver, fileName);
                    _test.Log(Status.Fail, $"{TestcaseNumber}|");
                    _test.Log(Status.Fail, "Error: " + TestContext.CurrentContext.Result.Message);
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath(@"Reports\Screenshots\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    _test.Log(Status.Warning, $"{TestcaseNumber}|");
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    _test.Log(Status.Skip, $"{TestcaseNumber}|");
                    break;
               // default:
                    //logstatus = Status.Pass;
                    //_test.Log(Status.Pass, $"{TestcaseNumber}|");
                    //break;
            }
            _extent.Flush();
            Dispose();
        }
        public IWebDriver GetDriver()
        {
            return _driver;
        }
        public static string CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + @"Reports\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + @"Reports\Screenshots\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}