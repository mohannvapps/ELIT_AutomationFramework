using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using ELIT_AutomationFramework.Utilities;

namespace ELIT_AutomationFramework.Methods.Registration
{
    public class SupReg_Methods
    {
        public IWebDriver driver;
        public Dictionary<string, string> testData;
        public ExcelUtility excelUtility;


        string signup       = "//button[text()='Supplier Registration']";
        string goBackToLogin= "//span[text()='Go back to Login']";
        string tc_accordion = "//div[text()='Terms and Conditions']";
        string scrolltext   = "//strong[text()='Our Responsibility']";
        string agree        = "//span[text()='I Agree']";
        string decline      = "//span[text()='I Decline']";
        string errortoast   = "//div[contains(@class,'Toastify__toast--error')]";

        //Duplicate Validation
        string CompanyN     = "//span[text()='Company Name is already exist!!!']";
        string LicenseN     = "//span[text()='CR/License Number is already taken.']";
        string LicenseNum5  = "//span[text()='CR/License Number should be minimum 6 characters']";
        string EmailA       = "//span[text()='Email Address is already taken.']";
        string search       = "//input[contains(@class, 'MuiInputBase-input MuiOutlinedInput')]";
        string filter       = "//*[@id='panel1a-content']/div/div/div[5]/div[2]/div[1]/div[2]/div[1]/div/div[1]";
        string delete       = "//*[name()='path' and contains(@d,'M6 19c0 1.')]";

        string ci_accordion         = "//div[text()='Company Information']";
        string companyname          = "//label[contains(text(), 'Company Name')]/following::input[1]";
        string companynamemandatory = "(//label[contains(text(), '*')]/following::input)[1]";
        string licensenumber        = "//label[contains(text(), 'CR/License Number')]/following::input[1]";
        string licensenumbermandatory = "(//label[contains(text(), '*')]/following::input)[2]";
        string Compnamegreentick    = "(//*[name()='svg' and contains(@class,'inputMIcon positionRight7 tx-green ')])[1]";
        string licensegreentick     = "(//*[name()='svg' and contains(@class,'inputMIcon positionRight7 tx-green ')])[2]";
        string establishment_date   = "//label[contains(text(), 'Establishment Date')]/following::input[1]";
        string establishment_datemandatory = "(//label[contains(text(), '*')]/following::input)[3]";
        string addAttachment        = "//span[text()='Add Attachment']";
        string attachmenttitle      = "//span[@class='tx-white']/following::input[1]";
        string attachmenttitleMandatory = "//span[text()='Attachment']/following::label[text()='Title*']";
        string attachmentDocType    = "//span[@class='tx-white']/following::input[2]";
        string uploadfile           = "//label[text()='Upload File']/following::input[@class='react-form-input inputText']";
        string documentcategory     = "//label[contains(text(), 'Document Category')]/following::input";
        string documentcategoryMandatory = "//span[text()='Attachment']/following::label[text()='Document Category*']";
        //string fileupload         = "(//input[@type='text'])[12]";
        string file                 = "//input[@class='react-form-input inputText']";
        string description          = "//label[contains(text(), 'Description')]/following::textarea";
        string descriptionMandatory = "//span[text()='Attachment']/following::label[text()='Description*']";
        string cancel               = "//span[text()='Cancel']";
        string Submit               = "//span[@class='tx-white']/following::span[text()='Submit']";

        string title                = "//label[contains(text(),'Title')]/following::input[1]";
        string titleMandatory       = "//label[contains(text(),'Title*')]";
        string firstname            = "//label[text()='First Name*']//parent::div/div/input";
        string middlename           = "//label[text()='Middle Name']//parent::div/div/input";
        string middlenameMandatory  = "//label[contains(text(), 'Middle Name')]";
        string lastname             = "//label[text()='Last Name*']//parent::div/div/input";
        string lastnameMandatory    = "//label[contains(text(),'Last Name*')]";
        string email                = "//label[text()='Email Address*']//parent::div/div/input";
        string emailMandatory       = "//label[contains(text(),'Email Address*')]";
        string emailgreentick       = "(//*[name()='svg' and contains(@class,'inputMIcon positionRight7 tx-green ')])[3]";
        string phonenumber          = "//label[text()='Phone Number*']/following::input";
        string phonenumberMandatory = "//label[contains(text(),'Phone Number*')]";
        string phonenumberFlag      = "//div[@class='selected-flag']";
        string phonenumberCode      = "//div[text()='Phone']/following::input";
        string phonenumberclear     = "//input[@value='+966']";
        string submitButton         = "//span[text()='Submit']";
        string clearbutton          = "//span[text()='Clear']";
        string goback               = "//span[text()='Go Back']";
        string gobacktoLogin        = "//span[text()='Go back to Login']";

        //Registration Approval
        string username = "//input[@type='text']";
        string password = "//input[@type='password']";
        string login    = "//button[text()='Login Now']";

        string approval             = "//i[@class='fa fa-lg fa-thumbs-o-up']";
        string appnotification      = "//span[text()='Approval Notificat']";
        string approvaldashboard    = "//h2[text()='Approval']";
        string registrationapproval = "//button[contains(.,'Registration')]";
        string registrationapprovalsearch = "(//input[@type='text'])[1]";
        string search_select        = "//div[@class='rt-thead -header']/following::div[@class='rt-td'][1]";

        string doc_action           = "//span[text()='Action']/parent::button";
        string document_Approve     = "//div[contains(@class, 'MuiPaper-root')]/ul/li[contains(text(),'Approve')]|//button[text()='Approve']";
        string document_reject      = "//div[contains(@class, 'MuiPaper-root')]/ul/li[contains(text(),'Reject')]|//button[text()='reject']";
        string comments             = "//label[text()='Comments*']/following::textarea";
        string document_Approve_Button = "//span[text()='Approve']";
        string document_Reject_Button = "//span[text()='Reject']";
        string doc_Profile          = "(//div[contains(@class, 'MuiAvatar-root')])[1]";
        string doc_logout           = "//span[text()='Logout']";

