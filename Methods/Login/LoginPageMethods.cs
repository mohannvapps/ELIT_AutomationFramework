using OpenQA.Selenium;
using ELIT_AutomationFramework.Utilities;
namespace ELIT_AutomationFramework.Methods.Login
{
    public class LoginPageMethods
    {
        public IWebDriver driver;
        public Dictionary<string, string> testData;
        public ExcelUtility excelUtility;

        // XPath locators
        private readonly string usernameXPath    = "//label[text()='Username*']/following::input[1]";
        private readonly string passwordXPath    = "//label[text()='Password*']/following::input";
        private readonly string loginButtonXPath = "//button[text()='Login Now']";
        private readonly string elitlogo         = "//img[@class='logo_pagetop']";

        public LoginPageMethods(IWebDriver driver, ExcelUtility excelUtility)
        {
            this.driver = driver;
            this.excelUtility = excelUtility;
            LoadExcelTemplate(); // Ensure testData is loaded
        }
        public void LoadExcelTemplate()
        {
            try
            {
                // Load all file paths from the text file
                string[] filePaths = File.ReadAllLines(@"D:\1.ELIT_AutomationFramework\Excel\Login_ExcelSheets\AllLoginExcelPaths.txt");
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
            // Ensure testData is not null and contains the "URL" key
            if (testData == null || !testData.ContainsKey("URL"))
            {
                throw new KeyNotFoundException("The key 'URL' was not found in the test data.");
            }
            driver.Navigate().GoToUrl(testData["URL"]);
        }
        public void EnterUsername()
        {
            // Ensure the "Username" key is present
            if (!testData.ContainsKey("Username"))
            {
                throw new KeyNotFoundException("The key 'Username' was not found in the test data.");
            }
            IWebElement userNameField = driver.FindElement(By.XPath(usernameXPath));
            userNameField.SendKeys(testData["Username"]);
        }
        public void EnterPassword()
        {
            // Ensure the "Password" key is present
            if (!testData.ContainsKey("Password"))
            {
                throw new KeyNotFoundException("The key 'Password' was not found in the test data.");
            }
            IWebElement passwordField = driver.FindElement(By.XPath(passwordXPath));
            passwordField.SendKeys(testData["Password"]);
        }
        public void ClickLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.XPath(loginButtonXPath));
            Thread.Sleep(1000); // Consider replacing with WebDriverWait for better practice
            loginButton.Click();
            Thread.Sleep(2000); // Consider replacing with WebDriverWait for better practice
            IWebElement ElitLogo = driver.FindElement(By.XPath(elitlogo));
            if (ElitLogo.Displayed)
            {
                Console.WriteLine("Login Successful");
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
