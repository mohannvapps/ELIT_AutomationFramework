using AventStack.ExtentReports;
using ELIT_AutomationFramework.BaseClass;
using ELIT_AutomationFramework.Methods.Registration;
using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.Registration
{
    public class C_Registration_Approval : ReportsGenerationClass
    {
        SupReg_Methods regtest;
        ExcelUtility excelUtility;

        [Test]
        [Category("Registration_Approval")]
        public void Registration_Approval_Test()
        {
            string excelPath;
            try
            {
                // Define the pattern for the file name including timestamp and version
                string directoryPath = @"D:\1.ELIT_AutomationFramework\Excel\Registration_ExcelSheets";
                string fileNamePattern = "RegistrationTestData_*_v*.xlsx";

                // Get the Excel file path based on the pattern
                excelPath = ExcelUtility.GetExcelFilePathWithTimestampAndVersion(directoryPath, fileNamePattern);
                Console.WriteLine($"Latest Path read from directory: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"Excel file not found or file does not exist: {excelPath}");
                }

                Console.WriteLine($"Loading data from Excel file: {excelPath}");

                excelUtility = new ExcelUtility();
                excelUtility.RegistrationLoadData(excelPath, "TestData"); // Load the data from the Excel file
                regtest = new SupReg_Methods(GetDriver(), excelUtility);// Create and initialize LoginPageMethods
            }
            catch (Exception ex)
            {
                // Log the failure in the extent report
                _test.Log(Status.Fail, $"Failed to load Excel file: {ex.Message}");
                Assert.Fail($"Failed to load Excel file: {ex.Message}");
                return;
            }
            try
            {
                _test.Log(Status.Pass, "********** Supplier Registration Approval **********");
                regtest.GoToPage();
                regtest.UserName();
                regtest.Password();
                TestcaseNumber = "TC168";
                regtest.Login_as_Approver();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Logged In and Approval Option is Displayed");

                TestcaseNumber = "TC169";
                regtest.ApproverDashboard();
                regtest.Approval_Notification();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Dashboard is Displayed");

                TestcaseNumber = "TC170";
                regtest.ApproverDashboardRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Dashboare Page Refresh is Successful");

                TestcaseNumber = "TC171";
                regtest.RegistraitonApprovalEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Registration Approval tab is Enabled");

                TestcaseNumber = "TC172";
                regtest.Registration_ApprovalCLick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Registration Approval Tab is Verified");

                TestcaseNumber = "TC173";
                regtest.SearchFieldEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Registration Approval Tab is Verified");

                TestcaseNumber = "TC174";
                regtest.SearchAlphaNumeric();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Search Field is Allowing Alpha Numeric and Special Characters");

                TestcaseNumber = "TC175";
                regtest.Registration_Search();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Searched Text is Filtered from the Table");

                TestcaseNumber = "TC177";
                regtest.ApprovalGoBackEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approval Screen GoBack Button is Enabled");

                TestcaseNumber = "TC178";
                regtest.ApprovalGoBackClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on GoBack Button and Page is Redirected to Approver Dashboard");

                TestcaseNumber = "TC179";
                regtest.Registration_Search();
                regtest.Doc_ActionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Button is Enabled");

                TestcaseNumber = "TC180";
                regtest.Doc_Action();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve, Reject and View Approval History Options are Displayed");

                TestcaseNumber = "TC181";
                regtest.ViewApprovalHistory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | View Approval History Screen is Displayed");

                TestcaseNumber = "TC182";
                regtest.HistoryGoback();
                _test.Log(Status.Pass, $"{TestcaseNumber} | View Approval History GoBack Button is Verified");

                TestcaseNumber = "TC183";
                regtest.ActionClick();
                regtest.Reject();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Comments Screen is Displayed");

                TestcaseNumber = "TC184";
                regtest.RejectWithoutComments();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Toast Displayed When Rejected without Comments");

                TestcaseNumber = "TC185";
                regtest.RejectCancelEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Cancel Button is Enabled");

                TestcaseNumber = "TC186";
                regtest.RejectCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to Document Screen when clicked on Cancel Button");

                TestcaseNumber = "TC187";
                regtest.ActionClick();
                regtest.Approve();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Comments Screen is Displayed");

                TestcaseNumber = "TC188";
                regtest.ApprovalCommentsEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Comments Field is Enabled");

                TestcaseNumber = "TC189";
                regtest.ApproroveWithoutComments();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Toast Displayed When Approved without Comments");

                TestcaseNumber = "TC190";
                regtest.ApprovalCommentsUpto400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Comments Upto 400 Characters");

                TestcaseNumber = "TC191";
                regtest.ApprovalCommentsAbove400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Comments Above 400 Characters");

                TestcaseNumber = "TC192";
                regtest.ApprovalComments();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Comments is Verified");

                TestcaseNumber = "TC193";
                regtest.ApproveButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Submit Button is Enabled");

                TestcaseNumber = "TC194";
                regtest.ApproveButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to the Dashboard");

                TestcaseNumber = "TC197";
                regtest.LOGOUT();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Logged Out");

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
                regtest.closeBrowser();
            }
        }
    }
}
