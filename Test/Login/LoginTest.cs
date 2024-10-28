using NUnit.Framework;
using AventStack.ExtentReports;
using ELIT_AutomationFramework.Utilities;
using ELIT_AutomationFramework.Methods.Login;
using ELIT_AutomationFramework.BaseClass;

namespace ELIT_AutomationFramework.Test.Login
{
    public class LoginTest : ReportsGenerationClass
    {
        LoginPageMethods logintest;
        ExcelUtility excelUtility;

        [Test]
        [Category("Load Login Excel File Data")]
        public void LoadExcelFileDataTest()
        {
            string excelPath;
            try
            {
                // Define the pattern for the file name including timestamp and version
                string directoryPath = @"D:\1.ELIT_AutomationFramework\Excel\Login_ExcelSheets";
                string fileNamePattern = "LoginTestData_*_v*.xlsx";

                // Get the Excel file path based on the pattern
                excelPath = ExcelUtility.GetExcelFilePathWithTimestampAndVersion(directoryPath, fileNamePattern);
                Console.WriteLine($"Latest Path read from directory: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"Excel file not found or file does not exist: {excelPath}");
                }

                Console.WriteLine($"Loading data from Excel file: {excelPath}");

                excelUtility = new ExcelUtility();

                // Load the data from the Excel file
                excelUtility.LoginLoadData(excelPath, "TestData");

                // Create and initialize LoginPageMethods
                logintest = new LoginPageMethods(GetDriver(), excelUtility);
            }
            catch (Exception ex)
            {
                // Log the failure in the extent report
                _test.Log(Status.Fail, $"Failed to load Excel file: {ex.Message}");
                Assert.Fail($"Failed to load Excel file: {ex.Message}");
                return;
            }

            // Test case numbers
            string goToPageTestcaseNumber       = "TC001";
            string usernameFieldTestcaseNumber  = "TC002";
            string passwordFieldTestcaseNumber  = "TC003";
            string loginButtonTestcaseNumber    = "TC004";

            try
            {
                TestcaseNumber = goToPageTestcaseNumber;
                logintest.GoToPage();
                _test.Log(Status.Pass, $"{TestcaseNumber} | QA Elit Dashboard is Verified");

                TestcaseNumber = usernameFieldTestcaseNumber;
                logintest.EnterUsername();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Username Field is Verified");

                TestcaseNumber = passwordFieldTestcaseNumber;
                logintest.EnterPassword();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Password Field is Verified");

                TestcaseNumber = loginButtonTestcaseNumber;
                logintest.ClickLoginButton();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Login Button is Verified");
            }
            catch (Exception ex)
            {
                DateTime time = DateTime.Now;
                string fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm") + ".png";
                string screenShotPath = CaptureScreenshot(GetDriver(), fileName);

                _test.Log(Status.Fail, $"{TestcaseNumber} | {ex.Message}");
                _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
            }
            finally
            {
                logintest.CloseBrowser();
            }
        }
    }
}