        public SupReg_Methods(IWebDriver driver, ExcelUtility excelUtility)
        {
            this.driver = driver;
            this.excelUtility = excelUtility;
            LoadExcelTemplate(); // Ensure testData is loaded
        }
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
        public void LoadExcelTemplate()
        {
            try
            {
                // Load all file paths from the text file
                string[] filePaths = File.ReadAllLines(@"D:\1.ELIT_AutomationFramework\Excel\Registration_ExcelSheets\AllRegistrationExcelPaths.txt");
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
                excelUtility.LoginLoadData(excelPath, sheetName);
                testData = excelUtility.logintestData; // Set the testData dictionary

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
                Console.WriteLine("QA Elit Dashboard Page is Verified");
            }
            else
            {
                Console.WriteLine("QA Elit Dashboard Page URL is incorrect");
                throw new Exception("QA Elit Dashboard Page URL is incorrect");
            }
        }
        public void LoginPageRefresh()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(500);
            string ActualTitle = driver.Title;
            string ExpecteTitle = "Login | ELIT";
            if (ExpecteTitle.Equals(ActualTitle))
            {
                Console.WriteLine("QA Elit Dashboard Page Refresh Successful");
            }
            else
            {
                Console.WriteLine("QA Elit Dashboard Page URL is incorrect");
            }
        }
        public void TC_PageRefresh()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1500);
            string ActualTitle = driver.Title;
            string ExpecteTitle = "Terms and Condition | ELIT";
            if (ExpecteTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Terms & Condition Screen Refresh is Verified");
            }
            else
            {
                Console.WriteLine("Terms & Condition Screen Refresh Failed");
            }
        }
        public void SR_PageRefresh()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(1500);
            string ActualTitle = driver.Title;
            string ExpecteTitle = "Register Supplier | ELIT";
            if (ExpecteTitle.Equals(ActualTitle))
            {
                Console.WriteLine("Registration Screen Refresh is Verified");
            }
            else
            {
                Console.WriteLine("Registration Screen Refresh Failed");
            }
        }
        public void SupplierRegistration()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(signup)));
            IWebElement SignupButton = driver.FindElement(By.XPath(signup));
            Thread.Sleep(100);
            if (SignupButton.Displayed)
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                jsExecutor.ExecuteScript("arguments[0].click()", SignupButton);
                //SignupButton.Click();
                Console.WriteLine("Registration Button is Verified");
            }
            else
            {
                Console.WriteLine("Registration Button is disabled");
            }
            var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(agree)));
        }
        public void Terms_ConditionPageScroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,500)");
            Thread.Sleep(1000);
            js.ExecuteScript("scroll(0,-500)");
            IWebElement scroll_text = driver.FindElement(By.XPath(scrolltext));
            if (scroll_text.Displayed)
            {
                Console.WriteLine("Terms & Condition Screen Scroll Function is Verified");
            }
            else
            {
                Console.WriteLine("Terms & Condition Screen Scroll Function is Not Working");
            }
        }
        public void TC_Accordion()
        {
            IWebElement TCAccordion = driver.FindElement(By.XPath(tc_accordion));
            if (TCAccordion.Displayed)
            {
                TCAccordion.Click();
                Console.WriteLine("Terms & Condition Accordion is Verified");
                Thread.Sleep(1000);
                TCAccordion.Click();
            }
            else
            {
                Console.WriteLine("Terms & Condition Accordion is Disabled");
            }
        }
        public void AgreeButtonEnabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            Thread.Sleep(500);
            IWebElement TCAccordion = driver.FindElement(By.XPath(tc_accordion));
            TCAccordion.Click();
            Thread.Sleep(800);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(agree)));
            if (element.Displayed)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                Thread.Sleep(100);
                Console.WriteLine("Agree Button is Enabled");
            }
            else
            {
                Console.WriteLine("Element is not Disabled");
            }
        }
        public void ClickOnAgree()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(agree)));
            if (element.Displayed)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Click().Perform();
                Thread.Sleep(1500);
                Console.WriteLine("Agree Button is Verified");
            }
            else
            {
                Console.WriteLine("Element is not Visible");
            }
        }
        public void DeclineEnable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(decline)));
            if (element.Enabled)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                Thread.Sleep(100);
                Console.WriteLine("Decline Button is Enabled");
            }
            else
            {
                Console.WriteLine("Decline is not Disabled");
            }
        }
        public void ClickOnDecline()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(decline)));
            if (element.Displayed)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Click().Perform();
                Thread.Sleep(100);
                Console.WriteLine("Decline Button is Verified");
            }
            else
            {
                Console.WriteLine("Decline is not Visible");
            }
        }
        public void ClearErrorToast()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(errortoast)));
            IWebElement ErrorToast = driver.FindElement(By.XPath(errortoast));
            if (ErrorToast.Displayed)
            {
                ErrorToast.Click();
                Thread.Sleep(3000);
                Console.WriteLine("Error Toast Cleared");
            }
            else
            {
                Console.WriteLine("Error Toast is Not Displayed");
            }
        }
        public void CompanyInfoVisible()
        {
            Thread.Sleep(2000);
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            if (CompName.Displayed && LicenseNum.Displayed && EstablishmentDate.Displayed)
            {
                Console.WriteLine("All Text Fields are Visible");
            }
            else
            {
                Console.WriteLine("All Text Fields are Not Visible");
            }
        }
        public void CI_Accordion()
        {
            IWebElement CI_Accordionn = driver.FindElement(By.XPath(ci_accordion));
            if (CI_Accordionn.Displayed)
            {
                CI_Accordionn.Click();
                Console.WriteLine("Company info Accordion is Verified");
                Thread.Sleep(500);
                CI_Accordionn.Click();
            }
            else
            {
                Console.WriteLine("Company info Accordion is Disabled");
            }
        }
        public void CompanynameEnabled()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,0);");
            Thread.Sleep(1000);
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            if (CompName.Enabled)
            {
                Console.WriteLine("Company Name Field is Enabled");
            }
            else
            {
                Console.WriteLine("Company Name Field is Disabled");
            }
        }
        public void Companyname()
        {
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            IWebElement License = driver.FindElement(By.XPath(licensenumber));            
            CompName.Click();
            if (!testData.ContainsKey("Company Name"))
            {
                throw new KeyNotFoundException("The key 'Company Name' was not found in the test data.");
            }
            CompName.SendKeys(testData["Company Name"]);
            Thread.Sleep(500);
            License.Click();
            Thread.Sleep(500);
            IWebElement GreenTick = driver.FindElement(By.XPath(Compnamegreentick));
            if (GreenTick.Displayed)
            {
                Console.WriteLine("Company Name Validation is Successful");
            }
            else
            {
                Console.WriteLine("Company Name Validation not Successful");
            }
        }
        public void CompanynameUpperCase()
        {
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            string name = "test input";
            CompName.SendKeys(name);
            if (name.Equals(name.ToUpper()))
            {
                Console.WriteLine("Company Name Contains Only Upper Case Characters");
            }
            else
            {
                Console.WriteLine("Company Name Contains both Upper & Lower Case Characters");
            }
            CompName.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void Companynamemandatory()
        {
            IWebElement mandatorySym = driver.FindElement(By.XPath(companynamemandatory));
            if (mandatorySym.Displayed)
            {
                Console.WriteLine("Company Name mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Company Name mandatory Symbol is Not Displayed");
            }
        }
        public void CompanynameEnterSpace()
        {
            IWebElement compName = driver.FindElement(By.XPath(companyname));
            compName.SendKeys(" ");
            string EnteredCompName = compName.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Company Name is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Company Name is taking Space and Special Characters in the beginning");
            }
        }
        public void CompanynameUpto80Characters()
        {
            Actions act = new Actions(driver);
            IWebElement compName = driver.FindElement(By.XPath(companyname));
            var CompName_80chars = RandomString1(random1, 80);
            compName.SendKeys(CompName_80chars);
            string Enteredname = compName.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Company Name Upto 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Company Name Upto 80 Characters");
            }
            compName.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CompanynameAbove80Characters()
        {
            IWebElement compName = driver.FindElement(By.XPath(companyname));
            var CompName_80chars = RandomString1(random1, 85);
            compName.SendKeys(CompName_80chars);
            string Enteredname = compName.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            Regex spcl = new Regex(@"^[^\w\s]");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Not Allowewd to Enter the Company Name Above 80 Characters");
            }
            else
            {
                Console.WriteLine("Allowewd to Enter the Company Name Above 80 Characters");
                throw new Exception("Allowewd to Enter the Company Name Above 80 Characters");
            }
            compName.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void DuplicateCompName()
        {
            IWebElement DupcompName = driver.FindElement(By.XPath(companyname));
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            DupcompName.SendKeys("Test@123");
            LicenseNum.Click();
            Thread.Sleep(1000);
            IWebElement CompanynameValidationerror = driver.FindElement(By.XPath(CompanyN));
            if (CompanynameValidationerror.Displayed)
            {
                Console.WriteLine("Company Name Duplicate Validation is Successful");
            }
            else
            {
                Console.WriteLine("Company Name Duplicate Validation is Failed");
            }
            DupcompName.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void CompInfoDisable()
        {
            IWebElement DupcompName = driver.FindElement(By.XPath(companyname));
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            DupcompName.SendKeys("Test@123");
            LicenseNum.Click();
            if (!LicenseNum.Enabled)
            {
                Console.WriteLine("Company Info Fields are Disabled when Duplicate Company Name is Entered");
            }
            else
            {
                Console.WriteLine("Company Info Fields are Enabled when Duplicate Company Name is Entered");
            }
            DupcompName.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void LicensenumberEnabled()
        {
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            LicenseNum.Click();
            if (LicenseNum.Enabled)
            {
                Console.WriteLine("License Number Field is Enabled");
            }
            else
            {
                Console.WriteLine("License Number Field is Disabled");
            }
        }
        public void LicensenumMandatory()
        {
            IWebElement mandatory = driver.FindElement(By.XPath(licensenumbermandatory));
            if (mandatory.Displayed)
            {
                Console.WriteLine("License Number mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("License Number mandatory Symbol Not Displayed");
            }
        }
        public void Licensenumber()
        {
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            LicenseNum.Click();
            Thread.Sleep(1000);
            LicenseNum.Click();
            if (!testData.ContainsKey("License Number"))
            {
                throw new KeyNotFoundException("The key 'License Number' was not found in the test data.");
            }
            LicenseNum.SendKeys(testData["License Number"]);
            Thread.Sleep(500);
        }
        public void LicensenumberSpace()
        {
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            LicenseNum.SendKeys(" ");
            string EnteredLicenseNum = LicenseNum.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredLicenseNum) || EnteredLicenseNum.Trim().Length == 0)
            {
                Console.WriteLine("License Number is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("License Number is taking Space and Special Characters in the beginning");
            }
        }
        public void LicenseUpto10Numbers()
        {
            Actions act = new Actions(driver);
            IWebElement LiceNum = driver.FindElement(By.XPath(licensenumber));

            Random random2 = new Random();
            int randomNumber = random2.Next(555555555, 999999999);
            string License_10num = randomNumber.ToString();

            LiceNum.SendKeys(License_10num);
            string Enteredname = LiceNum.GetAttribute("value");
            Regex rgx = new Regex(@"^[0-9]{1,10}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the License Number Upto 10 Digits");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the License Number Above 10 Digits");
            }
            LiceNum.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void LicenseAbove10Characters()
        {
            Actions act = new Actions(driver);
            IWebElement LiceNum = driver.FindElement(By.XPath(licensenumber));

            Random random3 = new Random();
            int randomNumber = random3.Next(555555555, 999999999);
            string LicenseNum_20chars = randomNumber.ToString();

            LiceNum.SendKeys(LicenseNum_20chars);
            LiceNum.SendKeys(LicenseNum_20chars);
            string Enteredname = LiceNum.GetAttribute("value");
            Regex rgx = new Regex(@"^[0-9]{1,10}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Not Allowewd to Enter the License Number Above 10 Digits");
            }
            else
            {
                Console.WriteLine("Allowewd to Enter the License Number Above 10 Digits");
            }
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void DuplicateLicenseNum()
        {
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            LicenseNum.SendKeys("123654");
            CompName.Click();
            Thread.Sleep(1000);
            IWebElement LicenseValidationerror = driver.FindElement(By.XPath(LicenseN));
            if (LicenseValidationerror.Displayed)
            {
                Console.WriteLine("License Number Duplicate Validation is Successful");
            }
            else
            {
                Console.WriteLine("License Number Duplicate Validation is Failed");
            }
            LicenseNum.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void SpecialCharLicenseNum()
        {
            Thread.Sleep(500);
            IWebElement LicenseNum = driver.FindElement(By.XPath(licensenumber));
            LicenseNum.SendKeys("ABC^&%$^&");
            Thread.Sleep(500);
            string enteredText = LicenseNum.GetAttribute("value");

            if (ContainsSpecialCharacters(enteredText))
            {
                Console.WriteLine("The text field contains special characters.");
            }
            else if (ContainsAlphabets(enteredText))
            {
                Console.WriteLine("The text field contains alphabets.");
            }
            else
            {
                Console.WriteLine("License Number field does not allowing special characters or alphabets.");
            }
            LicenseNum.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public bool ContainsSpecialCharacters(string text)
        {
            // Define a regex pattern to match special characters
            string pattern = @"[!@#$%^&*(),.?""':;{}|<>]";
            return Regex.IsMatch(text, pattern);
        }

        public bool ContainsAlphabets(string text)
        {
            // Define a regex pattern to match alphabets (both lowercase and uppercase)
            string pattern = @"[a-zA-Z]";
            return Regex.IsMatch(text, pattern);
        }

        public void LicenseNumberGreenTick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(companyname)));

            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            IWebElement License = driver.FindElement(By.XPath(licensenumber));        
            License.Click();
            if (!testData.ContainsKey("License Number"))
            {
                throw new KeyNotFoundException("The key 'License Number' was not found in the test data.");
            }
            License.SendKeys(testData["License Number"]);
            CompName.Click();
            Thread.Sleep(500);
            IWebElement GreenTick = driver.FindElement(By.XPath(licensegreentick));
            if (GreenTick.Displayed)
            {
                Console.WriteLine("License Number Validation is Successful");
            }
            else
            {
                Console.WriteLine("License Number Validation not Successful");
            }
        }
        public void LicenseNumberLessthan5()
        {
            IWebElement CompName = driver.FindElement(By.XPath(companyname));
            IWebElement License = driver.FindElement(By.XPath(licensenumber));           
            License.SendKeys("4575");
            CompName.Click();
            License.Click();
            Thread.Sleep(500);
            IWebElement ErrorMessage = driver.FindElement(By.XPath(LicenseNum5));
            if (ErrorMessage.Displayed)
            {
                Console.WriteLine("Displayed Error - License Number Should be minimum 6 characters");
            }
            else
            {
                Console.WriteLine("Not Displayed Error - License Number Should be minimum 6 characters");
            }
            License.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Establishment_DateEnable()
        {
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            EstablishmentDate.Click();
            if (EstablishmentDate.Enabled)
            {
                Console.WriteLine("Establishment Date Field is Enabled");
            }
            else
            {
                Console.WriteLine("Establishment Date Field is Disabled");
            }
            Thread.Sleep(100);
        }
        public void Establishment_DateMandatory()
        {
            IWebElement EstablishmentDateMandatory = driver.FindElement(By.XPath(establishment_datemandatory));
            if (EstablishmentDateMandatory.Displayed)
            {
                Console.WriteLine("Establishment Date mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Establishment Date mandatory Symbol is Not Displayed");
            }
            Thread.Sleep(100);
        }
        public void Establishment_DateDropdownSelect()
        {
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            EstablishmentDate.Click();
            Thread.Sleep(500);
            EstablishmentDate.SendKeys(Keys.ArrowDown);
            EstablishmentDate.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            EstablishmentDate.SendKeys(Keys.Enter);
            Console.WriteLine("Establishment Date is Selected From Dropdown");
            EstablishmentDate.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void InvalidEstablishment_Date()
        {
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            IWebElement title = driver.FindElement(By.XPath("//label[text()='Establishment Date*']"));
            EstablishmentDate.Click();
            Thread.Sleep(500);
            string date = "05-05-2025";
            EstablishmentDate.SendKeys(date);
            title.Click();
            Thread.Sleep(500);
            string getdate = EstablishmentDate.GetAttribute("value");
            
            if (string.IsNullOrEmpty(getdate) || getdate.Trim().Length == 0)
            {
                Console.WriteLine("Establishment Date is Cleared");
            }
            else
            {
                Console.WriteLine("Establishment Date is Not Cleared");
            }
        }
        public void Establishment_DateMonthandYear()
        {
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            EstablishmentDate.Click();
            IWebElement EstablishmentDateMonth = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            IWebElement EstablishmentDateYear = driver.FindElement(By.XPath("//span[contains(@class, 'selected-month')]"));
            if (EstablishmentDateMonth.Displayed && EstablishmentDateYear.Displayed)
            {
                Console.WriteLine("Establishment DatePicker contains Month and Year Dropdoen");
            }
            else
            {
                Console.WriteLine("Establishment DatePicker doesnot contains Month and Year Dropdoen");
            }
        }
        public void Establishment_Date()
        {
            IWebElement EstablishmentDate = driver.FindElement(By.XPath(establishment_date));
            EstablishmentDate.Click();
            Thread.Sleep(1000);
            string date = testData["Establishment Date"];
            Thread.Sleep(500);
            if (EstablishmentDate.Displayed)
            {
                EstablishmentDate.SendKeys(date);
                Thread.Sleep(500);
                EstablishmentDate.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                EstablishmentDate.SendKeys(Keys.Enter);
                Console.WriteLine("Establishment Date Field is Verified");
            }
            else
            {
                Console.WriteLine("Establishment Date Field is Disabled");
            }
            Thread.Sleep(100);
        }
        public void AddAttachmentEnabled()
        {
            IWebElement addattachment = driver.FindElement(By.XPath(addAttachment));
            if (addattachment.Enabled)
            {
                Console.WriteLine("Attachment Button is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Button is Disabled");
            }
        }
        public void AddAttachmentButtonClick()
        {
            IWebElement addattachment = driver.FindElement(By.XPath(addAttachment));          
            Thread.Sleep(500);
            addattachment.Click();
            Thread.Sleep(500);
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            if (Attachmenttitle.Displayed)
            {
                Console.WriteLine("Page is redirected to Attachment Screen");
            }
            else
            {
                Console.WriteLine("Page is Not redirected to Attachment Screen");
            }
            Thread.Sleep(1000);
        }
        public void AddAttachmentFields()
        {
            IWebElement Title = driver.FindElement(By.XPath(attachmenttitle));
            IWebElement DocType = driver.FindElement(By.XPath(attachmentDocType));
            IWebElement DocCateg = driver.FindElement(By.XPath(documentcategory));
            IWebElement Description = driver.FindElement(By.XPath(description));

            if (Title.Displayed && DocType.Displayed && DocCateg.Displayed && Description.Displayed)
            {
                Console.WriteLine("All Fields of Attachment Screen is Displayed");
            }
            else
            {
                Console.WriteLine("All Fields of Attachment Screen is Not Displayed");
            }
        }
        public void AttachmentDocType_File()
        {
            IWebElement DocType = driver.FindElement(By.XPath(attachmentDocType));
            DocType.Click();
            Thread.Sleep(500);
            DocType.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            DocType.SendKeys(Keys.Enter);
            IWebElement UploadFile = driver.FindElement(By.XPath(uploadfile));
            if (UploadFile.Displayed)
            {
                Console.WriteLine("Upload File Field is Displayed for the Document Type 'File'");
            }
            else
            {
                Console.WriteLine("Upload File Field is Not Displayed for the Document Type 'File'");
            }
        }

        public void AttachmentTitleEnabled()
        {
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            if (Attachmenttitle.Enabled)
            {
                Console.WriteLine("Attachment Title Field is Enabled");
            }
            else
            {
                Console.WriteLine("Attachment Title Field is Disabled");
            }
        }
        public void AttachmentTitleMandatory()
        {
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            if (Attachmenttitle.Enabled)
            {
                Console.WriteLine("Attachment Title Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Attachment Title Mandatory Symbol is missing");
            }
        }
        public void AttachmentTitleUpto80Char()
        {
            Actions act = new Actions(driver);
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            var Upto80chars = RandomString1(random1, 80);
            Attachmenttitle.SendKeys(Upto80chars);
            string EnteredTitle = Attachmenttitle.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(EnteredTitle))
            {
                Console.WriteLine("Attachment Title Field Taking Upto 80 Characters");
            }
            else
            {
                Console.WriteLine("Attachment Title Field Not Taking Upto 80 Characters");
            }
            Attachmenttitle.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void AttachmentTitleAbove80Char()
        {
            Actions act = new Actions(driver);
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            var Upto80chars = RandomString1(random1, 85);
            Attachmenttitle.SendKeys(Upto80chars);
            string EnteredTitle = Attachmenttitle.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(EnteredTitle))
            {
                Console.WriteLine("Attachment Title Field Not Taking Above 80 Characters");
            }
            else
            {
                Console.WriteLine("Attachment Title Field Taking Above 80 Characters");
            }
            Attachmenttitle.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void AttachmentTitleSpace()
        {
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            Attachmenttitle.SendKeys(" ");
            string EnteredTitle = Attachmenttitle.Text;
            if (string.IsNullOrEmpty(EnteredTitle) || EnteredTitle.Trim().Length == 0)
            {
                Console.WriteLine("Attachment title is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Attachment title is taking Space and Special Characters in the beginning");
            }
            Attachmenttitle.Click();
            Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void ClickOnSubmitButtonWithout_Data()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Submit)));
            element.Click();
            Thread.Sleep(1000);

            IWebElement TitleError = driver.FindElement(By.XPath("//span[text()='Please provide Title']"));
            IWebElement DocTypeError = driver.FindElement(By.XPath("//span[text()='Please provide Document Type']"));
            IWebElement DocCategError = driver.FindElement(By.XPath("//span[text()='Please provide Document Category']"));
            IWebElement DescriptionError = driver.FindElement(By.XPath("//span[text()='Please provide Description']"));

            if (TitleError.Displayed && DocTypeError.Displayed && DocCategError.Displayed && DescriptionError.Displayed)
            {
                Console.WriteLine("Field Validation Error Message is Displayed");
            }
            else
            {
                Console.WriteLine("Field Validation Error Message is Missing");
            }
            Thread.Sleep(1000);
        }
        public void AttachmentTitle()
        {
            IWebElement Attachmenttitle = driver.FindElement(By.XPath(attachmenttitle));
            Attachmenttitle.Click();
            if (Attachmenttitle.Enabled)
            {
                Attachmenttitle.SendKeys(testData["Attach Title"]);
                string EnteredTitle = Attachmenttitle.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9'  '~`!@#$%^&*()_+={}:;'<>,./?\|]{1,80}$");
                if (rgx.IsMatch(EnteredTitle))
                {
                    Console.WriteLine("Attachment Title is Verified");
                }
                if (EnteredTitle.StartsWith(' '))
                {
                    Console.WriteLine("Attachment Title Should not Contains Space in the Beginning");
                }
            }
            else
            {
                Console.WriteLine("Attachment Title Field is Disabled");
            }
        }
        public void DocumentTypeEnabled()
        {
            IWebElement DocumentType = driver.FindElement(By.XPath(attachmentDocType));
            if (DocumentType.Enabled)
            {
                Console.WriteLine("Document Type Field is Enabled");
            }
            else
            {
                Console.WriteLine("Document Type Field is Disabled");
            }
        }
        public void DocumentTypeMandatory()
        {
            IWebElement DocumentType = driver.FindElement(By.XPath(attachmentDocType));
            if (DocumentType.Displayed)
            {
                Console.WriteLine("Document Type Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Document Type Mandatory Symbol is missing");
            }
        }
        public void DocumentTypeSelect()
        {
            IWebElement DocumentType = driver.FindElement(By.XPath(attachmentDocType));
            DocumentType.Click();
            Thread.Sleep(500);
            DocumentType.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            DocumentType.SendKeys(Keys.Enter);
            if (DocumentType.Enabled)
            {
                Console.WriteLine("Document Type Option is Selected");
            }
            else
            {
                Console.WriteLine("Document Type Option Not Selected");
            }
        }
        public void DocumentTypeReselect()
        {
            IWebElement DocumentType = driver.FindElement(By.XPath(attachmentDocType));
            DocumentType.Click();
            Thread.Sleep(500);
            DocumentType.SendKeys(Keys.ArrowDown);
            DocumentType.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            DocumentType.SendKeys(Keys.Enter);
            if (DocumentType.Enabled)
            {
                Console.WriteLine("Document Type Option is Re-Selected");
            }
            else
            {
                Console.WriteLine("Document Type Option is Not Re-Selected");
            }
        }
        public void DocumentTypeManually()
        {
            IWebElement DocumentType = driver.FindElement(By.XPath(attachmentDocType));
            DocumentType.Click();
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
            Thread.Sleep(500);
            DocumentType.SendKeys(testData["Document Type"]);
            Thread.Sleep(500);
            DocumentType.SendKeys(Keys.ArrowDown);
            DocumentType.SendKeys(Keys.Enter);
            if (DocumentType.Enabled)
            {
                Console.WriteLine("Document Type Entered Manually");
            }
            else
            {
                Console.WriteLine("Document Type Not Entered Manually");
            }
        }
        public void FileUpload(string file)
        {
            IWebElement fileInput = driver.FindElement(By.XPath(uploadfile));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].value=arguments[1]", fileInput, file);
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", fileInput, file);
            fileInput.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        public void DocumentCategoryEnabled()
        {
            IWebElement Category = driver.FindElement(By.XPath(documentcategory));
            if (Category.Enabled)
            {
                Console.WriteLine("Document Category is Enabled");
            }
            else
            {
                Console.WriteLine("Document Category is Disabled");
            }
        }
        public void DocumentCategoryMandatory()
        {
            IWebElement Category = driver.FindElement(By.XPath(documentcategoryMandatory));
            if (Category.Enabled)
            {
                Console.WriteLine("Document Category Mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Document Category Mandatory Symbol is missing");
            }
        }

        public void DocumentCategorySelect()
        {
            IWebElement Category = driver.FindElement(By.XPath(documentcategory));
            if (Category.Enabled)
            {
                Category.Click();
                Thread.Sleep(500);
                Category.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Category.SendKeys(Keys.Enter);
                Console.WriteLine("Document Category is Selected");
            }
            else
            {
                Console.WriteLine("Document Category is Not Selected");
            }
            Thread.Sleep(500);
        }
        public void DocumentCategoryReSelect()
        {
            IWebElement Category = driver.FindElement(By.XPath(documentcategory));
            if (Category.Enabled)
            {
                Category.Click();
                Thread.Sleep(500);
                Category.SendKeys(Keys.ArrowDown);
                Category.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Category.SendKeys(Keys.Enter);
                Console.WriteLine("Document Category Field is Verified");
            }
            else
            {
                Console.WriteLine("Document Category Field is Not Verified");
            }
            Thread.Sleep(500);
        }
        public void DocumentCategory()
        {
            IWebElement Category = driver.FindElement(By.XPath(documentcategory));
            if (Category.Enabled)
            {
                Category.Click();
                Actions act = new Actions(driver);
                act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                act.SendKeys(Keys.Delete).Perform();
                Category.SendKeys(testData["Document Category"]);
                Thread.Sleep(500);
                Category.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Category.SendKeys(Keys.Enter);
                Console.WriteLine("Document Category Field is Verified");
            }
            else
            {
                Console.WriteLine("Document Category Field is Not Verified");
            }
            Thread.Sleep(500);
        }
        public void DescriptionEnabled()
        {
            IWebElement Descrip = driver.FindElement(By.XPath(description));
            if (Descrip.Enabled)
            {
                Console.WriteLine("Description Field is Enabled");
            }
            else
            {
                Console.WriteLine("Description Field is Disabled");
            }
        }
        public void DescriptionMandatory()
        {
            IWebElement Descrip = driver.FindElement(By.XPath(descriptionMandatory));
            if (Descrip.Displayed)
            {
                Console.WriteLine("Description Field Mandatory Symbol is displayed");
            }
            else
            {
                Console.WriteLine("Description Field Mandatory Symbol is missing");
            }
        }
        public void DescriptionUpto150()
        {
            Actions act = new Actions(driver);
            IWebElement Descrip = driver.FindElement(By.XPath(description));
            var Upto80chars = RandomString1(random1, 150);
            Descrip.SendKeys(Upto80chars);
            string EnteredTitle = Descrip.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,150}$");
            if (rgx.IsMatch(EnteredTitle))
            {
                Console.WriteLine("Description Field Taking Upto 150 Characters");
            }
            else
            {
                Console.WriteLine("Description Field Not Taking Upto 150 Characters");
            }
            Descrip.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void DescriptionAbove150()
        {
            Actions act = new Actions(driver);
            IWebElement Descrip = driver.FindElement(By.XPath(description));
            var Upto80chars = RandomString1(random1, 155);
            Descrip.SendKeys(Upto80chars);
            string EnteredTitle = Descrip.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,150}$");
            if (rgx.IsMatch(EnteredTitle))
            {
                Console.WriteLine("Description Field Not Taking Above 150 Characters");
            }
            else
            {
                Console.WriteLine("Description Field Taking Above 150 Characters");
            }
            Descrip.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Description()
        {
            IWebElement Descrip = driver.FindElement(By.XPath(description));
            Descrip.Click();
            Thread.Sleep(500);
            if (Descrip.Enabled)
            {
                Descrip.SendKeys(testData["Description"]);
                string EnteredDesc = Descrip.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+={}:;'<>,./?\|]{1,150}$");
                if (rgx.IsMatch(EnteredDesc))
                {
                    Console.WriteLine("Attachment Description is Verified");
                }
                else if (EnteredDesc.StartsWith(' '))
                {
                    Console.WriteLine("Attachment Description Should not Contains Space in the Beginning");
                }
            }
            else
            {
                Console.WriteLine("Attachment Description Field Is Disabled");
            }
        }

        public void SubmitButtonEnabled()
        {
            IWebElement submit = driver.FindElement(By.XPath(Submit));
            Thread.Sleep(500);
            if (submit.Enabled)
            {
                Console.WriteLine("Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Submit Button is Disabled");
            }
            Thread.Sleep(500);
        }
        public void SubmitButtonClick()
        {
            IWebElement submit = driver.FindElement(By.XPath(Submit));
            submit.Click();
            Thread.Sleep(1000);
            IWebElement SuccessToast = driver.FindElement(By.XPath("//div[contains(@class,'Toastify__toast-body')]"));
            if (SuccessToast.Displayed)
            {

                Console.WriteLine("Successful Toast is Displayed");
            }
            else
            {
                Console.WriteLine("Successful Toast is Not Displayed");
            }
            Thread.Sleep(3000);
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
            }
        }
        public void DeleteToast()
        {
            IWebElement Deletetoast = driver.FindElement(By.XPath("//div[contains(@class,'Toastify__toast-body')]"));
            if (Deletetoast.Displayed)
            {
                Console.WriteLine("Successfully Deleted Toast is displayed");
            }
            else
            {
                Console.WriteLine("Successfully Deleted Toast is Not displayed");
            }
        }
        public void CancelButtonEnabled()
        {
            IWebElement Cancel = driver.FindElement(By.XPath(cancel));
            Thread.Sleep(500);
            if (Cancel.Enabled)
            {
                Console.WriteLine("Cancel Button is Verified");
            }
            else
            {
                Console.WriteLine("Cancel Button is Disabled");
            }
        }
        public void CancelButtonClick()
        {
            IWebElement Cancel = driver.FindElement(By.XPath(cancel));
            Thread.Sleep(500);
            Cancel.Click();
            Thread.Sleep(500);
            IWebElement addattachment = driver.FindElement(By.XPath(addAttachment));
            if (addattachment.Displayed)
            {

                Console.WriteLine("Page Redirect to Registration Screen When Clicked on Attachment Cancel Button");
            }
            else
            {
                Console.WriteLine("Cancel Button is Disabled");
            }
        }
        public void AttachmentSearch()
        {
            IWebElement Searchbox = driver.FindElement(By.XPath(search));
            string SearchText = testData["Attach Title"];
            Thread.Sleep(1000);  
            IWebElement FilteredDoc = driver.FindElement(By.XPath(filter));
            if (Searchbox.Enabled)
            {
                Searchbox.SendKeys(SearchText);
                Thread.Sleep(1000);
                if (FilteredDoc.Displayed)
                {
                    Console.WriteLine("Search Field Filter is Verified");
                }
                else
                {
                    Console.WriteLine("Search Field Filter is Not Working");
                }
            }
        }
        public void AttachmentEdit()
        {
            IWebElement FilteredDoc = driver.FindElement(By.XPath(filter));   
            FilteredDoc.Click();
            Thread.Sleep(500);
            IWebElement AttachDesc = driver.FindElement(By.XPath(description));
            AttachDesc.Click();
            AttachDesc.Clear();
            AttachDesc.SendKeys(testData["Description"]);
            Thread.Sleep(500);
            IWebElement submit = driver.FindElement(By.XPath(Submit));
            submit.Click();
            Console.WriteLine("Attachment Edited Successfully");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(title)));
        }
        public void ContactInfoAccordion()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(title)));
            IWebElement CI_Accordion = driver.FindElement(By.XPath("//div[text()='Contact Information']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,500)");
            if (element.Displayed)
            {
                Console.WriteLine("Contact Information Accordion is Opened");
            }
            else
            {
                Console.WriteLine("Contact Information Accordion is Closed");
            }
        }
        public void ContactInfoAccordionClick()
        {
            IWebElement CI_Accordion = driver.FindElement(By.XPath("//div[text()='Contact Information']"));
            CI_Accordion.Click();
            Thread.Sleep(500);
            CI_Accordion.Click();
            Thread.Sleep(500);
        }
        public void ContactInfoFields()
        {
            IWebElement CI_Title = driver.FindElement(By.XPath(title));
            IWebElement CI_FirstName = driver.FindElement(By.XPath(firstname));
            IWebElement CI_Middlename = driver.FindElement(By.XPath(middlename));
            IWebElement CI_lastname = driver.FindElement(By.XPath(lastname));
            IWebElement CI_Email = driver.FindElement(By.XPath(email));
            IWebElement CI_Phone = driver.FindElement(By.XPath(phonenumber));

            if (CI_Title.Displayed && CI_FirstName.Displayed && CI_Middlename.Displayed && CI_lastname.Displayed && CI_Email.Displayed && CI_Phone.Displayed)
            {
                Console.WriteLine("All the Contact Information Fields are Displayed");
            }
            else
            {
                Console.WriteLine("All the Contact Information Fields are Not Displayed");
            }
        }
        public void ClickOnSubmitWithout_CI_Info()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(submitButton)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);

            IWebElement E1 = driver.FindElement(By.XPath("//span[text()='Please provide Title']"));
            IWebElement E2 = driver.FindElement(By.XPath("//span[text()='Please provide First Name']"));
            IWebElement E3 = driver.FindElement(By.XPath("//span[text()='Please provide Last Name']"));
            IWebElement E4 = driver.FindElement(By.XPath("//span[text()='Please provide Email Address']"));
            IWebElement E5 = driver.FindElement(By.XPath("//span[text()='Please provide Phone Number']"));

            if (E1.Displayed && E2.Displayed && E3.Displayed && E4.Displayed && E5.Displayed)
            {
                Console.WriteLine("Contact Info All Field Validation Error Message is Displayed");
            }
            else
            {
                Console.WriteLine("Contact Info Field Validation Error Message is Missing");
            }
            Thread.Sleep(1000);
        }
        public void TitleEnabled()
        {
            IWebElement Title = driver.FindElement(By.XPath(title));
            if (Title.Enabled)
            {
                Console.WriteLine("Title Field is Enabled");
            }
            else
            {
                Console.WriteLine("Title Field is Disabled");
            }
        }
        public void TitleMandatory()
        {
            IWebElement Title = driver.FindElement(By.XPath(titleMandatory));
            if (Title.Displayed)
            {
                Console.WriteLine("Title Field Mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("Title Field Mandatory Symbol is Not Displayed");
            }
        }
        public void Title()
        {
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("scroll(0,500)");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(title)));

            Thread.Sleep(500);
            IWebElement Title = driver.FindElement(By.XPath(title));

            if (Title.Enabled)
            {
                Title.Click();
                Thread.Sleep(500);
                Title.SendKeys(testData["CI Title"]);
                Thread.Sleep(500);
                Title.SendKeys(Keys.ArrowDown);
                Thread.Sleep(500);
                Title.SendKeys(Keys.Enter);
                Console.WriteLine("Title is Verified");
            }
            else
            {
                Console.WriteLine("Title  is Not Verified");
            }
            Thread.Sleep(500);
        }
        public void FirstNameEnabled()
        {
            IWebElement FirstNAME = driver.FindElement(By.XPath(firstname));
            if (FirstNAME.Enabled)
            {
                Console.WriteLine("Firstname Field is Enabled");
            }
            else
            {
                Console.WriteLine("Firstname Field is Disabled");
            }
        }
        public void FirstNameMandatory()
        {
            IWebElement FirstNAME = driver.FindElement(By.XPath(firstname));
            if (FirstNAME.Displayed)
            {
                Console.WriteLine("First Name Mandatory Symbol is Displayed");
            }
            else
            {
                Console.WriteLine("First Name Mandatory Symbol is Not Displayed");
            }
        }
        public void FirstNameSpace()
        {
            IWebElement Firstname = driver.FindElement(By.XPath(firstname));
            Firstname.SendKeys(" ");
            string EnteredCompName = Firstname.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("First name is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("First name is taking Space and Special Characters in the beginning");
            }
            Firstname.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void FirstNameUpto80Char()
        {
            Actions act = new Actions(driver);
            IWebElement FirstNAME = driver.FindElement(By.XPath(firstname));
            var C80chars = RandomString1(random1, 80);
            FirstNAME.SendKeys(C80chars);
            string Enteredname = FirstNAME.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the First Name Upto 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the First Name Upto 80 Characters");
            }
            FirstNAME.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void FirstNameAbove80Char()
        {
            Actions act = new Actions(driver);
            IWebElement FirstNAME = driver.FindElement(By.XPath(firstname));
            var C80chars = RandomString1(random1, 85);
            FirstNAME.SendKeys(C80chars);
            string Enteredname = FirstNAME.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Not Allowewd to Enter the First Name Above 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the First Name Above 80 Characters");
            }
            FirstNAME.Click();
            Thread.Sleep(1000);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void FirstName()
        {
            IWebElement FirstNAME = driver.FindElement(By.XPath(firstname));
            if (FirstNAME.Enabled)
            {
                //var autostring = RandomString(random, 10);
                string firstname = testData["First Name"];
                FirstNAME.SendKeys(firstname);
                string EnteredFirstName = FirstNAME.GetAttribute("value");
                Thread.Sleep(1000);
                Regex rgx = new Regex(@"^[A-Za-z' ']{1,80}$");
                if (rgx.IsMatch(EnteredFirstName))
                {
                    Console.WriteLine("First Name Field is Verified");
                }
                if (EnteredFirstName.StartsWith(' '))
                {
                    Console.WriteLine("First Name Should not Contains Space in the Beginning");
                }
            }
            else
            {
                Console.WriteLine("First Name Text Field is Disabled");
            }
        }
        public void MiddleNameEnabled()
        {
            IWebElement Middlename = driver.FindElement(By.XPath(middlename));
            if (Middlename.Enabled)
            {
                Console.WriteLine("Middle name Field is Enabled");
            }
            else
            {
                Console.WriteLine("Middle name Field is Disabled");
            }
        }
        public void MiddleNameMandatory()
        {
            IWebElement Middlename = driver.FindElement(By.XPath(middlenameMandatory));

            if (!Middlename.Displayed)
            {
                Console.WriteLine("Mandatory Symbol is Not Displayed for Middle Name");
            }
            else
            {
                Console.WriteLine("Mandatory Symbol is Displayed for Middle Name");
            }
        }
        public void MiddleNameSpace()
        {
            IWebElement Middlename = driver.FindElement(By.XPath(middlename));
            Middlename.SendKeys(" ");
            string EnteredCompName = Middlename.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Middle name is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Middle name is taking Space and Special Characters in the beginning");
            }
            Middlename.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void MiddleNameUpto80Char()
        {
            Actions act = new Actions(driver);
            IWebElement MiddleNAME = driver.FindElement(By.XPath(middlename));
            var C80chars = RandomString1(random1, 80);
            MiddleNAME.SendKeys(C80chars);
            string Enteredname = MiddleNAME.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Middle Name Upto 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Middle Name Upto 80 Characters");
            }
            MiddleNAME.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void MiddleNameAbove80Char()
        {
            Actions act = new Actions(driver);
            IWebElement MiddleNAME = driver.FindElement(By.XPath(middlename));
            var C80chars = RandomString1(random1, 85);
            MiddleNAME.SendKeys(C80chars);
            string Enteredname = MiddleNAME.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Not Allowewd to Enter the Middle Name Above 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Middle Name Above 80 Characters");
            }
            MiddleNAME.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }

        public void MiddleName()
        {
            IWebElement MidName = driver.FindElement(By.XPath(middlename));
            if (MidName.Enabled)
            {
                //var autostring = RandomString(random, 10);
                string middlename = testData["Middle Name"];
                MidName.SendKeys(middlename);
                string EnteredCompanyName = MidName.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z' ']{0,80}$");
                if (rgx.IsMatch(EnteredCompanyName))
                {
                    Console.WriteLine("Middle Name is Verified");
                }
                if (EnteredCompanyName.StartsWith(' '))
                {
                    Console.WriteLine("Middle Name Should not Starts with Space");
                }
            }
            else
            {
                Console.WriteLine("Middle Name Text Field is Disabled");
            }
        }
        public void LastNameEnabled()
        {
            IWebElement LastName = driver.FindElement(By.XPath(lastname));
            if (LastName.Enabled)
            {
                Console.WriteLine("Last name Field is Enabled");
            }
            else
            {
                Console.WriteLine("Last name Field is Disabled");
            }
        }
        public void LastNameMandatory()
        {
            IWebElement LastName = driver.FindElement(By.XPath(lastnameMandatory));

            if (LastName.Displayed)
            {
                Console.WriteLine("Mandatory Symbol is Displayed for Last Name");
            }
            else
            {
                Console.WriteLine("Mandatory Symbol is Not Displayed for Last Name");
            }
        }
        public void LastNameSpace()
        {
            IWebElement Lastename = driver.FindElement(By.XPath(lastname));
            Lastename.SendKeys(" ");
            string EnteredCompName = Lastename.GetAttribute("value");
            if (string.IsNullOrEmpty(EnteredCompName) || EnteredCompName.Trim().Length == 0)
            {
                Console.WriteLine("Last name is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Last name is taking Space and Special Characters in the beginning");
            }
        }

        public void LastNameUpto80Char()
        {
            Actions act = new Actions(driver);
            IWebElement Lastename = driver.FindElement(By.XPath(lastname));
            var C80chars = RandomString1(random1, 80);
            Lastename.SendKeys(C80chars);
            string Enteredname = Lastename.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Allowewd to Enter the Last Name Upto 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Last Name Upto 80 Characters");
            }
            Lastename.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void LastNameAbove80Char()
        {
            Actions act = new Actions(driver);
            IWebElement Lastename = driver.FindElement(By.XPath(lastname));
            var C80chars = RandomString1(random1, 85);
            Lastename.SendKeys(C80chars);
            string Enteredname = Lastename.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,80}$");
            if (rgx.IsMatch(Enteredname))
            {
                Console.WriteLine("Not Allowewd to Enter the Middle Name Above 80 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Middle Name Above 80 Characters");
            }
            Lastename.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void Last_Name()
        {
            IWebElement LastName = driver.FindElement(By.XPath(lastname));
            if (LastName.Enabled)
            {
                //var autostring = RandomString(random, 10);
                string lastname = testData["Last Name"];
                LastName.SendKeys(lastname);
                string Enteredlastname = LastName.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z' ']{1,80}$");
                if (rgx.IsMatch(Enteredlastname))
                {
                    Console.WriteLine("Last Name is Verified");
                }
                if (Enteredlastname.StartsWith(' '))
                {
                    Console.WriteLine("Last Name Should not Starts with Space");
                }
            }
            else
            {
                Console.WriteLine("Last Name Text Field is Disabled");
            }
        }
        public void EmailAddressEnabled()
        {
            IWebElement Emailaddress = driver.FindElement(By.XPath(email));
            if (Emailaddress.Enabled)
            {
                Console.WriteLine("Last name Field is Enabled");
            }
            else
            {
                Console.WriteLine("Last name Field is Disabled");
            }
        }
        public void EmailAddressMandatory()
        {
            IWebElement Emailaddress = driver.FindElement(By.XPath(emailMandatory));

            if (Emailaddress.Displayed)
            {
                Console.WriteLine("Mandatory Symbol is Displayed for Email Address");
            }
            else
            {
                Console.WriteLine("Mandatory Symbol is Not Displayed for Email Address");
            }
        }
        public void EmailAddressSpace()
        {
            IWebElement Emailaddress = driver.FindElement(By.XPath(email));
            Emailaddress.SendKeys(" ");
            string Enteredtext = Emailaddress.GetAttribute("value");
            if (string.IsNullOrEmpty(Enteredtext) || Enteredtext.Trim().Length == 0)
            {
                Console.WriteLine("Email Address is not taking Space and Special Characters in the beginning");
            }
            else
            {
                Console.WriteLine("Email Address is taking Space and Special Characters in the beginning");
            }
        }

        public void EmailUpto70Char()
        {
            Actions act = new Actions(driver);
            IWebElement Emailaddress = driver.FindElement(By.XPath(email));
            var C80chars = RandomString1(random1, 70);
            Emailaddress.SendKeys(C80chars);
            string Enteredtext = Emailaddress.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,70}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Allowewd to Enter the Email Upto 70 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Email Upto 70 Characters");
            }
            Emailaddress.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void EmailAbove70Char()
        {
            Actions act = new Actions(driver);
            IWebElement Emailaddress = driver.FindElement(By.XPath(email));
            var C80chars = RandomString1(random1, 75);
            Emailaddress.SendKeys(C80chars);
            string Enteredtext = Emailaddress.GetAttribute("value");
            Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+=|\{}:;'<>,.?/]{1,70}$");
            if (rgx.IsMatch(Enteredtext))
            {
                Console.WriteLine("Not Allowewd to Enter the Email Above 70 Characters");
            }
            else
            {
                Console.WriteLine("Not Allowewd to Enter the Email Above 70 Characters");
            }
            Emailaddress.Click();
            Thread.Sleep(500);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void EmailDuplicate()
        {
            IWebElement Duplicateemail = driver.FindElement(By.XPath(email));
            IWebElement phone = driver.FindElement(By.XPath(phonenumber));
            Duplicateemail.SendKeys("TEST@GMAIL.COM");
            phone.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//span[text()='Email Address is already taken.']"));
            if (Error.Displayed)
            {
                Console.WriteLine("Email Address Duplicate Validation is Successful");
            }
            else
            {
                Console.WriteLine("Email Address Duplicate Validation is Failed");
            }
            Duplicateemail.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void EmailInvalid()
        {
            IWebElement Invalidemail = driver.FindElement(By.XPath(email));
            IWebElement phone = driver.FindElement(By.XPath(phonenumber));
            Invalidemail.SendKeys("TESTGMAIL.COM");
            phone.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//span[text()='Email Address is invalid']"));
            if (Error.Displayed)
            {
                Console.WriteLine("Email Address Duplicate Validation is Successful");
            }
            else
            {
                Console.WriteLine("Email Address Duplicate Validation is Failed");
            }
            Invalidemail.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            act.SendKeys(Keys.Delete).Perform();
        }
        public void EmailAddress()
        {
            IWebElement EmailField = driver.FindElement(By.XPath(email));
            EmailField.Click();
            EmailField.SendKeys(testData["Email Address"]);
            Thread.Sleep(500);
            IWebElement Phonenumber = driver.FindElement(By.XPath(phonenumber));
            Phonenumber.Click();
            Thread.Sleep(500);
            IWebElement GreenTick = driver.FindElement(By.XPath(emailgreentick));
            if (GreenTick.Displayed)
            {
                Console.WriteLine("Email Address Green Tick mark is Displayed");
            }
            else
            {
                Console.WriteLine("Email Address Green Tick mark is Not Displayed");
            }
        }

        public void PhoneNumberEnabled()
        {
            IWebElement PhoneNum = driver.FindElement(By.XPath(phonenumber));
            if (PhoneNum.Enabled)
            {
                Console.WriteLine("Phone Number Field is Enabled");
            }
            else
            {
                Console.WriteLine("Phone Number Field is Disabled");
            }
        }
        public void PhoneNumberMandatory()
        {
            IWebElement PhoneNum = driver.FindElement(By.XPath(phonenumberMandatory));

            if (PhoneNum.Displayed)
            {
                Console.WriteLine("Mandatory Symbol is Displayed for Phone Number");
            }
            else
            {
                Console.WriteLine("Mandatory Symbol is Not Displayed for Phone Number");
            }
        }
        public void PhoneNumberCode()
        {
            IWebElement PhoneNumFlag = driver.FindElement(By.XPath(phonenumberFlag));
            PhoneNumFlag.Click();
            Thread.Sleep(1000);
            PhoneNumFlag.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            PhoneNumFlag.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            IWebElement PhoneNumCode = driver.FindElement(By.XPath(phonenumberCode));
            string Actualcode = PhoneNumCode.GetAttribute("value");
            string ExpectedCode = "+221";
            if (Actualcode.Equals(ExpectedCode))
            {
                Console.WriteLine("Phone Number Code is Changed as per the Selected Flag");
            }
            else
            {
                Console.WriteLine("Phone Number Code is Not Changed as per the Selected Flag");
            }
        }
        public void PhoneNumberClear()
        {
            IWebElement PhoneNum = driver.FindElement(By.XPath(phonenumber));
            IWebElement PhoneNumFlag = driver.FindElement(By.XPath(phonenumberFlag));
            PhoneNum.SendKeys("123456789");
            Thread.Sleep(500);
            PhoneNumFlag.Click();
            Thread.Sleep(500);
            PhoneNumFlag.SendKeys(Keys.ArrowUp);
            Thread.Sleep(500);
            PhoneNumFlag.SendKeys(Keys.Enter);
            Thread.Sleep(500);
            IWebElement PhoneNumClear = driver.FindElement(By.XPath(phonenumberclear));

            if (PhoneNumClear.Displayed)
            {
                Console.WriteLine("Phone Number is Cleared when the Fag is Changed");
            }
            else
            {
                Console.WriteLine("Phone Number is Not Cleared when the Fag is Changed");
            }
        }
        public void PhoneNumberInvalid()
        {
            IWebElement PhoneNum = driver.FindElement(By.XPath(phonenumber));
            IWebElement Submit = driver.FindElement(By.XPath("//span[text()='Submit']"));
            PhoneNum.Click();
            PhoneNum.SendKeys("123456789");
            Submit.Click();
            Thread.Sleep(1000);
            IWebElement PhoneNumError = driver.FindElement(By.XPath("//span[text()='Phone Number is invalid']"));
            if (PhoneNumError.Displayed)
            {
                Console.WriteLine("Invalid Phone Number Error is Displayed");
            }
            else
            {
                Console.WriteLine("Invalid Phone Number Error Not Displayed");
            }
            PhoneNum.Click();
            Thread.Sleep(500);
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
            act.SendKeys(Keys.Backspace).Perform();
        }
        public void PhoneNumberSpecialChar()
        {
            IWebElement PhoneNum = driver.FindElement(By.XPath(phonenumber));
            PhoneNum.SendKeys(" %^&*(*&^");
            string EnteredPhoneNum = PhoneNum.GetAttribute("value");
            string ExpectedPhoneNum = "+966";
            if (EnteredPhoneNum.Equals(ExpectedPhoneNum))
            {
                Console.WriteLine("Phone Number Field Not Acceptine Space and Special Characters");
            }
            else
            {
                Console.WriteLine("Phone Number Field Acceptine Space and Special Characters");
            }
        }
        public void PhoneNumber()
        {
            IWebElement PhoneNumb = driver.FindElement(By.XPath(phonenumber));
            if (PhoneNumb.Enabled)
            {
                string phonenum = testData["Phone Number"];
                PhoneNumb.SendKeys(phonenum);
                Thread.Sleep(1000);
                string EnteredPhoneNum = PhoneNumb.GetAttribute("value");
                Regex rgx = new Regex(@"^[+0-9' ']{1,16}$");
                if (rgx.IsMatch(EnteredPhoneNum))
                {
                    Console.WriteLine("Phone Number is Verified");
                }
                else
                {
                    Console.WriteLine("Phone Number is Invalid");
                }
            }
            else
            {
                Console.WriteLine("Phone Number Text Field Is Disabled");
            }
        }
        public void SubmitWithout_Data()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(submitButton)));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 600);");
            Thread.Sleep(500);

            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(500);

            IWebElement ErrorMessage = driver.FindElement(By.XPath("//span[@class='field-validation-error-text ']"));
            if (ErrorMessage.Displayed)
            {
                Console.WriteLine("Field Validation Error Message is Displayed");
            }
            else
            {
                Console.WriteLine("Field Validation Error Message is Missing");
            }
            Thread.Sleep(1000);
        }

        public void ClearButton()
        {
            IWebElement clearButton = driver.FindElement(By.XPath(clearbutton));            
            if (clearButton.Enabled)
            {
                clearButton.Click();
                bool isErrorPresent = driver.FindElements(By.XPath("//span[@class='field-validation-error-text ']")).Any();
                //Assert.IsFalse(isErrorPresent, "Error message is still displayed after providing data.");
                if (isErrorPresent)
                {
                    Console.WriteLine("Clear Function Not working");
                }
                else
                {
                    Console.WriteLine("Clear Function is Verified");
                }
            }
            else
            {
                Console.WriteLine("Clear button is Disabled");
            }
        }
        public void SubmitClickEnabled()
        {
            IWebElement SubmitButton = driver.FindElement(By.XPath(submitButton));
            if (SubmitButton.Enabled)
            {
                Console.WriteLine("Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Submit Button is disabled");
            }
            Thread.Sleep(500);
        }
        public void SubmitClickMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Verification link sent!']")));          
            IWebElement submitMessage = driver.FindElement(By.XPath("//span[text()='Verification link sent!']"));
            if (submitMessage.Displayed)
            {
                Console.WriteLine("Verification link sent! Message is Displayed");
            }
            else
            {
                Console.WriteLine("Verification link sent! Message is Not Displayed");
            }
            Thread.Sleep(500);
        }
        public void SubmitClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(submitButton)));
            Thread.Sleep(1000);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(1000);
            if (element.Enabled)
            {
                driver.FindElement(By.XPath(submitButton)).Click();
                Thread.Sleep(1000);
                Console.WriteLine("Clicked on Submit Button");
            }
            else
            {
                Console.WriteLine("Not Clicked on Submit Button");
            }
            Thread.Sleep(2000);
        }
        public void GoBackEnabled()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(gobacktoLogin)));
            if (element1.Enabled)
            {
                Console.WriteLine("Goback to Login Button is Enabled");
            }
            else
            {
                Console.WriteLine("Goback to Login Button is Disabled");
            }
        }
        public void GoBackButtonEnabled()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(goback)));
            Actions action1 = new Actions(driver);
            action1.MoveToElement(element1).Perform();
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
        public void ClickGoBackButton()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(gobacktoLogin)));
            Actions action1 = new Actions(driver);
            Thread.Sleep(500);
            action1.MoveToElement(element1).Click().Perform();
            Thread.Sleep(2000);
            IWebElement loginButton = driver.FindElement(By.XPath("//button[text()='Login Now']"));
            if (loginButton.Displayed)
            {
                Console.WriteLine("Clicked on GoBack Button and Page is Redirected to Login page");
            }
            else
            {
                Console.WriteLine("Clicked on GoBack Button and Page is Not Redirected to Login page");
            }
        }
        //******************************************* Registration Approval *****************************************************
        public void UserName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(username)));
            IWebElement UsernameTextField = driver.FindElement(By.XPath(username));
            if (UsernameTextField.Enabled)
            {
                UsernameTextField.Click();
                UsernameTextField.SendKeys(testData["Approver Username"]);
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
                    throw new Exception("Element is Not Visible");
                }
            }
            Thread.Sleep(500);
        }
        public void Password()
        {
            IWebElement PasswordTextField = driver.FindElement(By.XPath(password));
            if (PasswordTextField.Enabled)
            {
                PasswordTextField.Click();
                PasswordTextField.SendKeys(testData["Approver Password"]);
                string EnteredPassword = PasswordTextField.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9~`!@#$%^&*()_+={};':<>,./?]{1,12}$");
                //Regex rgx = new Regex(@"^[A-Z]{1,12}$");
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
                    Console.WriteLine("Password is Incorrect");
                    throw new Exception("Password is Incorrect");
                }
            }
            Thread.Sleep(500);
        }
        public void Login_as_Approver()
        {
            Thread.Sleep(100);
            IWebElement LoginButton  = driver.FindElement(By.XPath(login));
            LoginButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ApproverDash = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(approval)));
            Actions action = new Actions(driver);
            action.MoveToElement(ApproverDash).Perform();
            Thread.Sleep(1000);
            if (ApproverDash.Displayed)
            {
                Console.WriteLine("Approval Option is Displayed");
            }
            else
            {
                Console.WriteLine("Approval Option is Not Displayed");
            }
            Thread.Sleep(500);
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
        public void Approval_Notification()
        {
            IWebElement ApprovalOption = driver.FindElement(By.XPath(appnotification));
            ApprovalOption.Click();
            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(approvaldashboard)));
            if (element.Displayed)
            {
                Console.WriteLine("Approver Dashboard is Displayed");
            }
            else
            {
                Console.WriteLine("Approver Dashboard is Not Displayed");
                throw new Exception("Approver Dashboard is Not Displayed");
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
        public void RegistraitonApprovalEnabled()
        {
            IWebElement Reg_Approval = driver.FindElement(By.XPath(registrationapproval));
            if (Reg_Approval.Enabled)
            {
                Console.WriteLine("Registration Approval tab is Enabled");
            }
            else
            {
                Console.WriteLine("Registration Approval tab is Disabled");
            }
        }
        public void Registration_ApprovalCLick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(registrationapproval)));

            IWebElement Reg_Approve = driver.FindElement(By.XPath(registrationapproval));
            if (Reg_Approve.Displayed)
            {
                Thread.Sleep(4000);
                Reg_Approve.Click();
                var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(search_select)));
                Console.WriteLine("Supplier Registration Approval Tab is Verified");
            }
            else
            {
                Console.WriteLine("Supplier Registration Approval Tab is Not Displayed");
                throw new Exception("Element is Not Visible");
            }
            Thread.Sleep(500);
        }
        public void SearchFieldEnabled()
        {
            IWebElement search = driver.FindElement(By.XPath(registrationapprovalsearch));
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
            IWebElement searchfield = driver.FindElement(By.XPath(registrationapprovalsearch));
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
        public void Registration_Search()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(search_select)));
            IWebElement search1 = driver.FindElement(By.XPath(registrationapprovalsearch));
            IWebElement ele = driver.FindElement(By.XPath(search_select));
            search1.Click();
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys("L&T ENTERPRISE");
            Thread.Sleep(500);
            search1.SendKeys(Keys.Control + "a");
            search1.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            //search1.SendKeys(testData["Company Name"]);
            search1.SendKeys("L&T ENTERPRISE");
            Thread.Sleep(1000);

            var element1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(search_select)));

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
        public void ActionClick()
        {
            IWebElement action = driver.FindElement(By.XPath(doc_action));
            action.Click();
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
        public void Approve()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(document_Approve)));
            IWebElement ApproveOption = driver.FindElement(By.XPath(document_Approve));
            ApproveOption.Click();
            Thread.Sleep(1000);
            IWebElement commentsScreen = driver.FindElement(By.XPath("//span[text()='Comments']"));
            if (commentsScreen.Displayed)
            {
                Console.WriteLine("Approver Comments Screen is Displayed");
            }
            else
            {
                Console.WriteLine("Approve Option is Disabled");
                throw new Exception("Approve Option is Disabled");
            }
            Thread.Sleep(500);
        }
        public void Reject()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(document_reject)));
            IWebElement rejectOption = driver.FindElement(By.XPath(document_reject));
            rejectOption.Click();
            Thread.Sleep(1000);
            IWebElement commentsScreen = driver.FindElement(By.XPath("//span[text()='Comments']"));
            if (commentsScreen.Displayed)
            {
                Console.WriteLine("Approver Comments Screen is Displayed");
            }
            else
            {
                Console.WriteLine("Approve Option is Disabled");
                throw new Exception("Approve Option is Disabled");
            }
            Thread.Sleep(500);
        }
        public void ApprovalCommentsEnabled()
        {
            IWebElement ApproveComment = driver.FindElement(By.XPath(comments));
            if (ApproveComment.Enabled)
            {
                Console.WriteLine("Approver Comments Field is Enabled");
            }
            else
            {
                Console.WriteLine("Approver Comments Field is Disabled");
            }
        }
        public void ApproroveWithoutComments()
        {
            IWebElement ApproveSubmit = driver.FindElement(By.XPath(document_Approve_Button));
            ApproveSubmit.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[text()='Please provide Comments!']"));
            if (Error.Displayed)
            {
                Error.Click();
                Console.WriteLine("Error Toast Displayed When Approved without Comments");
            }
            else
            {
                Console.WriteLine("Error Toast Not Displayed When Approved without Comments");
            }
        }
        public void RejectWithoutComments()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(document_Reject_Button)));
            IWebElement rejectSubmit = driver.FindElement(By.XPath(document_Reject_Button));
            rejectSubmit.Click();
            Thread.Sleep(1000);
            IWebElement Error = driver.FindElement(By.XPath("//div[text()='Please provide Comments!']"));
            if (Error.Displayed)
            {
                Error.Click();
                Console.WriteLine("Error Toast Displayed When Rejected without Comments");
            }
            else
            {
                Console.WriteLine("Error Toast Not Displayed When Rejected without Comments");
            }
        }
        public void RejectCancelEnabled()
        {
            IWebElement rejectCancel = driver.FindElement(By.XPath("//span[text()='Cancel']"));
            if (rejectCancel.Displayed)
            {
                Console.WriteLine("Cancel Button is Enabled");
            }
            else
            {
                Console.WriteLine("Cancel Button is Disabled");
            }
        }
        public void RejectCancel ()
        {
            IWebElement rejectCancel = driver.FindElement(By.XPath("//span[text()='Cancel']"));
            rejectCancel.Click();
            Thread.Sleep(1000);
            IWebElement documentscreen = driver.FindElement(By.XPath("//span[text()='Action']"));
            if (documentscreen.Displayed)
            {
                Console.WriteLine("Page Redirects to Document Screen when clicked on Cancel Button");
            }
            else
            {
                Console.WriteLine("Page Redirects to Document Screen when clicked on Cancel Button");
            }
        }
        public void ApprovalCommentsUpto400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var Comments400 = RandomString1(random1, 400);
            Comments.SendKeys(Comments400);
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
        public void ApprovalCommentsAbove400()
        {
            Actions act = new Actions(driver);
            IWebElement Comments = driver.FindElement(By.XPath(comments));
            var Comments400 = RandomString1(random1, 410);
            Comments.SendKeys(Comments400);
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
        public void ApprovalComments()
        {
            IWebElement ApproveComment = driver.FindElement(By.XPath(comments));
            if (ApproveComment.Displayed)
            {
                ApproveComment.Click();
                var comment = RandomString1(random1, 10);
                ApproveComment.SendKeys("Approved_" + comment);
                string Enteredcomments = ApproveComment.GetAttribute("value");
                Regex rgx = new Regex(@"^[A-Za-z0-9' '~`!@#$%^&*()_+={};:'<>,./?\|]{1,400}$");
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
        }
        public void ApproveButtonEnabled()
        {
            IWebElement ApproveSubmit1 = driver.FindElement(By.XPath(document_Approve_Button));
            if (ApproveSubmit1.Enabled)
            {
                Console.WriteLine("Approver Submit Button is Enabled");
            }
            else
            {
                Console.WriteLine("Approver Submit Button is Disabled");
                throw new Exception("Approver Submit Button is Disabled");
            }
            Thread.Sleep(1000);
        }
        public void ApproveButtonClick() 
        { 
            IWebElement ApproveSubmit1 = driver.FindElement(By.XPath(document_Approve_Button));
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].click();", ApproveSubmit1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Approval']")));
            Thread.Sleep(3000);
            IWebElement Dashboard = driver.FindElement(By.XPath("//h2[text()='Approval']"));
            if (Dashboard.Displayed)
            {
                Console.WriteLine("Approver Submit Button is Verified");
            }
            else
            {
                Console.WriteLine("Approver Submit Button is Disabled");
                throw new Exception("Approver Submit Button is Disabled");
            }
            Thread.Sleep(1000);
        }
        public void LOGOUT()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(doc_Profile)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            Thread.Sleep(1000);
            IWebElement logOut = driver.FindElement(By.XPath(doc_logout));
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].click();", logOut);
        }
        public void ErrorValidation()
        {
            string validation_error = "//div[contains(@class,'Toastify__toast--error')] || //span[@class='field-validation-error-text ']";
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
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}