using ELIT_AutomationFramework.Utilities;
using java.util.function;
using javax.xml.ws;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using sun.net.idn;
using System.Text.RegularExpressions;

namespace ELIT_AutomationFramework.Methods.PR
{
    public class PurchaseReq_Methods
    {
        public IWebDriver driver;
        public Dictionary<string, string> testData;
        public ExcelUtility excelUtility;

        string PRNUM;
        //string PRNUM_Rejected;
        string username = "//input[@name='email']";
        string password = "//input[@type='password']";
        string login = "//button[text()='Login']";
        string MainDashboard = "//h6[text()='Create Requisition']";
        string searchsuggetion = "//input[@placeholder='Search...']/following::span[text()='Company Summary']";
        string companySummaryScreen = "//div[text()='Company Short Code']";
        string loader = "//div[@class='MuiBox-root css-v944vq']";

        string requisition = "(//li[@class='MuiListSubheader-root css-rq8mjm-MuiListSubheader-root']/span)[4]";
        string select_requisition = "//span[text()='Requisition']";
        string elitLogo = "//img[@src='/src/assets/img/logo/elit-logo.png']";
        string create = "//button[text()='Create']";
        string draftstatus = "//span[text()='Requisition Status']/following::button[text()='Month'][1]";
        string statussearch = "(//input[contains(@class,'MuiInputBase-input')])[2]";
        string filteredelement = "//div[@class='rt-tr']/following::div[@role='gridcell'][1]";
        string headerproject = "//label[text()='Project*']/following::input[1]";
        string title = "//label[contains(text(),'Title')]/following::input[1]";
        string titleMandatory = "//label[text()='Title*']";
        string prepared_byMandatory = "//label[text()='Prepared By*']";
        string prepared_byDefault = "//label[text()='Prepared By*']/following::span[text()='Singh Ms. Ashaka ']";
        string prepared_by = "//label[contains(text(),'Prepared By')]";
        string requested_by = "//label[contains(text(),'Requested By')]/following::input[1]";
        string requested_byMandatory = "//label[text()='Requested By*']";
        string operatingUnit = "//label[contains(text(),'Operating Unit')]";
        string operatingUnitmandatory = "//label[text()='Operating Unit*']";
        string operatingUniDefaultt = "//textarea[text()='ELIT Pvt Ltd']";
        //string ship_to_location = "//label[contains(text(),'Ship To Location*')]/following::input[1]";
        string ship_to_location = "//label[contains(text(),'Ship To Location*')]";
        string creationDate = "//label[contains(text(),'Creation Date')]";
        string status = "//label[contains(text(),'Status')]";
        string ship_to_locationMandatory = "//label[text()='Ship To Location*']";
        string description = "(//textarea[@name='description'])[1]";
        string descriptionMandatory = "//label[text()='Description*']";
        string cl_descriptionMandatory = "(//label[text()='Description*'])[2]";
        string fileupload = "(//input[@type='file'])[1]";
        string linefileupload = "(//input[@type='file'])[2]";
        string attachdelete = "//*[name()='path' and contains(@d,'M11.596')]";
        string Uploadlinedelete = "(//*[name()='path' and contains(@d,'M11.596')])[2]";
        string toast = "//div[contains(@class,'Toastify__toast-body')]";
        string deletedtoast = "//div[text()='Successfully Deleted']";
        string Submittedtoast = "//div[text()='Successfully Submitted']";
        string Line_delete = "(//*[name()='path' and contains(@d,'M6 19c0 1.1.9 2 2 2h8c1')])";
        string purchaserequest = "//textarea[text()='Draft']";
        string cancelButton = "//button[text()='Cancel']";
        string submitButton = "//button[text()='Submit']";
        string submitOption = "//li[text()='Submit']";
        string CancelledStatus = "//button[text()='Cancelled']";
        string searchfield = "//input[@placeholder='Search..']";
        string uploadline_table = "//div[@data-id='0']";
        string uploadline_Clear = "//button[text()='Clear']";
        string uploadline_Submit = "//button[text()='Apply']";
        string uploadline_LineType = "//input[@id='autocomplete-lineType']";
        string uploadline_Item = "//input[@id='autocomplete-lineItem']";
        string uploadline_ItemDescription = "//textarea[@name='itemDescription']";
        string uploadline_Category = "//input[@id='autocomplete-categoryName']";
        string uploadline_Unit = "//input[@id='autocomplete-uomName']";
        string uploadline_Buyer = "//input[@id='autocomplete-buyer']";
        string uploadline_Qty = "//input[@name='quantity']";
        string uploadline_needbyDate = "//input[@name='needByDate']";
        string uploadline_Brand = "//input[@name='brand']";
        string ItemDesc_error    = "//div[contains(text(),'Please provide Item Description')]";
        string category_error    = "//div[contains(text(),'Please provide Category')]";
        string unit_error        = "//div[contains(text(),'Please provide Unit')]";
        string qty_error        = "//div[contains(text(),'Please provide Quantity')]";
        string needbydate_error = "//div[contains(text(),'Please enter valid date format')]";
        string lineDeleteicon = "//div[text()='Line Number']/following::*[name()='path' and contains(@d,'M6')][1]";
        string supplier = "//input[@id='autocomplete-supplier']";
        string supplier_site = "//input[@id='autocomplete-supplierSite']";
        string supplier_contact = "//input[@id='autocomplete-supplierContact']";

        string linesAccordion = "//h6[text()='Lines']";
        string toastClear = "//*[name()='svg' and contains(@class,'h5k iconify iconify--mingcut')]";
        string go_button = "//button[text()='Go']";
        string accordionOpened = "//div[text()='Line']/following::span[text()='Action']";
        string actionDropdown = "(//input[contains(@class,'MuiInputBase')])[3]";
        string linecreate_select = "//span[text()='Action']/ancestor::div/div/select";

        string cl_linetype = "//label[text()='Line Type*']/following::input[1]";
        string cl_linetypeMandatory = "//label[text()='Line Type*']";
        string cl_item = "//label[contains(text(),'Item')]/following::input[1]";
        string cl_itemMandatory = "//label[text()='Item*']";
        string cl_quantity = "//label[contains(text(),'Quantity*')]/following::input[1]";
        string Ul_quantity = "//input[@name='quantity']";
        string cl_quantityMandatory = "//label[text()='Quantity*']";
        string cl_buyer = "//input[@id='autocomplete-buyer']";
        string cl_buyerMandatory = "//label[text()='Buyer']";
        string Cl_Need_Date = "//label[contains(text(),'Need By Date')]/following::input[1]";
        string Ul_Need_Date = "//input[@name='needByDate']";
        string Cl_Need_DateCalander = "//button[contains(@aria-label,'Choose date')]";
        string Ul_Need_DateCalander = "//button[contains(@aria-label,'Choose date')]";
        string Cl_Need_DateMandatory = "//label[text()='Need By Date*']";
        string cl_brand = "//label[text()='Preferred Brand']/following::input[@maxlength='100']";
        string Ul_brand = "//input[@name='brand']";
        string Ul_Linetype = "//input[@id='autocomplete-lineType']";
        string cl_brandMandatory = "//label[text()='Preferred Brand']";
        string cl_category = "//label[contains(text(),'Category')]/following::input[1]";
        string cl_categorymandatory = "//label[text()='Category*']";
        string cl_categoryReadOnly = "//label[contains(text(),'Category')]/following::div[1]";
        string cl_categoryDisabled = "//label[text()='Category*']/following::span[@class='labelTypeInput disabled'][1]";
        string cl_unit = "//label[text()='Unit*']/following::input[1]";
        string cl_unitMandatory = "//label[text()='Unit*']";
        string cl_unitDisabled = "//label[text()='Unit*']/following::span[@class='labelTypeInput disabled'][1]";
        string cl_description = "(//textarea[@name='description'])[2]";
        string Ul_description = "//textarea[@name='itemDescription']";
        string cl_Attachdelete = "(//*[name()='path' and contains(@d,'M11.596')])[2]";

        string apply = "//button[text()='Apply']";
        string LineCreate_apply = "//button[text()='Apply']";
        string Line_Update = "//button[text()='Update']";
        string lineApply_toast = "//div[text()='Successfully Processed']";
        string File_To_Upload = "(//input[@type='file'])[2]";
        string upload_line_item = "//input[@id='autocomplete-lineItem']";
        string upload_line_buyer = "//input[@id='autocomplete-buyer']";
        string upload_line_qty = "//input[@name='quantity']";
        string upload_line_needbydate = "//input[@name='needByDate']";
        string upload_line_brand = "//input[@name='brand']";
        //string File_To_Upload     = "(//label[text()='Attachment']/following::input[@type='file'])[2]";
        string UploadLinesubmit = "//button[text()='Submit']";

        string attach = "(//div[text()='Attachments supported'])[2]";
        string attachment = "//h6[text()='Attachment']";
        //string supplier_contact = "//label[text()='Supplier Contact']//parent::div/div/div/div/div/input";
        string File_Icon = "(//input[@type='file'])[2]";

        string goback = "//button[text()='Go Back']";
        string gobackIcon = "//button[contains(@class,'ion-arrow-left-c')]";
        string action = "//button[text()='Action']//parent::button";
        string saveForLater = "//li[text()='Save for Later']";
        string submit = "//li[text()='Submit']";
        string cancel = "//li[text()='Cancel']";

        string profile_icon = "(//div[contains(@class, 'MuiAvatar-root')])[1]";
        string logout = "//span[text()='Logout']";
        string PRnum = "//h4[contains(@class, 'MuiTypography-root')]";
        string tooltip = "//*[name()='svg' and contains(@class,'MuiSvgIcon-root editIconTable')]";

