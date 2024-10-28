using AventStack.ExtentReports;
using ELIT_AutomationFramework.BaseClass;
using ELIT_AutomationFramework.Methods.IR;
using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.IR
{
    [TestFixture]
    public class B_IR_Creation_and_Approval : ReportsGenerationClass
    {
        InternalReq_Methods IRtest;
        ExcelUtility excelUtility;

        [Test]
        [Category("Create and Approve IR")]
        public void IR_Create_and_Approve()
        {
            string excelPath;
            try
            {
                string directoryPath = @"D:\1.ELIT_AutomationFramework\Excel\IR_ExcelSheets";
                string fileNamePattern = "IRTestData_*_v*.xlsx";

                // Get the Excel file path based on the pattern
                excelPath = ExcelUtility.GetExcelFilePathWithTimestampAndVersion(directoryPath, fileNamePattern);
                Console.WriteLine($"Latest Path read from directory: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"Excel file not found or file does not exist: {excelPath}");
                }
                Console.WriteLine($"Loading data from Excel file: {excelPath}");
                excelUtility = new ExcelUtility();
                excelUtility.IRLoadData(excelPath, "TestData");
                IRtest = new InternalReq_Methods(GetDriver(), excelUtility);
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
                TestcaseNumber = "TC01";
                IRtest.GoToPage();
                IRtest.UserName();
                IRtest.Password();
                IRtest.LogIn();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Logged in as a Buyer");

                TestcaseNumber = "TC02";
                IRtest.HomePageRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Home Page Refresh Successful");

                TestcaseNumber = "TC03";
                IRtest.ElitLogo();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Elit Logo is Displayed on Homepage");

                TestcaseNumber = "TC04";
                IRtest.RequisitionTabEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition tab is Enabled");

                TestcaseNumber = "TC05";
                IRtest.RequisitionTabClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Displayed under the Requisition Tab");

                TestcaseNumber = "TC06";
                IRtest.RequisitionOptionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Enabled");

                TestcaseNumber = "TC07";
                IRtest.RequisitionOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Clicked");

                TestcaseNumber = "TC09";
                IRtest.RefreshRequisitionDashboard();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to Requisition Dashboard");

                TestcaseNumber = "TC10";
                IRtest.CreateButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Create Button is Enabled");

                TestcaseNumber = "TC11";
                IRtest.CreateButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to Create Requisition Page");

                TestcaseNumber = "TC12";
                IRtest.ActoinButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Button is Enabled");

                TestcaseNumber = "TC13";
                IRtest.ActionButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Save For Later and Preview Options are Displayed");

                TestcaseNumber = "TC14";
                IRtest.GobackButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Goback Button is Enabled");

                TestcaseNumber = "TC15";
                IRtest.GobackButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to Requisition Dashboard");

                TestcaseNumber = "TC16";
                IRtest.DashboardProjectEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Project Field is Verified");

                TestcaseNumber = "TC17";
                IRtest.DashboardProjectClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Project Field is Verified");

                TestcaseNumber = "TC18";
                IRtest.DashboardProjectSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Project Field is Verified");

                TestcaseNumber = "TC19";
                IRtest.Project();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Project Field is Verified");

                TestcaseNumber = "TC20";
                IRtest.CreateButtonClick();
                IRtest.RequisitionAccordions();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the Requisition Accordions are Displayed");

                TestcaseNumber = "TC21";
                IRtest.Header_Fields();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the header Fields are Displayed");

                TestcaseNumber = "TC22";
                IRtest.SaveForLater_WithoutData();
                IRtest.GobackButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Fields Error message is Displayed when Clicked on Save For later");

                TestcaseNumber = "TC23";
                IRtest.CreateButtonClick();
                IRtest.Preview_WithoutData();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Fields Error message is Displayed when Clicked on Preview");

                TestcaseNumber = "TC24";
                IRtest.Header_ProjectEnebled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Project Field is Enabled");

                TestcaseNumber = "TC26";
                IRtest.Header_ProjectMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Project Field Mandatory Symbol is displayed");

                TestcaseNumber = "TC28";
                IRtest.Header_ProjectSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Project Field is Enabled");

                TestcaseNumber = "TC29";
                IRtest.Header_Project();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Project Field is Enabled");

                TestcaseNumber = "TC31";
                IRtest.Header_TitleEnebled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Title is Enabled");

                TestcaseNumber = "TC32";
                IRtest.Header_TitleMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Title Field Mandatory Symbol is displayed");

                TestcaseNumber = "TC33";
                IRtest.Header_TitleSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                TestcaseNumber = "TC34";
                IRtest.Header_TitleUpto240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Title Upto 240 Characters");

                TestcaseNumber = "TC35";
                IRtest.Header_TitleAbove240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Title Above 240 Characters");

                TestcaseNumber = "TC36";
                IRtest.Header_Title();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Title is Verified");

                TestcaseNumber = "TC39";
                IRtest.Prepared_byDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Prepared By is disabled");

                TestcaseNumber = "TC40";
                IRtest.Prepared_byMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Prepared By Field Mandatory Symbol is displayed");

                TestcaseNumber = "TC41";
                IRtest.Prepared_byDefault();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Prepared By is Displayed as Buyer By Default");

                TestcaseNumber = "TC42";
                IRtest.requested_byEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requested By Field is Enabled");

                TestcaseNumber = "TC43";
                IRtest.Requested_byMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requested By Field Mandatory Symbol is displayed");

                TestcaseNumber = "TC45";
                IRtest.Requested_bySelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requested By is Option is Selected");

                TestcaseNumber = "TC46";
                IRtest.Requested_byReselect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requested By is Option is Re-Selected");

                TestcaseNumber = "TC48";
                IRtest.OperatingUnitDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Operating Unit is Disabled");

                TestcaseNumber = "TC49";
                IRtest.OperatingUnitMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Operating unit Mandatory Symbol is displayed");

                TestcaseNumber = "TC50";
                IRtest.OperatingUnitDefault();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Operating Unit is Displayed 'Appstec Technology Services LLC by Default'");

                TestcaseNumber = "TC51";
                IRtest.Ship_To_LocationEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Enabled");

                TestcaseNumber = "TC52";
                IRtest.Ship_To_LocationMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location Mandatory Symbol is displayed");

                TestcaseNumber = "TC54";
                IRtest.Ship_To_LocationSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Selected");

                TestcaseNumber = "TC55";
                IRtest.Ship_To_LocationResselect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Re-Selected");

                TestcaseNumber = "TC56";
                IRtest.Ship_To_Location();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Verified");

                TestcaseNumber = "TC62";
                IRtest.CreationDateDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Creation Date is Disabled");

                TestcaseNumber = "TC63";
                IRtest.CreationDateCurrent();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Creation Date is Displayed as Current Date");

                TestcaseNumber = "TC64";
                IRtest.IRStatusDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Status Field is Disabled");

                TestcaseNumber = "TC65";
                IRtest.IRStatusDraft();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Status is Displayed as Draft");

                TestcaseNumber = "TC66";
                IRtest.InternamReq_ButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Internal Requisition Button is Enabled");

                TestcaseNumber = "TC67";
                IRtest.InternamReq_ButtonSelected();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Internal Requisition Button is Selected");

                TestcaseNumber = "TC68";
                IRtest.InternamReq_ButtonUnselected();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Internal Requisition Button is Un-Selected");

                TestcaseNumber = "TC69";
                IRtest.Note_To_ApproverEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Note To Approver is Enabled");

                TestcaseNumber = "TC70";
                IRtest.Note_To_ApproverMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Note To Approver Mandatory Symbol is displayed");

                TestcaseNumber = "TC71";
                IRtest.Note_To_ApproverSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Note to Approver is not taking Space in the beginning");

                TestcaseNumber = "TC72";
                IRtest.Note_To_ApproverUpto1000();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Note to Approver Upto 1000 Characters");

                TestcaseNumber = "TC73";
                IRtest.Note_To_ApproverAbove1000();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Note to Approver Above 1000 Characters");

                TestcaseNumber = "TC74";
                IRtest.Note_To_ApproverEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Note To Approver Field Allowed to Edit the Text in the Middle");

                TestcaseNumber = "TC75";
                IRtest.Note_To_Approver();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Note To Approver is Verified");

                TestcaseNumber = "TC76";
                IRtest.DescriptionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description is Enabled");

                TestcaseNumber = "TC77";
                IRtest.DescriptionMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Mandatory Symbol is displayed");

                TestcaseNumber = "TC78";
                IRtest.DescriptionSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description is not taking Space in the beginning");

                TestcaseNumber = "TC79";
                IRtest.DescriptionUpto240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Description Upto 240 Characters");

                TestcaseNumber = "TC80";
                IRtest.DescriptionAbove240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Description Above 240 Characters");

                TestcaseNumber = "TC81";
                IRtest.DescriptionEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description Field Allowed to Edit the Text in the Middle");

                TestcaseNumber = "TC82";
                IRtest.Description();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description is Verified");

                TestcaseNumber = "TC83";
                IRtest.Add_AttachmentEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Add Attachment is Enabled");

                TestcaseNumber = "TC84";
                IRtest.Fileupload();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Add Attachment is Verified");

                TestcaseNumber = "TC91";
                IRtest.DeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Delete Icon is Enabled");

                TestcaseNumber = "TC92";
                IRtest.DeleteClickCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC93";
                IRtest.DeleteClickOk();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC94";
                IRtest.DeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Deleted Toast is displayed");

                TestcaseNumber = "TC108";
                IRtest.LinesAccordionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Saved and Successfully Processed Toast is Displayed");

                TestcaseNumber = "TC109";
                IRtest.LinesClick_IRNumber();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Number is Generated");

                TestcaseNumber = "TC110";
                IRtest.ActionButtonClick();
                IRtest.IR_CancelOption();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancel Option is Displayed once the IR ID is Generated");

                TestcaseNumber = "TC111";
                IRtest.PreviewOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Fields are Read-Only in Preview mode");

                TestcaseNumber = "TC112";
                IRtest.ActionClick();
                IRtest.PreviewModeActionOptions();
                _test.Log(Status.Pass, $"{TestcaseNumber} | only Update and Submit Options are be Displayed in preview mode");

                TestcaseNumber = "TC113";
                IRtest.UpdateOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Fields are Editable when Clicked on Update Button");

                TestcaseNumber = "TC114";
                IRtest.ActionButtonClick();
                IRtest.CancelOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments Screen is Displayed when clicked on Cancel Option");

                TestcaseNumber = "TC115";
                IRtest.CancelButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Cancel Button is Enabled");

                TestcaseNumber = "TC116";
                IRtest.CancelButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to IR Creation Screen");

                TestcaseNumber = "TC117";
                IRtest.ActionClick();
                IRtest.CancelOptionClick();
                IRtest.CancelSubmit_WithoutData();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Message Displayed when Submitted Without Data");

                TestcaseNumber = "TC118";
                IRtest.CancelCommentsEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field is Enabled");

                TestcaseNumber = "TC119";
                IRtest.CancelCommentsMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC120";
                IRtest.CancelCommentsSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments is not taking Space in the beginning");

                TestcaseNumber = "TC121";
                IRtest.CancelCommentsUpto400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Comments Upto 400 Characters");

                TestcaseNumber = "TC122";
                IRtest.CancelCommentsAbove400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Comments Above 400 Characters");

                TestcaseNumber = "TC123";
                IRtest.CancelCommentsEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field Allowed to Edit the Text in the Middle");

                TestcaseNumber = "TC124";
                IRtest.CancelComments();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field is Verified");

                TestcaseNumber = "TC125";
                IRtest.SubmitButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Enabled");

                TestcaseNumber = "TC126";
                IRtest.SubmitButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancellation is Submitted");

                IRtest.CreateButtonClick();
                IRtest.Header_Project();
                IRtest.Header_Title();
                IRtest.Requested_bySelect();
                IRtest.Ship_To_Location();
                IRtest.InternamReq_ButtonSelected();
                IRtest.Note_To_Approver();
                IRtest.Description();
                IRtest.Fileupload();
                IRtest.LinesAccordionClick();

                TestcaseNumber = "TC129.1";
                IRtest.ActionButtonClick();
                IRtest.SaveForLater();
                IRtest.ActionButtonClick();
                IRtest.Preview();
                IRtest.ActionClick();
                IRtest.ClickSubmit_WithoutLine();
                IRtest.ActionClick();
                IRtest.UpdateOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Displayed Error toast when user Submitted IR Without the Line");


                TestcaseNumber = "TC130";
                //IRtest.Draft();
                IRtest.Approved();
                IRtest.LineAccordionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Lines Accordion is Enabled");

                TestcaseNumber = "TC131";
                IRtest.LinesClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Dropdown, Go Button, and Search Field is Displayed under Lines Section");

                TestcaseNumber = "TC132";
                IRtest.LineActionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line - Action Dropdown is Enabled");

                TestcaseNumber = "TC132";
                IRtest.LineActionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line - Action Options are Displayed");

                TestcaseNumber = "TC134";
                IRtest.LineActionSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Selected Line Option");

                TestcaseNumber = "TC135";
                IRtest.LineActionReSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Re-Selected Other Line Option");

                TestcaseNumber = "TC136";
                IRtest.LineActionSelect();
                IRtest.GoButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Go Button is Enabled");

                TestcaseNumber = "TC137";
                IRtest.GOButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to Create Line Screen");

                TestcaseNumber = "TC138";
                IRtest.CreateLinePage_Refresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Create Line Page Refresh is Successful");

                TestcaseNumber = "TC139";
                IRtest.LinesClick();
                IRtest.GOButtonClick();
                IRtest.LineTypeDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Type is Disabled for IR");

                TestcaseNumber = "TC140";
                IRtest.LineTypeMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Type Mandatory Symbol is Displayed");

                TestcaseNumber = "TC141";
                IRtest.DefaultLineType();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Type is Selected as Goods by Default");

                TestcaseNumber = "TC142";
                IRtest.CreateLineFields();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the Create line Fields are Displayed");

                TestcaseNumber = "TC143";
                IRtest.ClickOnApplyWithout_Data();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Fields Error message is Displayed when Clicked on Line Apply Button Without Data");

                TestcaseNumber = "TC145";
                IRtest.ItemEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Item Field is Enabled");

                TestcaseNumber = "TC146";
                IRtest.Itemmandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Item Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC148";
                IRtest.ItemSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Item is Selected from Options");

                TestcaseNumber = "TC149";
                IRtest.Item_ReSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Item is Re-Selected from Options");

                TestcaseNumber = "TC150";
                IRtest.CL_Item();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Item Field is Verified");

                TestcaseNumber = "TC152";
                IRtest.CategoryDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Category Field is Read-Only");

                TestcaseNumber = "TC153";
                IRtest.CategoryMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Category Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC154";
                IRtest.CategoryPopupate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Category is Populated as per the Item Selected");

                TestcaseNumber = "TC155";
                IRtest.UnitDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field is Read-Only");

                TestcaseNumber = "TC156";
                IRtest.UnitMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC157";
                IRtest.UnitPopupate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Unit is Populated as per the Item Selected");

                TestcaseNumber = "TC158";
                IRtest.QuantityEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field is Enabled");

                TestcaseNumber = "TC159";
                IRtest.QuantityMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC160";
                IRtest.QuantitySpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field Not Allowing to Enter Space and Special Characters");

                TestcaseNumber = "TC161";
                IRtest.QuantityUpto9();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowed to Enter the Quantity Upto 9 Digits");

                TestcaseNumber = "TC162";
                IRtest.QuantityAbove9();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowed to Enter the Quantity Above 9 Digits");

                TestcaseNumber = "TC163";
                IRtest.QuantityEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowed to Edit the Entered Quantity");

                TestcaseNumber = "TC165";
                IRtest.CL_Quantity();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Quantity Field is Verified");

                TestcaseNumber = "TC180";
                IRtest.CL_NeedByDateEnable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Field is Enabled");

                TestcaseNumber = "TC181";
                IRtest.CL_NeedByDateMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate mandatory Symbol is Displayed");

                TestcaseNumber = "TC182";
                IRtest.CL_NeedByDateDropdownSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate is Selected From Dropdown");

                TestcaseNumber = "TC183";
                IRtest.CurrentCL_NeedByDate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Current NeedByDate is Cleared");

                TestcaseNumber = "TC184";
                IRtest.CL_NeedByDateMonthandYear();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Year and Month Select Dropdown is Displayed");

                TestcaseNumber = "TC186";
                IRtest.CL_NeedByDate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Valid NeedByDate Date is Selected");

                TestcaseNumber = "TC187";
                IRtest.IR_StatusDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Status Field is Disabled");

                TestcaseNumber = "TC188";
                IRtest.IR_StatusDraft();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Status Displayed as Draft by Default");

                TestcaseNumber = "TC189";
                IRtest.PreferredBrandDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Read-Only");

                TestcaseNumber = "TC190";
                IRtest.PreferredBrandMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand is a Non mandatory Field");

                TestcaseNumber = "TC191";
                IRtest.PreferredBrandPopupate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand is Populated as per the Item Selected");

                TestcaseNumber = "TC192";
                IRtest.DescriptionDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Description Field is Disabled");

                TestcaseNumber = "TC193";
                IRtest.DescriptionPopulated();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Description is Populated as per the Item Selected");

                TestcaseNumber = "TC194";
                IRtest.Line_AttachmentEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Enabled");

                TestcaseNumber = "TC200";
                IRtest.CL_Attachment();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Verified");

                TestcaseNumber = "TC201";
                IRtest.Line_AttachDeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Delete Icon is Enabled");

                TestcaseNumber = "TC202";
                IRtest.Line_AttachDeleteClickCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC203";
                IRtest.Line_AttachDeleteClickOk();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC204";
                IRtest.Line_AttachDeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Successfully Deleted Toast is displayed");

                TestcaseNumber = "TC217";
                IRtest.CL_ApplyEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Apply Button is Enabled");

                TestcaseNumber = "TC218";
                IRtest.CL_ApplyClick();
                IRtest.CL_ApplyToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Processed Toast is Displayed");

                TestcaseNumber = "TC219";
                IRtest.RedirectBackToHeader();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirect Back to the Header Screen");

                TestcaseNumber = "TC220";
                IRtest.InternalReq_ButtonDisabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Internal Request Button is Disabled after the Line Creation");

                TestcaseNumber = "TC221";
                IRtest.CreatedLine_Table();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Created Line is Displayed in the table");

                TestcaseNumber = "TC225";
                IRtest.UploadLine_OptionDisplayed();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Option is Displayed");

                TestcaseNumber = "TC226";
                IRtest.UploadLine_OptionSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Option is Selected");

                TestcaseNumber = "TC227";
                IRtest.UploadLine_GO();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Option is Selected, and Clicked on GO");

                TestcaseNumber = "TC228";
                IRtest.UploadLine_CancelEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Screen Cancel Button is Enabled");

                TestcaseNumber = "TC229";
                IRtest.UploadLine_CancelClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Cancel Button, and Page Redirect back to IR Creation Screen");

                TestcaseNumber = "TC230";
                IRtest.UploadLine_OptionSelect();
                IRtest.UploadLine_GO();
                IRtest.UploadLine_Refresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Screen Refresh Successful, and Page Redirect back to IR Creation Screen");

                TestcaseNumber = "TC226";
                IRtest.LinesClick();
                IRtest.UploadLine_OptionSelect();
                IRtest.UploadLine_GO();
                IRtest.UploadLine_Template();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Download Template Link is Enabled");

                TestcaseNumber = "TC239";
                IRtest.UploadFile();
                IRtest.UploadLine_ScreenTable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line is Displayed on the Table");

                TestcaseNumber = "TC240";
                IRtest.UploadLine_Fields();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Fields are Displayed on the Table");

                TestcaseNumber = "TC241";
                IRtest.UploadLine_ClearEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Screen Clear Button is Enabled");

                TestcaseNumber = "TC242";
                IRtest.UploadLine_ClearClick();
                IRtest.UploadLine_CancelClick();
                IRtest.UploadLine_GO();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Clear Button and the Lines are Cleard");

                TestcaseNumber = "TC243";
                IRtest.UploadFile();
                IRtest.UploadLine_SubmitEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Submit Button is Enabled");

                TestcaseNumber = "TC244";
                IRtest.UploadLine_SubmitClick_WithoutData();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Messages are Displayed when Clicked on Submit Button Without Providing Data");

                TestcaseNumber = "TC245";
                IRtest.UploadLine_Brand_populate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Brand Field Value is Auto Populated");

                TestcaseNumber = "TC246";
                IRtest.UploadLine_LineTypeDisabled();
                IRtest.UploadLine_ClearClick();
                IRtest.UploadLine_CancelClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line - Line Type is read-Only");

                TestcaseNumber = "TC247";
                IRtest.UploadLine_OptionSelect();
                IRtest.UploadLine_GO();
                IRtest.UploadFile();
                IRtest.UploadSubmit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Details are Updated as per the Item Selected");

                TestcaseNumber = "TC248";
                IRtest.LinesClickIfRequired();
                IRtest.UploadLine_OptionSelect();
                IRtest.UploadLine_GO();
                _test.Log(Status.Pass, "Clicked on Go Button");
                IRtest.UploadFile();
                _test.Log(Status.Pass, "File Uploaded");
                IRtest.Uploadline_QtyEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Quantity Field is Enabled");

                TestcaseNumber = "TC249";
                IRtest.Uploadline_QtyOnlyDigits();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Quantity Field is Accepting Only Numeric Values");

                TestcaseNumber = "TC250";
                IRtest.Uploadline_QtyMoreThan_OnhandQty();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Message is Displayed When user Entered More than Onhand Quantity");

                TestcaseNumber = "TC251";
                IRtest.Uploadline_Quantity();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Quantity Field is Verified");

                TestcaseNumber = "TC252";
                IRtest.Uploadline_NeedBydateEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Need By Date Field is Enabled");

                TestcaseNumber = "TC253";
                IRtest.UploadLine_NeedByDatePicker();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Date Picker is Displayed");

                TestcaseNumber = "TC254";
                IRtest.UploadLine_NeedByDateMonthandYear();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Year and Month Select Dropdown is Displayed");

                TestcaseNumber = "TC255";
                IRtest.UploadLine_NeedByDateDisplayed();
                _test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Given in the Excel Sheet is Displayed");

                TestcaseNumber = "TC256";
                IRtest.UploadLine_NeedByDateSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line NeedByDate is Selected");

                TestcaseNumber = "TC257";
                IRtest.UploadLine_CurrentDateSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowed to Select the Current Date as NeedByDate");

                TestcaseNumber = "TC259";
                IRtest.UploadLine_NeedByDateManually();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowed to Enter the NeedByDate Manually");

                TestcaseNumber = "TC260";
                IRtest.UploadLine_DeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Delete icon is Enabled");

                TestcaseNumber = "TC261";
                IRtest.UploadLine_DeleteCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC262";
                IRtest.UploadLine_DeleteClickOk();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC263";
                IRtest.UploadLine_DeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Deleted Toast is displayed");

                TestcaseNumber = "TC264";
                IRtest.UploadLine_SubmitClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded line is Submitted Successfully");

                TestcaseNumber = "TC265";
                IRtest.UploadLine_ScrollFunction();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded line Scroll Function is Working properly");

                TestcaseNumber = "TC270";
                IRtest.IR_Line_DeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Line Delete icon is Enabled");

                TestcaseNumber = "TC271";
                IRtest.IR_Line_DeleteCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Line is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC272";
                IRtest.IR_Line_DeleteOK();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Line Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC273";
                IRtest.IR_Line_DeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Line Successfully Deleted Toast is displayed");

                TestcaseNumber = "TC274";
                IRtest.IR_Line_DeleteTable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Deleted IR Line is Removed from the Table");

                TestcaseNumber = "TC275";
                IRtest.IR_Line_Search();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Line Search Function is Verified");

                TestcaseNumber = "TC276";
                IRtest.IR_Action();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Button is Enabled");

                TestcaseNumber = "TC277";
                IRtest.IR_ActionOptions();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Save For Later, cancel and Preview Options are Displayed");

                TestcaseNumber = "TC278";
                IRtest.PreviewOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Entered Preview Mode");

                TestcaseNumber = "TC279";
                IRtest.PreviewRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Refreshed Successfully in Preview mode");

                TestcaseNumber = "TC280";
                IRtest.ActionClick();
                IRtest.IR_PreviewActionOptions();
                IRtest.UpdateOptionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Update Option is Enabled");

                TestcaseNumber = "TC281";
                IRtest.UpdateOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Update Mode is Displayed");

                TestcaseNumber = "TC282";
                IRtest.ActionButtonClick();
                IRtest.SaveForLater();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Save For Later is Verified");

                TestcaseNumber = "TC283";
                IRtest.ActionButtonClick();
                IRtest.Preview();
                IRtest.ActionClick();
                IRtest.Submit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Button is Verified");

                TestcaseNumber = "TC284";
                IRtest.SubmitToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Submitted Toast is Displayed");

                TestcaseNumber = "TC285";
                IRtest.ApprovalinProgress();
                IRtest.IRStatusAfterSubmit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Status is Approval in-progress After the Submission");

                TestcaseNumber = "TC286";
                IRtest.IR_RequestType();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Request Type is Displayed as 'Internal'");

                TestcaseNumber = "TC287";
                IRtest.IR_ViewApprovalHistoryDisplayed();
                _test.Log(Status.Pass, $"{TestcaseNumber} | View Approval History Option is Displayed under the Action Button");

                TestcaseNumber = "TC288";
                IRtest.IR_ViewApprovalHistory();
                IRtest.LOGOUT();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver detailas are Displayed in the View Approval History Screen");

                _test.Log(Status.Pass, "-----------------IR Approval--------------");
                TestcaseNumber = "TC290";
                IRtest.Approver_UserName();
                IRtest.Password();
                IRtest.LogIn();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Logged In");

                TestcaseNumber = "TC291";
                IRtest.ApproverDashboard();
                IRtest.Approval_Notification();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Dashboard is Displayed");

                TestcaseNumber = "TC292";
                IRtest.ApproverDashboardRefresh();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approver Dashboare Page Refresh is Successful");

                TestcaseNumber = "TC293";
                IRtest.IRApprovalEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Approval tab is Enabled");

                TestcaseNumber = "TC294";
                IRtest.IR_ApprovalCLick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Approval Table is Displayed");

                TestcaseNumber = "TC295";
                IRtest.SearchFieldEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Approval Tab is Verified");

                TestcaseNumber = "TC296";
                IRtest.SearchAlphaNumeric();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Search Field is Allowing Alpha Numeric and Special Characters");

                TestcaseNumber = "TC297";
                IRtest.IR_Search();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Searched Text is Filtered from the Table");

                TestcaseNumber = "TC298";
                IRtest.IR_SearchClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | System is Allowed to Open the IR Document");

                TestcaseNumber = "TC299";
                IRtest.IR_LinesDisplayed();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Lines are Displayed");

                TestcaseNumber = "TC300";
                IRtest.ApprovalGoBackEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approval Screen GoBack Button is Enabled");

                TestcaseNumber = "TC301";
                IRtest.ApprovalGoBackClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on GoBack Button and Page is Redirected to Approver Dashboard");

                TestcaseNumber = "TC302";
                IRtest.IR_Search();
                IRtest.IR_SearchClick();
                IRtest.Doc_ActionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Action Button is Enabled");

                TestcaseNumber = "TC303";
                IRtest.Doc_Action();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve, Reject and View Approval History Options are Displayed");

                TestcaseNumber = "TC304";
                IRtest.ViewApprovalHistory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | View Approval History Screen is Displayed");

                TestcaseNumber = "TC305";
                IRtest.HistoryGoback();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page is Redirect Back to the IR Approval Screen");

                TestcaseNumber = "TC306";
                IRtest.ActionClick();
                IRtest.ActionApprove();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Message Displayed when Submitted Without Data");

                TestcaseNumber = "TC307";
                IRtest.ClickApprove_WithoutData();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Message Displayed when Submitted Without Data");

                TestcaseNumber = "TC308";
                IRtest.ApproveCommentsEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve Comments Field is Enabled");

                TestcaseNumber = "TC309";
                IRtest.ApproveCommentsMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve Comments Field Mandatory Symbol is Displayed");

                TestcaseNumber = "TC310";
                IRtest.ApproveCommentsSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve Comments is not taking Space and Special chars in the beginning");

                TestcaseNumber = "TC311";
                IRtest.ApproveCommentsUpto400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Comments Upto 400 Characters");

                TestcaseNumber = "TC312";
                IRtest.ApproveCommentsAbove400();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Comments Above 400 Characters");

                TestcaseNumber = "TC313";
                IRtest.ApproveCommentsEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve Comments Field Allowed to Edit the Text in the Middle");

                TestcaseNumber = "TC314";
                IRtest.CancelEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Cancel Button is Enabled");

                TestcaseNumber = "TC315";
                IRtest.CancelClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page is Redirected to the IR Approval Screen When clicked on Cancel Button");

                TestcaseNumber = "TC316";
                IRtest.ActionClick();
                IRtest.ActionApprove();
                IRtest.ApproveComments();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Approve Comments Field is Verified");

                TestcaseNumber = "TC317";
                IRtest.ApproveButtonEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Approve Button is Enabled");

                TestcaseNumber = "TC318";
                IRtest.ApproveButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR is Approved and 'Approved Successfully' Toast is Displayed");

                TestcaseNumber = "TC319";
                IRtest.StatusSelect();
                IRtest.IR_Search();
                IRtest.IR_SearchClick();
                IRtest.ActionClick();
                IRtest.ViewApprovalHistory();
                IRtest.IR_ViewAppHistory_Approved();
                _test.Log(Status.Pass, "After the IR Approval, IR Status is Displayed as 'Approved'");

                _test.Log(Status.Pass, "-----------------IR Rejection--------------");
                IRtest.LOGOUT();
                IRtest.UserName();
                _test.Log(Status.Pass, "Username Entered");
                IRtest.Password();
                _test.Log(Status.Pass, "Password Entered");
                IRtest.LogIn();
                _test.Log(Status.Pass, "Buyer Logged in");
                IRtest.RequisitionTabClick();
                _test.Log(Status.Pass, "Clicked on requisition tab");
                IRtest.RequisitionOptionClick();
                _test.Log(Status.Pass, "Clicked on requisition Option");
                IRtest.CreateButtonClick();
                _test.Log(Status.Pass, "Clicked on Create Button");
                IRtest.Header_Project();
                _test.Log(Status.Pass, "Project Selected");
                IRtest.Header_Title();
                _test.Log(Status.Pass, "Title Entered");
                IRtest.Requested_bySelect();
                _test.Log(Status.Pass, "Requested by Selected");
                IRtest.Ship_To_Location();
                _test.Log(Status.Pass, "Location Selected");
                IRtest.InternamReq_ButtonSelected();
                _test.Log(Status.Pass, "IR Button Selected");
                IRtest.Note_To_Approver();
                _test.Log(Status.Pass, "Note to Approver Entered");
                IRtest.Description();
                _test.Log(Status.Pass, "Description Entered");
                IRtest.LinesAccordionClick();
                _test.Log(Status.Pass, "Line Accordion Clicked");
                IRtest.UploadLine_OptionSelect();
                _test.Log(Status.Pass, "Upload line Option Selected");
                IRtest.UploadLine_GO();
                _test.Log(Status.Pass, "GO");
                IRtest.UploadFile();
                _test.Log(Status.Pass, "File Uploaded");
                IRtest.UploadSubmit();
                _test.Log(Status.Pass, "Clicked on Submit");
                IRtest.ActionButtonClick();
                _test.Log(Status.Pass, "Clicked on Action");
                IRtest.Preview();
                _test.Log(Status.Pass, "Clicked on Preview");
                IRtest.ActionClick();
                IRtest.SubmitForRejection();
                _test.Log(Status.Pass, "IR Submitted");
                IRtest.LOGOUT();
                IRtest.Approver_UserName();
                IRtest.Password();
                IRtest.LogIn();
                _test.Log(Status.Pass, "Approver Logged in");
                IRtest.Approval();
                IRtest.Approval_Notification();
                _test.Log(Status.Pass, "Clicked on Approval_Notification");
                IRtest.ApproverDashboard();
                _test.Log(Status.Pass, "Approver Dashboard is Displayed");
                IRtest.IR_ApprovalCLick();
                _test.Log(Status.Pass, "Clicked on Requisition Approval");
                IRtest.IR_Search2();
                _test.Log(Status.Pass, "Approval IR Searched");
                IRtest.IR_SearchClick();
                _test.Log(Status.Pass, "Clicked on Filtered Document");
                IRtest.ActionClick();
                _test.Log(Status.Pass, "Clicked on Action Button");

                TestcaseNumber = "TC321";
                IRtest.ActionReject();
                _test.Log(Status.Pass, $"{TestcaseNumber} | IR Rejection Comments Screen is Displayed");

                TestcaseNumber = "TC322";
                IRtest.RejectComments();
                IRtest.RejectButtonClick();
                _test.Log(Status.Pass, "IR is Rejected, and Successfully Rejected Toast is Displayed");

                TestcaseNumber = "TC323";
                IRtest.StatusSelect();
                IRtest.IR_Search_Rejected();
                IRtest.IR_SearchClick();
                IRtest.ActionClick();
                IRtest.ViewApprovalHistory();
                IRtest.IR_ViewAppHistory_Rejected();
                IRtest.LOGOUT();
                _test.Log(Status.Pass, "After the IR Rejection, IR Status is Displayed as 'Rejected'");

                _test.Log(Status.Pass, "-----------------IR Close--------------");
                //IRtest.LOGOUT();
                //IRtest.UserName();
                //_test.Log(Status.Pass, "Username Entered");
                //IRtest.Password();
                //_test.Log(Status.Pass, "Password Entered");
                //IRtest.LogIn();
                //_test.Log(Status.Pass, "Buyer Logged in");
                //IRtest.RequisitionTabClick();
                //IRtest.RequisitionOptionClick();
                //Thread.Sleep(7000);
                //IRtest.ClickonApprovedIR();
                //IRtest.ActionClick();
                //TestcaseNumber = "TC326";
                //IRtest.ActionOptions_approvedIR();
                //_test.Log(Status.Pass, "Close, Return & Cancel and View Approval history Options are Displayed");

                //TestcaseNumber = "TC327";
                //IRtest.ApprovedIR_CloseEnabled();
                //_test.Log(Status.Pass, "Close Option is Enabled");

                //TestcaseNumber = "TC328";
                //IRtest.ApprovedIR_CloseClick();
                //_test.Log(Status.Pass, "Page is Redirected to the Comments Screen");

                //TestcaseNumber = "TC329";
                //IRtest.CloseSubmit_WithoutData();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Fields Error message is Displayed when Clicked on Submit without Entering Data");

                //TestcaseNumber = "TC330";
                //IRtest.CloseCommentsEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancel Comments Field is Enabled");

                //TestcaseNumber = "TC331";
                //IRtest.CloseCommentsMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancel Comments Field Mandatory Symbol is Displayed");

                //TestcaseNumber = "TC332";
                //IRtest.CloseCommentsSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancel Comments is not taking Space in the beginning");

                //TestcaseNumber = "TC333";
                //IRtest.CloseCommentsUpto400();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Comments Upto 400 Characters");

                //TestcaseNumber = "TC334";
                //IRtest.CloseCommentsAbove400();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Comments Above 400 Characters");

                //TestcaseNumber = "TC335";
                //IRtest.CloseCommentsEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field Allowed to Edit the Text in the Middle");

                //TestcaseNumber = "TC336";
                //IRtest.CloseComments();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field is Verified");

                //TestcaseNumber = "TC337";
                //IRtest.Close_SubmitButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Enabled");

                //TestcaseNumber = "TC338";
                //IRtest.CLose_SubmitButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | IR Cancellation is Submitted and Successfully Closed Toast is Displayed");

                IRtest.LOGOUT();
                _test.Log(Status.Pass, $"{TestcaseNumber} | User Logged Out");
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
                IRtest.CloseBrowser();
            }
        }
    }
}