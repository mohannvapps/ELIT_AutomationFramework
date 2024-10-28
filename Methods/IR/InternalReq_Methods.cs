using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace ELIT_AutomationFramework.Methods.IR
{
    public class InternalReq_Methods
    {
        public IWebDriver driver;
        public Dictionary<string, string> testData;
        public ExcelUtility excelUtility;

        string IRNUM;
        string IRNUM_Rejected;
        string username = "//input[@type='text']";
        string password = "//input[@type='password']";
        string login = "//button[text()='Login Now']";

        string requisition = "(//ul[contains(@class,'al-sidebar-list')]/li/div/i[contains(@class,'fa fa-lg fa-th-large')])[1]";
        string select_requisition = "//span[text()='Requisition']";
        string dashboard_Project = "//input[contains(@class,'MuiInputBase-input')]";

        string create = "//button[contains(span,'Create')]";
        string project = "//label[contains(text(),'Project')]/following::input[1]";
        string projectMandatory = "//label[text()='Project*']";
        string draftstatus = "//span[text()='Requisition Status']/following::button[text()='Month'][1]";
        string AIP_status = "//span[text()='Approval Status']/following::button[text()='Month'][1]";
        string statussearch = "(//input[contains(@class,'MuiInputBase-input')])[2]";
        string filteredelement = "//div[@class='rt-tr']/following::div[@role='gridcell'][1]";
        string headerproject = "//label[text()='Project*']/following::input[1]";
        string title = "//label[contains(text(),'Title')]/following::input[1]";
        string titleMandatory = "//label[text()='Title*']";
        string prepared_by = "//label[contains(text(),'Prepared By')]/following::span[1]";
        string prepared_byMandatory = "//label[text()='Prepared By*']";
        string prepared_byDefault = "//label[text()='Prepared By*']/following::span[text()='Singh Ms. Ashaka ']";
        string requested_by = "//label[contains(text(),'Requested By')]/following::input[1]";
        string requested_byMandatory = "//label[text()='Requested By*']";
        string operatingUnit = "//label[contains(text(),'Operating Unit')]";
        string operatingUnitmandatory = "//label[text()='Operating Unit*']";
        string operatingUniDefaultt = "//span[text()='Appstec Technology Services LLC']";
        string internalrequest = "//div[@class='react-switch-bg']";
        string operating_unit = "//span[contains(text(),'Appstec Technology Services LLC')]";
        string ship_to_location = "//label[contains(text(),'Ship To Location*')]/following::input[1]";
        string creationDate = "//label[contains(text(),'Creation Date')]/following::input[1]";
        string ship_to_locationMandatory = "//label[text()='Ship To Location*']";
        string IR_ToggleButton = "//div[@class='react-switch-bg']";
        string IR_ToggleGreenColor = "//div[contains(@style,'rgb(0, 136, 0)')]";
        string IR_ToggleRedColor = "//div[contains(@style,'rgb(220, 53, 69)')]";
        string note_to_approval = "//label[contains(text(),'Note To Approver')]/following::textarea[1]";
        string note_to_approvalMandatory = "//label[text()='Note To Approver*']";
        string description = "(//textarea[@name='description'])[1]";
        string descriptionMandatory = "//label[text()='Description*']";
        string fileupload = "(//input[@type='file'])[1]";
        string linefileupload = "(//input[@type='file'])[2]";
        string delete = "//*[name()='path' and contains(@d,'M6 19c0 1.')]";
        string delete1 = "(//*[name()='path' and contains(@d,'M6 19c0 1.')])[2]";
        string toast = "//div[contains(@class,'Toastify__toast-body')]";
        string deletedtoast = "//div[text()='Successfully Deleted']";
        string Submittedtoast = "//div[text()='Successfully Submitted']";
        string Line_delete = "(//*[name()='path' and contains(@d,'M6 19c0 1.1.9 2 2 2h8c1')])";
        string cancelButton = "//span[text()='Cancel']";
        string submitButton = "//span[text()='Submit']";
        string uploadline_table = "//div[@class='ReactTable -striped -highlight']";
        string uploadline_Clear = "//span[text()='Clear']";
        string uploadline_Submit = "//span[text()='Submit']";
        string uploadline_Item = "//div[text()='Onhand quantity']/following::input[1]";
        string uploadline_Qty = "//div[text()='Onhand quantity']/following::input[4]";
        string uploadline_needbyDate = "//div[text()='Onhand quantity']/following::input[5]";
        string uploadline_needbyDate2 = "//div[text()='Onhand quantity']/following::input[10]";
        string uploadline_OnhandQty = "//div[text()='Onhand quantity']/following::span[@class='labelTypeInput disabled'][2]";
        string qty_error = "//span[text()=' Please provide Quantity']";
        string needbydate_error = "//span[text()=' Please provide Need By Date']";
        string Uploadlinedelete = "//span[text()='Download template']/following::*[name()='path' and contains(@d,'M6')][2]";
        string lineDeleteicon = "//div[text()='Line Number']/following::*[name()='path' and contains(@d,'M6')][1]";

        string linesAccordion = "//div[text()='Line']";
        string go_button = "//span[text()='Go']";
        string accordionOpened = "//div[text()='Line']/following::span[text()='Action']";
        string actionDropdown = "//select[@class='react-form-input inputText']";
        string linecreate_select = "//span[text()='Action']/ancestor::div/div/select";

        string cl_linetype = "//span[text()='Goods']";
        string cl_item = "//label[contains(text(),'Item*')]/following::input[1]";
        string cl_itemMandatory = "//label[text()='Item*']";
        string cl_quantity = "//label[contains(text(),'Quantity*')]/following::input[1]";
        string cl_quantityMandatory = "//label[text()='Quantity*']";
        string Cl_Need_Date = "//label[contains(text(),'Need By Date')]/following::input[1]";
        string Cl_Need_DateMandatory = "//label[text()='Need By Date*']";
        string cl_brand = "//label[text()='Preferred Brand']/following::span[@class='labelTypeInput disabled'][1]";
        string cl_brandMandatory = "//label[text()='Preferred Brand']";
        string cl_category = "//label[contains(text(),'Category')]/following::input[1]";
        string cl_categorymandatory = "//label[text()='Category*']";
        string cl_categoryDisabled = "//label[text()='Category*']/following::span[@class='labelTypeInput disabled'][1]";
        string cl_unit = "//label[text()='Unit*']/following::input[1]";
        string cl_unitMandatory = "//label[text()='Unit*']";
        string cl_unitDisabled = "//label[text()='Unit*']/following::span[@class='labelTypeInput disabled'][1]";
        string cl_description = "(//textarea[@name='description'])[2]";

        string apply = "//span[text()='Apply']";
        string LineCreate_apply = "//button[contains(@class,'MuiButtonBase-root MuiButton-root MuiButton-contained themeButton_themebg m')]";
        string lineApply_toast = "//div[text()='Successfully Processed']";
        string File_To_Upload = "(//input[@type='file'])[2]";
        //string File_To_Upload     = "(//label[text()='Attachment']/following::input[@type='file'])[2]";
        string UploadLinesubmit = "//span[text()='Submit']";

        string attach = "(//div[text()='Attachments supported'])[2]";
        string attachment = "//label[text()='Attachment']";
        //string supplier_contact = "//label[text()='Supplier Contact']//parent::div/div/div/div/div/input";
        string File_Icon = "(//input[@type='file'])[2]";

        string goback = "//span[text()='Go Back']//parent::button";
        string gobackIcon = "//button[contains(@class,'ion-arrow-left-c')]";
        string action = "//span[text()='Action']//parent::button";
        string preview = "//li[text()='Preview']";
        string saveForLater = "//li[text()='Save for Later']";
        string submit = "//li[text()='Submit']";
        string cancel = "//li[text()='Cancel']";
        string update = "//li[text()='Update']";
        string approve = "//li[text()='Approve']";
        string reject = "//li[text()='Reject']";
        string viewapprovalhistory = "//li[text()='View Approval History']";

        string profile_icon = "(//div[contains(@class, 'MuiAvatar-root')])[1]";
        string logout = "//span[text()='Logout']";
        string IRnum = "//h2[contains(@class, 'color_title_text')]";
        string tooltip = "//*[name()='svg' and contains(@class,'MuiSvgIcon-root editIconTable')]";

        string approval = "//ul[contains(@class,'al-sidebar-list')]/li/div/i[contains(@class,'fa fa-lg fa-thumbs-o-up')]";
        string approvalnotification = "//span[text()='Approval Notificat']";
        string approvaldashboard = "//h2[text()='Approval']";

        string IR_approval = "//button[contains(.,'Requisition')]";
        string requisitionsearch = "(//input[@type='text'])[1]";
        string search_select = "//*[@id=\"root\"]/div/div[3]/div[1]/div/div/div[3]/div/div[1]/div[2]/div[1]/div/div[1]";

        string doc_action = "//span[text()='Action']/parent::button";
        string document_Approve = "//div[contains(@class, 'MuiPaper-root')]/ul/li[contains(text(),'Approve')]|//button[text()='Approve']";
        string document_reject = "//div[contains(@class, 'MuiPaper-root')]/ul/li[contains(text(),'Reject')] |//button[text()='Reject']";
        string comments = "//label[contains(text(),'Comments*')]/following::textarea[1]";
        string commentsmandatory = "//label[text()='Comments*']";
        string document_action_Approve = "//span[text()='Approve']";
        string cancel_submit = "//span[text()='Submit']";
        string close_submit = "//span[text()='Submit']";
        string document_action_Reject = "//span[text()='Reject']";

        Random random, random1 = new Random();
        public static string RandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz`~!@#$%^&*()_+-={}|[];':<>?,./";
            var randomStr = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomStr;
        }
        public static string RandomString1(Random random1, int length)
        {
            const string chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz' '";
            var randomStr1 = new string(Enumerable.Repeat(chars1, length).Select(s => s[random1.Next(s.Length)]).ToArray());
            return randomStr1;
        }

        public InternalReq_Methods(IWebDriver driver, ExcelUtility excelUtility)
        {
            this.driver = driver;
            this.excelUtility = excelUtility;
            LoadExcelTemplate();
        }
        public void LoadExcelTemplate()
        {
            try
            {
                // Load all file paths from the text file
                string[] filePaths = File.ReadAllLines(@"D:\1.ELIT_AutomationFramework\Excel\IR_ExcelSheets\AllIRExcelPaths.txt");
                if (filePaths.Length == 0)
                {
                    throw new FileNotFoundException("No Excel file paths found in the text file.");
                }

                // Get the latest path (last one in the list)
                string excelPath = filePaths.Last();
                Console.WriteLine($"Latest Path read from file: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"No Excel file found or file does not exist: {excelPath}");
                }

                string sheetName = "TestData";
                excelUtility.IRLoadData(excelPath, sheetName);
                testData = excelUtility.irtestData; // Set the testData dictionary

                // Log loaded data for debugging
                Console.WriteLine("Loaded test data:");
                foreach (var kvp in testData)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Excel data: {ex.Message}");
                throw;
            }
        }
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testData["URL"]);
            Thread.Sleep(1000);
            string ActualTitle = driver.Title;
            string ExpecteTitle = "Login | ELIT";
            if (ExpecteTitle.Equals(ActualTitle))
            {
                Console.WriteLine("QA Elit Login Page is Displayed");
            }
            else
            {
                Console.WriteLine("QA Elit URL is incorrect");
                throw new Exception("QA Elit URL is incorrect");
            }
        }
        public void UserName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(username)));
            IWebElement UsernameTextField = driver.FindElement(By.XPath(username));
            if (UsernameTextField.Enabled)
            {
                UsernameTextField.Click();
                UsernameTextField.SendKeys(testData["username"]);
                string EnteredName = UsernameTextField.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Z0-9@.]{1,100}$");
                if (rgx.IsMatch(EnteredName))
                {
                    Console.WriteLine("User Name is Verified");
                }
                else if (EnteredName.StartsWith(' '))
                {
                    Console.WriteLine("User Name Should not Starts with Space");
                }
                else
                {
                    Console.WriteLine("User Name TextField is Not Displayed");
                    throw new Exception("User Name TextField is Not Displayed");
                }
            }
            Thread.Sleep(500);
        }
        public void Approver_UserName()
        {
            IWebElement UsernameTextField = driver.FindElement(By.XPath(username));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(username)));

            if (UsernameTextField.Enabled)
            {
                UsernameTextField.Click();
                UsernameTextField.SendKeys(testData["Approver UserName"]);
                Console.WriteLine("Approver Username Entered");
            }
            else
            {
                Console.WriteLine("Approver Username Not Entered");
                throw new Exception("Approver Username Not Entered");
            }
            Thread.Sleep(500);
        }
        public void Password()
        {
            IWebElement PasswordTextField = driver.FindElement(By.XPath(password));
            if (PasswordTextField.Enabled)
            {
                PasswordTextField.SendKeys(testData["password"]);
                string EnteredPassword = PasswordTextField.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9@`!$%^&*()_=[.<>/?.]{1,12}$");
                if (rgx.IsMatch(EnteredPassword))
                {
                    Console.WriteLine("Password is Verified");
                }
                else if (EnteredPassword.StartsWith(' '))
                {
                    Console.WriteLine("Password Should not Starts with Space");
                }
                else
                {
                    Console.WriteLine("Password TextField is Not Displayed");
                    throw new Exception("Password TextField is Not Displayed");
                }
            }
            Thread.Sleep(500);
        }
        public void LogIn()
        {
            Thread.Sleep(100);
            IWebElement LoginButton = driver.FindElement(By.XPath(login));
            if (LoginButton.Enabled)
            {
                Console.WriteLine("Login Button is Verified");
                LoginButton.Click();
            }
            else
            {
                Console.WriteLine("Login Button is Not Enabled");
                throw new Exception("Login Button is Not Enabled");
            }
            Thread.Sleep(500);
        }
        public void LoginPageRefresh()
        {
            driver.Navigate().Refresh();
            string ActualTitle = driver.Title;
            string ExpectedTitle = "Login | ELIT";
            if (ExpectedTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Refresh Successful, Page Redirect to Login Page");
            }
            else
            {
                Console.WriteLine("Refresh Successful, But Page Not Redirect to Login Page");
                throw new Exception("Page Not Redirect to Login Page");
            }
        }
        public void HomePageRefresh()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            string ActualTitle = driver.Title;
            string ExpectedTitle = "Dashboard | ELIT";
            if (ExpectedTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Refresh Successful, Page Redirect to Login Page");
            }
            else
            {
                Console.WriteLine("Refresh Successful, But Page Not Redirect to Login Page");
                throw new Exception("Page Not Redirect to Login Page");
            }
        }
        public void ElitLogo()
        {
            IWebElement ELit_Logo = driver.FindElement(By.XPath("//img[@class='logo_pagetop']"));
            if (ELit_Logo.Displayed)
            {
                Console.WriteLine("Elit Logo is Displayed in the Homepage");
            }
            else
            {
                Console.WriteLine("Elit Logo is Not Displayed in the Homepage");
                throw new Exception("Elit Logo is Not Displayed in the Homepage");
            }
        }
        public void RequisitionTabEnabled()
        {
            IWebElement RequisitionSideMenu = driver.FindElement(By.XPath(requisition));
            Actions action = new Actions(driver);
            action.MoveToElement(RequisitionSideMenu).Perform();
            if (RequisitionSideMenu.Displayed)
            {
                Console.WriteLine("Requisition Tab is Enabled");
            }
            else
            {
                Console.WriteLine("Requisition Tab is Disabled");
                throw new Exception("Requisition Tab is Disabled");
            }
        }
        public void RequisitionTabClick()
        {
            IWebElement RequisitionSideMenu = driver.FindElement(By.XPath(requisition));
            Actions action = new Actions(driver);
            action.MoveToElement(RequisitionSideMenu).Click().Perform();
            IWebElement RequisitionOption = driver.FindElement(By.XPath(select_requisition));
            if (RequisitionOption.Displayed)
            {
                Console.WriteLine("Requisition Option is Displayed under the Requisition Tab");
            }
            else
            {
                Console.WriteLine("Requisition Option is Not Displayed under the Requisition Tab");
                throw new Exception("Requisition Option is Not Displayed");
            }
        }
        public void RequisitionOptionEnabled()
        {
            IWebElement RequisitionOption = driver.FindElement(By.XPath(select_requisition));
            if (RequisitionOption.Enabled)
            {
                Console.WriteLine("Requisition Option is Enabled");
            }
            else
            {
                Console.WriteLine("Requisition Option is Disabled");
                throw new Exception("Requisition Option is Disabled");
            }
        }
        public void RequisitionOptionClick()
        {
            IWebElement RequisitionOption = driver.FindElement(By.XPath(select_requisition));
            RequisitionOption.Click();
            Thread.Sleep(3000);
            IWebElement RequisitionDashboard = driver.FindElement(By.XPath("//h2[text()='Requisition']"));
            if (RequisitionDashboard.Displayed)
            {
                Console.WriteLine("Page Redirected to Requisition Dashboard");
            }
            else
            {
                Console.WriteLine("Page Not Redirected to Requisition Dashboard");
                throw new Exception("Page Not Redirected to Requisition Dashboard");
            }
        }

        public void RefreshRequisitionDashboard()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            string ActualTitle = driver.Title;
            string ExpectedTitle = "Dashboard | ELIT";
            if (ExpectedTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Refresh Successful, Page Redirect to Elit Dashboard");
            }
            else
            {
                Console.WriteLine("Refresh Successful, But Page Not Redirect to Elit Dashboard");
                throw new Exception("Page Not Redirect to Elit Dashboard");
            }
        }
        public void CreateButtonEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(create)));

            IWebElement CreateButton = driver.FindElement(By.XPath(create));
            if (CreateButton.Enabled)
            {
                Console.WriteLine("Create Button is Verified");
            }
            else
            {
                Console.WriteLine("Create Button is Disabled");
                throw new Exception("Create Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void CreateButtonClick()
        {
            IWebElement CreateButton = driver.FindElement(By.XPath(create));
            CreateButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//h2[text()='Requisition']")));
            Thread.Sleep(1000);
            IWebElement RequisitionScreen = driver.FindElement(By.XPath("//h2[text()='Requisition']"));
            if (RequisitionScreen.Displayed)
            {
                Console.WriteLine("Page Redirects to Create Requisition Page");
            }
            else
            {
                Console.WriteLine("Page Not Redirects to Create Requisition Page");
                throw new Exception("Page Not Redirects to Create Requisition Page");
            }
            Thread.Sleep(500);
        }
        public void ActoinButtonEnabled()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            if (ActionButton.Enabled)
            {
                Console.WriteLine("Action Button is Enabled");
            }
            else
            {
                Console.WriteLine("Action Button is Disabled");
                throw new Exception("Action Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void ActionButtonClick()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            ActionButton.Click();
            Thread.Sleep(500);
            IWebElement saveForlater = driver.FindElement(By.XPath("//li[text()='Save for Later']"));
            IWebElement preview = driver.FindElement(By.XPath("//li[text()='Preview']"));
            if (saveForlater.Displayed && preview.Displayed)
            {
                Console.WriteLine("Save For Later and Preview Options are Displayed");
            }
            else
            {
                Console.WriteLine("Save For Later and Preview Options are Not Displayed");
                throw new Exception("Save For Later and Preview Options are Not Displayed");
            }
            Thread.Sleep(1000);
        }
        public void ActionClick()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            ActionButton.Click();
        }
        public void ClickonApprovedIR()
        {

        }
        public void ActionOptions_approvedIR()
        {
            IWebElement Close = driver.FindElement(By.XPath("//li[text()='Close']"));
            IWebElement Return_Cancel = driver.FindElement(By.XPath("//li[text()='Return and Cancel']"));
            IWebElement ApprovalHistory = driver.FindElement(By.XPath("//li[text()='View Approval History']"));
            if (Close.Displayed && Return_Cancel.Displayed && ApprovalHistory.Displayed)
            {
                Console.WriteLine("Close, Return & Cancel and View Approval history Options are Displayed");
            }
            else
            {
                Console.WriteLine("Close, Return & Cancel and View Approval history Options are Not Displayed");
                throw new Exception("Close, Return & Cancel and View Approval history Options are Not Displayed");
            }
        }
        public void ApprovedIR_CloseEnabled()
        {
            IWebElement Close = driver.FindElement(By.XPath("//li[text()='Close']"));
            if (Close.Enabled)
            {
                Console.WriteLine("IR Close Option is Enabled");
            }
            else
            {
                Console.WriteLine("IR Close Option is Disabled");
                throw new Exception("IR Close Option is Disabled");
            }
        }
        public void ApprovedIR_CloseClick()
        {
            IWebElement Close = driver.FindElement(By.XPath("//li[text()='Close']"));
            Close.Click();
            Thread.Sleep(2000);
            IWebElement CloseComments = driver.FindElement(By.XPath("//label[text()='Comments*']/following::textarea[1]"));
            if (CloseComments.Displayed)
            {
                Console.WriteLine("Page is Redirected to the Comments Screen");
            }
            else
            {
                Console.WriteLine("Page is Not Redirected to the Comments Screen");
                throw new Exception("Page is Not Redirected to the Comments Screen");
            }
        }
        public void CloseSubmit_WithoutData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(close_submit)));
            IWebElement SubmitButton = driver.FindElement(By.XPath(close_submit));
            SubmitButton.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[text()='Please provide Comments!']"));
            if (Error.Displayed)
            {
                Error.Click();
                Thread.Sleep(1000);
                Console.WriteLine("Error Message Displayed when Submitted Without Data");
            }
            else
            {
                Console.WriteLine("Error Message Not Displayed when Submitted Without Data");
                throw new Exception("Error Message Not Displayed when Submitted Without Data");
            }
        }
        public void CloseCommentsEnabled()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Enabled)
            {
                Console.WriteLine("Comments Field is Enabled");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void CloseCommentsMandatory()
        {
            IWebElement CommentsMandatory = driver.FindElement(By.XPath(commentsmandatory));
            if (CommentsMandatory.Displayed)
            {
                Console.WriteLine("Comments mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Comments mandatory Symbol is Not Displayed");
                throw new Exception("Comments mandatory Symbol is Not Displayed");
            }
        }
        public void CloseCommentsSpace()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys(" ");
            string EnteredCompName = Comments.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Company Name is not taking Space in the beginning");
            }
            else
            {
                Console.WriteLine("Company Name is taking Space in the beginning");
            }
        }
        public void CloseCommentsUpto400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C400chars = RandomString1(random1, 400);
            Comments.SendKeys(C400chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Comments Upto 400 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Upto 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CloseCommentsAbove400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C405chars = RandomString1(random1, 405);
            Comments.SendKeys(C405chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Above 400 Characters");
            }
            else
            {
                Console.WriteLine("Allowewd to Enter the Comments Above 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CloseCommentsEdit()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys("test");
            Thread.Sleep(500);
            Comments.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Comments.SendKeys(Keys.Backspace);
            Comments.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Comments.SendKeys("es");
            string Actualtext = Comments.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Comments Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Comments Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Comments Field Allowed to Edit the Text in the Middle");
            }
            Comments.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CloseComments()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Displayed)
            {
                Comments.SendKeys(testData["IR Close Comments"]);
                Console.WriteLine("IR Close Comments Field is Verified");
            }
            else
            {
                Console.WriteLine("IR Close Comments Field is Disabled");
                throw new Exception("IR Close Comments Field is Disabled");
            }
        }
        public void Close_SubmitButtonEnabled()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            if (SubmitButton.Enabled)
            {
                Console.WriteLine("Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Submit Button is Disabled");
                throw new Exception("Submit Button is Disabled");
            }
        }
        public void CLose_SubmitButtonClick()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            SubmitButton.Click();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Closed Successfully']")));
            IWebElement Toast = driver.FindElement(By.XPath("//div[text()='Closed Successfully']"));
            if (Toast.Displayed)
            {
                Console.WriteLine("IR Cancelled Successfully Toast is Displayed");
            }
            else
            {
                Console.WriteLine("IR Cancelled Successfully Toast is Displayed");
                throw new Exception("IR Cancelled Successfully Toast is Displayed");
            }
            Thread.Sleep(2000);
        }
        public void ActionApprove()
        {
            IWebElement ApproveButton = driver.FindElement(By.XPath(approve));
            ApproveButton.Click();
        }
        public void ActionReject()
        {
            IWebElement ApproveReject = driver.FindElement(By.XPath(reject));
            ApproveReject.Click();
        }
        public void RejectComments()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Displayed)
            {
                Comments.SendKeys(testData["IR Reject Comments"]);
                Console.WriteLine("Comments Field is Verified");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void GobackButtonEnabled()
        {
            IWebElement GobackButton = driver.FindElement(By.XPath(goback));
            if (GobackButton.Enabled)
            {
                Console.WriteLine("Goback Button is Enabled");
            }
            else
            {
                Console.WriteLine("Goback Button is Disabled");
                throw new Exception("Goback Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void GobackIcon()
        {
            IWebElement GobackButton = driver.FindElement(By.XPath(gobackIcon));
            GobackButton.Click();
        }
        public void GobackButton()
        {
            IWebElement GobackButton = driver.FindElement(By.XPath(goback));
            GobackButton.Click();
            Thread.Sleep(2000);
        }
        public void GobackButtonClick()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(goback)));
            IWebElement GobackButton = driver.FindElement(By.XPath(goback));
            GobackButton.Click();
            Thread.Sleep(2000);
            IWebElement ReqDashboard = driver.FindElement(By.XPath("//h2[text()='Requisition']"));
            if (ReqDashboard.Displayed)
            {
                Console.WriteLine("Page Redirects to Requisition Dashboard");
            }
            else
            {
                Console.WriteLine("Page Not Redirects to Requisition Dashboard");
                throw new Exception("Page Not Redirects to Requisition Dashboard");
            }
            Thread.Sleep(500);
        }
        public void DashboardProjectEnabled()
        {
            IWebElement Pro = driver.FindElement(By.XPath(dashboard_Project));
            if (Pro.Enabled)
            {
                Console.WriteLine("Project Field is Enabled");
            }
            else
            {
                Console.WriteLine("Project Field is Disabled");
                throw new Exception("Project Field is Disabled");
            }
        }
        public void DashboardProjectClick()
        {
            IWebElement Pro = driver.FindElement(By.XPath(dashboard_Project));
            Pro.Click();
            Thread.Sleep(500);
            if (Pro.Displayed)
            {
                Console.WriteLine("Project Field is Clicked");
            }
            else
            {
                Console.WriteLine("Project Field is Not Displayed");
                throw new Exception("Project Field is Not Displayed");
            }
        }
        public void DashboardProjectSelect()
        {
            IWebElement Pro = driver.FindElement(By.XPath(dashboard_Project));
            if (Pro.Enabled)
            {
                Pro.Click();
                Thread.Sleep(800);
                Pro.SendKeys(Keys.ArrowDown);
                Pro.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Pro.SendKeys(Keys.Enter);
                Console.WriteLine("Project Field is Verified");
            }
            else
            {
                Console.WriteLine("Project Field is Disabled");
                throw new Exception("Project Field is Disabled");
            }
        }
        public void Project()
        {
            IWebElement Pro = driver.FindElement(By.XPath(dashboard_Project));
            if (Pro.Enabled)
            {
                Actions act = new Actions(driver);
                Pro.Click();
                Thread.Sleep(500);
                act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                act.SendKeys(Keys.Delete).Perform();
                Thread.Sleep(500);
                Pro.SendKeys(testData["project"]);
                Thread.Sleep(500);
                Pro.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Pro.SendKeys(Keys.Enter);
                Console.WriteLine("Project Field is Verified");
            }
            else
            {
                Console.WriteLine("Project Field is Disabled");
                throw new Exception("Project Field is Disabled");
            }
        }
        public void Draft()
        {
            Thread.Sleep(1000);
            IWebElement DraftStatus = driver.FindElement(By.XPath(draftstatus));
            Actions act = new Actions(driver);
            act.MoveToElement(DraftStatus).Perform();
            act.MoveByOffset(0, 100).Click().Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            IWebElement StatusSearch = driver.FindElement(By.XPath(statussearch));
            if (StatusSearch.Displayed)
            {
                StatusSearch.Click();
                js.ExecuteScript("window.scrollTo(0, 800)");
                StatusSearch.SendKeys("1306");
                Thread.Sleep(2000);
                StatusSearch.SendKeys(Keys.Control + "a");
                StatusSearch.SendKeys(Keys.Clear);
                StatusSearch.SendKeys("1306");
                Thread.Sleep(1000);
                Console.WriteLine("PR Draft Search Field is Verified");
            }
            else
            {
                Console.WriteLine("PR Draft Search Field is Disabled");
                throw new Exception("PR Draft Search Field is Disabled");
            }
            Thread.Sleep(2000);
            IWebElement FilteredElement = driver.FindElement(By.XPath(filteredelement));
            FilteredElement.Click();
        }
        public void Approved()
        {          
            bool elementIdentified = driver.FindElements(By.XPath("//span[text()='Approved:']")).Any();
            if (elementIdentified)
            {
                IWebElement FilteredElement = driver.FindElement(By.XPath("//span[text()='Approved:']"));
                FilteredElement.Click();
            }
            else
            {
                Console.WriteLine("Approved Status Element Not Displayed");
            }        
        }
        public void ApprovalinProgress()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(AIP_status)));
            IWebElement ApprovalINProgressStatus = driver.FindElement(By.XPath(AIP_status));
            Actions act = new Actions(driver);
            act.MoveToElement(ApprovalINProgressStatus).Click().Perform();
            act.MoveByOffset(0, 100).Click().Perform();
            //act.MoveToLocation(700, 350).Click().Perform();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            IWebElement StatusSearch = driver.FindElement(By.XPath(statussearch));
            if (StatusSearch.Displayed)
            {
                StatusSearch.Click();
                js.ExecuteScript("window.scrollTo(0, 800)");
                StatusSearch.SendKeys("1306");
                Thread.Sleep(2000);
                StatusSearch.SendKeys(Keys.Control + "a");
                StatusSearch.SendKeys(Keys.Clear);
                StatusSearch.SendKeys("1306");
                Thread.Sleep(1000);
            }
        }
        public void RequisitionAccordions()
        {
            IWebElement HeaderAccordion = driver.FindElement(By.XPath("//div[text()='Header']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
            IWebElement LineAccordion = driver.FindElement(By.XPath("//div[text()='Line']"));
            if (HeaderAccordion.Displayed && LineAccordion.Displayed)
            {
                Console.WriteLine("All the Requisition Accordions are Displayed");
                js.ExecuteScript("window.scrollTo(0,0)");
            }
            else
            {
                Console.WriteLine("All the Requisition Accordions are Not Displayed");
                throw new Exception("All the Requisition Accordions are Not Displayed");
            }
        }
        public void Header_Fields()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(title)));
            IWebElement project = driver.FindElement(By.XPath(headerproject));
            IWebElement Title = driver.FindElement(By.XPath(title));
            IWebElement requestedBy = driver.FindElement(By.XPath(requested_by));
            IWebElement ShipToLoc = driver.FindElement(By.XPath(ship_to_location));
            IWebElement NoteToApp = driver.FindElement(By.XPath(note_to_approval));
            IWebElement Desription = driver.FindElement(By.XPath(description));
            IWebElement Attachment = driver.FindElement(By.XPath(attachment));

            if (project.Displayed && Title.Displayed && requestedBy.Displayed && ShipToLoc.Displayed && NoteToApp.Displayed && Desription.Displayed && Attachment.Displayed)
            {
                Console.WriteLine("All the header Fields are Displayed");
            }
            else
            {
                Console.WriteLine("All the header Fields are Not Displayed");
                throw new Exception("All the header Fields are Not Displayed");
            }
        }
        public void SaveForLater_WithoutData()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            ActionButton.Click();
            Thread.Sleep(500);
            IWebElement SaveForLater = driver.FindElement(By.XPath(saveForLater));
            SaveForLater.Click();
            Thread.Sleep(500);
            IWebElement ProjectError = driver.FindElement(By.XPath("//span[text()='Please provide Project']"));
            IWebElement TitleError = driver.FindElement(By.XPath("//span[text()='Please provide Title']"));
            IWebElement ReqByError = driver.FindElement(By.XPath("//span[text()='Please provide Requested By']"));
            IWebElement ShipToLocError = driver.FindElement(By.XPath("//span[text()='Please provide Ship To Location']"));
            IWebElement NoteError = driver.FindElement(By.XPath("//span[text()='Please provide Note To Approver']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            IWebElement DescriptionError = driver.FindElement(By.XPath("//span[text()='Please provide Description']"));
            js.ExecuteScript("window.scrollTo(0,0)");
            if (ProjectError.Displayed && TitleError.Displayed && ReqByError.Displayed && ShipToLocError.Displayed && NoteError.Displayed && DescriptionError.Displayed)
            {
                Console.WriteLine("Mandatory Fields Error message is Displayed when Clicked on Save For later");
            }
            else
            {
                Console.WriteLine("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
                throw new Exception("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
            }
        }
        public void Preview_WithoutData()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            ActionButton.Click();
            Thread.Sleep(500);
            IWebElement Preview = driver.FindElement(By.XPath(preview));
            Preview.Click();
            Thread.Sleep(500);
            IWebElement ProjectError = driver.FindElement(By.XPath("//span[text()='Please provide Project']"));
            IWebElement TitleError = driver.FindElement(By.XPath("//span[text()='Please provide Title']"));
            IWebElement ReqByError = driver.FindElement(By.XPath("//span[text()='Please provide Requested By']"));
            IWebElement ShipToLocError = driver.FindElement(By.XPath("//span[text()='Please provide Ship To Location']"));
            IWebElement NoteError = driver.FindElement(By.XPath("//span[text()='Please provide Note To Approver']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            IWebElement DescriptionError = driver.FindElement(By.XPath("//span[text()='Please provide Description']"));
            js.ExecuteScript("window.scrollTo(0,0)");
            if (ProjectError.Displayed && TitleError.Displayed && ReqByError.Displayed && ShipToLocError.Displayed && NoteError.Displayed && DescriptionError.Displayed)
            {
                Console.WriteLine("Mandatory Fields Error message is Displayed when Clicked on Save For later");
            }
            else
            {
                Console.WriteLine("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
                throw new Exception("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
            }
        }
        public void Header_ProjectEnebled()
        {
            IWebElement Project = driver.FindElement(By.XPath(project));
            if (Project.Enabled)
            {
                Console.WriteLine("Header Project is Enabled");
            }
            else
            {
                Console.WriteLine("Header Project is Disabled");
                throw new Exception("Header Project is Disabled");
            }
        }
        public void Header_ProjectMandatory()
        {
            IWebElement ProjectMandatory = driver.FindElement(By.XPath(projectMandatory));
            if (ProjectMandatory.Displayed)
            {
                Console.WriteLine("Header Project Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Header Project Field Mandatory Symbol is Not displayed");
                throw new Exception("Header Project Field Mandatory Symbol is Not displayed");
            }
        }
        public void Header_ProjectSelect()
        {
            IWebElement Project = driver.FindElement(By.XPath(project));
            if (Project.Displayed)
            {
                Project.Click();
                Thread.Sleep(500);
                Project.SendKeys(Keys.ArrowDown);
                Project.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Project.SendKeys(Keys.Enter);
                Console.WriteLine("Header Project is Enabled");
            }
            else
            {
                Console.WriteLine("Header Project is Disabled");
                throw new Exception("Header Project is Disabled");
            }
        }
        public void Header_Project()
        {
            IWebElement Project = driver.FindElement(By.XPath(project));
            Project.Click();
            if (Project.Displayed)
            {
                Actions act = new Actions(driver);
                act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                act.SendKeys(Keys.Delete).Perform();
                Project.SendKeys(testData["project"]);
                Project.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Project.SendKeys(Keys.Enter);
                Console.WriteLine("Header Project is Selected");
            }
            else
            {
                Console.WriteLine("Header Project is Disabled");
                throw new Exception("Header Project is Disabled");
            }
        }
        public void Header_TitleEnebled()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            if (Title.Enabled)
            {
                Console.WriteLine("Header Title is Enabled");
            }
            else
            {
                Console.WriteLine("Header Title is Disabled");
                throw new Exception("Header Title is Disabled");
            }
        }
        public void Header_TitleMandatory()
        {
            IWebElement TitleMandatory = driver.FindElement(By.XPath(titleMandatory));
            if (TitleMandatory.Displayed)
            {
                Console.WriteLine("Header Title Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Header Title Field Mandatory Symbol is Not displayed");
                throw new Exception("Header Title Field Mandatory Symbol is Not displayed");
            }
        }
        public void Header_TitleSpace()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            Title.SendKeys(" @");
            string Enteredtext = Title.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Title is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Title is taking Space and Special Characters in the beginning");
                throw new Exception("Title is taking Space and Special Characters in the beginning");
            }
        }
        public void Header_TitleUpto240()
        {
            Actions act = new Actions(driver);
            IWebElement Title = driver.FindElement(By.XPath(title));
            var C80chars = RandomString1(random1, 240);
            Title.SendKeys(C80chars);
            string Enteredname = Title.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Title Upto 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Title Upto 240 Characters");
                throw new Exception("Not Allowewd to Enter the Title Upto 240 Characters");
            }
            Title.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Header_TitleAbove240()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            var C80chars = RandomString1(random1, 245);
            Title.SendKeys(C80chars);
            string Enteredtext = Title.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            Regex spcl = new Regex(@"^[^\w\s]");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Title Above 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Title Above 240 Characters");
                throw new Exception("Not Allowewd to Enter the Title Above 240 Characters");
            }
            Title.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Header_Title()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            if (Title.Displayed)
            {
                Title.SendKeys(testData["IR Title"]);
                Console.WriteLine("Header Title Field is Verified");
            }
            else
            {
                Console.WriteLine("Header Title Field is Disabled");
                throw new Exception("Header Title Field is Disabled");
            }
        }
        public void Prepared_byDisabled()
        {
            IWebElement PreparedBy = driver.FindElement(By.XPath("//label[text()='Prepared By*']/following::span[@class='labelTypeInput disabled'][1]"));
            if (PreparedBy.Displayed)
            {
                Console.WriteLine("Prepared By Field is Disabled");
            }
            else
            {
                Console.WriteLine("Prepared By Field is Enabled");
                throw new Exception("Prepared By Field is Enabled");
            }
        }
        public void Prepared_byMandatory()
        {
            IWebElement PreparedBy = driver.FindElement(By.XPath(prepared_byMandatory));
            if (PreparedBy.Displayed)
            {
                Console.WriteLine("Prepared By Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Prepared By Field mandatory Symbol is Not displayed");
                throw new Exception("Prepared By Field mandatory Symbol is Not displayed");
            }
        }
        public void Prepared_byDefault()
        {
            IWebElement PreparedByDefault = driver.FindElement(By.XPath(prepared_byDefault));
            if (PreparedByDefault.Displayed)
            {
                Console.WriteLine("Prepared By is Displayed as Buyer By Default");
            }
            else
            {
                Console.WriteLine("Prepared By is Not Displayed as Buyer By Default");
                throw new Exception("Prepared By is Not Displayed as Buyer By Default");
            }
        }
        public void requested_byEnabled()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(requested_by));
            if (Requestedby.Enabled)
            {

                Console.WriteLine("requested By Field is Enabled");
            }
            else
            {
                Console.WriteLine("requested By Field is Disabled");
                throw new Exception("requested By Field is Disabled");
            }
        }
        public void Requested_byMandatory()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(requested_byMandatory));
            if (Requestedby.Displayed)
            {
                Console.WriteLine("Prepared By Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Prepared By Field mandatory Symbol is Not displayed");
                throw new Exception("Prepared By Field mandatory Symbol is Not displayed");
            }
        }
        public void Requested_bySelect()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(requested_by));
            if (Requestedby.Displayed)
            {
                Requestedby.Click();
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.Enter);
                Console.WriteLine("Requested_by Field is Verified");
            }
            else
            {
                Console.WriteLine("Requested_by Field is Disabled");
                throw new Exception("Requested_by Field is Disabled");
            }
        }
        public void Requested_byReselect()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(requested_by));
            if (Requestedby.Displayed)
            {
                Requestedby.Click();
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.ArrowDown);
                Requestedby.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.Enter);
                Console.WriteLine("Requested_by Field is Verified");
            }
            else
            {
                Console.WriteLine("Requested_by Field is Disabled");
                throw new Exception("Requested_by Field is Disabled");
            }
        }
        public void OperatingUnitDisabled()
        {
            IWebElement OperatingUnit = driver.FindElement(By.XPath("//label[text()='Operating Unit*']/following::span[@class='labelTypeInput disabled'][1]"));
            if (OperatingUnit.Displayed)
            {
                Console.WriteLine("Operating Unit is Disabled");
            }
            else
            {
                Console.WriteLine("Operating Unit is Enabled");
                throw new Exception("Operating Unit is Enabled");
            }
        }
        public void OperatingUnitMandatory()
        {
            IWebElement OperatingUnit = driver.FindElement(By.XPath(operatingUnitmandatory));
            if (OperatingUnit.Displayed)
            {
                Console.WriteLine("Operating Unit Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Operating Unit Field mandatory Symbol is Not displayed");
                throw new Exception("Operating Unit Field mandatory Symbol is Not displayed");
            }
        }
        public void OperatingUnitDefault()
        {
            IWebElement OperatingUnitDefault = driver.FindElement(By.XPath(operatingUniDefaultt));
            if (OperatingUnitDefault.Displayed)
            {
                Console.WriteLine("Operating Unit is Displayed as Appstec Technology Services LLC By Default");
            }
            else
            {
                Console.WriteLine("Operating Unit is Not Displayed as Appstec Technology Services LLC By Default");
                throw new Exception("Appstec Technology Services LLC Not Displayed");
            }
        }
        public void Ship_To_LocationEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(ship_to_location)));
            IWebElement location = driver.FindElement(By.XPath(ship_to_location));
            if (location.Enabled)
            {

                Console.WriteLine("Ship To Location is Enabled");
            }
            else
            {
                Console.WriteLine("Ship To Location is Disabled");
                throw new Exception("Ship To Location is Disabled");
            }
        }
        public void Ship_To_LocationMandatory()
        {
            IWebElement locationSymbol = driver.FindElement(By.XPath(ship_to_locationMandatory));
            if (locationSymbol.Displayed)
            {

                Console.WriteLine("Ship To Location Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Ship To Location Mandatory Symbol is Not displayed");
                throw new Exception("Ship To Location Mandatory Symbol is Not displayed");
            }
        }
        public void Ship_To_LocationSelect()
        {
            IWebElement location = driver.FindElement(By.XPath(ship_to_location));
            if (location.Displayed)
            {
                location.Click();
                Thread.Sleep(500);
                location.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                location.SendKeys(Keys.Enter);
                Console.WriteLine("Ship To Location is Selected");
            }
            else
            {
                Console.WriteLine("Ship To Location is Not Selected");
                throw new Exception("Ship To Location is Not Selected");
            }
        }
        public void Ship_To_LocationResselect()
        {
            IWebElement location = driver.FindElement(By.XPath(ship_to_location));
            if (location.Displayed)
            {
                location.Click();
                Thread.Sleep(500);
                location.SendKeys(Keys.ArrowDown);
                location.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                location.SendKeys(Keys.Enter);
                Console.WriteLine("Ship To Location is Re-Selected");
            }
            else
            {
                Console.WriteLine("Ship To Location is Not Re-Selected");
                throw new Exception("Ship To Location is Not Re-Selected");
            }
        }
        public void Ship_To_Location()
        {
            IWebElement location = driver.FindElement(By.XPath(ship_to_location));
            if (location.Enabled)
            {
                location.Click();
                Actions act = new Actions(driver);
                act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                act.SendKeys(Keys.Delete).Perform();
                Thread.Sleep(500);
                location.SendKeys(testData["Ship To Location"]);
                Thread.Sleep(500);
                location.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                location.SendKeys(Keys.Enter);
                Console.WriteLine("Ship To Location is Match With Project");
            }
            else
            {
                Console.WriteLine("Ship To Location is Not Match With Project");
                throw new Exception("Ship To Location is Not Match With Project");
            }
        }
        public void CreationDateDisabled()
        {
            IWebElement CreationDate = driver.FindElement(By.XPath("//label[text()='Creation Date']/following::input[@class='labelTypeInput ']"));
            if (CreationDate.Displayed)
            {
                Console.WriteLine("Creation Date is Disabled");
            }
            else
            {
                Console.WriteLine("Creation Date is Enabled");
                throw new Exception("Creation Date is Enabled");
            }
        }
        public void CreationDateCurrent()
        {
            IWebElement CreationDate = driver.FindElement(By.XPath(creationDate));
            Thread.Sleep(500);
            string actualDate = CreationDate.GetAttribute("value");
            string currentDate = DateTime.Now.ToString("dd-MMM-yyyy");
            if (actualDate.Equals(currentDate))
            {
                Console.WriteLine("Current Date is Displayed as Creation Date");
            }
            else
            {
                Console.WriteLine("Current Date is Not Displayed as Creation Date");
                throw new Exception("Current Date is Not Displayed as Creation Date");
            }
        }
        public void IRStatusDisabled()
        {
            IWebElement IRStatus = driver.FindElement(By.XPath("//label[text()='PR Status']/following::span[@class='labelTypeInput disabled'][1]"));
            if (IRStatus.Displayed)
            {
                Console.WriteLine("IR Status is Disabled");
            }
            else
            {
                Console.WriteLine("IR Status is Enabled");
                throw new Exception("IR Status is Enabled");
            }
        }
        public void IRStatusDraft()
        {
            IWebElement IRStatus = driver.FindElement(By.XPath("//span[text()='Draft']"));
            if (IRStatus.Displayed)
            {
                Console.WriteLine("IR Status is Displayed as Draft");
            }
            else
            {
                Console.WriteLine("IR Status is Not Displayed as Draft");
                throw new Exception("IR Status is Not Displayed as Draft");
            }
        }
        public void InternamReq_ButtonEnabled()
        {
            IWebElement IRButton = driver.FindElement(By.XPath(IR_ToggleButton));
            if (IRButton.Enabled)
            {
                Console.WriteLine("Internal request Button is Enabled");
            }
            else
            {
                Console.WriteLine("Internal request Button is Disabled");
                throw new Exception("Internal request Button is Disabled");
            }
        }
        public void InternamReq_ButtonSelected()
        {
            IWebElement IRButton = driver.FindElement(By.XPath(IR_ToggleButton));
            IRButton.Click();
            Thread.Sleep(1000);
            IWebElement IR_GreenColor = driver.FindElement(By.XPath(IR_ToggleGreenColor));
            if (IR_GreenColor.Displayed)
            {
                Console.WriteLine("Internal Requisition Button is Selected");
            }
            else
            {
                Console.WriteLine("Internal Requisition Button is Not Selected");
                throw new Exception("Internal Requisition Button is Not Selected");
            }
        }
        public void InternamReq_ButtonUnselected()
        {
            IWebElement IRButton = driver.FindElement(By.XPath(IR_ToggleButton));
            IRButton.Click();
            Thread.Sleep(1000);
            IWebElement IR_RedColor = driver.FindElement(By.XPath(IR_ToggleRedColor));
            if (IR_RedColor.Displayed)
            {
                Console.WriteLine("Internal Requisition Button is Un-Selected");
            }
            else
            {
                Console.WriteLine("Internal Requisition Button is Not Un-Selected");
                throw new Exception("Internal Requisition Button is Not Un-Selected");
            }
            IRButton.Click();
        }
        public void Note_To_ApproverEnabled()
        {
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            if (Note.Enabled)
            {
                Console.WriteLine("Note to Approver is Enabled");
            }
            else
            {
                Console.WriteLine("Note to Approver is Disabled");
                throw new Exception("Note to Approver is Disabled");
            }
        }
        public void Note_To_ApproverMandatory()
        {
            IWebElement NoteMandatory = driver.FindElement(By.XPath(note_to_approvalMandatory));
            if (NoteMandatory.Displayed)
            {
                Console.WriteLine("Note to Approver Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Note to Approver Field Mandatory Symbol is Not displayed");
                throw new Exception("Note to Approver Field Mandatory Symbol is Not displayed");
            }
        }
        public void Note_To_ApproverSpace()
        {
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            Note.SendKeys(" ");
            string Enteredtext = Note.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Note to Approver is not taking Space in the beginning");
            }
            else
            {
                Console.WriteLine("Note to Approver is taking Space in the beginning");
                throw new Exception("Note to Approver is taking Space in the beginning");
            }
        }
        public void Note_To_ApproverUpto1000()
        {
            Actions act = new Actions(driver);
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            var C1000chars = RandomString1(random1, 1000);
            Note.SendKeys(C1000chars);
            string Enteredname = Note.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,1000}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Note to Approver Upto 1000 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Note to Approver Upto 1000 Characters");
                throw new Exception("Not Allowewd to Enter the Note to Approver Upto 1000 Characters");
            }
            Note.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Note_To_ApproverAbove1000()
        {
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            var C1000chars = RandomString1(random1, 1005);
            Note.SendKeys(C1000chars);
            string Enteredtext = Note.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,1000}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Note to Approver Above 1000 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Note to Approver Above 1000 Characters");
                throw new Exception("Not Allowewd to Enter the Note to Approver Above 1000 Characters");
            }
            Note.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Note_To_ApproverEdit()
        {
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            Note.SendKeys("test");
            Thread.Sleep(500);
            Note.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Note.SendKeys(Keys.Backspace);
            Note.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Note.SendKeys("es");
            string Actualtext = Note.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Note To Approver Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Note To Approver Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Note To Approver Field Not Allowed to Edit the Text in the Middle");
            }
            Note.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Note_To_Approver()
        {
            IWebElement Note = driver.FindElement(By.XPath(note_to_approval));
            if (Note.Displayed)
            {
                Note.Click();
                Thread.Sleep(500);
                Note.SendKeys(testData["Approver Note"]);
                Console.WriteLine("Note To Approver is Verified");
            }
            else
            {
                Console.WriteLine("Note To Approver is Disabled");
                throw new Exception("Note To Approver is Disabled");
            }
        }
        public void DescriptionEnabled()
        {
            IWebElement Description = driver.FindElement(By.XPath(description));
            if (Description.Enabled)
            {
                Console.WriteLine("Description Field is Enabled");
            }
            else
            {
                Console.WriteLine("Description Field is Disabled");
                throw new Exception("Description Field is Disabled");
            }
        }
        public void DescriptionMandatory()
        {
            IWebElement DescriptionMandatory = driver.FindElement(By.XPath(descriptionMandatory));
            if (DescriptionMandatory.Displayed)
            {
                Console.WriteLine("Description Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Description Field Mandatory Symbol is Not displayed");
                throw new Exception("Description Field Mandatory Symbol is Not displayed");
            }
        }
        public void DescriptionSpace()
        {
            IWebElement Description = driver.FindElement(By.XPath(description));
            Description.SendKeys(" ");
            string Enteredtext = Description.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Description is not taking Space  the beginning");
            }
            else
            {
                Console.WriteLine("Description is taking Space in the beginning");
                throw new Exception("Description is taking Space in the beginning");
            }
        }
        public void DescriptionUpto240()
        {
            Actions act = new Actions(driver);
            IWebElement Description = driver.FindElement(By.XPath(description));
            var C240chars = RandomString1(random1, 240);
            Description.SendKeys(C240chars);
            string Enteredname = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Description Upto 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Description Upto 240 Characters");
                throw new Exception("Not Allowewd to Enter the Description Upto 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void DescriptionAbove240()
        {
            IWebElement Description = driver.FindElement(By.XPath(description));
            var C240chars = RandomString1(random1, 245);
            Description.SendKeys(C240chars);
            string Enteredtext = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Description Above 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Description Above 240 Characters");
                throw new Exception("Not Allowewd to Enter the Description Above 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void DescriptionEdit()
        {
            IWebElement Description = driver.FindElement(By.XPath(description));
            Description.SendKeys("test");
            Thread.Sleep(500);
            Description.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Description.SendKeys(Keys.Backspace);
            Description.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Description.SendKeys("es");
            string Actualtext = Description.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Description Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Description Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Description Field Allowed to Edit the Text in the Middle");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Description()
        {
            IWebElement Description = driver.FindElement(By.XPath(description));
            if (Description.Enabled)
            {
                Description.Click();
                Thread.Sleep(500);
                Description.SendKeys(testData["Description"]);
                string EnteredDesc = Description.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
                Regex spcl = new Regex(@"^[^\w\s]");
                if (rgx.IsMatch(EnteredDesc))
                {
                    Console.WriteLine("Description Field is Verified");
                }
                if (spcl.IsMatch(EnteredDesc))
                {
                    Console.WriteLine("Description Field Should not Starts with Space");
                }
            }
            else
            {
                Console.WriteLine("Description Field is Disabled");
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
        }
        public void Add_AttachmentEnabled()
        {
            IWebElement File = driver.FindElement(By.XPath(fileupload));
            if (File.Enabled)
            {
                Console.WriteLine("Attachment Field is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Field is Disabled");
                throw new Exception("Attachment Field is Disabled");
            }
        }
        public void Fileupload()
        {
            IWebElement File = driver.FindElement(By.XPath(fileupload));
            Thread.Sleep(500);
            if (File.Enabled)
            {
                File.SendKeys(testData["Attachment path"]);
                Thread.Sleep(500);
                Console.WriteLine("Attachment Field is Verified");
            }
            else
            {
                Console.WriteLine("Attachment Field is Disabled");
                throw new Exception("Attachment Field is Disabled");
            }
        }
        public void DeleteEnabled()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete));
            if (DeleteIcon.Enabled)
            {
                Console.WriteLine("Attachment Delete Icon is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Delete Icon is Disabled");
                throw new Exception("Attachment Delete Icon is Disabled");
            }
        }
        public void DeleteClickCancel()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete));
            if (DeleteIcon.Enabled)
            {
                DeleteIcon.Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Attachment is Not Deleted When Clicked on Cancel");
            }
            else
            {
                Console.WriteLine("Attachment is Deleted When Clicked on Cancel");
                throw new Exception("Attachment is Deleted When Clicked on Cancel");
            }
        }
        public void DeleteClickOk()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete));
            if (DeleteIcon.Enabled)
            {
                DeleteIcon.Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("Attachment Deleted Successfully When Clicked on OK");
            }
            else
            {
                Console.WriteLine("Attachment Not Deleted When Clicked on OK");
                throw new Exception("Attachment Not Deleted When Clicked on OK");
            }
            Thread.Sleep(1000);
        }
        public void DeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(title)));
            IWebElement Deletetoast = driver.FindElement(By.XPath(deletedtoast));
            if (Deletetoast.Displayed)
            {
                Console.WriteLine("Successfully Deleted Toast is displayed");
            }
            else
            {
                Console.WriteLine("Successfully Deleted Toast is Not displayed");
                throw new Exception("Successfully Deleted Toast is Not displayed");
            }
        }
        public void LineAccordion()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
            IWebElement line = driver.FindElement(By.XPath(linesAccordion));
            line.Click();
            js.ExecuteScript("window.scrollTo(0, 500)");
        }
        public void LinesAccordionClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(linesAccordion)));
            IWebElement line = driver.FindElement(By.XPath(linesAccordion));
            line.Click();
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Successfully Processed']")));
            IWebElement SuccessfulToast = driver.FindElement(By.XPath("//div[text()='Successfully Processed']"));
            if (SuccessfulToast.Displayed)
            {
                Console.WriteLine("IR Saved and Successfully Processed Toast is Displayed");
            }
            else
            {
                Console.WriteLine("IR Saved and Successfully Processed Toast is missing");
                throw new Exception("IR Saved and Successfully Processed Toast is missing");
            }
            Thread.Sleep(2000);
            //line.Click();
        }
        public void LinesClick_IRNumber()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(IRnum)));
            IWebElement IRNumber = driver.FindElement(By.XPath(IRnum));
            if (IRNumber.Displayed)
            {
                Console.WriteLine("IR Number is Generated");
            }
            else
            {
                Console.WriteLine("IR Number is Not Generated");
            }
        }
        public void IR_CancelOption()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//li[text()='Cancel']")));
            IWebElement CancelOption = driver.FindElement(By.XPath("//li[text()='Cancel']"));
            if (CancelOption.Displayed)
            {
                Console.WriteLine("IR Cancel Option is Displayed once the IR ID is Generated");
            }
            else
            {
                Console.WriteLine("IR Cancel Option is Not Displayed once the IR ID is Generated");
                throw new Exception("IR Cancel Option is Not Displayed once the IR ID is Generated");
            }
        }
        public void PreviewOptionClick()
        {
            IWebElement Preview = driver.FindElement(By.XPath(preview));
            Preview.Click();
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(tooltip)));
            IWebElement Tooltip = driver.FindElement(By.XPath(tooltip));
            if (Tooltip.Displayed)
            {
                Console.WriteLine("Requisition Fields are Read-Only in Preview mode");
            }
            else
            {
                Console.WriteLine("Requisition Fields are Editable in Preview mode");
                throw new Exception("Requisition Fields are Editable in Preview mode");
            }
        }
        public void PreviewRefresh()
        {
            driver.Navigate().Refresh();
        }
        public void PreviewModeActionOptions()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//li[text()='Update']")));
            IWebElement UpdateOption = driver.FindElement(By.XPath("//li[text()='Update']"));
            IWebElement SubmitOption = driver.FindElement(By.XPath("//li[text()='Submit']"));
            if (SubmitOption.Displayed && UpdateOption.Displayed)
            {
                Console.WriteLine("only Update and Submit Options are be Displayed in preview mode");
            }
            else
            {
                Console.WriteLine("only Update and Submit Options are Not Displayed in preview mode");
                throw new Exception("only Update and Submit Options are Not Displayed in preview mode");
            }
            Thread.Sleep(500);
        }
        public void UpdateOptionEnabled()
        {
            IWebElement UpdateOption = driver.FindElement(By.XPath("//li[text()='Update']"));
            if (UpdateOption.Enabled)
            {
                Console.WriteLine("Update Option is Enabled");
            }
            else
            {
                Console.WriteLine("Update Option is Disabled");
                throw new Exception("Update Option is Disabled");
            }
        }
        public void UpdateOptionClick()
        {
            IWebElement UpdateOption = driver.FindElement(By.XPath("//li[text()='Update']"));
            UpdateOption.Click();
            Thread.Sleep(500);
            IWebElement Title = driver.FindElement(By.XPath(title));
            if (Title.Enabled)
            {
                Console.WriteLine("IR Fields are Editable when Clicked on Update Button");
            }
            else
            {
                Console.WriteLine("IR Fields are Not Editable when Clicked on Update Button");
                throw new Exception("IR Fields are Not Editable when Clicked on Update Button");
            }
        }
        public void CancelOptionClick()
        {
            IWebElement CancelOption = driver.FindElement(By.XPath("//li[text()='Cancel']"));
            CancelOption.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(comments)));
            IWebElement CancelCommnets = driver.FindElement(By.XPath(comments));
            if (CancelCommnets.Displayed)
            {
                Console.WriteLine("Comments Screen is Displayed when clicked on Cancel Option");
            }
            else
            {
                Console.WriteLine("Comments Screen is Displayed when clicked on Cancel Option");
                throw new Exception("Comments Screen is Displayed when clicked on Cancel Option");
            }
            Thread.Sleep(1000);
        }
        public void CancelButtonEnabled()
        {
            IWebElement CancelButton = driver.FindElement(By.XPath(cancelButton));
            if (CancelButton.Enabled)
            {
                Console.WriteLine("Cancel Button is Enabled");
            }
            else
            {
                Console.WriteLine("Cancel Button is Disabled");
                throw new Exception("Cancel Button is Disabled");
            }
        }
        public void CancelButtonClick()
        {
            IWebElement CancelButton = driver.FindElement(By.XPath(cancelButton));
            CancelButton.Click();
            Thread.Sleep(1000);
            IWebElement IRCreationScreen = driver.FindElement(By.XPath(internalrequest));
            if (IRCreationScreen.Displayed)
            {
                Console.WriteLine("Page Redirected to IR Creation Screen");
            }
            else
            {
                Console.WriteLine("Page Not Redirected to IR Creation Screen");
                throw new Exception("Page Not Redirected to IR Creation Screen");
            }
        }
        public void ClickApprove_WithoutData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(document_action_Approve)));
            IWebElement ApproveButton = driver.FindElement(By.XPath(document_action_Approve));
            ApproveButton.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[text()='Please provide Comments!']"));
            if (Error.Displayed)
            {
                Error.Click();
                Thread.Sleep(1000);
                Console.WriteLine("Error Message Displayed when Submitted Without Data");
            }
            else
            {
                Console.WriteLine("Error Message Not Displayed when Submitted Without Data");
                throw new Exception("Error Message Not Displayed when Submitted Without Data");
            }
        }
        public void CancelSubmit_WithoutData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(cancel_submit)));
            IWebElement ApproveButton = driver.FindElement(By.XPath(cancel_submit));
            ApproveButton.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[text()='Please provide Comments!']"));
            if (Error.Displayed)
            {
                Error.Click();
                Thread.Sleep(1000);
                Console.WriteLine("Error Message Displayed when Submitted Without Data");
            }
            else
            {
                Console.WriteLine("Error Message Not Displayed when Submitted Without Data");
                throw new Exception("Error Message Not Displayed when Submitted Without Data");
            }
        }
        public void CancelCommentsEnabled()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Enabled)
            {
                Console.WriteLine("Comments Field is Enabled");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void CancelCommentsMandatory()
        {
            IWebElement CommentsMandatory = driver.FindElement(By.XPath(commentsmandatory));
            if (CommentsMandatory.Displayed)
            {
                Console.WriteLine("Comments mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Comments mandatory Symbol is Not Displayed");
                throw new Exception("Comments mandatory Symbol is Not Displayed");
            }
        }
        public void CancelCommentsSpace()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys(" ");
            string EnteredCompName = Comments.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Company Name is not taking Space in the beginning");
            }
            else
            {
                Console.WriteLine("Company Name is taking Space in the beginning");
            }
        }
        public void CancelCommentsUpto400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C400chars = RandomString1(random1, 400);
            Comments.SendKeys(C400chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Comments Upto 400 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Upto 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CancelCommentsAbove400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C405chars = RandomString1(random1, 405);
            Comments.SendKeys(C405chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Above 400 Characters");
            }
            else
            {
                Console.WriteLine("Allowewd to Enter the Comments Above 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CancelCommentsEdit()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys("test");
            Thread.Sleep(500);
            Comments.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Comments.SendKeys(Keys.Backspace);
            Comments.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Comments.SendKeys("es");
            string Actualtext = Comments.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Comments Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Comments Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Comments Field Allowed to Edit the Text in the Middle");
            }
            Comments.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CancelComments()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Displayed)
            {
                Comments.SendKeys(testData["IR Cancel Comments"]);
                Console.WriteLine("Comments Field is Verified");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void SubmitButtonEnabled()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            if (SubmitButton.Enabled)
            {
                Console.WriteLine("Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Submit Button is Disabled");
                throw new Exception("Submit Button is Disabled");
            }
        }
        public void SubmitButtonClick()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            SubmitButton.Click();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Cancelled Successfully']")));
            IWebElement Toast = driver.FindElement(By.XPath("//div[text()='Cancelled Successfully']"));
            if (Toast.Displayed)
            {
                Console.WriteLine("IR Cancelled Successfully Toast is Displayed");
            }
            else
            {
                Console.WriteLine("IR Cancelled Successfully Toast is Displayed");
                throw new Exception("IR Cancelled Successfully Toast is Displayed");
            }
            Thread.Sleep(2000);
        }
        public void LineAccordionEnabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            IWebElement lineAccordion = driver.FindElement(By.XPath(linesAccordion));
            if (lineAccordion.Enabled)
            {
                Console.WriteLine("lines Accordion is Enabled");
            }
            else
            {
                Console.WriteLine("lines Accordion is Disabled");
                throw new Exception("lines Accordion is Disabled");
            }
        }
        public void LinesClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            IWebElement lineAccordion = driver.FindElement(By.XPath(linesAccordion));
            Thread.Sleep(500);
            lineAccordion.Click();
            js.ExecuteScript("window.scrollTo(0, 800)");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));

            IWebElement GoButton = driver.FindElement(By.XPath(go_button));
            IWebElement ActionDropdown = driver.FindElement(By.XPath(actionDropdown));
            if (GoButton.Displayed && ActionDropdown.Displayed)
            {
                Console.WriteLine("Action Dropdown, Go Button, and Search Field is Displayed under Lines Section");
            }
            else
            {
                Console.WriteLine("Action Dropdown, Go Button, and Search Field is Not Displayed under Lines Section");
                throw new Exception("Action Dropdown, Go Button, and Search Field is Not Displayed under Lines Section");
            }
        }
        public void LineActionEnabled()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            if (lineAction.Enabled)
            {
                Console.WriteLine("Line Action Dropdown is Enabled");
            }
            else
            {
                Console.WriteLine("Line Action Dropdown is Disabled");
                throw new Exception("Line Action Dropdown is Disabled");
            }
        }
        public void LineActionClick()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            lineAction.Click();
            Thread.Sleep(500);
            IList<IWebElement> options = driver.FindElements(By.CssSelector("select.react-form-input.inputText option"));
            List<string> expectedOptions = new List<string> { "Create Line", "Upload Line" };
            foreach (var optionPresent in expectedOptions)
            {
                bool optionFound = false;
                foreach (var option in options)
                {
                    if (option.Text.Equals(optionPresent, StringComparison.OrdinalIgnoreCase))
                    {
                        optionFound = true;
                        break;
                    }
                }
                Assert.IsTrue(optionFound, $"Option '{optionPresent}' not found in the dropdown.");
            }
        }
        public void LineActionSelect()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));

            if (lineAction.Displayed)
            {
                lineAction.SendKeys("C");
                lineAction.SendKeys(Keys.Enter);
                Console.WriteLine("Selected the Line Option");
            }
            else
            {
                Console.WriteLine("Not Selected the Line Option");
                throw new Exception("Not Selected the Line Option");
            }
        }
        public void LineActionReSelect()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            if (lineAction.Displayed)
            {
                lineAction.Click();
                Thread.Sleep(500);
                lineAction.SendKeys(Keys.ArrowDown);
                lineAction.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                lineAction.SendKeys(Keys.Enter);
                Console.WriteLine("Re-Selected Other Line Option");
            }
            else
            {
                Console.WriteLine("Not Re-Selected Other Line Option");
                throw new Exception("Not Re-Selected Other Line Option");
            }
        }
        public void GoButtonEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));
            Thread.Sleep(1000);
            IWebElement go = driver.FindElement(By.XPath(go_button));
            if (go.Enabled)
            {
                Console.WriteLine("Go Button is Enabled");
            }
            else
            {
                Console.WriteLine("Go Button is Disabled");
                throw new Exception("Go Button is Disabled");
            }
        }
        public void GOButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));
            Thread.Sleep(1000);
            IWebElement go = driver.FindElement(By.XPath(go_button));
            go.Click();
            IWebElement LineModel = driver.FindElement(By.XPath("//label[text()='Line Type*']"));
            if (LineModel.Displayed)
            {

                Console.WriteLine("Page is Redirected to Create Line Screen");
            }
            else
            {
                Console.WriteLine("Page is Not Redirected to Create Line Screen");
                throw new Exception("Page is Not Redirected to Create Line Screen");
            }
        }
        public void CreateLinePage_Refresh()
        {
            driver.Navigate().Refresh();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(internalrequest)));

            IWebElement ReqCreationScreen = driver.FindElement(By.XPath(internalrequest));
            if (ReqCreationScreen.Displayed)
            {
                Console.WriteLine("Page is Redirected to IR Creation Screen");
            }
            else
            {
                Console.WriteLine("Page is Not Redirected to IR Creation Screen");
                throw new Exception("Page is Not Redirected to IR Creation Screen");
            }
        }
        public void LineTypeDisabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Line Type*']/following::span[1]")));
            IWebElement LineType = driver.FindElement(By.XPath("//label[text()='Line Type*']/following::span[@class='labelTypeInput disabled'][1]"));
            if (LineType.Displayed)
            {
                Console.WriteLine("Line Type is Disabled for IR");
            }
            else
            {
                Console.WriteLine("Line Type is Enabled for IR");
                throw new Exception("Line Type is Enabled for IR");
            }
        }
        public void LineTypeMandatory()
        {
            IWebElement mandatory = driver.FindElement(By.XPath("//label[text()='Line Type*']"));
            if (mandatory.Displayed)
            {
                Console.WriteLine("Line Type mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Line Type mandatory Symbol Not Displayed");
                throw new Exception("Line Type Mandatory Symbol Not Displayed");
            }
        }
        public void DefaultLineType()
        {
            IWebElement TypeDefault = driver.FindElement(By.XPath("//span[text()='Goods']"));
            if (TypeDefault.Displayed)
            {
                Console.WriteLine("Line Type is Selected as Goods by Default");
            }
            else
            {
                Console.WriteLine("Line Type is Not Selected as Goods by Default");
                throw new Exception("Line Type is Not Selected as Goods by Default");
            }
        }
        public void CreateLineFields()
        {
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetype));
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            IWebElement Qty = driver.FindElement(By.XPath(cl_quantity));
            IWebElement Need = driver.FindElement(By.XPath(Cl_Need_Date));
            IWebElement Apply = driver.FindElement(By.XPath(apply));
            IWebElement Categ = driver.FindElement(By.XPath(cl_category));
            IWebElement Unit = driver.FindElement(By.XPath(cl_unit));

            if (LineType.Displayed && Item.Displayed && Qty.Displayed && Need.Displayed && Apply.Displayed && Categ.Displayed && Unit.Displayed)
            {
                Console.WriteLine("All the Create line Fields are Displayed");
            }
            else
            {
                Console.WriteLine("All the Create line Fields are Not Displayed");
                throw new Exception("All the Create line Fields are Not Displayed");
            }
        }
        public void ClickOnApplyWithout_Data()
        {
            IWebElement ApplyButton = driver.FindElement(By.XPath(apply));
            ApplyButton.Click();
            Thread.Sleep(500);
            IWebElement Item = driver.FindElement(By.XPath("//span[text()='Please provide Item']"));
            IWebElement Category = driver.FindElement(By.XPath("//span[text()='Please provide Category']"));
            IWebElement Unit = driver.FindElement(By.XPath("//span[text()='Please provide Unit']"));
            IWebElement Qty = driver.FindElement(By.XPath("//span[text()='Please provide Quantity']"));
            IWebElement Need = driver.FindElement(By.XPath("//span[text()='Please provide Need By Date']"));
            IWebElement Desc = driver.FindElement(By.XPath("//span[text()='Please provide Description']"));

            if (Item.Displayed && Category.Displayed && Unit.Displayed && Qty.Displayed && Need.Displayed && Desc.Displayed)
            {
                Console.WriteLine("Mandatory Fields Error message is Displayed when Clicked on Line Apply");
            }
            else
            {
                Console.WriteLine("Mandatory Fields Error message is Not Displayed when Clicked on Line Apply");
                throw new Exception("Mandatory Fields Error message is Not Displayed when Clicked on Line Apply");
            }
        }
        public void ItemEnabled()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            if (Item.Enabled)
            {

                Console.WriteLine("Item Field is Enabled");
            }
            else
            {
                Console.WriteLine("Item Field is Disabled");
                throw new Exception("Item Field is Disabled");
            }
        }
        public void Itemmandatory()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_itemMandatory));
            if (Item.Displayed)
            {
                Console.WriteLine("Item Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Item Field mandatory Symbol is Not displayed");
                throw new Exception("Item Field mandatory Symbol is Not displayed");
            }
        }
        public void ItemSelect()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            if (Item.Displayed)
            {
                Item.Click();
                Thread.Sleep(4000);
                Item.SendKeys(Keys.ArrowDown);
                Item.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Item.SendKeys(Keys.Enter);
                Thread.Sleep(3000);
                Console.WriteLine("Item is Selected from Options");
            }
            else
            {
                Console.WriteLine("Item is Not Selected from Options");
                throw new Exception("Item is Not Selected from Options");
            }
        }
        public void Item_ReSelect()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(cl_item)));
            if (Item.Displayed)
            {
                Item.Click();
                Thread.Sleep(500);
                Item.SendKeys(Keys.ArrowDown);
                Item.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Item.SendKeys(Keys.Enter);
                Thread.Sleep(3000);
                Console.WriteLine("Item is Re-Selected from Options");
            }
            else
            {
                Console.WriteLine("Item is Not Re-Selected from Options");
                throw new Exception("Item is Not Re-Selected from Options");
            }
        }
        public void CL_Item()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(cl_item)));
            Thread.Sleep(2000);
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            if (Item.Enabled)
            {
                Actions acti = new Actions(driver);
                acti.MoveToElement(Item).Click().Perform();
                Thread.Sleep(5000);
                acti.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                acti.SendKeys(Keys.Delete).Perform();

                Item.SendKeys(testData["lineitem"]);
                Thread.Sleep(1000);
                Item.SendKeys(Keys.ArrowDown);
                Item.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Item.SendKeys(Keys.Enter);
                Thread.Sleep(3000);
                Console.WriteLine("Item is Verified");
            }
            else
            {
                Console.WriteLine("Item Field is Disabled");
                throw new Exception("Item Field is Disabled");
            }
            Thread.Sleep(2500);
        }
        public void CategoryDisabled()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_categoryDisabled));
            if (Category.Enabled)
            {
                Console.WriteLine("Category Field is Disabled");
            }
            else
            {
                Console.WriteLine("Category Field is Enabled");
                throw new Exception("Category Field is Enabled");
            }
        }
        public void CategoryMandatory()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_categorymandatory));
            if (Category.Displayed)
            {
                Console.WriteLine("Category mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Category Field mandatory Symbol Not Displayed");
                throw new Exception("Category Field mandatory Symbol Not Displayed");
            }
        }
        public void CategoryPopupate()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_categoryDisabled));
            if (Category.Displayed)
            {
                Console.WriteLine("Category is Populated as per the Item Selected");
            }
            else
            {
                Console.WriteLine("Category is Not Populated as per the Item Selected");
                throw new Exception("Category is Not Populated as per the Item Selected");
            }
        }
        public void UnitDisabled()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unitDisabled));
            if (Unit.Enabled)
            {
                Console.WriteLine("Unit Field is Disabled");
            }
            else
            {
                Console.WriteLine("Unit Field is Enabled");
                throw new Exception("Unit Field is Enabled");
            }
        }
        public void UnitMandatory()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unitMandatory));
            if (Unit.Displayed)
            {
                Console.WriteLine("Unit Field mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Unit Field mandatory Symbol Not Displayed");
                throw new Exception("Unit Field mandatory Symbol Not Displayed");
            }
        }
        public void UnitPopupate()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unitDisabled));
            if (Unit.Displayed)
            {
                Console.WriteLine("Unit is Populated as per the Item Selected");
            }
            else
            {
                Console.WriteLine("Unit is Not Populated as per the Item Selected");
                throw new Exception("Unit is Not Populated as per the Item Selected");
            }
        }
        public void QuantityEnabled()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            if (Quantity.Enabled)
            {
                Console.WriteLine("Quantity is Enabled");
            }
            else
            {
                Console.WriteLine("Quantity is Disabled");
                throw new Exception("Quantity is Disabled");
            }
        }
        public void QuantityMandatory()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantityMandatory));
            if (Quantity.Displayed)
            {
                Console.WriteLine("Quantity Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Quantity Field Mandatory Symbol is Not displayed");
                throw new Exception("Quantity Field Mandatory Symbol is Not displayed");
            }
        }
        public void QuantitySpace()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            Quantity.SendKeys(" *&@");
            string Enteredtext = Quantity.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Quantity is not taking Space and Special Characters");
            }
            else
            {
                Console.WriteLine("Quantity is taking Space and Special Characters");
                throw new Exception("Quantity is taking Space and Special Characters");
            }
        }
        public void QuantityUpto9()
        {
            Actions act = new Actions(driver);
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));

            Random random1 = new Random();
            int randomNumber = random1.Next(555555555, 999999999);
            string numberString = randomNumber.ToString();
            Quantity.SendKeys(numberString);
            string Enteredtext = Quantity.GetAttribute("value");
            Regex rgx = new Regex(@"^[0-9]{1,9}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Quantity Upto 9 Digits");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Quantity Upto 9 Digits");
                throw new Exception("Not Allowewd to Enter the Quantity Upto 9 Digits");
            }
            Quantity.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void QuantityAbove9()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            Random random1 = new Random();
            int randomNumber = random1.Next(1555555555, 1999999999);
            string numberString = randomNumber.ToString();
            Quantity.SendKeys(numberString);
            string Enteredtext = Quantity.GetAttribute("value");
            Regex rgx = new Regex(@"^[0-9]{1,9}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Quantity Above 9 Digits");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Title Quantity 9 Digits");
                throw new Exception("Not Allowewd to Enter the Title Quantity 9 Digits");
            }
            Quantity.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void QuantityEdit()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            Quantity.SendKeys("1234");
            Thread.Sleep(500);
            Quantity.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Quantity.SendKeys(Keys.Backspace);
            Quantity.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Quantity.SendKeys("23");
            string Actualtext = Quantity.GetAttribute("value");
            string ExpectedText = "1234";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Allowed to Edit the Quantity in the Middle");
            }
            else
            {
                Console.WriteLine("Not Allowed to Edit the Quantity in the Middle");
                throw new Exception("NotAllowed to Edit the Quantity in the Middle");
            }
            Quantity.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CL_Quantity()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            Thread.Sleep(1000);
            if (Quantity.Enabled)
            {
                Quantity.Click();
                Quantity.SendKeys(testData["line Qty"]);
                string EnteredQuantity = Quantity.GetAttribute("value");
                Regex rgx = new Regex(@"^[0-9]{1,10}$");
                if (rgx.IsMatch(EnteredQuantity))
                {
                    Console.WriteLine("Quantity is Verified");
                }
                else
                {
                    Console.WriteLine("Quantity is Not Verified");
                }
            }
            else
            {
                Console.WriteLine("Quantity Field is Disabled");
            }
        }
        public void CL_NeedByDateEnable()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            NeedByDate.Click();
            if (NeedByDate.Enabled)
            {
                Console.WriteLine("NeedByDate Field is Enabled");
            }
            else
            {
                Console.WriteLine("NeedByDate Field is Disabled");
                throw new Exception("NeedByDate Field is Disabled");
            }
            Thread.Sleep(100);
        }
        public void CL_NeedByDateMandatory()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_DateMandatory));
            if (NeedByDate.Displayed)
            {
                Console.WriteLine("NeedByDate mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("NeedByDate mandatory Symbol is Not Displayed");
                throw new Exception("NeedByDate mandatory Symbol is Not Displayed");
            }
            Thread.Sleep(100);
        }
        public void CL_NeedByDateDropdownSelect()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            NeedByDate.Click();
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.ArrowDown);
            NeedByDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.Enter);
            Console.WriteLine("NeedByDate is Selected From Dropdown");
            NeedByDate.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void CurrentCL_NeedByDate()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            IWebElement title = driver.FindElement(By.XPath("//label[text()='Need By Date*']"));
            NeedByDate.Click();
            Thread.Sleep(500);
            string date = "05-05-2022";
            DateTime nextDate = DateTime.Now.AddDays(1);
            string Next_Date = nextDate.ToString("dd-MM-yyyy");
            NeedByDate.SendKeys(date);
            title.Click();
            Thread.Sleep(500);
            string getdate = NeedByDate.GetAttribute("value");

            if (getdate.Equals(Next_Date))
            {
                Console.WriteLine("NeedByDate Date is updated to Next Date of the Current Date");
            }
            else
            {
                Console.WriteLine("NeedByDate Date is Not updated to Next Date of the Current Date");
                throw new Exception("NeedByDate Date is Not updated to Next Date of the Current Date");
            }
        }
        public void CL_NeedByDateMonthandYear()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            NeedByDate.Click();
            IWebElement NeedByDateMonth = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            IWebElement NeedByDateYear = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            if (NeedByDateMonth.Displayed && NeedByDateYear.Displayed)
            {
                Console.WriteLine("NeedByDate DatePicker contains Month and Year Dropdoen");
            }
            else
            {
                Console.WriteLine("NeedByDate DatePicker doesnot contains Month and Year Dropdoen");
                throw new Exception("NeedByDate DatePicker doesnot contains Month and Year Dropdoen");
            }
        }
        public void CL_NeedByDate()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            if (NeedByDate.Enabled)
            {
                NeedByDate.Click();
                Thread.Sleep(500);
                NeedByDate.SendKeys(testData["Need By Date"]);
                Thread.Sleep(500);
                NeedByDate.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                NeedByDate.SendKeys(Keys.Enter);
                Console.WriteLine("Valid Need By Date is Selected");
            }
            else
            {
                Console.WriteLine("Valid Need By Date is Not Selected");
                throw new Exception("Valid Need By Date is Not Selected");
            }
            Thread.Sleep(1000);

        }
        public void IR_StatusDisabled()
        {
            IWebElement IRStatus = driver.FindElement(By.XPath("//label[text()='Status']"));
            if (IRStatus.Displayed)
            {
                Console.WriteLine("IR Status Field is Disabled");
            }
            else
            {
                Console.WriteLine("IR Status Field is Enabled");
                throw new Exception("IR Status Field is Enabled");
            }
        }
        public void IR_StatusDraft()
        {
            IWebElement IRStatus = driver.FindElement(By.XPath("//label[text()='Status']/following::span[text()='Draft']"));
            if (IRStatus.Displayed)
            {
                Console.WriteLine("IR Status Displayed as Draft by Default");
            }
            else
            {
                Console.WriteLine("IR Status Not Displayed as Draft by Default");
                throw new Exception("IR Status Not Displayed as Draft by Default");
            }
        }
        public void PreferredBrandDisabled()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            if (PreferredBrand.Displayed)
            {
                Console.WriteLine("Preferred Brand Field is Disabled");
            }
            else
            {
                Console.WriteLine("Preferred Brand Field is Enabled");
                throw new Exception("Preferred Brand Field is Enabled");
            }
        }
        public void PreferredBrandMandatory()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brandMandatory));
            if (PreferredBrand.Displayed)
            {
                Console.WriteLine("Preferred Brand is a Non Mandatory Field");
            }
            else
            {
                Console.WriteLine("Preferred Brand is a Mandatory Field");
                throw new Exception("Preferred Brand is a Mandatory Field");
            }
        }
        public void PreferredBrandPopupate()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            if (PreferredBrand.Displayed)
            {
                Console.WriteLine("Preferred Brand is Populated as per the Item Selected");
            }
            else
            {
                Console.WriteLine("Preferred Brand is Not Populated as per the Item Selected");
                throw new Exception("Preferred Brand is Not Populated as per the Item Selected");
            }
        }
        public void DescriptionDisabled()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            if (Description.Displayed)
            {
                Console.WriteLine("Line Description Field is Disabled");
            }
            else
            {
                Console.WriteLine("Line Description Field is Enabled");
                throw new Exception("Line Description Field is Enabled");
            }
        }
        public void DescriptionPopulated()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            if (Description.Displayed)
            {
                Console.WriteLine("Line Description is Populated as per the Item Selected");
            }
            else
            {
                Console.WriteLine("Line Description is Not Populated as per the Item Selected");
                throw new Exception("Line Description is Not Populated as per the Item Selected");
            }
        }
        public void Line_AttachmentEnabled()
        {
            IWebElement File = driver.FindElement(By.XPath(fileupload));
            if (File.Enabled)
            {
                Console.WriteLine("Attachment Field is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Field is Disabled");
                throw new Exception("Attachment Field is Disabled");
            }
        }
        public void CL_Attachment()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,200)");
            IWebElement LineFileUpload = driver.FindElement(By.XPath(linefileupload));
            if (LineFileUpload.Enabled)
            {
                LineFileUpload.SendKeys(testData["Attachment path"]);
                Console.WriteLine("Attachment is Verified");
            }
            else
            {
                Console.WriteLine("Attachment Field is DisabledImageType");
                throw new Exception("Attachment Field is DisabledImageType");
            }
        }
        public void Line_AttachDeleteEnabled()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete));
            if (DeleteIcon.Enabled)
            {
                Console.WriteLine("Attachment Delete Icon is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Delete Icon is Disabled");
                throw new Exception("Attachment Delete Icon is Disabled");
            }
        }
        public void Line_AttachDeleteClickCancel()
        {
            Actions act = new Actions(driver);
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete));
            if (DeleteIcon.Displayed)
            {
                act.ScrollToElement(DeleteIcon).Perform();
                IWebElement DeleteCancel = driver.FindElement(By.XPath("(//button[text()='Cancel'])[2]"));
                DeleteCancel.Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Attachment is Not Deleted When Clicked on Cancel");
            }
            else
            {
                Console.WriteLine("Attachment is Deleted When Clicked on Cancel");
                throw new Exception("Attachment is Deleted When Clicked on Cancel");
            }
        }
        public void Line_AttachDeleteClickOk()
        {
            Actions act = new Actions(driver);
            IWebElement DeleteIcon = driver.FindElement(By.XPath(delete1));
            if (DeleteIcon.Displayed)
            {
                act.MoveToElement(DeleteIcon).Click().Perform();
                Thread.Sleep(500);
                IWebElement DeleteOK = driver.FindElement(By.XPath("//button[text()='Delete']"));
                DeleteOK.Click();
                Console.WriteLine("Attachment Deleted Successfully When Clicked on OK");
            }
            else
            {
                Console.WriteLine("Attachment Not Deleted When Clicked on OK");
                throw new Exception("Attachment Not Deleted When Clicked on OK");
            }
            Thread.Sleep(1000);
        }
        public void Line_AttachDeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(deletedtoast)));
            IWebElement Deletetoast = driver.FindElement(By.XPath(deletedtoast));
            if (Deletetoast.Displayed)
            {
                Console.WriteLine("Successfully Deleted Toast is displayed");
            }
            else
            {
                Console.WriteLine("Successfully Deleted Toast is Not displayed");
                throw new Exception("Successfully Deleted Toast is Not displayed");
            }
        }
        public void CL_ApplyEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LineCreate_apply)));
            IWebElement applybutton = driver.FindElement(By.XPath(LineCreate_apply));
            Thread.Sleep(500);
            Actions action = new Actions(driver);
            action.MoveToElement(applybutton).Perform();
            if (applybutton.Enabled)
            {
                Console.WriteLine("Apply Button is Enabled");
            }
            else
            {
                Console.WriteLine("Apply Button is Disabled");
                throw new Exception("Apply Button is Disabled");
            }
        }
        public void CL_ApplyClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(LineCreate_apply)));
            IWebElement applybutton = driver.FindElement(By.XPath(LineCreate_apply));
            Thread.Sleep(500);
            Actions action = new Actions(driver);
            action.MoveToElement(applybutton).Perform();
            Thread.Sleep(500);
            if (applybutton.Displayed)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", applybutton);
                Console.WriteLine("Apply Button is Verified");
            }
            else
            {
                Console.WriteLine("Apply Button Field is Disabled");
                throw new Exception("Apply Button Field is Disabled");
            }
        }
        public void CL_ApplyToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(lineApply_toast)));
            IWebElement toast = driver.FindElement(By.XPath(lineApply_toast));
            if (toast.Displayed)
            {
                Console.WriteLine("Successfully Processed Toast is Displayed");
            }
            else
            {
                Console.WriteLine("Successfully Processed Toast is Not Displayed");
                throw new Exception("Successfully Processed Toast is Not Displayed");
            }
        }
        public void RedirectBackToHeader()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(internalrequest)));
            Thread.Sleep(2000);
            IWebElement InternalReq_Button = driver.FindElement(By.XPath(internalrequest));
            if (InternalReq_Button.Displayed)
            {
                Console.WriteLine("Page Redirect Back to the Header Screen");
            }
            else
            {
                Console.WriteLine("Page Not Redirect Back to the Header Screen");
                throw new Exception("Page Not Redirect Back to the Header Screen");
            }
        }
        public void InternalReq_ButtonDisabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,0)");
            IWebElement InternalReq_Button_ReadOnly = driver.FindElement(By.XPath("//div[contains(@style,'opacity: 0.5')]"));
            if (InternalReq_Button_ReadOnly.Displayed)
            {
                Console.WriteLine("Internal Request Button is Disabled after the Line Creation");
            }
            else
            {
                Console.WriteLine("Internal Request Button is Not Disabled after the Line Creation");
                throw new Exception("Internal Request Button is Not Disabled after the Line Creation");
            }
        }
        public void CreatedLine_Table()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,900)");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='rt-tr -odd']")));
            IWebElement CreatedLine = driver.FindElement(By.XPath("//div[@class='rt-tr -odd']"));
            if (CreatedLine.Displayed)
            {
                Console.WriteLine("Created Line is Displayed in the table");
            }
            else
            {
                Console.WriteLine("Created Line is Not Displayed in the table");
                throw new Exception("Created Line is Not Displayed in the table");
            }
        }
        public void UploadLine_OptionDisplayed()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            lineAction.Click();
            IWebElement UploadOption = driver.FindElement(By.XPath("//option[text()='Upload Line']"));
            if (UploadOption.Displayed)
            {
                Console.WriteLine("Upload line Option is Displayed");
            }
            else
            {
                Console.WriteLine("Upload line Option is Not Displayed");
                throw new Exception("Upload line Option is Not Displayed");
            }
        }
        public void UploadLine_OptionSelect()
        {
            IWebElement UploadOption = driver.FindElement(By.XPath("//option[text()='Upload Line']"));
            UploadOption.Click();
            Console.WriteLine("Upload Option Selected");

        }
        public void LinesClickIfRequired()
        {
            bool isAccordionOpened = driver.FindElements(By.XPath(accordionOpened)).Any();
            if (!isAccordionOpened)
            {
                Console.WriteLine("Lines Accordion is Opened");
            }
            else
            {
                LineAccordion();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("scroll(0,500)");
            }
        }
        public void UploadLine_GO()
        {
            IWebElement GO = driver.FindElement(By.XPath(go_button));
            Actions act = new Actions(driver);
            act.ScrollToElement(GO).Perform();
            GO.Click();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Upload Icon']")));
            IWebElement UploadScreen = driver.FindElement(By.XPath("//img[@alt='Upload Icon']"));
            if (UploadScreen.Displayed)
            {
                Console.WriteLine("Upload GO Button is Clicked");
            }
            else
            {
                Console.WriteLine("Upload GO Button is Not Clicked");
                throw new Exception("Upload GO Button is Not Clicked");
            }
        }
        public void UploadLine_CancelEnabled()
        {
            IWebElement UploadlineCancelButton = driver.FindElement(By.XPath(cancelButton));
            if (UploadlineCancelButton.Enabled)
            {
                Console.WriteLine("Upload line Screen Cancel Button is Enabled");
            }
            else
            {
                Console.WriteLine("Upload line Screen Cancel Button is Disabled");
                throw new Exception("Upload line Screen Cancel Button is Disabled");
            }
        }
        public void UploadLine_CancelClick()
        {
            IWebElement UploadlineCancelButton = driver.FindElement(By.XPath(cancelButton));
            UploadlineCancelButton.Click();
            IWebElement IR_Header = driver.FindElement(By.XPath("//label[text()='Attachment']"));
            if (IR_Header.Displayed)
            {
                Console.WriteLine("Clicked on Cancel Button, and Page Redirect back to IR Creation Screen");
            }
            else
            {
                Console.WriteLine("Clicked on Cancel Button, But Page Not Redirect back to IR Creation Screen");
                throw new Exception("Page Not Redirect back to IR Creation Screen");
            }
        }
        public void UploadLine_Refresh()
        {
            driver.Navigate().Refresh();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Attachment']")));
            IWebElement IR_Header = driver.FindElement(By.XPath("//label[text()='Attachment']"));
            if (IR_Header.Displayed)
            {
                Console.WriteLine("Upload Line Screen Refresh Successful, and Page Redirect back to IR Creation Screen");
            }
            else
            {
                Console.WriteLine("Upload Line Screen Refresh Successful, and Page Redirect back to IR Creation Screen");
                throw new Exception("Upload Line Screen Refresh Un-Successful");
            }
        }
        public void UploadLine_Template()
        {
            IWebElement Downloadtemplate = driver.FindElement(By.XPath("//span[text()='Download template']"));
            if (Downloadtemplate.Enabled)
            {
                Console.WriteLine("Download Template Link is Enabled");
            }
            else
            {
                Console.WriteLine("Download Template Link is Disabled");
                throw new Exception("Download Template Link is Disabled");
            }
        }
        public void UploadLine_ScreenTable()
        {
            IWebElement UploadLineTable = driver.FindElement(By.XPath(uploadline_table));
            if (UploadLineTable.Displayed)
            {
                Console.WriteLine("Uploaded Line are Displayed on the Table");
            }
            else
            {
                Console.WriteLine("Uploaded Line are Not Displayed on the Table");
                throw new Exception("Uploaded Line are Not Displayed on the Table");
            }
        }
        public void UploadLine_Fields()
        {
            IWebElement UploadLine_type     = driver.FindElement(By.XPath("//div[text()='Line Type']"));
            IWebElement UploadLine_Item     = driver.FindElement(By.XPath("//div[text()='Item']"));
            IWebElement UploadLine_Desc     = driver.FindElement(By.XPath("//div[text()='Item Description']"));
            IWebElement UploadLine_Categ    = driver.FindElement(By.XPath("//div[text()='Category']"));
            IWebElement UploadLine_Unit     = driver.FindElement(By.XPath("//div[text()='Unit']"));
            IWebElement UploadLine_Onhand   = driver.FindElement(By.XPath("//div[text()='Onhand quantity']"));
            IWebElement UploadLine_Qty      = driver.FindElement(By.XPath("//div[text()='Quantity']"));
            IWebElement UploadLine_Needby   = driver.FindElement(By.XPath("//div[text()='Need By Date']"));
            IWebElement UploadLine_Brand    = driver.FindElement(By.XPath("//div[text()='Preferred Brand']"));
            IWebElement UploadLine_Action   = driver.FindElement(By.XPath("//div[text()='Action']"));
            if (UploadLine_type.Displayed && UploadLine_Item.Displayed && UploadLine_Desc.Displayed && UploadLine_Categ.Displayed && UploadLine_Unit.Displayed && UploadLine_Onhand.Displayed)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                driver.FindElement(By.XPath("(//span[text()='Goods'])[1]")).Click();
                Thread.Sleep(500);
                js.ExecuteScript("scroll(500,0)");
                if (UploadLine_Qty.Displayed && UploadLine_Needby.Displayed && UploadLine_Brand.Displayed && UploadLine_Action.Displayed)
                Console.WriteLine("Uploaded Line Fields are Displayed on the Table");
                js.ExecuteScript("scroll(0,500)");
            }
            else
            {
                Console.WriteLine("Uploaded Line Fields are Not Displayed on the Table");
                throw new Exception("Uploaded Line Fields are Not Displayed on the Table");
            }
        }
        public void UploadLine_ClearEnabled()
        {
            IWebElement UploadLine_Clear = driver.FindElement(By.XPath(uploadline_Clear));
            if (UploadLine_Clear.Enabled)
            {
                Console.WriteLine("Upload Line Clear Button is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Clear Button is Disabled");
                throw new Exception("Upload Line Clear Button is Disabled");
            }
        }
        public void UploadLine_ClearClick()
        {
            IWebElement UploadLine_Clear = driver.FindElement(By.XPath(uploadline_Clear));
            UploadLine_Clear.Click();
            bool islinesPresent = driver.FindElements(By.XPath("//span[text()='Goods']")).Any();
            if (!islinesPresent)
            {
                Console.WriteLine("Clicked on Clear Button and the Lines are Cleard");
            }
            else
            {
                Console.WriteLine("Clear Function Not Working");
                throw new Exception("Clear Function Not Working");
            }
        }
        public void UploadLine_SubmitEnabled()
        {
            Actions act = new Actions(driver);          
            IWebElement UploadLine_Submit = driver.FindElement(By.XPath(uploadline_Submit));
            act.ScrollToElement(UploadLine_Submit).Perform();
            if (UploadLine_Submit.Enabled)
            {
                Console.WriteLine("Upload Line Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Submit Button is Disabled");
                throw new Exception("Upload Line Submit Button is Disabled");
            }
        }
        public void UploadLine_SubmitClick()
        {
            IWebElement UploadLine_Submit = driver.FindElement(By.XPath(uploadline_Submit));
            UploadLine_Submit.Click();
            //IWebElement SuccessToast = driver.FindElement(By.XPath("//div[text()='Successfully Processed']"));
            IWebElement header = driver.FindElement(By.XPath("//label[text()='Attachment']"));
            if (header.Displayed)
            {               
                Console.WriteLine("Uploaded line is Submitted Successfully");
            }
            else
            {
                Console.WriteLine("Uploaded line is Not Submitted");
            }
        }
        public void UploadLine_SubmitClick_WithoutData()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,-500)");
            js.ExecuteScript("scroll(500,0)");
            IWebElement UploadLine_Submit   = driver.FindElement(By.XPath(uploadline_Submit));
            IWebElement UploadLine_Qty      = driver.FindElement(By.XPath(uploadline_Qty));
            IWebElement UploadLine_Needby   = driver.FindElement(By.XPath(uploadline_needbyDate));
            UploadLine_Qty.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();

            UploadLine_Needby.Click();
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
            js.ExecuteScript("scroll(0,500)");
            UploadLine_Submit.Click();
            Thread.Sleep(1000);

            js.ExecuteScript("scroll(0,-500)");
            IWebElement UploadLine_QtyError = driver.FindElement(By.XPath(qty_error));
            IWebElement UploadLine_NeedbyError = driver.FindElement(By.XPath(needbydate_error));

            if (UploadLine_QtyError.Displayed && UploadLine_NeedbyError.Displayed)
            {
                Console.WriteLine("Error Messages are Displayed when Clicked on Submit Button Without Providing Data");
            }
            else
            {
                Console.WriteLine("Error Messages are Not Displayed when Clicked on Submit Button Without Providing Data");
                throw new Exception("Error Messages are Not Displayed when Clicked on Submit Button Without Providing Data");
            }
        }
        public void UploadLine_Brand_populate()
        {
            IWebElement UploadLine_brand = driver.FindElement(By.XPath("(//span[@class='labelTypeInput disabled'])[6]"));
            if (UploadLine_brand.Displayed)
            {
                Console.WriteLine("Uploaded Line Brand Field Value is Auto Populated");
            }
            else
            {
                Console.WriteLine("Uploaded Line Brand Field Value is Not Displayed");
                throw new Exception("Uploaded Line Brand Field Value is Not Displayed");
            }
        }
        public void UploadLine_LineTypeDisabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(-500,-500)");
            Thread.Sleep(1000);
            IWebElement UploadLine_Type = driver.FindElement(By.XPath("//span[text()='Goods']"));
            if (UploadLine_Type.Displayed)
            {
                Console.WriteLine("Uploaded Line - Line Type is read-Only");
            }
            else
            {
                Console.WriteLine("Uploaded Line - Line Type is Enabled");
                throw new Exception("Uploaded Line - Line Type is Enabled");
            }
            js.ExecuteScript("scroll(0,500)");
        }
        public void UploadLine()
        {
            IWebElement uploadOption = driver.FindElement(By.XPath(linecreate_select));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(linecreate_select)));

            if (element.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", uploadOption);

                uploadOption.Click();
                Thread.Sleep(500);
                uploadOption.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                uploadOption.SendKeys(Keys.Enter);
                Console.WriteLine("Upload Line is Selected");
            }
            else
            {
                Console.WriteLine("Upload Line is Not Selected");
                throw new Exception("Upload Line is Not Selected");
            }
            Thread.Sleep(5000);
        }
        public void UploadFile()
        {
            IWebElement FileIcon = driver.FindElement(By.XPath(File_Icon));
            FileIcon.SendKeys(testData["upload line path"]);
            Console.WriteLine("Line is Uploaded");
        }
        public void UploadSubmit()
        {
            IWebElement Uploadsubmit = driver.FindElement(By.XPath(UploadLinesubmit));
            Actions action = new Actions(driver);
            action.MoveToElement(Uploadsubmit).Perform();
            if (Uploadsubmit.Displayed)
            {
                action.Click().Perform();
                Console.WriteLine("Uploaded Line is Submitted");
            }
            else
            {
                Console.WriteLine("Uploaded Line is Not Submitted");
                throw new Exception("Uploaded Line is Not Submitted");
            }
            Thread.Sleep(3000);
        }

        public void Uploadline_QtyEnabled()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(uploadline_Qty));
            if (Quantity.Enabled)
            {
                Console.WriteLine("Upload Line Quantity Field is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Quantity Field is Disabled");
                throw new Exception("Upload Line Quantity Field is Disabled");
            }
        }
        public void Uploadline_QtyOnlyDigits()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(uploadline_Qty));
            Quantity.Clear();
            Quantity.SendKeys("Abc!@#1234564785");
            string EnteredQty = Quantity.GetAttribute("value");
            Regex rgx = new Regex(@"^[0-9]{0,9}$");
            if (rgx.IsMatch(EnteredQty))
            {
                Console.WriteLine("Quantity Field is Accepting Only Numeric Values");
            }
            else
            {
                Console.WriteLine("Quantity Field is Accepting non Numeric Values");
                throw new Exception("Quantity Field is Accepting non Numeric Values");
            }
            Quantity.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Uploadline_QtyMoreThan_OnhandQty()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(uploadline_Qty));
            IWebElement OnhandQuantity = driver.FindElement(By.XPath(uploadline_OnhandQty));
            int onHandQuantity = int.Parse(OnhandQuantity.Text);
            int quantityToEnter = onHandQuantity + 1;
            string OnhandQty = quantityToEnter.ToString();
            Quantity.SendKeys(OnhandQty);
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            SubmitButton.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//span[text()=' Entered quantity cannot be greater than onhand quantity']"));
            if (Error.Displayed)
            {
                Console.WriteLine("Error Message is Displayed When user Entered More than Onhand Quantity");
            }
            else
            {
                Console.WriteLine("Error Message is Not Displayed When user Entered More than Onhand Quantity");
                throw new Exception("Error Message is Not Displayed When user Entered More than Onhand Quantity");
            }
            Quantity.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Uploadline_Quantity()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(uploadline_Qty));
            Quantity.SendKeys(testData["line Qty"]);
        }
        public void Uploadline_NeedBydateEnabled()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            if (NeedByDate.Enabled)
            {
                Console.WriteLine("Upload Line NeedByDate Field is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line NeedByDate Field is Disabled");
                throw new Exception("Upload Line NeedByDate Field is Disabled");
            }
            Thread.Sleep(100);
        }
        public void UploadLine_NeedByDatePicker()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.ArrowDown);
            NeedByDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.Enter);
            Console.WriteLine("NeedByDate is Selected From Dropdown");
            NeedByDate.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void UploadLine_NeedByDateMonthandYear()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            IWebElement NeedByDateMonth = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            IWebElement NeedByDateYear = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            if (NeedByDateMonth.Displayed && NeedByDateYear.Displayed)
            {
                Console.WriteLine("NeedByDate DatePicker contains Month and Year Dropdoen");
            }
            else
            {
                Console.WriteLine("NeedByDate DatePicker doesnot contains Month and Year Dropdoen");
                throw new Exception("NeedByDate DatePicker doesnot contains Month and Year Dropdoen");
            }
        }
        public void UploadLine_NeedByDateDisplayed()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate2));
            if (NeedByDate.Displayed)
            {
                Console.WriteLine("NeedByDate Given in the Excel Sheet is Displayed");
            }
            else
            {
                Console.WriteLine("NeedByDate Given in the Excel Sheet is Not Displayed");
                throw new Exception("NeedByDate Given in the Excel Sheet is Not Displayed");
            }
        }
        public void UploadLine_NeedByDateSelect()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.ArrowDown);
            NeedByDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.Enter);
            Console.WriteLine("NeedByDate is Selected From Dropdown");
            NeedByDate.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void UploadLine_CurrentDateSelect()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            string currentDate = DateTime.Now.ToString("MM-dd-yyyy");
            NeedByDate.SendKeys(currentDate);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.Enter);
            string enteredDate = NeedByDate.GetAttribute("value");
            if (enteredDate.Equals(currentDate))
            {
                Console.WriteLine("Allowing to Select the Current Date as NeedByDate");
                throw new Exception("Allowing to Select the Current Date as NeedByDate");
            }
            else
            {
                Console.WriteLine("Not Allowed to Select the Current Date as NeedByDate");
            }   
        }
        public void UploadLine_NeedByDateManually()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(uploadline_needbyDate));
            NeedByDate.Click();
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.ArrowDown);
            NeedByDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            NeedByDate.SendKeys(Keys.Enter);
        }
        public void UploadLine_DeleteEnabled()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            Actions act = new Actions(driver);
            act.ScrollToElement(DeleteIcon).Perform();
            if (DeleteIcon.Enabled)
            {
                Console.WriteLine("Upload Line Delete icon is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Delete icon is disabled");
                throw new Exception("Upload Line Delete icon is disabled");
            }
        }
        public void UploadLine_DeleteCancel()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            IWebElement Scroll = driver.FindElement(By.XPath("//span[text()='Download template']/following::div[text()='Action']"));
            Scroll.Click();
            Actions act = new Actions(driver);
           
            if (DeleteIcon.Enabled)
            {
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Uploadlinedelete)));
                act.MoveToElement(DeleteIcon).Click().Perform();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Upload Line is Not Deleted When Clicked on Cancel");
            }
            else
            {
                Console.WriteLine("Upload Line is Deleted When Clicked on Cancel");
                throw new Exception("Upload Line is Deleted When Clicked on Cancel");
            }
        }
        public void UploadLine_DeleteClickOk()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            Actions act = new Actions(driver);
            if (DeleteIcon.Displayed)
            {
                act.MoveToElement(DeleteIcon).Click().Perform();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("Upload Line Deleted Successfully When Clicked on OK");
            }
            else
            {
                Console.WriteLine("Upload Line Not Deleted When Clicked on OK");
                throw new Exception("Upload Line Not Deleted When Clicked on OK");
            }
            //Thread.Sleep(1000);
        }
        public void UploadLine_DeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(toast)));
            IWebElement Deletetoast = driver.FindElement(By.XPath(toast));
            if (Deletetoast.Displayed)
            {
                Console.WriteLine("Successfully Deleted Toast is displayed");
            }
            else
            {
                Console.WriteLine("Successfully Deleted Toast is Not displayed");
                throw new Exception("Successfully Deleted Toast is Not displayed");
            }
        }
        public void UploadLine_ScrollFunction()
        {

        }
        public void IR_Line_DeleteEnabled()
        {
            driver.Navigate().Refresh();
            Actions act = new Actions(driver);
            Thread.Sleep(3000);
            LineAccordion();
            driver.FindElement(By.XPath("//div[text()='Line Number']")).Click();
            IWebElement DeleteIcon = driver.FindElement(By.XPath(lineDeleteicon));
            act.ScrollToElement(DeleteIcon).Perform();
            if (DeleteIcon.Enabled)
            {
                Console.WriteLine("IR Line Delete icon is Enabled");
            }
            else
            {
                Console.WriteLine("IR Line Delete icon is Disabled");
                throw new Exception("IR Line Delete icon is Disabled");
            }
        }
        public void IR_Line_DeleteCancel()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(lineDeleteicon));
            if (DeleteIcon.Enabled)
            {
                DeleteIcon.Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Line is Not Deleted When Clicked on Cancel");
            }
            else
            {
                Console.WriteLine("Line is Deleted When Clicked on Cancel");
                throw new Exception("Line is Deleted When Clicked on Cancel");
            }
        }
        public void IR_Line_DeleteOK()
        {
            IWebElement DeleteIcon = driver.FindElement(By.XPath(lineDeleteicon));
            if (DeleteIcon.Displayed)
            {
                DeleteIcon.Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("Line Deleted Successfully When Clicked on OK");
            }
            else
            {
                Console.WriteLine("Line Not Deleted When Clicked on OK");
                throw new Exception("Line Not Deleted When Clicked on OK");
            }
            Thread.Sleep(1000);
        }
        public void IR_Line_DeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(deletedtoast)));
            IWebElement Deletetoast = driver.FindElement(By.XPath(toast));
            if (Deletetoast.Displayed)
            {
                Console.WriteLine("Successfully Deleted Toast is displayed");
            }
            else
            {
                Console.WriteLine("Successfully Deleted Toast is Not displayed");
                throw new Exception("Successfully Deleted Toast is Not displayed");
            }
        }
        public void IR_Line_DeleteTable()
        {

        }
        public void IR_Line_Search()
        {

        }
        public void IR_Action()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(action)));

            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            Actions move = new Actions(driver);
            move.MoveToElement(ActionButton).Perform();
            if (ActionButton.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", ActionButton);
                Console.WriteLine("Action Button is Verified");
            }
            else
            {
                Console.WriteLine("Action Button is Disabled");
                throw new Exception("Action Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void IR_ActionOptions()
        {
            IWebElement SaveFor_later = driver.FindElement(By.XPath(saveForLater));
            IWebElement Preview = driver.FindElement(By.XPath(preview));
            IWebElement Cancel = driver.FindElement(By.XPath(cancel));

            if (SaveFor_later.Displayed && Preview.Displayed && Cancel.Displayed)
            {
                Console.WriteLine("Save For Later, cancel and Preview Options are Displayed");
            }
            else
            {
                Console.WriteLine("Save For Later, cancel and Preview Options are Not Displayed");
                throw new Exception("Save For Later, cancel and Preview Options are Not Displayed");
            }
        }
        public void IR_PreviewActionOptions()
        {
            IWebElement Update = driver.FindElement(By.XPath(update));
            IWebElement Submit = driver.FindElement(By.XPath(submit));
            if (Update.Displayed && Submit.Displayed)
            {
                Console.WriteLine("Update and Submit Options are Displayed in the Preview Mode");
            }
            else
            {
                Console.WriteLine("Update and Submit Options are Not Displayed in the Preview Mode");
                throw new Exception("Update and Submit Options are Not Displayed in the Preview Mode");
            }
        }
        public void SaveForLater()
        {
            IWebElement SFLButton = driver.FindElement(By.XPath(saveForLater));
            if (SFLButton.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", SFLButton);
                Console.WriteLine("Save For Later Button is Verified");
            }
            else
            {
                Console.WriteLine("Save For Later Button is Disabled");
                throw new Exception("Save For Later Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void Preview()
        {
            IWebElement PreviewButton = driver.FindElement(By.XPath(preview));
            if (PreviewButton.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", PreviewButton);
                Console.WriteLine("Preview Button is Verified");
            }
            else
            {
                Console.WriteLine("Preview Button is Disabled");
                throw new Exception("Preview Button is Disabled");
            }
        }
        public void Submit()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submit));
            IWebElement IRNumber = driver.FindElement(By.XPath(IRnum));

            string fullText = IRNumber.Text;// Get the full text of the h2 element
            string number = fullText.Split('#')[1].Trim();// Extract the specific number (e.g., 1275) from the full text
            IRNUM = number;
            if (SubmitButton.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", SubmitButton);
                Console.WriteLine("Submit Button is Verified");
            }
            else
            {
                Console.WriteLine("Submit Button is Disabled");
                throw new Exception("Submit Button is Disabled");
            }
        }
        public void SubmitForRejection()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submit));
            IWebElement IRNumber = driver.FindElement(By.XPath(IRnum));

            string fullText = IRNumber.Text;// Get the full text of the h2 element
            string number = fullText.Split('#')[1].Trim();// Extract the specific number (e.g., 1275) from the full text
            IRNUM_Rejected = number;
            if (SubmitButton.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", SubmitButton);
                Console.WriteLine("Submit Button is Verified");
            }
            else
            {
                Console.WriteLine("Submit Button is Disabled");
                throw new Exception("Submit Button is Disabled");
            }
            Thread.Sleep(2000);
        }
        public void SubmitToast()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Submittedtoast)));
            //IWebElement SubmitToast = driver.FindElement(By.XPath(Submittedtoast));
            //if (SubmitToast.Displayed)
            //{
            //    Console.WriteLine("Successfully Submitted Toast is displayed");
            //}
            //else
            //{
            //    Console.WriteLine("Successfully Submitted Toast is Not displayed");
            //    throw new Exception("Successfully Submitted Toast is Not displayed");
            //}
        }
        public void ClickSubmit_WithoutLine()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submit));
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].click();", SubmitButton);
            Thread.Sleep(1000);
            IWebElement ErrorToast = driver.FindElement(By.XPath("//div[text()='Please add atleast one line!']"));
            if (ErrorToast.Displayed)
            {
                Console.WriteLine("Displayed Error toast when user Submitted IR Without the Line");
            }
            else
            {
                Console.WriteLine("Not Displayed Error toast when user Submitted IR Without the Line");
                throw new Exception("Not Displayed Error toast when user Submitted IR Without the Line");
            }
            ErrorToast.Click();
            Thread.Sleep(500);
        }
        public void IRStatusAfterSubmit()
        {
            IWebElement IRStatus = driver.FindElement(By.XPath("//div[text()='Approval In Progress']"));
            if (IRStatus.Displayed)
            {
                Console.WriteLine("IR Status is 'Approval In Progress' After the Submission");
            }
            else
            {
                Console.WriteLine("IR Status is Not Displayed as 'Approval In Progress'");
                throw new Exception("IR Status is Not Displayed as 'Approval In Progress");
            }
        }
        public void IR_RequestType()
        {
            IWebElement IR_ReqType = driver.FindElement(By.XPath("//span[text()='Internal']"));
            if (IR_ReqType.Displayed)
            {
                Console.WriteLine("IR Request Type is Displayed as 'Internal'");
            }
            else
            {
                Console.WriteLine("IR Request Type is Not Displayed as 'Internal'");
                throw new Exception("IR Request Type is Not Displayed as 'Internal'");
            }
        }
        public void IR_ViewApprovalHistoryDisplayed()
        {
            IWebElement FilteredElement = driver.FindElement(By.XPath(filteredelement));
            FilteredElement.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(action)));
            ActionClick();
            Thread.Sleep(1000);
            IWebElement ViewAppHistory = driver.FindElement(By.XPath(viewapprovalhistory));
            if (ViewAppHistory.Displayed)
            {
                Console.WriteLine("View Approval History Option is Displayed under the Action Button");
            }
            else
            {
                Console.WriteLine("View Approval History Option is Not Displayed under the Action Button");
                throw new Exception("View Approval History Option is Not Displayed under the Action Button");
            }
        }
        public void IR_ViewApprovalHistory()
        {
            IWebElement ViewAppHistory = driver.FindElement(By.XPath(viewapprovalhistory));
            ViewAppHistory.Click();
            Thread.Sleep(2000);
            IWebElement Approverdetails = driver.FindElement(By.XPath("//div[text()='Pending for Approval']"));
            if (Approverdetails.Displayed)
            {
                Console.WriteLine("View Approval History Option is Displayed under the Action Button");
            }
            else
            {
                Console.WriteLine("View Approval History Option is Not Displayed under the Action Button");
                throw new Exception("View Approval History Option is Not Displayed under the Action Button");
            }
        }
        public void LOGOUT()
        {
            Thread.Sleep(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(profile_icon)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(500);
            IWebElement logOut = driver.FindElement(By.XPath(logout));
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].click();", logOut);
            Thread.Sleep(3000);
        }
        public void ApproverDashboard()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(approval)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(1000);

            IWebElement ApprovalSiedBar = driver.FindElement(By.XPath(approval + "//parent::div[text()='Approval']"));
            if (ApprovalSiedBar.Displayed)
            {
                ApprovalSiedBar.Click();
                Console.WriteLine("Approval Side Bar is Verified");
            }
            else
            {
                Console.WriteLine("Approval Side Bar is Not Displayed");
                throw new Exception("Element is Not Visible");
            }
            Thread.Sleep(500);
        }
        public void ApproverDashboardRefresh()
        {
            driver.Navigate().Refresh();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(approvaldashboard)));
            if (element.Displayed)
            {
                Console.WriteLine("Approver Dashboare Page Refresh is Successful");
            }
            else
            {
                Console.WriteLine("Approver Dashboare Page Refresh is Failed");
            }
        }
        public void IRApprovalEnabled()
        {
            IWebElement IR_Approval = driver.FindElement(By.XPath(IR_approval));
            if (IR_Approval.Enabled)
            {
                Console.WriteLine("IR Approval tab is Enabled");
            }
            else
            {
                Console.WriteLine("IR Approval tab is Disabled");
                throw new Exception("IR Approval tab is Disabled");
            }
        }
        public void IR_ApprovalCLick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(IR_approval)));

            IWebElement IR_Approve = driver.FindElement(By.XPath(IR_approval));
            if (IR_Approve.Displayed)
            {
                Thread.Sleep(4000);
                IR_Approve.Click();
                var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(search_select)));
                Console.WriteLine("IR Approval Tab is Verified");
            }
            else
            {
                Console.WriteLine("IR Approval Tab is Not Displayed");
                throw new Exception("IR Approval Tab is Not Displayed");
            }
            Thread.Sleep(500);
        }
        public void SearchFieldEnabled()
        {
            IWebElement search = driver.FindElement(By.XPath(requisitionsearch));
            if (search.Enabled)
            {
                Console.WriteLine("Search Field is Enabled");
            }
            else
            {
                Console.WriteLine("Search Field is Disabled");
            }
        }
        public void SearchAlphaNumeric()
        {
            IWebElement searchfield = driver.FindElement(By.XPath(requisitionsearch));
            searchfield.Click();
            var searchtext = RandomString1(random1, 10);
            searchfield.SendKeys(searchtext);
            string enteredtext = searchfield.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~!@#$%^&*()_+{}[\|;':<>,./?]{1,100}$");
            if (rgx.IsMatch(enteredtext))
            {
                Console.WriteLine("Search Field is Allowing Alpha Numeric and Special Characters");
            }
            else
            {
                Console.WriteLine("Search Field is Not Allowing Alpha Numeric and Special Characters");
            }
            Thread.Sleep(1000);
            searchfield.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();

        }
        public void StatusSelect()
        {
            IWebElement clear = driver.FindElement(By.XPath("(//*[name()='svg' and contains(@class,'css-8mmkcg')])[1]"));
            IWebElement searchStatus = driver.FindElement(By.XPath("//div[@class=' css-19bb58m']"));
            clear.Click();
            Thread.Sleep(500);
            searchStatus.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
        }
        public void IR_Search()
        {
            IWebElement search1 = driver.FindElement(By.XPath(requisitionsearch));
            search1.Click();
            search1.Clear();
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM);
            Thread.Sleep(500);
            search1.SendKeys(Keys.Control + "a");
            search1.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM);
            Thread.Sleep(1000);
        }
        public void IR_Search2()
        {
            IWebElement search1 = driver.FindElement(By.XPath(requisitionsearch));
            search1.Click();
            search1.Clear();
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM_Rejected);
            Thread.Sleep(500);
            search1.SendKeys(Keys.Control + "a");
            search1.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM_Rejected);
            Thread.Sleep(1000);
        }
        public void IR_Search_Rejected()
        {
            IWebElement search1 = driver.FindElement(By.XPath(requisitionsearch));
            search1.Click();
            search1.Clear();
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM_Rejected);
            Thread.Sleep(500);
            search1.SendKeys(Keys.Control + "a");
            search1.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys(IRNUM_Rejected);
            Thread.Sleep(1000);
        }
        public void IR_SearchClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(search_select)));
            IWebElement ele = driver.FindElement(By.XPath(search_select));
            if (element1.Displayed)
            {
                ele.Click();
                Thread.Sleep(3000);
                Console.WriteLine("Searched Text is Filtered from the Table");
            }
            else
            {
                Console.WriteLine("Searched Text is Not Filtered from the Table");
                throw new Exception("Searched Text is Not Filtered from the Table");
            }
        }
        public void IR_LinesDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(internalrequest)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,800)");
            IWebElement Lines = driver.FindElement(By.XPath(linesAccordion));
            Lines.Click();
            js.ExecuteScript("scroll(0,500)");
            Thread.Sleep(1000);
            IWebElement lines_on_table = driver.FindElement(By.XPath("(//div[@class='rt-tr -odd'])[1]"));
            if (lines_on_table.Displayed)
            {
                Console.WriteLine("IR Lines are Displayed");
            }
            else
            {
                Console.WriteLine("IR Lines are Not Displayed");
                throw new Exception("IR Lines are Not Displayed");
            }
        }
        public void ApprovalGoBackEnabled()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(goback)));
            if (element1.Enabled)
            {
                Console.WriteLine("Goback Button is Enabled");
            }
            else
            {
                Console.WriteLine("Goback Button is Disabled");
            }
            Thread.Sleep(100);
        }
        public void ApprovalGoBackClick()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(goback)));
            Actions action1 = new Actions(driver);
            action1.MoveToElement(element1).Click().Perform();
            Thread.Sleep(2000);
            IWebElement Dashboard = driver.FindElement(By.XPath(approvaldashboard));
            if (Dashboard.Displayed)
            {
                Console.WriteLine("Clicked on GoBack Button and Page is Redirected to Approver Dashboard");
            }
            else
            {
                Console.WriteLine("Clicked on GoBack Button and Page is Not Redirected to Approver Dashboard");
            }
        }
        public void Doc_ActionEnabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(doc_action)));
            IWebElement action = driver.FindElement(By.XPath(doc_action));
            if (action.Enabled)
            {
                Console.WriteLine("Action Button is Enabled");
            }
            else
            {
                Console.WriteLine("Action Button is Disabled");
                throw new Exception("Action Button is Disabled");
            }
            Thread.Sleep(1000);
        }
        public void Doc_Action()
        {
            IWebElement action = driver.FindElement(By.XPath(doc_action));
            action.Click();
            Thread.Sleep(1000);
            IWebElement Approve = driver.FindElement(By.XPath("//li[text()='Approve']"));
            IWebElement Reject = driver.FindElement(By.XPath("//li[text()='Reject']"));
            IWebElement ViewHistory = driver.FindElement(By.XPath("//li[text()='View Approval History']"));

            if (Approve.Displayed && Reject.Displayed && ViewHistory.Displayed)
            {

                Console.WriteLine("Approve, Reject and View Approval History Options are Displayed");
            }
            else
            {
                Console.WriteLine("Approve, Reject and View Approval History Options are Not Displayed");
                throw new Exception("Approve, Reject and View Approval History Options are Not Displayed");
            }
            Thread.Sleep(1000);
        }
        public void ViewApprovalHistory()
        {
            IWebElement ViewAppr_History = driver.FindElement(By.XPath("//li[text()='View Approval History']"));
            ViewAppr_History.Click();
            Thread.Sleep(1000);
            IWebElement VAH_Screen = driver.FindElement(By.XPath("//button[text()='View Approval History']"));
            if (VAH_Screen.Displayed)
            {
                Console.WriteLine("View Approval History Screen is Displayed");
            }
            else
            {
                Console.WriteLine("View Approval History Screen is Not Displayed");
            }
        }
        public void IR_ViewAppHistory_Approved()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Approved'][1]")));
            IWebElement Approved = driver.FindElement(By.XPath("//div[text()='Approved'][1]"));
            if (Approved.Displayed)
            {
                Console.WriteLine("IR Status is Displayed as 'Approved'");
            }
            else
            {
                Console.WriteLine("IR Status is Not Displayed as 'Approved'");
                throw new Exception("IR Status is Not Displayed as 'Approved'");
            }
        }
        public void IR_ViewAppHistory_Rejected()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Rejected'][1]")));
            IWebElement Approved = driver.FindElement(By.XPath("//div[text()='Rejected'][1]"));
            if (Approved.Displayed)
            {
                Console.WriteLine("IR Status is Displayed as 'Approved'");
            }
            else
            {
                Console.WriteLine("IR Status is Not Displayed as 'Approved'");
                throw new Exception("IR Status is Not Displayed as 'Approved'");
            }
        }
        public void HistoryGoback()
        {
            IWebElement HistoryGobackButton = driver.FindElement(By.XPath("//button[@class='tabButton tabButtonSelected ion-arrow-left-c']"));
            HistoryGobackButton.Click();
            Thread.Sleep(1000);
            IWebElement DocScreen = driver.FindElement(By.XPath("//span[text()='Action']"));
            if (DocScreen.Displayed)
            {
                Console.WriteLine("View Approval History Go back Button is Verified");
            }
            else
            {
                Console.WriteLine("View Approval History Go back Button is Disabled");
            }
        }
        public void Approval()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(approval)));
            IWebElement Approval = driver.FindElement(By.XPath(approval));
            if (Approval.Displayed)
            {
                Approval.Click();
                Console.WriteLine("Approval Option is Verified");
            }
            else
            {
                Console.WriteLine("Approval Option Bar is Not Displayed");
                throw new Exception("Approval Option Bar is Not Displayed");
            }

        }
        public void Approval_Notification()
        {
            IWebElement ApprovalOption = driver.FindElement(By.XPath(approvalnotification));
            if (ApprovalOption.Displayed)
            {
                ApprovalOption.Click();
                Console.WriteLine("Approval Notification Option is Verified");
            }
            else
            {
                Console.WriteLine("Approval Notification Option Bar is Not Displayed");
                throw new Exception("Element is Not Visible");
            }
            Thread.Sleep(4000);
        }
        public void IR_Approval()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(IR_approval)));

            IWebElement IR_Approve = driver.FindElement(By.XPath(IR_approval));
            if (IR_Approve.Displayed)
            {
                IR_Approve.Click();
                Thread.Sleep(3000);
                Console.WriteLine("Requisition Approval Header is Verified");
            }
            else
            {
                Console.WriteLine("Requisition Approval Header is Not Displayed");
                throw new Exception("Element is Not Visible");
            }
            Thread.Sleep(500);
        }
        public void Approve()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(document_Approve)));
            IWebElement ApproveOption = driver.FindElement(By.XPath(document_Approve));
            if (ApproveOption.Enabled)
            {
                ApproveOption.Click();
                Console.WriteLine("Approve Option is Verified");
            }
            else
            {
                Console.WriteLine("Approve Option is Disabled");
            }
            Thread.Sleep(500);

            IWebElement ApproveComment = driver.FindElement(By.XPath(comments));
            if (ApproveComment.Enabled)
            {
                ApproveComment.Click();
                var autostring = RandomString(random, 10);
                ApproveComment.SendKeys(autostring);
                string Enteredcomments = ApproveComment.GetAttribute("value");

                Regex rgx = new Regex(@"^[A-za-z0-9' '~`!@#$%^&*()_+={}{[\|:;'<>,./?-]{1,400}$");
                if (rgx.IsMatch(Enteredcomments))
                {
                    Console.WriteLine("Approver Comment is Verified");
                }
                else if (Enteredcomments.StartsWith(' '))
                {
                    Console.WriteLine("Approver Comments Should not Starts with Space");
                }
                else
                {
                    Console.WriteLine("Approver Comments is Incorrect");
                    throw new Exception("Approver Comments is Incorrect");
                }
            }
            IWebElement ApproveSubmit1 = driver.FindElement(By.XPath(document_action_Approve));
            if (ApproveSubmit1.Enabled)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", ApproveSubmit1);
                Console.WriteLine("Approver Submit Button is Verified");
            }
            else
            {
                Console.WriteLine("Approver Submit Button is Disabled");
            }
            Thread.Sleep(1000);
        }
        public void ApproveCommentsEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(comments)));
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Enabled)
            {
                Console.WriteLine("Comments Field is Enabled");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void ApproveCommentsMandatory()
        {
            IWebElement CommentsMandatory = driver.FindElement(By.XPath(commentsmandatory));
            if (CommentsMandatory.Displayed)
            {
                Console.WriteLine("Comments mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Comments mandatory Symbol is Not Displayed");
                throw new Exception("Comments mandatory Symbol is Not Displayed");
            }
        }
        public void ApproveCommentsSpace()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys(" ");
            string EnteredCompName = Comments.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Approve Comments is not taking Space in the beginning");
            }
            else
            {
                Console.WriteLine("Approve Comments is taking Space in the beginning");
                throw new Exception("Approve Comments is taking Space in the beginning");
            }
        }
        public void ApproveCommentsUpto400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C400chars = RandomString1(random1, 400);
            Comments.SendKeys(C400chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Comments Upto 400 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Upto 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void ApproveCommentsAbove400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var C405chars = RandomString1(random1, 405);
            Comments.SendKeys(C405chars);
            string Enteredtext = Comments.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,400}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Comments Above 400 Characters");
            }
            else
            {
                Console.WriteLine("Allowewd to Enter the Comments Above 400 Characters");
            }
            Comments.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void ApproveCommentsEdit()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            Comments.SendKeys("test");
            Thread.Sleep(500);
            Comments.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Comments.SendKeys(Keys.Backspace);
            Comments.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Comments.SendKeys("es");
            string Actualtext = Comments.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Comments Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Comments Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Comments Field Allowed to Edit the Text in the Middle");
            }
            Comments.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CancelEnabled()
        {
            IWebElement Cancel = driver.FindElement(By.XPath(cancelButton));
            if (Cancel.Enabled)
            {
                Console.WriteLine("Cancel Button is Enabled");
            }
            else
            {
                Console.WriteLine("Cancel Button is Disabled");
                throw new Exception("Cancel Button is Disabled");
            }
        }
        public void CancelClick()
        {
            IWebElement Cancel = driver.FindElement(By.XPath(cancelButton));
            Cancel.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Action']")));
            IWebElement IR_ApprovalScreen = driver.FindElement(By.XPath("//span[text()='Action']"));
            if (IR_ApprovalScreen.Displayed)
            { 
                Console.WriteLine("Page is Redirected to the IR Approval Screen When clicked on Cancel Button");
            }
            else
            {
                Console.WriteLine("Page is Not Redirected to the IR Approval Screen When clicked on Cancel Button");
                throw new Exception("Page is Not Redirected to the IR Approval Screen When clicked on Cancel Button");
            }
        }
        public void ApproveComments()
        {
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            if (Comments.Displayed)
            {
                Comments.SendKeys(testData["IR Approve Comments"]);
                Console.WriteLine("Comments Field is Verified");
            }
            else
            {
                Console.WriteLine("Comments Field is Disabled");
                throw new Exception("Comments Field is Disabled");
            }
        }
        public void ApproveButtonEnabled()
        {
            IWebElement ApproveButton = driver.FindElement(By.XPath(document_action_Approve));
            if (ApproveButton.Enabled)
            {
                Console.WriteLine("Approve Button is Enabled");
            }
            else
            {
                Console.WriteLine("Approve Button is Disabled");
                throw new Exception("Approve Button is Disabled");
            }
        }
        public void ApproveButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(document_action_Approve)));
            IWebElement ApproveButton = driver.FindElement(By.XPath(document_action_Approve));
            ApproveButton.Click();
            var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Successfully Approved']")));
            IWebElement Toast = driver.FindElement(By.XPath("//div[text()='Successfully Approved']"));
            if (Toast.Displayed)
            {
                Console.WriteLine("IR Successfully Approved Toast is Displayed");
            }
            else
            {
                Console.WriteLine("IR Successfully Approved Toast is Not Displayed");
                throw new Exception("IR Successfully Approved Toast is Not Displayed");
            }
            Thread.Sleep(2000);
        }
        public void RejectButtonClick()
        {
            IWebElement RejectButton = driver.FindElement(By.XPath(document_action_Reject));
            RejectButton.Click();
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Successfully Rejected']")));
            IWebElement Toast = driver.FindElement(By.XPath("//div[text()='Successfully Rejected']"));
            if (Toast.Displayed)
            {
                Console.WriteLine("IR Successfully Rejected Toast is Displayed");
            }
            else
            {
                Console.WriteLine("IR Successfully Rejected Toast is Not Displayed");
                throw new Exception("IR Successfully Rejected Toast is Not Displayed");
            }
            Thread.Sleep(2000);
        }
        public void Reject()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(document_reject)));
            IWebElement RejectOption = driver.FindElement(By.XPath(document_reject));
            if (RejectOption.Enabled)
            {
                RejectOption.Click();
                Console.WriteLine("Reject Option is Verified");
            }
            else
            {
                Console.WriteLine("Reject Option is Disabled");
            }
            Thread.Sleep(500);

            IWebElement RejectComment = driver.FindElement(By.XPath(comments));
            if (RejectComment.Enabled)
            {
                RejectComment.Click();
                var autostring = RandomString(random, 10);
                RejectComment.SendKeys(autostring);
                string EnteredRejectcomments = RejectComment.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-za-z0-9' '~`!@#$%^&*()_+={}{[\|:;'<>,./?-]{1,400}$");
                if (rgx.IsMatch(EnteredRejectcomments))
                {
                    Console.WriteLine("Reject Comment is Verified");
                }
                else if (EnteredRejectcomments.StartsWith(' '))
                {
                    Console.WriteLine("Reject Comments Should not Starts with Space");
                }
                else
                {
                    Console.WriteLine("Reject Comments is Incorrect");
                    throw new Exception("Reject Comments is Incorrect");
                }
                Thread.Sleep(500);

                IWebElement RejectSubmit = driver.FindElement(By.XPath(document_action_Reject));
                if (RejectSubmit.Enabled)
                {
                    IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                    j.ExecuteScript("arguments[0].click();", RejectSubmit);
                    Console.WriteLine("Reject Submit Button is Verified");
                }
                else
                {
                    Console.WriteLine("Reject Submit Button is Disabled");
                }
                Thread.Sleep(1000);
            }
        }
        public void ErrorValidation()
        {
            string validation_error = "//span[@class='field-validation-error-text ']|//div[contains(@class,'Toastify__toast--error')]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var ve = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(validation_error)));
            Actions action = new Actions(driver);
            action.MoveToElement(ve).Perform();

            bool isvalidationPresent = ve.Displayed;
            if (isvalidationPresent)
            {
                string error = driver.FindElement(By.XPath(validation_error)).GetAttribute("innerHTML");
                throw new InvalidOperationException(error);
            }
        }
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}