        string doc_action = "//button[text()='Action']";
        string comments = "//textarea[@name='userComment']";
        string commentsmandatory = "//label[text()='Comments *']";
        string document_action_Approve = "//span[text()='Approve']";
        string cancel_submit = "//button[text()='Submit']";
        string close_submit = "//button[text()='Submit']";

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
        public PurchaseReq_Methods(IWebDriver driver, ExcelUtility excelUtility)
        {
            this.driver = driver;
            this.excelUtility = excelUtility;
            LoadExcelTemplate();
        }
        public void LoadExcelTemplate()
        {
            try
            {
                string[] filePaths = File.ReadAllLines(@"D:\1.ELIT_AutomationFramework\Excel\PR_ExcelSheets\AllPRExcelPaths.txt");
                if (filePaths.Length == 0)
                {
                    throw new FileNotFoundException("No Excel file paths found in the text file.");
                }
                string excelPath = filePaths.Last();
                Console.WriteLine($"Latest Path read from file: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"No Excel file found or file does not exist: {excelPath}");
                }
                string sheetName = "TestData";
                excelUtility.PRLoadData(excelPath, sheetName);
                testData = excelUtility.prtestData; // Set the testData dictionary

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
            driver.Navigate().GoToUrl(testData["url"]);
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(username)));
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
        public void HomePageRefresh()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainDashboard)));
            //Thread.Sleep(5000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            string ActualTitle = driver.Title;
            string ExpectedTitle = "Common Dashboard";
            if (ExpectedTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Refresh Successful, Page Redirect to Common Dashboard");
            }
            else
            {
                Console.WriteLine("Refresh Successful, But Page Not Redirect to Common Dashboard");
                throw new Exception("Page Not Redirect to Common Dashboard");
            }
        }
        public void ElitLogo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainDashboard)));
            IWebElement ELit_Logo = driver.FindElement(By.XPath(elitLogo));
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
        public void MainDashboardCardsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainDashboard)));
            IWebElement CreateRequisitionCard = driver.FindElement(By.XPath("//h6[text()='Create Requisition']"));
            IWebElement CreatePOCard = driver.FindElement(By.XPath("//h6[text()='Create Purchase Order']"));
            IWebElement CreateQuotationCard = driver.FindElement(By.XPath("//h6[text()='Create Quotation']"));
            IWebElement ProfileManagementCard = driver.FindElement(By.XPath("//h6[text()='Profile Management']"));
            IWebElement ShipmentCard = driver.FindElement(By.XPath("//h6[text()='Shipment']"));
            IWebElement InvoiceCard = driver.FindElement(By.XPath("//h6[text()='Invoice']"));
            IWebElement PurchaseOrderCard = driver.FindElement(By.XPath("//h6[text()='Purchase Order']"));
            IWebElement RequisitionCard = driver.FindElement(By.XPath("//h6[text()='Requisition']"));
            IWebElement SourcingCard = driver.FindElement(By.XPath("//h6[text()='Sourcing']"));
            IWebElement ApprovalCard = driver.FindElement(By.XPath("//h6[text()='Approval']"));

            if (CreateRequisitionCard.Displayed && CreatePOCard.Displayed && CreateQuotationCard.Displayed && ProfileManagementCard.Displayed &&
                ShipmentCard.Displayed && InvoiceCard.Displayed && PurchaseOrderCard.Displayed && RequisitionCard.Displayed && SourcingCard.Displayed && ApprovalCard.Displayed)
            {
                Console.WriteLine("All the Module Cards are Displayed in the Main Dashboard");
            }
            else
            {
                {
                    Console.WriteLine("All the Module Cards are Not Displayed in the Main Dashboard");
                }
            }
        }
        public void MainDashboardCardsEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(MainDashboard)));
            IWebElement CreateRequisitionCard = driver.FindElement(By.XPath("//h6[text()='Create Requisition']"));
            IWebElement CreatePOCard = driver.FindElement(By.XPath("//h6[text()='Create Purchase Order']"));
            IWebElement CreateQuotationCard = driver.FindElement(By.XPath("//h6[text()='Create Quotation']"));
            IWebElement ProfileManagementCard = driver.FindElement(By.XPath("//h6[text()='Profile Management']"));
            IWebElement ShipmentCard = driver.FindElement(By.XPath("//h6[text()='Shipment']"));
            IWebElement InvoiceCard = driver.FindElement(By.XPath("//h6[text()='Invoice']"));
            IWebElement PurchaseOrderCard = driver.FindElement(By.XPath("//h6[text()='Purchase Order']"));
            IWebElement RequisitionCard = driver.FindElement(By.XPath("//h6[text()='Requisition']"));
            IWebElement SourcingCard = driver.FindElement(By.XPath("//h6[text()='Sourcing']"));
            IWebElement ApprovalCard = driver.FindElement(By.XPath("//h6[text()='Approval']"));

            if (CreateRequisitionCard.Enabled && CreatePOCard.Enabled && CreateQuotationCard.Enabled && ProfileManagementCard.Enabled &&
                ShipmentCard.Enabled && InvoiceCard.Enabled && PurchaseOrderCard.Enabled && RequisitionCard.Enabled && SourcingCard.Enabled && ApprovalCard.Enabled)
            {
                Console.WriteLine("All the Module Cards are Displayed in the Main Dashboard");
            }
            else
            {
                {
                    Console.WriteLine("All the Module Cards are Not Displayed in the Main Dashboard");
                }
            }
        }
        public void ClickOnCard()
        {
            IWebElement CreateRequisitionCard = driver.FindElement(By.XPath("//h6[text()='Create Requisition']"));
            CreateRequisitionCard.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h4[text()='Purchase Request']")));
            IWebElement CreateReqScreen = driver.FindElement(By.XPath("//h4[text()='Purchase Request']"));
            if (CreateReqScreen.Displayed)
            {
                Console.WriteLine("User Redirected to the Selected Module Screen");
            }
            else
            {
                Console.WriteLine("User Not Redirected to the Selected Module Screen");
            }
        }
        public void MainSearchIconEnabled()
        {
            IWebElement MainSearch = driver.FindElement(By.XPath("//*[name()='path' and contains(@d,'m20')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(MainSearch).Perform();
            if (MainSearch.Displayed)
            {
                Console.WriteLine("Main Search Icon is Enabled");
            }
            else
            {
                Console.WriteLine("Main Search Icon is Disabled");
                throw new Exception("Main Search Icon is Disabled");
            }
        }
        public void MainSearchIconClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            var element1 = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[name()='path' and contains(@d,'m20')]")));
            IWebElement MainSearch = driver.FindElement(By.XPath("//*[name()='path' and contains(@d,'m20')]"));
            Actions action = new Actions(driver);
            action.MoveToElement(MainSearch).Click().Perform();
            IWebElement MainSearchField = driver.FindElement(By.XPath("//input[@placeholder='Search...']"));
            if (MainSearchField.Displayed)
            {
                Console.WriteLine("Clicked on Main Search Icon and Main Search Field is Displayed");
            }
            else
            {
                Console.WriteLine("Clicked on Main Search Icon But Main Search Field is Not Displayed");
                throw new Exception("Clicked on Main Search Icon But Main Search Field is Not Displayed");
            }
        }
        public void ClickOnSuggestedModule()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(searchsuggetion)));
            IWebElement SearchSuggetion = driver.FindElement(By.XPath(searchsuggetion));
            SearchSuggetion.Click();
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(companySummaryScreen)));
            IWebElement Redirect = driver.FindElement(By.XPath(companySummaryScreen));
            if (Redirect.Displayed)
            {
                Console.WriteLine("Clicked on the Suggested Module below the Search Field");
            }
            else
            {
                Console.WriteLine("Not Clicked on the Suggested Module below the Search Field");
                throw new Exception("Not Clicked on the Suggested Module below the Search Field");
            }
        }
        public void clickOnLogo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elitLogo)));
            element.Click();
            Thread.Sleep(1000);
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
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element1 = wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath(select_requisition)));
            IWebElement RequisitionOption = driver.FindElement(By.XPath(select_requisition));
            RequisitionOption.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            IWebElement RequisitionDashboard = driver.FindElement(By.XPath("//h4[text()='Requisition']"));
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
        public void DraftPR()
        {
            IWebElement DraftStatus = driver.FindElement(By.XPath("//button[text()='Draft']"));
            DraftStatus.Click();
            IWebElement DraftSearch = driver.FindElement(By.XPath(searchfield));
            DraftSearch.Click();
            DraftSearch.SendKeys("1175");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[text()='1175']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
        }
        public void RefreshRequisitionDashboard()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(create)));
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h4[text()='Purchase Request']")));
            Thread.Sleep(1000);
            IWebElement RequisitionScreen = driver.FindElement(By.XPath("//h4[text()='Purchase Request']"));
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
            if (saveForlater.Displayed)
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
        public void GobackButtonClick()
        {
            IWebElement GobackButton = driver.FindElement(By.XPath(goback));
            Thread.Sleep(1000);
            if (GobackButton.Displayed)
            {
                Actions act = new Actions(driver);
                act.MoveToElement(GobackButton).Click().Perform();
                act.MoveToElement(GobackButton).Click().Perform();
                Console.WriteLine("Confirmation Popup is Displayed");
            }
            else
            {
                Console.WriteLine("Confirmation Popup is Not Displayed");
                throw new Exception("Confirmation Popup is Not Displayed");
            }
            Thread.Sleep(500);
        }
        public void GobackClickCancel()
        {
            driver.SwitchTo().Alert().Dismiss();
            Console.WriteLine("Confirmation Popup has been closed");
        }
        public void GobackClickOk()
        {
            IWebElement GobackButton = driver.FindElement(By.XPath(goback));
            if (GobackButton.Displayed)
            {
                Actions act = new Actions(driver);
                act.MoveToElement(GobackButton).Click().Perform();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine("Page is redirected to the Requisition Dashboard");
            }
            else
            {
                Console.WriteLine("Page is Not redirected to the Requisition Dashboard");
                throw new Exception("Page is Not redirected to the Requisition Dashboard");
            }
            Thread.Sleep(1000);
        }
        public void MainSearchIrrelevantText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Search...']")));
            IWebElement SeacrchField = driver.FindElement(By.XPath("//input[@placeholder='Search...']"));
            SeacrchField.SendKeys("test");
            IWebElement NotFound = driver.FindElement(By.XPath("//h6[text()='Not Found']"));
            if (NotFound.Displayed)
            {
                Console.WriteLine("Error message is Displayed like - Not Found");
            }
            else
            {
                {
                    Console.WriteLine("Error message is Not Displayed like - Not Found");
                    throw new Exception("Error message is Not Displayed like - Not Found");
                }
            }
            SeacrchField.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void MainSearchValidText()
        {
            IWebElement SeacrchField = driver.FindElement(By.XPath("//input[@placeholder='Search...']"));
            SeacrchField.SendKeys("Requisition");
            Actions act = new Actions(driver);
            IWebElement FilteredReq = driver.FindElement(By.XPath("//span[text()='esc']/following::span[text()='Requisition'][1]"));
            if (FilteredReq.Displayed)
            {
                Console.WriteLine("Searched Module is displayed to the User");
            }
            else
            {
                Console.WriteLine("Search Module is Not displayed to the User");
                throw new Exception("Search Module is Not displayed to the User");
            }
        }
        public void ClickOnFilteredModule()
        {
            IWebElement SeacrchField = driver.FindElement(By.XPath("//input[@placeholder='Search...']"));
            SeacrchField.SendKeys("Requisition");
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
            SeacrchField.SendKeys("Requisition");
            IWebElement FilteredReq = driver.FindElement(By.XPath("//span[text()='esc']/following::span[text()='Requisition'][1]"));
            if (FilteredReq.Displayed)
            {
                FilteredReq.Click();
                Console.WriteLine("Searched Module is displayed to the User");
            }
            else
            {
                Console.WriteLine("Search Module is Not displayed to the User");
                throw new Exception("Search Module is Not displayed to the User");
            }
        }
        public void Header_Fields()
        {
            driver.FindElement(By.XPath("(//*[name()='svg' and contains(@class,'component')])[5]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(title)));
            IWebElement Title = driver.FindElement(By.XPath(title));
            IWebElement preparedBy = driver.FindElement(By.XPath(prepared_by));
            IWebElement requestedBy = driver.FindElement(By.XPath(requested_by));
            IWebElement OperatingUnit = driver.FindElement(By.XPath(operatingUnit));
            IWebElement ShipToLoc = driver.FindElement(By.XPath(ship_to_location));
            IWebElement CreationDate = driver.FindElement(By.XPath(creationDate));
            IWebElement Status = driver.FindElement(By.XPath(status));
            IWebElement Desription = driver.FindElement(By.XPath(description));
            IWebElement Attachment = driver.FindElement(By.XPath(attachment));

            if (Title.Displayed && preparedBy.Displayed && requestedBy.Displayed && OperatingUnit.Displayed && ShipToLoc.Displayed && Desription.Displayed && Attachment.Displayed)
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
            IWebElement TitleError = driver.FindElement(By.XPath("//div[text()='Please provide Title']"));
            //IWebElement ShipToLocError = driver.FindElement(By.XPath("//div[text()='Please provide Ship To Location']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            IWebElement DescriptionError = driver.FindElement(By.XPath("//div[text()='Please provide Description']"));
            js.ExecuteScript("window.scrollTo(0,0)");
            if (TitleError.Displayed && /*ShipToLocError.Displayed &&*/ DescriptionError.Displayed)
            {
                Console.WriteLine("Mandatory Fields Error message is Displayed when Clicked on Save For later");
            }
            else
            {
                Console.WriteLine("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
                throw new Exception("Mandatory Fields Error message is Not Displayed when Clicked on Save For later");
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
        public void Header_TitleEdit()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            Title.SendKeys("test");
            Thread.Sleep(500);
            Title.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            Title.SendKeys(Keys.Backspace);
            Title.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            Title.SendKeys("es");
            string Actualtext = Title.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Title Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Title Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Title Field Not Allowed to Edit the Text in the Middle");
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
                Title.SendKeys(testData["PR Title"]);
                Console.WriteLine("Header Title Field is Verified");
            }
            else
            {
                Console.WriteLine("Header Title Field is Disabled");
                throw new Exception("Header Title Field is Disabled");
            }
        }
        public void Header_PreparedBy()
        {
            IWebElement PreparedBy = driver.FindElement(By.XPath("//textarea[@aria-invalid='false' and text()='SINGH Ms. ASHAKA']"));
            if (PreparedBy.Displayed)
            {
                Console.WriteLine("Prepared By Field Displaying Buyer in Read-Only mode");
            }
            else
            {
                Console.WriteLine("Prepared By Field Not Displaying Buyer in Read-Only mode");
                throw new Exception("Prepared By Field Not Displaying Buyer in Read-Only mode");
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
                Console.WriteLine("requested By Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("requested By Field mandatory Symbol is Not displayed");
                throw new Exception("requested By Field mandatory Symbol is Not displayed");
            }
        }
        public void Requested_bySelect()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(requested_by));
            if (Requestedby.Displayed)
            {
                Requestedby.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
                var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
                var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(ship_to_location)));
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
                //Thread.Sleep(500);
                //location.SendKeys(Keys.ArrowDown);
                //Thread.Sleep(500);
                //location.SendKeys(Keys.Enter);
                Console.WriteLine("Ship To Location is Selected");
            }
            else
            {
                Console.WriteLine("Ship To Location is Not Selected");
                throw new Exception("Ship To Location is Not Selected");
            }
        }
        public void Ship_To_LocationToolTip()
        {
            IWebElement Tooltip = driver.FindElement(By.XPath("//*[name()='svg' and @class='MuiBox-root css-1l2qb5c iconify iconify--eva']"));
            if (Tooltip.Displayed)
            {
                Console.WriteLine("Ship To Location Tool tip Function is Displayed");
            }
            else
            {
                Console.WriteLine("Ship To Location Tool tip Function is Not Displayed");
                throw new Exception("Ship To Location Tool tip Function is Not Displayed");
            }
        }
        public void PRCreationDate()
        {
            IWebElement CurrentDate = driver.FindElement(By.XPath("(//textarea[@aria-invalid='false'])[4]"));
            string ActualDate = CurrentDate.Text;
            String ExpectedDate = DateTime.Now.ToString("dd-MMM-yyyy");
            if (ActualDate.Equals(ExpectedDate))
            {
                Console.WriteLine("PR Creation Date is Displaying Current Date");
            }
            else
            {
                Console.WriteLine("PR Creation Date is Not Displaying Current Date");
                throw new Exception("PR Creation Date is Not Displaying Current Date");
            }
        }
        public void PRStatus()
        {
            IWebElement DraftStatus = driver.FindElement(By.XPath("//textarea[@aria-invalid='false' and text()='Draft']"));
            if (DraftStatus.Displayed)
            {
                Console.WriteLine("PR Status is Displayed as Draft by Default");
            }
            else
            {
                Console.WriteLine("PR Status is Not Displayed as Draft by Default");
                throw new Exception("PR Status is Not Displayed as Draft by Default");
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(attachdelete));
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(attachdelete));
            if (DeleteIcon.Enabled)
            {
                DeleteIcon.Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[text()='Cancel']")).Click();
                //driver.SwitchTo().Alert().Dismiss();
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(attachdelete));
            if (DeleteIcon.Enabled)
            {
                DeleteIcon.Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
                //driver.SwitchTo().Alert().Accept();
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(deletedtoast)));
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
        public void LinesAccordionClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");

            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(linesAccordion)));
            IWebElement line = driver.FindElement(By.XPath(linesAccordion));
            line.Click();
            var element1 = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            var element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Successfully Processed']")));
            IWebElement SuccessfulToast = driver.FindElement(By.XPath("//div[text()='Successfully Processed']"));
            if (SuccessfulToast.Displayed)
            {
                IWebElement ToastClear = driver.FindElement(By.XPath(toastClear));
                ToastClear.Click();
                Console.WriteLine("PR Saved and Successfully Processed Toast is Displayed");
            }
            else
            {
                Console.WriteLine("PR Saved and Successfully Processed Toast is missing");
                throw new Exception("PR Saved and Successfully Processed Toast is missing");
            }
            Thread.Sleep(2000);
            //line.Click();
        }
        public void LinesClick_PRNumber()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(PRnum)));
            IWebElement PRNumber = driver.FindElement(By.XPath(PRnum));
            if (PRNumber.Displayed)
            {
                Console.WriteLine("PR Number is Generated");
            }
            else
            {
                Console.WriteLine("PR Number is Not Generated");
            }
        }
        public void CancelOptionDisplayed()
        {
            IWebElement ActionButton = driver.FindElement(By.XPath(action));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            ActionButton.Click();
            IWebElement cancel = driver.FindElement(By.XPath("//li[text()='Cancel']"));
            if (cancel.Displayed)
            {
                Console.WriteLine("PR Cancel Option is Displayed");
            }
            else
            {
                Console.WriteLine("PR Cancel Option is Not Displayed");
                throw new Exception("PR Cancel Option is Not Displayed");
            }
        }
        public void CancelOptionClick()
        {
            IWebElement CancelOption = driver.FindElement(By.XPath("//li[text()='Cancel']"));
            CancelOption.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(comments)));
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
            IWebElement PRCreationScreen = driver.FindElement(By.XPath(purchaserequest));
            if (PRCreationScreen.Displayed)
            {
                IWebElement IRNumber = driver.FindElement(By.XPath(PRnum));

                string fullText = IRNumber.Text;
                string number = Regex.Match(fullText, @"\d+").Value;
                PRNUM = number;
                Console.WriteLine("Page Redirected to PR Creation Screen");
            }
            else
            {
                Console.WriteLine("Page Not Redirected to PR Creation Screen");
                throw new Exception("Page Not Redirected to PR Creation Screen");
            }
        }
        public void ClickApprove_WithoutData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(document_action_Approve)));
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
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cancel_submit)));
            IWebElement ApproveButton = driver.FindElement(By.XPath(cancel_submit));
            ApproveButton.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[contains(text(),'Please provide Comments')]"));
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
                throw new Exception("Company Name is taking Space in the beginning");
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
                throw new Exception("Not Allowewd to Enter the Comments Upto 400 Characters");
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
                throw new Exception("Allowewd to Enter the Comments Above 400 Characters");
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
                Comments.SendKeys(testData["PR Cancel Comments"]);
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Cancelled Successfully']")));
            IWebElement Toast = driver.FindElement(By.XPath("//div[text()='Cancelled Successfully']"));
            if (Toast.Displayed)
            {
                Console.WriteLine("PR Cancelled Successfully Toast is Displayed");
            }
            else
            {
                Console.WriteLine("PR Cancelled Successfully Toast is Displayed");
                throw new Exception("PR Cancelled Successfully Toast is Displayed");
            }
            Thread.Sleep(2000);
        }
        public void SubmitClickWithoutLine()
        {
            IWebElement SubmitOption = driver.FindElement(By.XPath(submitOption));
            SubmitOption.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Please add atleast one line!']")));
            IWebElement ErrorToast = driver.FindElement(By.XPath("//div[text()='Please add atleast one line!']"));

            if (ErrorToast.Displayed)
            {
                IWebElement ErrorClear = driver.FindElement(By.XPath(toastClear));
                ErrorClear.Click();
                Console.WriteLine("Error toast is Displayed when Clicked on PR Submit, without Line");
            }
            else
            {
                Console.WriteLine("Error toast is Not Displayed when Clicked on PR Submit, without Line");
                throw new Exception("Error toast is Not Displayed when Clicked on PR Submit, without Line");
            }
        }
        public void ClickOnCancelledStatus()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(CancelledStatus)));
            IWebElement Status = driver.FindElement(By.XPath(CancelledStatus));
            if (Status.Displayed)
            {
                Status.Click();
                Console.WriteLine("Cancelled PR Moved to 'Cancelled' Status");
            }
            else
            {
                Console.WriteLine("Cancelled PR Not Moved to 'Cancelled' Status");
                throw new Exception("Cancelled PR Not Moved to 'Cancelled' Status");
            }
        }
        public void SearchCancelledPR()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(searchfield)));
            IWebElement Search = driver.FindElement(By.XPath(searchfield));
            Search.SendKeys(PRNUM);
            Thread.Sleep(1000);
            IWebElement filteredDoc = driver.FindElement(By.XPath("(//div[@class='MuiDataGrid-cellContent'])[1]"));
            string ActualDoc = filteredDoc.Text;
            string ExpectedDoc = PRNUM;
            if (ActualDoc.Equals(ExpectedDoc))
            {
                Console.WriteLine("Cancelled PR Moved to 'Cancelled' Status");
            }
            else
            {
                Console.WriteLine("Cancelled PR Not Moved to 'Cancelled' Status");
                throw new Exception("Cancelled PR Not Moved to 'Cancelled' Status");
            }
        }
        public void RequestType()
        {
            IWebElement reqType = driver.FindElement(By.XPath("//div[text()='Purchase']"));
            if (reqType.Displayed)
            {
                Console.WriteLine("Request Type is Displayed as Purchase");
            }
            else
            {
                Console.WriteLine("Request Type is Not Displayed as Purchase");
                throw new Exception("Request Type is Not Displayed as Purchase");
            }
        }
        public void LinesSectionFields()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000);");
            IWebElement line = driver.FindElement(By.XPath(linesAccordion));
            line.Click();
            js.ExecuteScript("window.scrollTo(0, 1000);");
            IWebElement Create_UploadDropdown = driver.FindElement(By.XPath("(//input[contains(@class,'MuiInputBase')])[3]"));
            Thread.Sleep(500);
            IWebElement Search = driver.FindElement(By.XPath(searchfield));
            Thread.Sleep(500);
            IWebElement AddLineButton = driver.FindElement(By.XPath("(//button[contains(@class,'Primary')])[3]"));
            Thread.Sleep(500);
            IWebElement Table = driver.FindElement(By.XPath("//div[contains(@class,'Row')]"));
            if (Create_UploadDropdown.Displayed && Search.Displayed && AddLineButton.Displayed && Table.Displayed)
            {
                Console.WriteLine("All the Fields are Displayed in the Lines Section");
            }
            else
            {
                Console.WriteLine("All the Fields are Not Displayed in the Lines Section");
                throw new Exception("All the Fields are Not Displayed in the Lines Section");
            }
        }

        public void Create_UploadEnabled()
        {
            IWebElement Create_UploadDropdown = driver.FindElement(By.XPath("(//input[contains(@class,'MuiInputBase')])[3]"));
            if (Create_UploadDropdown.Enabled)
            {
                Console.WriteLine("Create/Upload Line Dropdown is Enabled");
            }
            else
            {
                Console.WriteLine("Create/Upload Line Dropdown is Not Enabled");
                throw new Exception("Create/Upload Line Dropdown is Not Enabled");
            }
        }
        public void Create_UploadOptions()
        {
            IWebElement Create_UploadDropdown = driver.FindElement(By.XPath(actionDropdown));
            Create_UploadDropdown.Click();

            IWebElement CreateOption = driver.FindElement(By.XPath("//li[text()='Create Line']"));
            IWebElement UploadOption = driver.FindElement(By.XPath("//li[text()='Upload Lines']"));
            if (CreateOption.Displayed && UploadOption.Displayed)
            {
                Console.WriteLine("Create and Upload Line Options Are Displayed");
            }
            else
            {
                Console.WriteLine("Create and Upload Line Options Are Not Displayed");
                throw new Exception("Create and Upload Line Options Are Not Displayed");
            }
        }
        public void CreateLineselect()
        {
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            lineAction.Click();
            if (lineAction.Displayed)
            {
                lineAction.SendKeys(Keys.ArrowDown);
                lineAction.SendKeys(Keys.Enter);
                Console.WriteLine("Selected the Line Option");
            }
            else
            {
                Console.WriteLine("Not Selected the Line Option");
                throw new Exception("Not Selected the Line Option");
            }
        }
        public void OtherOptionSelect()
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
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));
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
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));
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
        public void LineTypeEnabled()
        {
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetype));
            if (LineType.Enabled)
            {
                Console.WriteLine("Line Type Field is Enabled");
            }
            else
            {
                Console.WriteLine("Line Type Field is Disabled");
                throw new Exception("Line Type Field is Disabled");
            }
        }
        public void LineTypemandatory()
        {
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetypeMandatory));
            if (LineType.Displayed)
            {
                Console.WriteLine("Line Type Mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Line Type Mandatory Symbol is Not Displayed");
                throw new Exception("Line Type Mandatory Symbol is Not Displayed");
            }
        }
        public void LineTypeSelectGoods()
        {
            Actions act = new Actions(driver);
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetypeMandatory));
            act.MoveToElement(LineType).Click().Perform();
            Thread.Sleep(500);
            act.SendKeys("Goods").Perform();
            act.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            IWebElement Item = driver.FindElement(By.XPath("//label[text()='Item*']"));
            IWebElement Category = driver.FindElement(By.XPath("//label[text()='Category*']"));
            IWebElement Unit = driver.FindElement(By.XPath("//label[text()='Unit*']"));
            IWebElement Qty = driver.FindElement(By.XPath("//label[text()='Quantity*']"));
            IWebElement Buyer = driver.FindElement(By.XPath("//label[text()='Buyer']"));
            IWebElement NeedBy = driver.FindElement(By.XPath("//label[text()='Need By Date*']"));
            IWebElement Brand = driver.FindElement(By.XPath("//label[text()='Preferred Brand']"));
            IWebElement Status = driver.FindElement(By.XPath("(//label[text()='Status'])[2]"));
            IWebElement Description = driver.FindElement(By.XPath("(//label[text()='Description*'])[2]"));

            if (Item.Displayed && Category.Displayed && Unit.Displayed && Qty.Displayed && Buyer.Displayed && NeedBy.Displayed && Brand.Displayed && Status.Displayed && Description.Displayed)
            {
                Console.WriteLine("Line Type is Selected as Goods");
            }
            else
            {
                Console.WriteLine("Line Type is Not Selected as Goods");
                throw new Exception("Line Type is Not Selected as Goods");
            }
        }
        public void Line_Goods()
        {
            Actions act = new Actions(driver);
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetypeMandatory));
            act.MoveToElement(LineType).Perform();
            act.Click().Perform();
            Thread.Sleep(1000);
            act.SendKeys("Goods").Perform();
            act.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
        }
        public void LineGoods_ApplyWithoutData()
        {
            Actions act = new Actions(driver);
            IWebElement LineApply = driver.FindElement(By.XPath(apply));
            act.ScrollToElement(LineApply).Perform();
            LineApply.Click();
            IWebElement ItemError = driver.FindElement(By.XPath("//div[text()='Please provide Item']"));
            act.ScrollToElement(ItemError).Perform();
            IWebElement CategoryError = driver.FindElement(By.XPath("//div[text()='Please provide Category']"));
            IWebElement UnitError = driver.FindElement(By.XPath("//div[text()='Please provide Unit']"));
            IWebElement QtyError = driver.FindElement(By.XPath("//div[text()='Please provide Quantity']"));
            IWebElement NeedByDateError = driver.FindElement(By.XPath("//div[text()='Please provide Need By Date']"));
            if (ItemError.Displayed && CategoryError.Displayed && UnitError.Displayed && QtyError.Displayed && NeedByDateError.Displayed)
            {
                Console.WriteLine("All Mandatory Fields Error Messages are Displayed when Submitted Goods Line Without Data");
            }
            else
            {
                Console.WriteLine("All Mandatory Fields Error Messages are Not Displayed when Submitted Goods Line Without Data");
                throw new Exception("All Mandatory Fields Error Messages are Not Displayed when Submitted Goods Line Without Data");
            }
        }
        public void Line_FPS()
        {
            Actions act = new Actions(driver);
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetypeMandatory));
            act.MoveToElement(LineType).Perform();
            act.Click().Perform();
            act.SendKeys("Fixed Price Services").Perform();
            act.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
        }
        public void LineTypeSelect_FS()
        {
            Actions act = new Actions(driver);
            IWebElement LineType = driver.FindElement(By.XPath(cl_linetypeMandatory));
            act.MoveToElement(LineType).Click().Perform();
            act.SendKeys("Fixed").Perform();
            act.SendKeys(Keys.ArrowDown).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(500);
            IWebElement Category = driver.FindElement(By.XPath("//label[text()='Category*']"));
            IWebElement Unit = driver.FindElement(By.XPath("//label[text()='Unit*']"));
            IWebElement Qty = driver.FindElement(By.XPath("//label[text()='Quantity*']"));
            IWebElement Buyer = driver.FindElement(By.XPath("//label[text()='Buyer']"));
            IWebElement NeedBy = driver.FindElement(By.XPath("//label[text()='Need By Date*']"));
            IWebElement Brand = driver.FindElement(By.XPath("//label[text()='Preferred Brand']"));
            IWebElement Status = driver.FindElement(By.XPath("(//label[text()='Status'])[2]"));
            IWebElement Description = driver.FindElement(By.XPath("(//label[text()='Description*'])[2]"));

            if (Category.Displayed && Unit.Displayed && Qty.Displayed && Buyer.Displayed && NeedBy.Displayed && Brand.Displayed && Status.Displayed && Description.Displayed)
            {
                Console.WriteLine("Line Type is Selected as Fixed Price Services");
            }
            else
            {
                Console.WriteLine("Line Type is Selected as Fixed Price Services");
                throw new Exception("Line Type is Not Selected as Fixed Price Services");
            }
        }
        public void LineFPS_ApplyWithoutData()
        {
            Actions act = new Actions(driver);
            IWebElement LineApply = driver.FindElement(By.XPath(apply));
            act.ScrollToElement(LineApply).Perform();
            LineApply.Click();
            IWebElement CategoryError = driver.FindElement(By.XPath("//div[text()='Please provide Category']"));
            IWebElement UnitError = driver.FindElement(By.XPath("//div[text()='Please provide Unit']"));
            IWebElement QtyError = driver.FindElement(By.XPath("//div[text()='Please provide Quantity']"));
            IWebElement NeedByDateError = driver.FindElement(By.XPath("//div[text()='Please provide Need By Date']"));
            IWebElement DescriptionError = driver.FindElement(By.XPath("//div[text()='Please provide Description']"));
            if (DescriptionError.Displayed && CategoryError.Displayed && UnitError.Displayed && QtyError.Displayed && NeedByDateError.Displayed)
            {
                Console.WriteLine("All Mandatory Fields Error Messages are Displayed when Submitted Goods Line Without Data");
            }
            else
            {
                Console.WriteLine("All Mandatory Fields Error Messages are Not Displayed when Submitted Goods Line Without Data");
                throw new Exception("All Mandatory Fields Error Messages are Not Displayed when Submitted Goods Line Without Data");
            }
        }
        public void LineItemEnabled()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            if (Item.Enabled)
            {
                Console.WriteLine("Line Item Field is Enabled");
            }
            else
            {
                Console.WriteLine("Line Item Field is Disabled");
                throw new Exception("Line Item Field is Disabled");
            }
        }
        public void LineItemMandatory()
        {
            IWebElement ItemMandatory = driver.FindElement(By.XPath(cl_itemMandatory));
            if (ItemMandatory.Displayed)
            {
                Console.WriteLine("Line item Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Line item Field Mandatory Symbol is Not displayed");
                throw new Exception("Line item Field Mandatory Symbol is Not displayed");
            }
        }
        public void LineItemClick()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            Item.Click();
            Thread.Sleep(2000);
            IWebElement ItemOption = driver.FindElement(By.XPath("//li[text()='10 dsad']"));
            if (ItemOption.Displayed)
            {
                Console.WriteLine("Line Item Options are Displayed");
            }
            else
            {
                Console.WriteLine("Line Item Options are Not Displayed");
                throw new Exception("Line Item Options are Not Displayed");
            }
        }
        public void LineitemSelect()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            //Item.Click();
            Thread.Sleep(500);
            Item.SendKeys(Keys.ArrowDown);
            Item.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Item.SendKeys(Keys.Enter);
            IWebElement ItemSelected = driver.FindElement(By.XPath("//label[text()='Category*']/following::textarea[@aria-hidden='true'][1]"));
            if (ItemSelected.Enabled)
            {
                Console.WriteLine("Line Item is Selected");
            }
            else
            {
                Console.WriteLine("Line Item is Not Selected");
                throw new Exception("Line Item is Not Selected");
            }
        }
        public void Lineitem_ReSelect()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            Item.Click();
            Thread.Sleep(500);
            Item.SendKeys(Keys.ArrowDown);
            Item.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Item.SendKeys(Keys.Enter);
            IWebElement ItemSelected = driver.FindElement(By.XPath("//label[text()='Category*']/following::textarea[@aria-hidden='true'][1]"));
            if (ItemSelected.Enabled)
            {
                Console.WriteLine("Line Item is Re-Selected");
            }
            else
            {
                Console.WriteLine("Line Item is Not Re-Selected");
                throw new Exception("Line Item is Not Re-Selected");
            }
        }
        public void LineCategoryPopulate()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            Item.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
            Item.SendKeys("AIR COOLER");
            Thread.Sleep(500);
            Item.SendKeys(Keys.ArrowDown);
            Item.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Item.SendKeys(Keys.Enter);
            IWebElement Category = driver.FindElement(By.XPath("//textarea[contains(text(),'FANS')]"));
            if (Category.Displayed)
            {
                Console.WriteLine("Category is Populated When user Selects Item");
            }
            else
            {
                Console.WriteLine("Category is Not Populated When user Selects Item");
                throw new Exception("Category is Not Populated When user Selects Item");
            }
        }
        public void LineCategory_ChangeItem()
        {
            IWebElement Item = driver.FindElement(By.XPath(cl_item));
            Item.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
            Item.SendKeys("KEYBOARD Keyboard - Wireless");
            Thread.Sleep(500);
            Item.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Item.SendKeys(Keys.Enter);
            IWebElement Category = driver.FindElement(By.XPath("//textarea[contains(text(),'ITAV')]"));
            if (Category.Displayed)
            {
                Console.WriteLine("Category is Populated When user Changes Item");
            }
            else
            {
                Console.WriteLine("Category is Not Populated When user Changes Item");
                throw new Exception("Category is Not Populated When user Changes Item");
            }
        }
        public void LineCategory_ReadOnly()
        {
            IWebElement read_Only = driver.FindElement(By.XPath(cl_categoryReadOnly));
            if (read_Only.Displayed)
            {
                Console.WriteLine("Category Field is Read-Only");
            }
            else
            {
                Console.WriteLine("Category Field is Enabled");
                throw new Exception("Category Field is Enabled");
            }
        }
        public void LineCategory_Mandatory()
        {
            IWebElement CategoryMandatory = driver.FindElement(By.XPath(cl_categorymandatory));
            if (CategoryMandatory.Displayed)
            {
                Console.WriteLine("Category Field is Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Category Field is Mandatory Symbol is Not displayed");
                throw new Exception("Category Field is Mandatory Symbol is Not displayed");
            }
        }
        public void LineCategory_Click()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_category));
            Category.Click();
            Thread.Sleep(500);
            IWebElement CategoryOption = driver.FindElement(By.XPath("//li[contains(text(),'ITAV')]"));
            if (CategoryOption.Displayed)
            {
                Console.WriteLine("Category Options are Displayed");
            }
            else
            {
                Console.WriteLine("Category Options are Not Displayed");
                throw new Exception("Category Options are Not Displayed");
            }
        }
        public void LineCategory_Select()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_category));
            //Category.Click();
            Thread.Sleep(500);
            Category.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Category.SendKeys(Keys.Enter);
            IWebElement CategorySelected = driver.FindElement(By.XPath("//input[contains(@value,'ITAV')]"));
            if (CategorySelected.Displayed)
            {
                Console.WriteLine("Line Category is Selected");
            }
            else
            {
                Console.WriteLine("Line Category is Not Selected");
                throw new Exception("Line Category is Not Selected");
            }
        }
        public void LineCategory_ReSelect()
        {
            IWebElement Category = driver.FindElement(By.XPath(cl_category));
            Category.Click();
            Thread.Sleep(500);
            Category.SendKeys(Keys.ArrowDown);
            Category.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Category.SendKeys(Keys.Enter);
            IWebElement CategorySelected = driver.FindElement(By.XPath("//input[contains(@value,'FANS')]"));
            if (CategorySelected.Displayed)
            {
                Console.WriteLine("Line Category is Re-Selected");
            }
            else
            {
                Console.WriteLine("Line Category is Not Re-Selected");
                throw new Exception("Line Category is Not Re-Selected");
            }
        }
        public void LineUnit_Enabled()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unit));
            if (Unit.Enabled)
            {
                Console.WriteLine("Line Unit Field is Enabled");
            }
            else
            {
                Console.WriteLine("Line Unit Field is Disabled");
                throw new Exception("Line Unit Field is Disabled");
            }

        }
        public void LineUnit_Mandatory()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unitMandatory));
            if (Unit.Displayed)
            {
                Console.WriteLine("Line Unit Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Line Unit Field Mandatory Symbol is Not displayed");
                throw new Exception("Line Unit Field Mandatory Symbol is Not displayed");
            }
        }
        public void LineUnit_Click()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unit));
            Unit.Click();
            IWebElement UnitOption = driver.FindElement(By.XPath("//li[contains(text(),'Each')]"));
            if (UnitOption.Displayed)
            {
                Console.WriteLine("Line Item Options are Displayed");
            }
            else
            {
                Console.WriteLine("Line Item Options are Not Displayed");
                throw new Exception("Line Item Options are Not Displayed");
            }
        }
        public void LineUnit_Select()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unit));
            Unit.Click();
            Thread.Sleep(500);
            Unit.SendKeys(Keys.ArrowDown);
            Unit.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Unit.SendKeys(Keys.Enter);
            IWebElement ItemSelected = driver.FindElement(By.XPath("//input[@value='Each']"));
            if (ItemSelected.Displayed)
            {
                Console.WriteLine("Line Unit is Selected");
            }
            else
            {
                Console.WriteLine("Line Unit is Not Selected");
                throw new Exception("Line Unit is Not Selected");
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
                throw new Exception("Quantity Field is Disabled");
            }
        }
        public void Buyer_Enabled()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyer));
            if (Buyer.Enabled)
            {

                Console.WriteLine("Buyer Field is Enabled");
            }
            else
            {
                Console.WriteLine("Buyer Field is Disabled");
                throw new Exception("Buyer Field is Disabled");
            }
        }
        public void Buyer_Mandatory()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyerMandatory));
            if (Buyer.Displayed)
            {
                Console.WriteLine("Buyer Field mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Buyer Field mandatory Symbol is Not displayed");
                throw new Exception("Buyer Field mandatory Symbol is Not displayed");
            }
        }
        public void Buyer_Click()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyer));
            if (Buyer.Displayed)
            {
                Buyer.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4 * 60));
                var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
                Buyer.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Buyer.SendKeys(Keys.Enter);
                Console.WriteLine("Buyer Field Options are Displayed");
            }
            else
            {
                Console.WriteLine("Buyer Field Options are Not Displayed");
                throw new Exception("Buyer Field Options are Not Displayed");
            }
        }
        public void Buyer_Select()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyer));
            if (Buyer.Displayed)
            {
                Buyer.Click();
                Thread.Sleep(500);
                Buyer.SendKeys(Keys.ArrowDown);
                Buyer.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Buyer.SendKeys(Keys.Enter);
                Console.WriteLine("Buyer is Selected");
            }
            else
            {
                Console.WriteLine("Buyer is Selected");
                throw new Exception("Buyer is Selected");
            }
        }
        public void Buyer_Enter()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyer));
            Buyer.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyDown(Keys.Control).Perform();
            act.KeyDown(Keys.Delete).Perform();
            Thread.Sleep(500);
            Buyer.SendKeys("Ramesh");
            Thread.Sleep(500);
            IWebElement FilteredBuyer = driver.FindElement(By.XPath("//li[text()='Kumar Mr. Ramesh']"));
            if (FilteredBuyer.Displayed)
            {
                Console.WriteLine("Entered Buyer is Filtered from Options");
            }
            else
            {
                Console.WriteLine("Entered Buyer is Not Filtered from Options");
                throw new Exception("Entered Buyer is Not Filtered from Options");
            }
        }
        public void Buyer_Edit()
        {
            IWebElement Buyer = driver.FindElement(By.XPath(cl_buyer));
            Buyer.Click();
            Buyer.SendKeys(Keys.Control + "a");
            Buyer.SendKeys(Keys.Delete);
            Actions act = new Actions(driver);
            act.SendKeys("test").Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.ArrowLeft).Perform();
            Thread.Sleep(500);
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            Thread.Sleep(500);
            act.SendKeys("es").Perform();
            string Actualtext = Buyer.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Buyer Field is Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Buyer Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Buyer Field Not Allowed to Edit the Text in the Middle");
            }
            Buyer.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Buyer_Reselect()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(cl_buyer));
            if (Requestedby.Displayed)
            {
                Requestedby.Click();
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.Enter);
                Console.WriteLine("Buyer Field Option is Re-Selected");
            }
            else
            {
                Console.WriteLine("Buyer Field Option is Not Re-Selected");
                throw new Exception("Buyer Field Option is Not Re-Selected");
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions act = new Actions(driver);
            IWebElement DatePicker = driver.FindElement(By.XPath(Cl_Need_DateCalander));
            DatePicker.Click();
            //IWebElement NextMonth = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[name()='path' and contains(@d,'M10 19a1')])[2]")));
            //act.MoveToElement(NextMonth).Perform();
            //act.Click().Perform();
            Thread.Sleep(500);
            IWebElement Date = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='28']")));
            act.MoveToElement(Date).Perform();
            act.Click().Perform();
            //NeedByDate.SendKeys(Keys.Enter);
            Console.WriteLine("NeedByDate is Selected From Dropdown");
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            NeedByDate.Click();
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void CurrentCL_NeedByDate()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            IWebElement title = driver.FindElement(By.XPath("//label[text()='Need By Date*']"));
            //NeedByDate.Click();
            Thread.Sleep(500);
            string date = "05-05-2022";
            DateTime nextDate = DateTime.Now.AddDays(1);
            string Next_Date = nextDate.ToString("dd-MMM-yyyy");
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
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_DateCalander));
            NeedByDate.Click();
            IWebElement NeedByDateMonth = driver.FindElement(By.XPath("(//*[name()='path' and contains(@d,'M10 19a1')])[2]"));
            IWebElement NeedByDateYear = driver.FindElement(By.XPath("//div[contains(@id, 'grid-label')]"));
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
                NeedByDate.SendKeys(Keys.Control + "a");
                //NeedByDate.SendKeys(Keys.Delete);
                NeedByDate.SendKeys(testData["Need By Date"]);
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//h6[contains(text(),'Purchase')]")).Click();
                Console.WriteLine("Valid Need By Date is Selected");
            }
            else
            {
                Console.WriteLine("Valid Need By Date is Not Selected");
                throw new Exception("Valid Need By Date is Not Selected");
            }
            Thread.Sleep(1000);
        }
        public void cl_StatusDisabled()
        {
            IWebElement PRStatus = driver.FindElement(By.XPath("//label[text()='Need By Date*']/following::textarea[@readonly][1]"));
            if (PRStatus.Displayed)
            {
                Console.WriteLine("PR Status Field is Disabled");
            }
            else
            {
                Console.WriteLine("PR Status Field is Enabled");
                throw new Exception("PR Status Field is Enabled");
            }
        }
        public void cl_StatusDraft()
        {
            IWebElement PRStatus = driver.FindElement(By.XPath("(//label[text()='Status'])[2]/following::textarea[text()='Draft']"));
            if (PRStatus.Displayed)
            {
                Console.WriteLine("PR Status Displayed as Draft by Default");
            }
            else
            {
                Console.WriteLine("PR Status Not Displayed as Draft by Default");
                throw new Exception("PR Status Not Displayed as Draft by Default");
            }
        }
        public void PreferredBrandEnabled()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            if (PreferredBrand.Enabled)
            {
                Console.WriteLine("Preferred Brand Field is Enabled");
            }
            else
            {
                Console.WriteLine("Preferred Brand Field is Disabled");
                throw new Exception("Preferred Brand Field is Disabled");
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
        public void PreferredBrandSpace()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            PreferredBrand.Click();
            PreferredBrand.SendKeys(" *&@");
            string Enteredtext = PreferredBrand.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Preferred Brand is not taking Space and Special Characters");
            }
            else
            {
                Console.WriteLine("Preferred Brand is taking Space and Special Characters");
                throw new Exception("Preferred Brand is taking Space and Special Characters");
            }
        }
        public void PreferredBrandUpto100()
        {
            Actions act = new Actions(driver);
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            var C100chars = RandomString1(random1, 100);
            PreferredBrand.SendKeys(C100chars);
            string Enteredtext = PreferredBrand.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,100}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Brand Upto 100 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Brand Upto 100 Characters");
                throw new Exception("Not Allowewd to Enter the Brand Upto 100 Characters");
            }
            PreferredBrand.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void PreferredBrandAbove100()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            var C100chars = RandomString1(random1, 105);
            PreferredBrand.SendKeys(C100chars);
            string Enteredtext = PreferredBrand.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,100}$");
            Regex spcl = new Regex(@"^[^\w\s]");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Brand Above 100 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Brand Above 100 Characters");
                throw new Exception("Not Allowewd to Enter the Brand Above 100 Characters");
            }
            PreferredBrand.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void PreferredBrandEdit()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(cl_brand));
            PreferredBrand.SendKeys("test");
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.Backspace);
            PreferredBrand.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            PreferredBrand.SendKeys("es");
            string Actualtext = PreferredBrand.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Preferred Brand Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Preferred Brand Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Preferred Brand Field Not Allowed to Edit the Text in the Middle");
            }
            PreferredBrand.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Preferred_Brand()
        {
            IWebElement Title = driver.FindElement(By.XPath(cl_brand));
            if (Title.Displayed)
            {
                Title.SendKeys("test");
                Console.WriteLine("Preferred Brand Field is Verified");
            }
            else
            {
                Console.WriteLine("Preferred Brand Field is Disabled");
                throw new Exception("Preferred Brand Field is Disabled");
            }
        }
        public void Cl_DescriptionEnabled()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            if (Description.Enabled)
            {
                Console.WriteLine("Line Description Field is Enabled");
            }
            else
            {
                Console.WriteLine("Line Description Field is Disabled");
                throw new Exception("Line Description Field is Disabled");
            }
        }
        public void Cl_DescriptionMandatory()
        {
            IWebElement DescriptionMandatory = driver.FindElement(By.XPath(cl_descriptionMandatory));
            if (DescriptionMandatory.Displayed)
            {
                Console.WriteLine("Line Description Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Line Description Field Mandatory Symbol is Not displayed");
                throw new Exception("Line Description Field Mandatory Symbol is Not displayed");
            }
        }
        public void Cl_DescriptionSpace()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            Description.SendKeys(" ");
            string Enteredtext = Description.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Line Description is not taking Space  the beginning");
            }
            else
            {
                Console.WriteLine("Line Description is taking Space in the beginning");
                throw new Exception("Line Description is taking Space in the beginning");
            }
        }
        public void Cl_DescriptionUpto240()
        {
            Actions act = new Actions(driver);
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            var C240chars = RandomString1(random1, 240);
            Description.SendKeys(C240chars);
            string Enteredname = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Line Description Upto 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Line Description Upto 240 Characters");
                throw new Exception("Not Allowewd to Enter the Line Description Upto 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Cl_DescriptionAbove240()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            var C240chars = RandomString1(random1, 245);
            Description.SendKeys(C240chars);
            string Enteredtext = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Line Description Above 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Line Description Above 240 Characters");
                throw new Exception("Not Allowewd to Enter the Line Description Above 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Cl_DescriptionEdit()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
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
                Console.WriteLine("Line Description Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Line Description Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Line Description Field Allowed to Edit the Text in the Middle");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Cl_Description()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
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
                    Console.WriteLine("Line Description Field is Verified");
                }
                if (spcl.IsMatch(EnteredDesc))
                {
                    Console.WriteLine("Line Description Field Should not Starts with Space");
                }
            }
            else
            {
                Console.WriteLine("Description Field is Disabled");
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(cl_Attachdelete));
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(cl_Attachdelete));
            if (DeleteIcon.Displayed)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0,300)");
                act.MoveToElement(DeleteIcon).Perform();
                act.Click().Perform();
                IWebElement DeleteCancel = driver.FindElement(By.XPath("(//button[text()='Cancel'])[2]"));
                DeleteCancel.Click();
                Thread.Sleep(500);
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
            IWebElement DeleteIcon = driver.FindElement(By.XPath(cl_Attachdelete));
            if (DeleteIcon.Displayed)
            {
                act.MoveToElement(DeleteIcon).Perform();
                act.Click().Perform();
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
            Thread.Sleep(500);
        }
        public void Line_AttachDeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(deletedtoast)));
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
        public void SupplierSection()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            IWebElement SupplierContact = driver.FindElement(By.XPath(supplier_contact));
            Actions act = new Actions(driver);
            act.ScrollToElement(Supplier).Perform();
            if (Supplier.Displayed && SupplierSite.Displayed && SupplierContact.Displayed)
            {
                Console.WriteLine("All the Supplier Fields are Displayed");
            }
            else
            {
                Console.WriteLine("All the Supplier Fields are Not Displayed");
                throw new Exception("All the Supplier Fields are Not Displayed");
            }
        }
        public void SupplierDropdownEnabled()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            if (Supplier.Enabled)
            {
                Console.WriteLine("Supplier Dropdown is Enabled");
            }
            else
            {
                Console.WriteLine("Supplier Dropdown is Disabled");
                throw new Exception("Supplier Dropdown is Disabled");
            }
        }
        public void ClickSupplierSite()
        {
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            SupplierSite.Click();
            Thread.Sleep(500);
            bool isOptionsPresent = driver.FindElements(By.XPath("//li[contains(text(),'BBLN')]")).Any();
            if (!isOptionsPresent)
            {
                Console.WriteLine("'No Options' is Displayed when user clicks Supplier Site Without Selecting Supplier");
            }
            else
            {
                Console.WriteLine("'No Options' is Not Displayed when user clicks Supplier Site Without Selecting Supplier");
                throw new Exception("'No Options' is Not Displayed when user clicks Supplier Site Without Selecting Supplier");
            }
        }
        public void SupplierDropdownClick()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            Supplier.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            IWebElement SupplierOptions = driver.FindElement(By.XPath("//li[contains(text(),'JARIR BOOKSTORE')]"));
            if (SupplierOptions.Displayed)
            {
                Console.WriteLine("Supplier Options are Displayed");
            }
            else
            {
                Console.WriteLine("Supplier Options are Not Displayed");
                throw new Exception("Supplier Options are Not Displayed");
            }
        }
        public void SupplierSelect()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            if (Supplier.Displayed)
            {
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.ArrowDown);
                Supplier.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.Enter);
                Console.WriteLine("Supplier is Selected");
            }
            else
            {
                Console.WriteLine("Supplier is Not Selected");
                throw new Exception("Supplier is Not Selected");
            }
        }
        public void SupplierEnter()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            if (Supplier.Displayed)
            {
                Supplier.SendKeys(Keys.Control + "a");
                Supplier.SendKeys("DOOM");
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.Enter);
                Console.WriteLine("Entered the Text and Selected the Supplier");
            }
            else
            {
                Console.WriteLine("Not Entered the Text and Selected the Supplier");
                throw new Exception("Not Entered the Text and Selected the Supplier");
            }
        }
        public void SupplierReselect()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            if (Supplier.Displayed)
            {
                Supplier.Click();
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.Control + "a");
                Supplier.SendKeys(Keys.Delete);
                Thread.Sleep(500);
                Supplier.SendKeys("Branch");
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.Enter);
                Console.WriteLine("Supplier is Re-Selected");
            }
            else
            {
                Console.WriteLine("Supplier is Not Re-Selected");
                throw new Exception("Supplier is Not Re-Selected");
            }
        }
        public void SupplierSiteEnabled()
        {
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            if (SupplierSite.Enabled)
            {
                Console.WriteLine("Supplier Site Dropdown is Enabled");
            }
            else
            {
                Console.WriteLine("Supplier Site Dropdown is Disabled");
                throw new Exception("Supplier Site Dropdown is Disabled");
            }
        }
        public void SupplierSiteClick()
        {
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            SupplierSite.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            IWebElement SiteOptions = driver.FindElement(By.XPath("//li[contains(text(),'BBLN')]"));
            if (SiteOptions.Displayed)
            {
                Console.WriteLine("Supplier Site Options are Displayed");
            }
            else
            {
                Console.WriteLine("Supplier Site Options are Not Displayed");
                throw new Exception("Supplier Site Options are Not Displayed");
            }
        }
        public void SupplierSiteSelect()
        {
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            if (SupplierSite.Displayed)
            {
                Thread.Sleep(500);
                SupplierSite.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                SupplierSite.SendKeys(Keys.Enter);
                Console.WriteLine("Supplier Site is Selected");
            }
            else
            {
                Console.WriteLine("Supplier Site is Not Selected");
                throw new Exception("Supplier Site is Not Selected");
            }
        }
        public void SupplierSiteReselect()
        {
            IWebElement SupplierSite = driver.FindElement(By.XPath(supplier_site));
            if (SupplierSite.Displayed)
            {
                SupplierSite.Click();
                Thread.Sleep(500);
                SupplierSite.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                SupplierSite.SendKeys(Keys.Enter);
                Console.WriteLine("Supplier Site is Re-Selected");
            }
            else
            {
                Console.WriteLine("Supplier Site is Not Re-Selected");
                throw new Exception("Supplier Site is Not Re-Selected");
            }
        }
        public void ChangeSupplier()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            Supplier.Click();
            Thread.Sleep(500);
            Supplier.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            Supplier.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            IWebElement SupplierSite = driver.FindElement(By.XPath("//label[contains(text(),'Supplier Site')]/following::textarea[@readonly][1]"));
            if (Supplier.Displayed)
            {
                Console.WriteLine("Supplier Site is Changed when user change the Supplier");
            }
            else
            {
                Console.WriteLine("Supplier Site is Not Changed when user change the Supplier");
                throw new Exception("Supplier Site is Not Changed when user change the Supplier");
            }
        }
        public void SupplierContactDisplayed()
        {
            IWebElement SupplierContact = driver.FindElement(By.XPath("//label[contains(text(),'Supplier Contact')]/following::textarea[@readonly][1]"));
            if (SupplierContact.Displayed)
            {
                Console.WriteLine("Supplier Contact is Displayed");
            }
            else
            {
                Console.WriteLine("Supplier Contact is Not Displayed");
                throw new Exception("Supplier Contact is Not Displayed");
            }
        }
        public void CL_ApplyEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LineCreate_apply)));
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
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(LineCreate_apply)));
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(lineApply_toast)));
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
        public void CL_CreatedLine_Click()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-colindex='0']")));

            IWebElement CreatedLine = driver.FindElement(By.XPath("//div[@data-colindex='0']"));
            CreatedLine.Click();
            IWebElement CreatedLineScreen = driver.FindElement(By.XPath("//h6[contains(text(),'Update Line')]"));
            if (CreatedLineScreen.Displayed)
            {
                Console.WriteLine("Line Update Screen is Displayed");
            }
            else
            {
                Console.WriteLine("Line Update Screen is Not Displayed");
                throw new Exception("Line Update Screen is Not Displayed");
            }
        }
        public void LineCategoryEdit()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cl_category)));
            IWebElement Category = driver.FindElement(By.XPath(cl_category));
            Category.Click();
            if (Category.Displayed)
            {
                Thread.Sleep(500);
                Category.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Category.SendKeys(Keys.Enter);
                Console.WriteLine("System is allowing to Edit the Category Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Category Field");
                throw new Exception("System is Not allowing to Edit the Category Field");
            }
        }
        public void LineItemEdit()
        {
            IWebElement Item = driver.FindElement(By.XPath(upload_line_item));
            Item.Click();
            if (Item.Displayed)
            {
                Thread.Sleep(500);
                Item.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Item.SendKeys(Keys.Enter);
                Console.WriteLine("System is allowing to Edit the Item Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Item Field");
                throw new Exception("System is Not allowing to Edit the Item Field");
            }
        }
        public void LineUnitEdit()
        {
            IWebElement Unit = driver.FindElement(By.XPath(cl_unit));
            Unit.Click();
            if (Unit.Displayed)
            {
                Thread.Sleep(500);
                Unit.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Unit.SendKeys(Keys.Enter);
                Console.WriteLine("System is allowing to Edit the Unit Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Unit Field");
                throw new Exception("System is Not allowing to Edit the Unit Field");
            }
        }
        public void LineQuantityEdit()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(cl_quantity));
            Thread.Sleep(1000);
            if (Quantity.Enabled)
            {
                Quantity.Click();
                Quantity.SendKeys(Keys.Control + "a");
                Quantity.SendKeys(Keys.Control + "x");
                Quantity.SendKeys(Keys.Control + "v");
                string EnteredQuantity = Quantity.GetAttribute("value");
                Regex rgx = new Regex(@"^[0-9]{1,10}$");
                if (rgx.IsMatch(EnteredQuantity))
                {
                    Console.WriteLine("System is allowing to Edit the Quantity Field");
                }
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Quantity Field");
                throw new Exception("System is Not allowing to Edit the Quantity Field");
            }
        }
        public void LineBuyerEdit()
        {
            IWebElement Requestedby = driver.FindElement(By.XPath(cl_buyer));
            if (Requestedby.Displayed)
            {
                Requestedby.Click();
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Requestedby.SendKeys(Keys.Enter);
                Console.WriteLine("System is allowing to Edit the Buyer Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Buyer Field");
                throw new Exception("System is Not allowing to Edit the Buyer Field");
            }
        }
        public void LineNeedByDateEdit()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Cl_Need_Date));
            if (NeedByDate.Enabled)
            {
                NeedByDate.Click();
                Thread.Sleep(500);
                NeedByDate.SendKeys(Keys.Control + "a");
                //NeedByDate.SendKeys(Keys.Delete);
                NeedByDate.SendKeys(testData["Need By Date"]);
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//h6[contains(text(),'Purchase')]")).Click();
                Console.WriteLine("System is allowing to Edit the NeedByDate Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the NeedByDate Field");
                throw new Exception("System is Not allowing to Edit the NeedByDate Field");
            }
            Thread.Sleep(1000);
        }
        public void LineBrandEdit()
        {
            IWebElement Brand = driver.FindElement(By.XPath(cl_brand));
            if (Brand.Displayed)
            {
                Brand.SendKeys(Keys.Control + "a");
                Brand.SendKeys(Keys.Control + "x");
                Brand.SendKeys(Keys.Control + "v");
                Console.WriteLine("System is allowing to Edit the Preferred Brand Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Preferred Brand Field");
                throw new Exception("System is Not allowing to Edit the Preferred Brand Field");
            }
        }
        public void LineDescriptionEdit()
        {
            IWebElement Description = driver.FindElement(By.XPath(cl_description));
            if (Description.Displayed)
            {
                Description.SendKeys(Keys.Control + "a");
                Description.SendKeys(Keys.Control + "x");
                Description.SendKeys(Keys.Control + "v");
                Console.WriteLine("System is allowing to Edit the Description Field");
            }
            else
            {
                Console.WriteLine("System is Not allowing to Edit the Description Field");
                throw new Exception("System is Not allowing to Edit the Description Field");
            }
        }
        public void LineAttachmentEdit()
        {
            CL_Attachment();
        }
        public void CL_AddedAttachment()
        {
            IWebElement AddedFile = driver.FindElement(By.XPath("(//div[@class='MuiStack-root css-1cmqhw5-MuiStack-root'])[2]"));
            if (AddedFile.Displayed)
            {
                Console.WriteLine("Addded Attachment is Displyed inside the Line");
            }
            else
            {
                Console.WriteLine("Addded Attachment is Not Displyed inside the Line");
                throw new Exception("Addded Attachment is Not Displyed inside the Line");
            }
        }
        public void LineSupplierEdit()
        {
            IWebElement Supplier = driver.FindElement(By.XPath(supplier));
            Supplier.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            if (Supplier.Displayed)
            {
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Supplier.SendKeys(Keys.Enter);
                Console.WriteLine("Supplier is Selected");
            }
            else
            {
                Console.WriteLine("Supplier is Not Selected");
                throw new Exception("Supplier is Not Selected");
            }
        }
        public void CL_UpdateEnabled()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Line_Update)));
            IWebElement updatebutton = driver.FindElement(By.XPath(Line_Update));
            Thread.Sleep(500);
            Actions action = new Actions(driver);
            action.MoveToElement(updatebutton).Perform();
            if (updatebutton.Enabled)
            {
                Console.WriteLine("Update Button is Enabled");
            }
            else
            {
                Console.WriteLine("Update Button is Disabled");
                throw new Exception("Update Button is Disabled");
            }
        }
        public void CL_UpdateClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Line_Update)));
            IWebElement updatebutton = driver.FindElement(By.XPath(Line_Update));
            Thread.Sleep(500);
            Actions action = new Actions(driver);
            action.MoveToElement(updatebutton).Perform();
            Thread.Sleep(500);
            if (updatebutton.Displayed)
            {
                IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
                j.ExecuteScript("arguments[0].click();", updatebutton);
                Console.WriteLine("Update Button is Verified");
            }
            else
            {
                Console.WriteLine("Update Button Field is Disabled");
                throw new Exception("Update Button Field is Disabled");
            }
        }
        public void UploadLine_OptionDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2 * 60));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            IWebElement lineAction = driver.FindElement(By.XPath(actionDropdown));
            lineAction.Click();
            IWebElement UploadOption = driver.FindElement(By.XPath("//li[contains(text(),'Upload Line')]"));
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
            IWebElement UploadOption = driver.FindElement(By.XPath("//li[contains(text(),'Upload Line')]"));
            if (UploadOption.Displayed)
            {
                UploadOption.Click();
                Console.WriteLine("Upload Line Option Selected");
            }
            else
            {
                Console.WriteLine("Upload Line Option Not Selected");
                throw new Exception("Upload Line Option Not Selected");
            }
        }
        public void UploadLine_GO()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(go_button)));
            IWebElement GO = driver.FindElement(By.XPath(go_button));          
            GO.Click();
            Thread.Sleep(1000);
            
            var element2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Download template']")));
            IWebElement UploadScreen = driver.FindElement(By.XPath("//a[text()='Download template']"));
            if (UploadScreen.Displayed)
            {
                Console.WriteLine("Upload Line Screen is Displayed");
            }
            else
            {
                Console.WriteLine("Upload Line Screen is Not Displayed");
                throw new Exception("Upload Line Screen is Not Displayed");
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
            IWebElement PRCreation = driver.FindElement(By.XPath("//h6[text()='Lines']"));
            if (PRCreation.Displayed)
            {
                Console.WriteLine("Clicked on Cancel Button, and Page Redirect back to PR Creation Screen");
            }
            else
            {
                Console.WriteLine("Clicked on Cancel Button, But Page Not Redirect back to PR Creation Screen");
                throw new Exception("Page Not Redirect back to PR Creation Screen");
            }
        }
        public void UploadLine_Template()
        {
            IWebElement UploadScreen = driver.FindElement(By.XPath("//a[text()='Download template']"));
            if (UploadScreen.Enabled)
            {
                Console.WriteLine("Download Template Link is Enabled");
            }
            else
            {
                Console.WriteLine("Download Template Link is Disabled");
                throw new Exception("Download Template Link is Disabled");
            }
        }
        public void CancelClick()
        {
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//button[contains(text(),'Cancel')]")).Click();
        }
        public void UploadFile()
        {
            IWebElement FileIcon = driver.FindElement(By.XPath(File_Icon));
            FileIcon.SendKeys(testData["upload line path"]);
            Console.WriteLine("Line is Uploaded");
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
            Actions act = new Actions(driver);
            IWebElement UploadLine_type = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Line Type']"));
            IWebElement UploadLine_Item = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Item']"));
            IWebElement UploadLine_Desc = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Item Description']"));
            IWebElement UploadLine_Categ = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Category']"));
            IWebElement UploadLine_Unit = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Unit']"));
            IWebElement UploadLine_Buyer = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Buyer']"));
            IWebElement UploadLine_Qty = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Quantity']"));
            IWebElement UploadLine_Needby = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Need By Date']"));
            IWebElement UploadLine_Brand = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Preferred Brand']"));
            IWebElement UploadLine_Action = driver.FindElement(By.XPath("//h6[contains(text(),'Import Line')]/following::div[text()='Actions']"));
            if (UploadLine_type.Displayed && UploadLine_Item.Displayed && UploadLine_Desc.Displayed && UploadLine_Categ.Displayed && UploadLine_Unit.Displayed)
            {
                act.ScrollToElement(UploadLine_Action).Perform();
                if(UploadLine_Buyer.Displayed && UploadLine_Qty.Displayed && UploadLine_Needby.Displayed && UploadLine_Brand.Displayed && UploadLine_Action.Displayed)
                Console.WriteLine("Uploaded Line Fields are Displayed on the Table");
            }
            else
            {
                Console.WriteLine("Uploaded Line Fields are Not Displayed on the Table");
                throw new Exception("Uploaded Line Fields are Not Displayed on the Table");
            }
        }
        public void UploadLine_ClearEnabled()
        {
            Actions act = new Actions(driver);
            IWebElement UploadLine_Clear = driver.FindElement(By.XPath(uploadline_Clear));
            act.MoveToElement(UploadLine_Clear).Perform();
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
            bool islinesPresent = driver.FindElements(By.XPath("//div[@data-id='0']")).Any();
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
        public void UploadLineChangeLineType()
        {
            Actions act = new Actions(driver);
            IWebElement UploadLine_Linetype = driver.FindElement(By.XPath(uploadline_LineType));
            UploadLine_Linetype.Click();
            UploadLine_Linetype.SendKeys(Keys.Control + "a");
            UploadLine_Linetype.SendKeys("Fixed");
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.ArrowDown);
            UploadLine_Linetype.SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }
        public void UploadLine_SubmitClick_WithoutData()
        {
            Actions act = new Actions(driver);
            IWebElement UploadLine_Linetype = driver.FindElement(By.XPath(uploadline_LineType));
            UploadLine_Linetype.Click();
            Thread.Sleep(500);
            //UploadLine_Linetype.SendKeys(Keys.Control+"a");
            //Thread.Sleep(500);
            //UploadLine_Linetype.SendKeys(Keys.Delete);
            //Thread.Sleep(500);
            //UploadLine_Linetype.SendKeys("Fixed");
            //Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            IWebElement UploadLine_Apply = driver.FindElement(By.XPath(uploadline_Submit));
            act.ScrollToElement(UploadLine_Apply).Perform();
            UploadLine_Apply.Click();
            Thread.Sleep(1000);            
            IWebElement ItemDescError = driver.FindElement(By.XPath(ItemDesc_error));
            act.ScrollToElement(ItemDescError).Perform();
            IWebElement CategoryError = driver.FindElement(By.XPath(category_error));
            IWebElement UnitError = driver.FindElement(By.XPath(unit_error));
            IWebElement DateError = driver.FindElement(By.XPath(needbydate_error));
            IWebElement QuantityError = driver.FindElement(By.XPath(qty_error));
            if (ItemDescError.Displayed && CategoryError.Displayed && UnitError.Displayed && DateError.Displayed && QuantityError.Displayed)
            {
                Console.WriteLine("Error Messages are Displayed when Clicked on Submit Button Without Providing Data");
            }
            else
            {
                Console.WriteLine("Error Messages are Not Displayed when Clicked on Submit Button Without Providing Data");
                throw new Exception("Error Messages are Not Displayed when Clicked on Submit Button Without Providing Data");
            }
        }
        public void UploadLineDeleteEnabled()
        {
            Actions act = new Actions(driver);
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            act.MoveToElement(DeleteIcon).Perform();
            if (DeleteIcon.Enabled)
            {
                Console.WriteLine("Uploaded Line Delete Icon is Enabled");
            }
            else
            {
                Console.WriteLine("Uploaded Line Delete Icon is Disabled");
                throw new Exception("Uploaded Line Delete Icon is Disabled");
            }
        }
        public void UploadDeleteClickCancel()
        {
            Actions act = new Actions(driver);
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            IWebElement apply = driver.FindElement(By.XPath("//button[text()='Apply']"));
            act.ScrollToElement(apply).Perform();
            act.MoveToElement(DeleteIcon).Perform();
            if (DeleteIcon.Enabled)
            {
                act.Click().Perform();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(//button[text()='Cancel'])[2]")).Click();
                Console.WriteLine("Attachment is Not Deleted When Clicked on Cancel");
            }
            else
            {
                Console.WriteLine("Attachment is Deleted When Clicked on Cancel");
                throw new Exception("Attachment is Deleted When Clicked on Cancel");
            }
        }
        public void UploadDeleteClickOk()
        {
            Actions act = new Actions(driver);
            IWebElement DeleteIcon = driver.FindElement(By.XPath(Uploadlinedelete));
            IWebElement apply = driver.FindElement(By.XPath("//button[text()='Apply']"));
            act.ScrollToElement(apply).Perform();
            Thread.Sleep(500);
            act.ScrollToElement(DeleteIcon).Perform();
            Thread.Sleep(500);
            act.ScrollToElement(DeleteIcon).Perform();
            if (DeleteIcon.Enabled)
            {
                act.MoveToElement(DeleteIcon).Click().Perform();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
                Console.WriteLine("Attachment Deleted Successfully When Clicked on OK");
            }
            else
            {
                Console.WriteLine("Attachment Not Deleted When Clicked on OK");
                throw new Exception("Attachment Not Deleted When Clicked on OK");
            }
            Thread.Sleep(1000);
        }
        public void UploadDeleteToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(deletedtoast)));
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
            var element2 = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(deletedtoast)));
        }
        public void ChangeLineType_Goods()
        {
            IWebElement UploadLine_Linetype = driver.FindElement(By.XPath(uploadline_LineType));
            UploadLine_Linetype.Click();
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }
        public void ChangeLineType_FPS()
        {
            IWebElement UploadLine_Linetype = driver.FindElement(By.XPath(uploadline_LineType));
            UploadLine_Linetype.Click();
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            UploadLine_Linetype.SendKeys(Keys.Enter);
            Thread.Sleep(500);
        }
        public void UploadLine_GoodsLineEdit()
        {
            IWebElement UploadLine_Item = driver.FindElement(By.XPath(upload_line_item));
            IWebElement UploadLine_Buyer = driver.FindElement(By.XPath(upload_line_buyer));
            IWebElement UploadLine_Qty = driver.FindElement(By.XPath(upload_line_qty));
            IWebElement UploadLine_NeedByDate = driver.FindElement(By.XPath(upload_line_needbydate));
            IWebElement UploadLine_Brand = driver.FindElement(By.XPath(upload_line_brand));

            if (UploadLine_Item.Enabled && UploadLine_Buyer.Enabled && UploadLine_Qty.Enabled && UploadLine_NeedByDate.Enabled && UploadLine_Brand.Enabled)
            {
                Console.WriteLine("User is Allowed to Edit the Goods line Fields");
            }
            else
            {
                Console.WriteLine("User is Not Allowed to Edit the Goods line Fields");
                throw new Exception("User is Not Allowed to Edit the Goods line Fields");
            }
        }
        public void UploadLineQuantityAbove9()
        {
            IWebElement Quantity = driver.FindElement(By.XPath(Ul_quantity));
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
            Thread.Sleep(500);
            Quantity.SendKeys(Keys.Control+"a");
            Quantity.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            Quantity.SendKeys("5");
        }
        public void UL_NeedByDateEnable()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Ul_Need_Date));
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
        public void UL_NeedByDateDropdownSelect()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Actions act = new Actions(driver);
            IWebElement DatePicker = driver.FindElement(By.XPath(Ul_Need_DateCalander));
            DatePicker.Click();
            //IWebElement NextMonth = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[name()='path' and contains(@d,'M10 19a1')])[2]")));
            //act.MoveToElement(NextMonth).Perform();
            //act.Click().Perform();
            Thread.Sleep(500);
            IWebElement Date = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='28']")));
            act.MoveToElement(Date).Perform();
            act.Click().Perform();
            //NeedByDate.SendKeys(Keys.Enter);
            Console.WriteLine("NeedByDate is Selected From Dropdown");
            IWebElement NeedByDate = driver.FindElement(By.XPath(Ul_Need_Date));
            NeedByDate.Click();
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void CurrentUL_NeedByDate()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Ul_Need_Date));
            IWebElement title = driver.FindElement(By.XPath("(//input[@placeholder='Search..'])[2]"));
            //NeedByDate.Click();
            Thread.Sleep(500);
            string date = "05-05-2022";
            DateTime nextDate = DateTime.Now.AddDays(1);
            string Next_Date = nextDate.ToString("dd-MMM-yyyy");
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
        public void UL_NeedByDateMonthandYear()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Ul_Need_DateCalander));
            NeedByDate.Click();
            IWebElement NeedByDateMonth = driver.FindElement(By.XPath("(//*[name()='path' and contains(@d,'M10 19a1')])[2]"));
            IWebElement NeedByDateYear = driver.FindElement(By.XPath("//div[contains(@id, 'grid-label')]"));
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
        public void UL_NeedByDate()
        {
            IWebElement NeedByDate = driver.FindElement(By.XPath(Ul_Need_Date));
            if (NeedByDate.Enabled)
            {
                NeedByDate.Click();
                Thread.Sleep(500);
                NeedByDate.SendKeys(Keys.Control + "a");
                //NeedByDate.SendKeys(Keys.Delete);
                NeedByDate.SendKeys(testData["Need By Date"]);
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//h6[contains(text(),'Import')]")).Click();
                Console.WriteLine("Valid Need By Date is Selected");
            }
            else
            {
                Console.WriteLine("Valid Need By Date is Not Selected");
                throw new Exception("Valid Need By Date is Not Selected");
            }
            Thread.Sleep(1000);
        }
        public void UL_PreferredBrandEnabled()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            if (PreferredBrand.Enabled)
            {
                Console.WriteLine("Upload Line Preferred Brand Field is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Preferred Brand Field is Disabled");
                throw new Exception("Upload Line Preferred Brand Field is Disabled");
            }
        }
        public void UL_PreferredBrandPopupate()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            if (PreferredBrand.Displayed)
            {
                Console.WriteLine("Upload Line Preferred Brand is Populated as per the Item Selected");
            }
            else
            {
                Console.WriteLine("Upload Line Preferred Brand is Not Populated as per the Item Selected");
                throw new Exception("Upload Line Preferred Brand is Not Populated as per the Item Selected");
            }
        }
        public void UL_PreferredBrandSpace()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            PreferredBrand.Click();
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.Control+"a");
            PreferredBrand.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            PreferredBrand.SendKeys(" *&@");
            string Enteredtext = PreferredBrand.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Upload Line Preferred Brand is not taking Space and Special Characters");
            }
            else
            {
                Console.WriteLine("Upload Line Preferred Brand is taking Space and Special Characters");
                throw new Exception("Upload Line Preferred Brand is taking Space and Special Characters");
            }
        }
        public void UL_PreferredBrandUpto100()
        {
            Actions act = new Actions(driver);
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            var C100chars = RandomString1(random1, 100);
            PreferredBrand.SendKeys(C100chars);
            string Enteredtext = PreferredBrand.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,100}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Upload Line Allowewd to Enter the Brand Upto 100 Characters");
            }
            else
            {
                Console.WriteLine("Upload Line Not Allowewd to Enter the Brand Upto 100 Characters");
                throw new Exception("Upload Line Not Allowewd to Enter the Brand Upto 100 Characters");
            }
            PreferredBrand.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void UL_PreferredBrandAbove100()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            var C100chars = RandomString1(random1, 105);
            PreferredBrand.SendKeys(C100chars);
            string Enteredtext = PreferredBrand.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,100}$");
            Regex spcl = new Regex(@"^[^\w\s]");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Upload Line Brand Above 100 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Upload Line Brand Above 100 Characters");
                throw new Exception("Not Allowewd to Enter the Upload Line Brand Above 100 Characters");
            }
            PreferredBrand.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void UL_PreferredBrandEdit()
        {
            IWebElement PreferredBrand = driver.FindElement(By.XPath(Ul_brand));
            PreferredBrand.SendKeys("test");
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.ArrowLeft);
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.Backspace);
            PreferredBrand.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            PreferredBrand.SendKeys("es");
            string Actualtext = PreferredBrand.GetAttribute("value");
            string ExpectedText = "test";
            if (Actualtext.Equals(ExpectedText))
            {
                Console.WriteLine("Upload Line Preferred Brand Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Upload Line Preferred Brand Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Upload Line Preferred Brand Field Not Allowed to Edit the Text in the Middle");
            }
            PreferredBrand.Click();
            Thread.Sleep(500);
            PreferredBrand.SendKeys(Keys.Control+"a");
            PreferredBrand.SendKeys(Keys.Delete);
        }
        public void UL_Preferred_Brand()
        {
            IWebElement Brand = driver.FindElement(By.XPath(Ul_brand));
            if (Brand.Displayed)
            {
                Brand.SendKeys("test");
                Console.WriteLine("Upload Line Preferred Brand Field is Verified");
            }
            else
            {
                Console.WriteLine("Upload Line Preferred Brand Field is Disabled");
                throw new Exception("Upload Line Preferred Brand Field is Disabled");
            }
        }
        public void UL_LineTypeChange()
        {
            IWebElement LineType = driver.FindElement(By.XPath(Ul_Linetype));
            LineType.Click();
            Thread.Sleep(500);
            LineType.SendKeys(Keys.Control+"a");
            LineType.SendKeys("Fixed");
            Thread.Sleep(500);
            LineType.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        public void Ul_DescriptionEnabled()
        {
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
            if (Description.Enabled)
            {
                Console.WriteLine("Upload Line Item Description Field is Enabled");
            }
            else
            {
                Console.WriteLine("Upload Line Item Description Field is Disabled");
                throw new Exception("Upload Line Item Description Field is Disabled");
            }
        }
        public void Ul_DescriptionSpace()
        {
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
            Description.SendKeys(Keys.Control+"a");
            Thread.Sleep(500);
            Description.SendKeys(" ");
            string Enteredtext = Description.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Upload Line Item Description is not taking Space  the beginning");
            }
            else
            {
                Console.WriteLine("Upload Line Item Description is taking Space in the beginning");
                throw new Exception("Upload Line Item Description is taking Space in the beginning");
            }
        }
        public void Ul_DescriptionUpto240()
        {
            Actions act = new Actions(driver);
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
            var C240chars = RandomString1(random1, 240);
            Description.SendKeys(C240chars);
            string Enteredname = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Upload Line Item Description Upto 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Upload Line Item Description Upto 240 Characters");
                throw new Exception("Not Allowewd to Enter the Upload Line Item Description Upto 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Ul_DescriptionAbove240()
        {
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
            var C240chars = RandomString1(random1, 245);
            Description.SendKeys(C240chars);
            string Enteredtext = Description.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,240}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Upload Line Item Description Above 240 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Upload Line Item Description Above 240 Characters");
                throw new Exception("Not Allowewd to Enter the Upload Line Item Description Above 240 Characters");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Ul_DescriptionEdit()
        {
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
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
                Console.WriteLine("Upload Line Item Description Field Allowed to Edit the Text in the Middle");
            }
            else
            {
                Console.WriteLine("Upload Line Item Description Field Not Allowed to Edit the Text in the Middle");
                throw new Exception("Upload Line Item Description Field Allowed to Edit the Text in the Middle");
            }
            Description.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Ul_Description()
        {
            IWebElement Description = driver.FindElement(By.XPath(Ul_description));
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
                    Console.WriteLine("Upload Line Item Description Field is Verified");
                }
                if (spcl.IsMatch(EnteredDesc))
                {
                    Console.WriteLine("Upload Line Item Description Field Should not Starts with Space");
                }
            }
            else
            {
                Console.WriteLine("Upload Line Item Description Field is Disabled");
            }
        }
        public void Ul_Apply()
        {
            Actions act = new Actions(driver);
            IWebElement UploadLine_Apply = driver.FindElement(By.XPath(uploadline_Submit));
            act.ScrollToElement(UploadLine_Apply).Perform();
            UploadLine_Apply.Click();
        }
        public void Ul_SubmitToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2*60));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Successfully'])")));
            var element1 = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(loader)));
            IWebElement SuccessfulToast = driver.FindElement(By.XPath("//div[contains(text(),'Successfully'])"));
            if (SuccessfulToast.Displayed)
            {
                Console.WriteLine("Successfully Processed Toast is Displayed");
            }
            else
            {
                Console.WriteLine("Successfully Processed Toast is missing");
                throw new Exception("Successfully Processed Toast is missing");
            }
        }











        public void LOGOUT()
        {
            Thread.Sleep(4000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(profile_icon)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(500);
            IWebElement logOut = driver.FindElement(By.XPath(logout));
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].click();", logOut);
            Thread.Sleep(3000);
        }
        public void ErrorValidation()
        {
            string validation_error = "//span[@class='field-validation-error-text ']|//div[contains(@class,'Toastify__toast--error')]";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ve = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(validation_error)));
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