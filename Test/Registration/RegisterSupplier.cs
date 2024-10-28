using AventStack.ExtentReports;
using ELIT_AutomationFramework.BaseClass;
using ELIT_AutomationFramework.Methods.Registration;
using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.Registration
{
    public class B_Register_Supplier : ReportsGenerationClass
    {
        SupReg_Methods regtest;
        ExcelUtility excelUtility;

        [Test]
        [Category("Supplier Registration")]
        public void Sup_RegistrationTest()
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
                TestcaseNumber = "TC001";
                regtest.GoToPage();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page is Redirected To Elit Login Page");

                TestcaseNumber = "TC002";
                regtest.LoginPageRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Login Page refresh is Successful");

                TestcaseNumber = "TC003 & TC004";
                regtest.SupplierRegistration();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Supplier registration Button");

                TestcaseNumber = "TC005";
                regtest.TC_PageRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Terms & Condition Screen Refresh is Verified");

                TestcaseNumber = "TC006";
                regtest.GoBackEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Go Back to Login Button is Enabled");

                TestcaseNumber = "TC007";
                regtest.ClickGoBackButton();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Go Back to Login is Clicked");

                TestcaseNumber = "TC008";
                regtest.SupplierRegistration();
                regtest.Terms_ConditionPageScroll();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Terms & Condition Page Scroll Function is working");

                TestcaseNumber = "TC009 & TC010";
                regtest.TC_Accordion();
                _test.Log(Status.Pass, $"{TestcaseNumber} | T&C Accordion is Verified");

                TestcaseNumber = "TC011";
                regtest.DeclineEnable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Decline Button is Enabled");

                TestcaseNumber = "TC012";
                regtest.ClickOnDecline();
                regtest.ClearErrorToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Decline Button, and Cleared Error toast");

                TestcaseNumber = "TC013";
                regtest.AgreeButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Go Back to Login Button is Enabled");

                TestcaseNumber = "TC014";
                regtest.ClickOnAgree();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Agree Button is Verified");

                TestcaseNumber = "TC015";
                regtest.SR_PageRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Registration Page Refresh Successful");

                TestcaseNumber = "TC016";
                regtest.CompanyInfoVisible();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All Company Info Text Fields are Visible");

                TestcaseNumber = "TC017";
                regtest.CI_Accordion();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Name is Field Verified");

                TestcaseNumber = "TC018";
                regtest.SubmitWithout_Data();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Submit button without Fill the data & Found Error Message");

                TestcaseNumber = "TC019";
                regtest.ClearButton();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Cleared all the Error Messages");

                TestcaseNumber = "TC020";
                regtest.CompanynameEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Name Field is Enabled");

                TestcaseNumber = "TC021";
                regtest.Companynamemandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Name mandatory Symbol is Displayed");

                TestcaseNumber = "TC022";
                regtest.CompanynameEnterSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                TestcaseNumber = "TC023";
                regtest.CompanynameUpto80Characters();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Company Name Upto 80 Characters");

                TestcaseNumber = "TC024";
                regtest.CompanynameAbove80Characters();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Company Name Above 80 Characters");

                TestcaseNumber = "TC026";
                regtest.DuplicateCompName();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Duplicate Company Name validation is Successful");

                TestcaseNumber = "TC027";
                regtest.CompanynameUpperCase();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Name Contains Only Upper Case Characters");

                TestcaseNumber = "TC028";
                regtest.Companyname();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Name Field Validation Green Tick mark Displayed");

                TestcaseNumber = "TC029";
                regtest.LicensenumberEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number Field is Enabled");

                TestcaseNumber = "TC030";
                regtest.LicensenumMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number mandatory Symbol is Displayed");

                TestcaseNumber = "TC031";
                regtest.CompInfoDisable();
                regtest.Companyname();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Company Info Fields are Disabled when Duplicate Company Name is Entered");

                TestcaseNumber = "TC032";
                regtest.LicensenumberSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                TestcaseNumber = "TC033";
                regtest.LicenseUpto10Numbers();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the License Number Upto 10 Characters");

                TestcaseNumber = "TC034";
                regtest.LicenseAbove10Characters();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the License Number Above 10 Characters");

                TestcaseNumber = "TC035";
                regtest.SpecialCharLicenseNum();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number Field Not taking Special Characters");

                TestcaseNumber = "TC036";
                regtest.DuplicateLicenseNum();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Duplicate License Number validation is Successful");

                TestcaseNumber = "TC037";
                regtest.SpecialCharLicenseNum();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number Field Not taking Special Characters");

                TestcaseNumber = "TC038";
                regtest.LicenseNumberLessthan5();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number Field Validation Green Tick mark Displayed");

                TestcaseNumber = "TC039";
                regtest.LicenseNumberGreenTick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | License Number Field Validation Green Tick mark Displayed");

                TestcaseNumber = "TC040";
                regtest.Establishment_DateEnable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Establishment Date Field is Verified");

                TestcaseNumber = "TC041";
                regtest.Establishment_DateMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Establishment Date mandatory Symbol is Displayed");

                TestcaseNumber = "TC042";
                regtest.Establishment_DateDropdownSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Establishment Date is Selected From Dropdown");

                TestcaseNumber = "TC043";
                regtest.InvalidEstablishment_Date();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Invalid Establishment Date is Cleared");

                TestcaseNumber = "TC044";
                regtest.Establishment_DateMonthandYear();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Establishment Date Year and Month Select Dropdown is Displayed");

                TestcaseNumber = "TC045";
                regtest.Establishment_Date();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Valid Establishment Date is Selected");

                TestcaseNumber = "TC046";
                regtest.AddAttachmentEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Add Attachment Button is Enabled");

                TestcaseNumber = "TC047";
                regtest.AddAttachmentButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page is redirected to Attachment Screen");

                TestcaseNumber = "TC048";
                regtest.AddAttachmentFields();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All Fields of the Attachment Screen is Verified");

                TestcaseNumber = "TC049";
                regtest.AttachmentDocType_File();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload File Field is Displayed for the Document Type 'File'");

                TestcaseNumber = "TC050";
                regtest.AttachmentTitleEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Title Field is Enabled");

                TestcaseNumber = "TC051";
                regtest.AttachmentTitleMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Title Mandatory Symbol is displayed");

                TestcaseNumber = "TC052";
                regtest.AttachmentTitleUpto80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Title Field Taking Upto 80 Characters");

                TestcaseNumber = "TC053";
                regtest.AttachmentTitleAbove80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Title Field Not Taking Above 80 Characters");

                TestcaseNumber = "TC054";
                regtest.AttachmentTitleSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Title Field Not Taking Space in the Beginning");

                TestcaseNumber = "TC055";
                regtest.CancelButtonClick();
                regtest.AddAttachmentButtonClick();
                regtest.ClickOnSubmitButtonWithout_Data();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Found Field Error Message for Clicking Submit Button without Passing Data");

                TestcaseNumber = "TC057";
                regtest.AttachmentTitle();
                _test.Log(Status.Pass, $"{TestcaseNumber} | System is Allowed to Enter The Valid Title");

                TestcaseNumber = "TC058";
                regtest.DocumentTypeEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Type Field is Enabled");

                TestcaseNumber = "TC059";
                regtest.DocumentTypeMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Type Field is Mandatory");

                TestcaseNumber = "TC061";
                regtest.DocumentTypeSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Type Select is verified");

                TestcaseNumber = "TC062";
                regtest.DocumentTypeReselect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Type is Options are Verified");

                TestcaseNumber = "TC063";
                regtest.DocumentTypeManually();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Manually Entered Document Type");

                TestcaseNumber = "TC074";
                regtest.DocumentCategoryEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Category is Enabled");

                TestcaseNumber = "TC075";
                regtest.DocumentCategoryMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Category Mandatory Symbol is Displayed");

                TestcaseNumber = "TC077";
                regtest.DocumentCategorySelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Category is Selected");

                TestcaseNumber = "TC078";
                regtest.DocumentCategoryReSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Category is Re-Selected");

                TestcaseNumber = "TC079";
                regtest.DocumentCategory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Document Category is Verified");

                TestcaseNumber = "TC082";
                regtest.DescriptionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field is Enabled");

                TestcaseNumber = "TC083";
                regtest.DescriptionMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC084";
                regtest.DescriptionUpto150();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field Taking Upto 80 Characters");

                TestcaseNumber = "TC085";
                regtest.DescriptionAbove150();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field Not Taking Above 80 Characters");

                TestcaseNumber = "TC086";
                regtest.Description();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field is Verified");

                TestcaseNumber = "TC088";
                regtest.SubmitButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Enabled");

                TestcaseNumber = "TC089";
                regtest.SubmitButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Clicked and Displayed Successful Toast");

                TestcaseNumber = "TC090";
                regtest.DeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Delete Icon is Enabled");

                TestcaseNumber = "TC091";
                regtest.DeleteClickCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC092";
                regtest.DeleteClickOk();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC093";
                regtest.DeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Deleted Toast is displayed");

                TestcaseNumber = "TC094";
                regtest.AddAttachmentButtonClick();
                regtest.CancelButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Cancel Button is Enabled");

                TestcaseNumber = "TC095";
                regtest.CancelButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirect to Registration Screen When Clicked on Attachment Cancel Button");

                regtest.AddAttachmentButtonClick();
                regtest.AttachmentTitle();
                regtest.DocumentTypeManually();
                regtest.DocumentCategory();
                regtest.Description();
                regtest.SubmitButtonClick();

                TestcaseNumber = "TC096";
                regtest.AttachmentSearch();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Edit is Successful");

                TestcaseNumber = "TC097";
                regtest.AttachmentEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Edit is Successful");

                TestcaseNumber = "TC102";
                regtest.ContactInfoAccordion();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Contact Information Accordion is Opened");

                TestcaseNumber = "TC103";
                regtest.ContactInfoAccordionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Contact Information Accordion is Closed when Clicked");

                TestcaseNumber = "TC104";
                regtest.ContactInfoFields();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the Contact Information Fields are Displayed");

                TestcaseNumber = "TC105";
                regtest.ClickOnSubmitWithout_CI_Info();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Field Error Messages are Displayed");

                /*TestcaseNumber = "TC106";
                regtest.ClearButton();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Message Cleared when Clicked on Clear Button");*/

                TestcaseNumber = "TC107";
                regtest.TitleEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Title Field is Enabled");

                TestcaseNumber = "TC108";
                regtest.TitleMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Title Field is Enabled");

                TestcaseNumber = "TC110";
                regtest.Title();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Title Field is Verified");

                TestcaseNumber = "TC112";
                regtest.FirstNameEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | First Name Field is Enabled");

                TestcaseNumber = "TC113";
                regtest.FirstNameMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | First Name Mandatory Symbol is Displayed");

                TestcaseNumber = "TC114";
                regtest.FirstNameSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                TestcaseNumber = "TC115";
                regtest.FirstNameUpto80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the First Name Upto 80 Characters");

                TestcaseNumber = "TC116";
                regtest.FirstNameAbove80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the First Name Above 80 Characters");

                TestcaseNumber = "TC118";
                regtest.FirstName();
                _test.Log(Status.Pass, $"{TestcaseNumber} | First Name Field is Verified");

                TestcaseNumber = "TC119";
                regtest.MiddleNameEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Middle Name Field is Enabled");

                TestcaseNumber = "TC120";
                regtest.MiddleNameMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Symbol is Not Displayed for Middle Name");

                TestcaseNumber = "TC121";
                regtest.MiddleNameSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                TestcaseNumber = "TC122";
                regtest.MiddleNameUpto80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Middle Name Upto 80 Characters");

                TestcaseNumber = "TC123";
                regtest.MiddleNameAbove80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Middle Name Above 80 Characters");

                TestcaseNumber = "TC124";
                regtest.MiddleName();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Middle Name Field is Verified");

                TestcaseNumber = "TC126";
                regtest.LastNameEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Last Name Field is Verified");

                TestcaseNumber = "TC127";
                regtest.LastNameMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Last Name Field mandatory Symbol is displayed");

                TestcaseNumber = "TC128";
                regtest.LastNameSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Last Name Field Not Allowed Space in the Beginning");

                TestcaseNumber = "TC129";
                regtest.LastNameUpto80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Last Name Upto 80 Characters");

                TestcaseNumber = "TC130";
                regtest.LastNameAbove80Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Last Name Above 80 Characters");

                TestcaseNumber = "TC131";
                regtest.Last_Name();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Last Name Field is Verified");

                TestcaseNumber = "TC133";
                regtest.EmailAddressEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Email Address Field is Enabled");

                TestcaseNumber = "TC134";
                regtest.EmailAddressMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Email Address Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC135";
                regtest.EmailAddressSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Email Address Field is Not Accepting Space in the Beginning");

                TestcaseNumber = "TC136";
                regtest.EmailUpto70Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Email Upto 70 Characters");

                TestcaseNumber = "TC137";
                regtest.EmailAbove70Char();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Email Above 70 Characters");

                TestcaseNumber = "TC138";
                regtest.EmailDuplicate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Found Error message for Duplicate Email");

                TestcaseNumber = "TC139";
                regtest.EmailInvalid();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Found Error message for Invalid Email");

                TestcaseNumber = "TC140";
                regtest.EmailAddress();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Email Address Green Tick mark is Displayed");

                TestcaseNumber = "TC141";
                regtest.PhoneNumberEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number Field is Enabled");

                TestcaseNumber = "TC142";
                regtest.PhoneNumberMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC144";
                regtest.PhoneNumberCode();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number Code is Changed as per the Selected Flag");

                TestcaseNumber = "TC145";
                regtest.PhoneNumberClear();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number is Cleared when the Fag is Changed");

                TestcaseNumber = "TC146";
                regtest.PhoneNumberInvalid();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Invalid Phone Number Error is Displayed");

                TestcaseNumber = "TC147";
                regtest.PhoneNumberSpecialChar();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number Field Not Acceptine Space and Special Characters");

                TestcaseNumber = "TC149";
                regtest.PhoneNumber();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Phone Number Field is Verified");

                TestcaseNumber = "TC150";
                regtest.SubmitClickEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Enabled");

                TestcaseNumber = "TC151";
                regtest.SubmitClick();
                regtest.SubmitClickMessage();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Verification link sent! Message is Displayed");

                TestcaseNumber = "TC153";
                regtest.GoBackButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | GoBack Button is Enabled");

                TestcaseNumber = "TC154";
                regtest.ClickGoBackButton();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on GoBack Button and Page is Redirected to Login page");

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
