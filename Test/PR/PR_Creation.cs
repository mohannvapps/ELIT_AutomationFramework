using AventStack.ExtentReports;
using ELIT_AutomationFramework.BaseClass;
using ELIT_AutomationFramework.Methods.PR;
using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.PR
{
    public class PR_Creation : ReportsGenerationClass
    {
        PurchaseReq_Methods PRtest;
        ExcelUtility excelUtility;

        [Test]
        [Category("Create PR")]
        public void PR_Create()
        {
            string excelPath;
            try
            {
                string directoryPath = @"D:\1.ELIT_AutomationFramework\Excel\PR_ExcelSheets";
                string fileNamePattern = "PRtestData_*_v*.xlsx";

                excelPath = ExcelUtility.GetExcelFilePathWithTimestampAndVersion(directoryPath, fileNamePattern);
                Console.WriteLine($"Latest Path read from directory: {excelPath}");

                if (string.IsNullOrEmpty(excelPath) || !File.Exists(excelPath))
                {
                    throw new FileNotFoundException($"Excel file not found or file does not exist: {excelPath}");
                }
                Console.WriteLine($"Loading data from Excel file: {excelPath}");
                excelUtility = new ExcelUtility();
                excelUtility.PRLoadData(excelPath, "TestData");
                PRtest = new PurchaseReq_Methods(GetDriver(), excelUtility);
            }
            catch (Exception ex)
            {
                _test.Log(Status.Fail, $"Failed to load Excel file: {ex.Message}");
                Assert.Fail($"Failed to load Excel file: {ex.Message}");
                return;
            }
            try
            {
                TestcaseNumber = "TC01";
                PRtest.GoToPage();
                PRtest.UserName();
                PRtest.Password();
                PRtest.LogIn();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Logged in as a Buyer");

                //TestcaseNumber = "TC02";
                //PRtest.HomePageRefresh();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Home Page Refresh Successful");

                //TestcaseNumber = "TC03";
                //PRtest.ElitLogo();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | ELIT Logo is Displayed");

                //TestcaseNumber = "TC04";
                //PRtest.MainDashboardCardsDisplayed();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | All the Module Cards are Displayed in the Main Dashboard");

                //TestcaseNumber = "TC05";
                //PRtest.MainDashboardCardsEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | All the Module Cards are Enabled in the Main Dashboard");

                /*TestcaseNumber = "TC06";
                PRtest.ClickOnCard();
                _test.Log(Status.Pass, $"{TestcaseNumber} | User is Redirected to the Selected Module Screen");*/

                //TestcaseNumber = "TC07";
                //PRtest.MainSearchIconEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Search Icon Should be in Enabled State");

                //TestcaseNumber = "TC08";
                //PRtest.MainSearchIconClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Search Model is displayed to the User");

                //TestcaseNumber = "TC09";
                //PRtest.ClickOnSuggestedModule();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | User is Redirected to the Selected Module");

                //TestcaseNumber = "TC10";
                //PRtest.clickOnLogo();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | User is Redirected to the Selected Module");                

                //TestcaseNumber = "TC11";
                //PRtest.RequisitionTabEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requisition tab is Enabled");

                //TestcaseNumber = "TC12";
                //PRtest.RequisitionTabClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Displayed under the Requisition Tab");

                //TestcaseNumber = "TC13";
                //PRtest.RequisitionOptionEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Enabled");

                TestcaseNumber = "TC14";
                PRtest.RequisitionOptionClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requisition Option is Clicked");

                PRtest.DraftPR();

                //TestcaseNumber = "TC15";
                //PRtest.RefreshRequisitionDashboard();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to Requisition Dashboard");

                //TestcaseNumber = "TC16";
                //PRtest.CreateButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Create Button is Enabled");

                //TestcaseNumber = "TC17";
                //PRtest.CreateButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to Create Requisition Screen");

                //TestcaseNumber = "TC18";
                //PRtest.ActoinButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Action  Button is Enabled");

                //TestcaseNumber = "TC19";
                //PRtest.ActionButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Save For Later Option is Displayed");

                //TestcaseNumber = "TC20";
                //PRtest.GobackButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Goback Button is Enabled");

                //TestcaseNumber = "TC21";
                //PRtest.GobackButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Confirmation Popup is Displayed");

                //TestcaseNumber = "TC22";
                //PRtest.GobackClickCancel();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Confirmation Popup has been closed");

                //TestcaseNumber = "TC23";
                //PRtest.GobackClickOk();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page is redirected to the Requisition Dashboard");

                //TestcaseNumber = "TC24";
                //PRtest.MainSearchIconClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Search Model is displayed to the User");

                //TestcaseNumber = "TC25";
                //PRtest.MainSearchIrrelevantText();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Found Text is Displayed when Entered Irrelevant Text into the Search Feld");

                //TestcaseNumber = "TC26";
                //PRtest.MainSearchValidText();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Search Criteria has Filtered from the Options");

                //TestcaseNumber = "TC27";
                //PRtest.ClickOnFilteredModule();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to the Requisition Dashboard");

                //TestcaseNumber = "TC28";
                //PRtest.CreateButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirects to Create Requisition Screen");

                //TestcaseNumber = "TC29";
                //PRtest.Header_Fields();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | All the header Fields are Displayed");

                //TestcaseNumber = "TC30";
                //PRtest.SaveForLater_WithoutData();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Mandatory Fields Error message is Displayed when Clicked on Save For later");

                //TestcaseNumber = "TC31";
                //PRtest.Header_TitleEnebled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Header Title is Enabled");

                //TestcaseNumber = "TC32";
                //PRtest.Header_TitleMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Header Title Field Mandatory Symbol is displayed");

                //TestcaseNumber = "TC33";
                //PRtest.Header_TitleSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter Space/Special Characters in the beginning");

                //TestcaseNumber = "TC34";
                //PRtest.Header_TitleUpto240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Title Upto 240 Characters");

                //TestcaseNumber = "TC35";
                //PRtest.Header_TitleAbove240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Title Above 240 Characters");

                //TestcaseNumber = "TC36";
                //PRtest.Header_TitleEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Header Title Edit Function is Verified");

                /*TestcaseNumber = "TC37";
                PRtest.Header_Title();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Header Title is Verified");*/

                //TestcaseNumber = "TC38";
                //PRtest.Header_PreparedBy();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Prepared By Field Displaying Buyer in Read-Only mode");

                //TestcaseNumber = "TC39";
                //PRtest.requested_byEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requested By Field is Enabled");

                //TestcaseNumber = "TC40";
                //PRtest.Requested_byMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requested By Field Mandatory Symbol is displayed");

                /*TestcaseNumber = "TC41";
                PRtest.Requested_bySelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Requested By is Option is Selected");*/

                //TestcaseNumber = "TC42";
                //PRtest.Requested_byReselect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Requested By is Option is Re-Selected");

                //TestcaseNumber = "TC43";
                //PRtest.OperatingUnitDefault();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Operating Unit is Displayed 'ELIT Procure to Pay Solution by Default'");

                /*TestcaseNumber = "TC44";
                PRtest.Ship_To_LocationEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Enabled");

                TestcaseNumber = "TC45";
                PRtest.Ship_To_LocationMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location Mandatory Symbol is displayed");

                TestcaseNumber = "TC46";
                PRtest.Ship_To_LocationSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location is Selected");*/

                //TestcaseNumber = "TC48";
                //PRtest.Ship_To_LocationToolTip();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Ship To Location Tool Tip Function is Displayed");

                //TestcaseNumber = "TC49";
                //PRtest.PRCreationDate();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR Creation Date is Displaying Current Date");

                //TestcaseNumber = "TC50";
                //PRtest.PRStatus();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR Status is Displayed as 'Draft' By Default");

                //TestcaseNumber = "TC51";
                //PRtest.DescriptionEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Description is Enabled");

                //TestcaseNumber = "TC52";
                //PRtest.DescriptionMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Description Mandatory Symbol is displayed");

                //TestcaseNumber = "TC53";
                //PRtest.DescriptionSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Description is not taking Space in the beginning");

                //TestcaseNumber = "TC54";
                //PRtest.DescriptionUpto240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Description Upto 240 Characters");

                //TestcaseNumber = "TC55";
                //PRtest.DescriptionAbove240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Description Above 240 Characters");

                //TestcaseNumber = "TC56";
                //PRtest.DescriptionEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Description Field Allowed to Edit the Text in the Middle");

                /*TestcaseNumber = "TC57";
                PRtest.Description();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Description is Verified");*/

                //TestcaseNumber = "TC58";
                //PRtest.Add_AttachmentEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Add Attachment is Enabled");

                //TestcaseNumber = "TC59";
                //PRtest.Fileupload();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Add Attachment is Verified");

                //TestcaseNumber = "TC75";
                //PRtest.DeleteEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Delete Icon is Enabled");

                //TestcaseNumber = "TC76";
                //PRtest.DeleteClickCancel();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Attachment is Not Deleted When Clicked on Cancel");

                //TestcaseNumber = "TC77";
                //PRtest.DeleteClickOk();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Attachment Deleted Successfully When Clicked on OK");

                //TestcaseNumber = "TC78";
                //PRtest.DeleteToast();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Deleted Toast is displayed");

                //TestcaseNumber = "TC79";
                //PRtest.Fileupload();
                //PRtest.LinesAccordionClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR Saved and Successfully Processed Toast is Displayed");

                //TestcaseNumber = "TC80";
                //PRtest.LinesClick_PRNumber();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR ID is Generated");

                //TestcaseNumber = "TC81";
                //PRtest.CancelOptionDisplayed();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR Cancel Option is Displayed");

                //TestcaseNumber = "TC82";
                //PRtest.CancelOptionClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Screen is Displayed when clicked on Cancel Option");

                //TestcaseNumber = "TC83";
                //PRtest.CancelButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Cancel Button is Enabled");

                //TestcaseNumber = "TC84";
                //PRtest.CancelButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to PR Creation Screen");

                //TestcaseNumber = "TC85";
                //PRtest.ActionClick();
                //PRtest.CancelOptionClick();
                //PRtest.CancelSubmit_WithoutData();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Error Message Displayed when Submitted Without Data");

                //TestcaseNumber = "TC86";
                //PRtest.CancelCommentsEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field is Enabled");

                //TestcaseNumber = "TC87";
                //PRtest.CancelCommentsMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field Mandatory Symbol is Displayed");

                //TestcaseNumber = "TC88";
                //PRtest.CancelCommentsSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments is not taking Space in the beginning");

                //TestcaseNumber = "TC89";
                //PRtest.CancelCommentsUpto400();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Comments Upto 400 Characters");

                //TestcaseNumber = "TC90";
                //PRtest.CancelCommentsAbove400();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Comments Above 400 Characters");

                //TestcaseNumber = "TC91";
                //PRtest.CancelCommentsEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field Allowed to Edit the Text in the Middle");

                //TestcaseNumber = "TC92";
                //PRtest.CancelComments();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Comments Field is Verified");

                //TestcaseNumber = "TC93";
                //PRtest.SubmitButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Submit Button is Enabled");

                //TestcaseNumber = "TC94";
                //PRtest.SubmitButtonClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | PR Cancellation is Submitted with Successful Toast");

                //TestcaseNumber = "TC95";
                //PRtest.ClickOnCancelledStatus();
                //PRtest.SearchCancelledPR();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Cancelled PR Moved to 'Cancelled' Status");

                //TestcaseNumber = "TC97";
                //PRtest.RequestType();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Request Type is Displayed as Purchase");

                //PRtest.CreateButtonClick();
                //PRtest.Header_Title();
                //PRtest.Description();
                //PRtest.Fileupload();              
                //PRtest.LinesAccordionClick();
                //PRtest.ActionClick();

                //TestcaseNumber = "TC98";
                //PRtest.SubmitClickWithoutLine();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Error toast is Displayed when Clicked on PR Submit, without Line");

                TestcaseNumber = "TC99";
                PRtest.LinesSectionFields();//modification Req for flow (without draft)
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the Fields are Displayed in the Lines Section");

                //TestcaseNumber = "TC100";
                //PRtest.Create_UploadEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Create/Upload Line Dropdown is Enabled");

                //TestcaseNumber = "TC101";
                //PRtest.Create_UploadOptions();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Create and Upload Line Options Are Displayed");

                /*TestcaseNumber = "TC102";
                PRtest.CreateLineselect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Create Line Options is Selected");*/

                //TestcaseNumber = "TC103";
                //PRtest.OtherOptionSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Option is Selected");

                //TestcaseNumber = "TC104";
                //PRtest.GoButtonEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Go Button is Enabled");

                /*TestcaseNumber = "TC105";
                PRtest.GOButtonClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Page Redirected to Create Line Screen");*/

                //TestcaseNumber = "TC106";
                //PRtest.LineTypeEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | LineType Field is Enabled");

                //TestcaseNumber = "TC107";
                //PRtest.LineTypemandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | LineType Field Mandatory Symbol is Displayed");

                //TestcaseNumber = "TC108";
                //PRtest.LineTypeSelectGoods();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | all the Line Fields are Displayed for the Line Type - Goods");

                //TestcaseNumber = "TC109";
                //PRtest.LineGoods_ApplyWithoutData();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | All Mandatory Fields Error Messages are Displayed when Submitted Goods Line Without Data");

                //TestcaseNumber = "TC110";
                //PRtest.LineTypeSelect_FS();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | all the Line Fields are Not Displayed for the Line Type - Goods");

                //TestcaseNumber = "TC111";
                //PRtest.LineFPS_ApplyWithoutData();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | All Mandatory Fields Error Messages are Displayed when Submitted Fixed Price Line Without Data");

                //TestcaseNumber = "TC112";
                //PRtest.Line_Goods();
                //PRtest.LineItemEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Item Field is Enabled");

                /*TestcaseNumber = "TC113"; //Bug
                PRtest.LineItemMandatory();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Item Field Mandatory Symbol is Displayed");*/

                //TestcaseNumber = "TC114";
                //PRtest.LineItemClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Item Options are Displayed");

                //TestcaseNumber = "TC115";
                //PRtest.LineitemSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Item is Selected");

                //TestcaseNumber = "TC118";
                //PRtest.Lineitem_ReSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Item is Re-Selected");

                //TestcaseNumber = "TC119";
                //PRtest.LineCategoryPopulate();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Category is Populated When user Selects Item");

                //TestcaseNumber = "TC120";
                //PRtest.LineCategory_ChangeItem();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Category is Populated When user Changes Item");

                //TestcaseNumber = "TC121";
                //PRtest.LineCategory_ReadOnly();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Category Field is Read-Only");

                //TestcaseNumber = "TC122";
                //PRtest.LineCategory_Mandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Category Field mandatory Symbol is Displayed");

                /*TestcaseNumber = "TC123";
                PRtest.Line_FPS();
                PRtest.LineCategory_Click();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Category Options are Displayed");

                TestcaseNumber = "TC124";
                PRtest.LineCategory_Select();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowing to Select the Line Category");*/

                //TestcaseNumber = "TC125";
                //PRtest.LineCategory_ReSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowing to Re-Select the Line Category");

                //TestcaseNumber = "TC127";
                //PRtest.LineUnit_Enabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field is Enabled");

                //TestcaseNumber = "TC128";
                //PRtest.LineUnit_Mandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field Mandatory Symbol is Displayed");

                /*TestcaseNumber = "TC129";
                PRtest.LineUnit_Click();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field Options are Displayed");

                TestcaseNumber = "TC130";
                PRtest.LineUnit_Select();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Unit Field is Selected");*/

                //TestcaseNumber = "TC132";
                //PRtest.QuantityEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field is Enabled");

                //TestcaseNumber = "TC133";
                //PRtest.QuantityMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field Mandatory Symbol is Displayed");

                //TestcaseNumber = "TC134";
                //PRtest.QuantitySpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Quantity Field Not Allowing to Enter Space and Special Characters");

                //TestcaseNumber = "TC135";
                //PRtest.QuantityUpto9();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowed to Enter the Quantity Upto 9 Digits");

                //TestcaseNumber = "TC136";
                //PRtest.QuantityAbove9();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowed to Enter the Quantity Above 9 Digits");

                //TestcaseNumber = "TC137";
                //PRtest.QuantityEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowed to Edit the Entered Quantity");

                /*TestcaseNumber = "TC138";
                PRtest.CL_Quantity();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Quantity Field is Verified");*/

                //TestcaseNumber = "TC139";
                //PRtest.Buyer_Enabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Buyer Field is Enabled");

                //TestcaseNumber = "TC140";
                //PRtest.Buyer_Mandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Buyer Field Mandatory Symbol is displayed");

                //TestcaseNumber = "TC141";
                //PRtest.Buyer_Click();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Buyer Field Options are Displayed");

                //TestcaseNumber = "TC142";
                //PRtest.Buyer_Select();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Buyer is Selected");

                //TestcaseNumber = "TC143";
                //PRtest.Buyer_Enter();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Entered the Buyer Manually");

                /*TestcaseNumber = "T144";
                PRtest.Buyer_Reselect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Buyer Option is Re-Selected");*/

                //TestcaseNumber = "TC145";
                //PRtest.CL_NeedByDateEnable();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Field is Enabled");

                //TestcaseNumber = "TC146";
                //PRtest.CL_NeedByDateMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate mandatory Symbol is Displayed");

                //TestcaseNumber = "TC147";
                //PRtest.CL_NeedByDateDropdownSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate is Selected From Dropdown");

                //TestcaseNumber = "TC148";
                //PRtest.CurrentCL_NeedByDate();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Date is updated to Next Date of the Current Date");

                //TestcaseNumber = "TC150";
                //PRtest.CL_NeedByDateMonthandYear();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | NeedByDate Year and Month Select Dropdown is Displayed");

                /*TestcaseNumber = "TC151";
                PRtest.CL_NeedByDate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Valid NeedByDate Date is Selected");*/

                //TestcaseNumber = "TC152";
                //PRtest.cl_StatusDisabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Status Field is Disabled");

                //TestcaseNumber = "TC153";
                //PRtest.cl_StatusDraft();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | line Status Displayed as Draft by Default");

                //TestcaseNumber = "TC154";
                //PRtest.PreferredBrandEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Enabled");

                //TestcaseNumber = "TC155";
                //PRtest.PreferredBrandMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand is a Non mandatory Field");

                //TestcaseNumber = "TC156";
                //PRtest.PreferredBrandPopupate();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand is Populated as per the Item Selected");

                //TestcaseNumber = "TC157";
                //PRtest.PreferredBrandSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Not Accepting Space and Special Chars in Beginning");

                //TestcaseNumber = "TC158";
                //PRtest.PreferredBrandUpto100();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Brand Upto 100 Characters");

                //TestcaseNumber = "TC159";
                //PRtest.PreferredBrandAbove100();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Brand Above 100 Characters");

                //TestcaseNumber = "TC160";
                //PRtest.PreferredBrandEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Edit Function is Verified");

                /*TestcaseNumber = "TC161";
                PRtest.Preferred_Brand();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Verified");*/

                //TestcaseNumber = "TC162";
                //PRtest.Cl_DescriptionEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Description is Enabled");

                //TestcaseNumber = "TC163";
                //PRtest.Cl_DescriptionMandatory();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Description Mandatory Symbol is displayed");

                //TestcaseNumber = "TC164";
                //PRtest.Cl_DescriptionSpace();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Description is not taking Space in the beginning");

                //TestcaseNumber = "TC165";
                //PRtest.Cl_DescriptionUpto240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Line Description Upto 240 Characters");

                //TestcaseNumber = "TC166";
                //PRtest.Cl_DescriptionAbove240();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Line Description Above 240 Characters");

                //TestcaseNumber = "TC167";
                //PRtest.Cl_DescriptionEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Description Field Allowed to Edit the Text in the Middle");

                /*TestcaseNumber = "TC168";
                PRtest.Cl_Description();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Description is Verified");*/

                //TestcaseNumber = "TC169";
                //PRtest.Line_AttachmentEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Enabled");

                /*TestcaseNumber = "TC170";
                PRtest.CL_Attachment();
                PRtest.CL_Attachment();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Verified");*/

                //TestcaseNumber = "TC176";
                //PRtest.Line_AttachDeleteEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Delete Icon is Enabled");

                //TestcaseNumber = "TC177";
                //PRtest.Line_AttachDeleteClickCancel();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment is Not Deleted When Clicked on Cancel");

                //TestcaseNumber = "TC178";
                //PRtest.Line_AttachDeleteClickOk();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Deleted Successfully When Clicked on OK");

                //TestcaseNumber = "TC179";
                //PRtest.Line_AttachDeleteToast();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Attachment Successfully Deleted Toast is displayed");

                /*TestcaseNumber = "TC191";
                PRtest.SupplierSection();
                _test.Log(Status.Pass, $"{TestcaseNumber} | All the Supplier Fields are Displayed");

                TestcaseNumber = "TC192";
                PRtest.SupplierDropdownEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Dropdown is Enabled");

                TestcaseNumber = "TC193";
                PRtest.ClickSupplierSite();
                _test.Log(Status.Pass, $"{TestcaseNumber} | 'No Options' is Displayed when user clicks Supplier Site Without Selecting Supplier");

                TestcaseNumber = "TC194";
                PRtest.SupplierDropdownClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Options are Displayed");

                TestcaseNumber = "TC195";
                PRtest.SupplierSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Supplier is Selected");*/

                //TestcaseNumber = "TC196";
                //PRtest.SupplierEnter();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Entered the Text and Selected the Supplier");

                //TestcaseNumber = "TC197";
                //PRtest.SupplierReselect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier is Re-Selected");

                //TestcaseNumber = "TC198";
                //PRtest.SupplierSiteEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Site Dropdown is Enabled");

                //TestcaseNumber = "TC199";
                //PRtest.SupplierSiteClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Site Options are Displayed");

                //TestcaseNumber = "TC200";
                //PRtest.SupplierSiteSelect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Site is Selected");

                //TestcaseNumber = "TC201";
                //PRtest.SupplierSiteReselect();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Site is Re-Selected");

                //TestcaseNumber = "TC202";
                //PRtest.ChangeSupplier();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Site is Changed when user change the Supplier");

                //TestcaseNumber = "TC203";
                //PRtest.SupplierContactDisplayed();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Supplier Contact is Displayed");

                //TestcaseNumber = "TC204";
                //PRtest.CL_ApplyEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Apply Button is Enabled");

                /*TestcaseNumber = "TC205";
                PRtest.CL_ApplyClick();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Apply Button");

                TestcaseNumber = "TC206";
                PRtest.CL_ApplyToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Processed Toast is Displayed");*/

                //TestcaseNumber = "TC207";
                //PRtest.CL_CreatedLine_Click();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Update Screen is Displayed");               

                //TestcaseNumber = "TC208";
                //PRtest.LineCategoryEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Category Field");

                //TestcaseNumber = "TC209";
                //PRtest.LineUnitEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Unit Field");

                //TestcaseNumber = "TC210";
                //PRtest.LineQuantityEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Quantity Field");

                //TestcaseNumber = "TC211";
                //PRtest.LineBuyerEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Buyer Field");

                //TestcaseNumber = "TC212";
                //PRtest.LineNeedByDateEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Need By Date Field");

                //TestcaseNumber = "TC213";
                //PRtest.LineBrandEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Brand Field");

                //TestcaseNumber = "TC214";
                //PRtest.LineDescriptionEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Description Field");

                //TestcaseNumber = "TC215";
                //PRtest.LineAttachmentEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Attachment Field");

                //TestcaseNumber = "TC216";
                //PRtest.CL_AddedAttachment();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Addded Attachment is Displyed inside the Line");

                //TestcaseNumber = "TC217";
                //PRtest.LineSupplierEdit();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | System is allowing to Edit the Supplier Field");

                //TestcaseNumber = "TC218";
                //PRtest.CL_UpdateEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Apply Button is Enabled");

                //TestcaseNumber = "TC219";
                //PRtest.CL_UpdateClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Line Updated, Successfully Processed Toast is Displayed");

                TestcaseNumber = "TC220";
                PRtest.UploadLine_OptionDisplayed();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Option is Displayed");

                TestcaseNumber = "TC221";
                PRtest.UploadLine_OptionSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Option is Selected");

                TestcaseNumber = "TC222";
                PRtest.UploadLine_GO();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Screen is Displayed");

                //TestcaseNumber = "TC223";
                //PRtest.UploadLine_CancelEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Upload line Screen Cancel Button is Enabled");

                //TestcaseNumber = "TC224";
                //PRtest.UploadLine_CancelClick();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Cancel Button, and Page Redirect back to PR Creation Screen");

                //TestcaseNumber = "TC226";
                //PRtest.UploadLine_OptionDisplayed();
                //PRtest.UploadLine_OptionSelect();
                //PRtest.UploadLine_GO();
                //PRtest.UploadLine_Template();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Download Template Link is Enabled");

                //TestcaseNumber = "TC236";
                //PRtest.UploadFile();
                //PRtest.UploadLine_ScreenTable();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line is Displayed on the Import Line Page");

                //TestcaseNumber = "TC237";
                //PRtest.UploadLine_Fields();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Fields are Displayed on the Table");

                //TestcaseNumber = "TC238";
                //PRtest.UploadLine_ClearEnabled();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Screen Clear Button is Enabled");

                //TestcaseNumber = "TC239";
                //PRtest.UploadLine_ClearClick();
                //PRtest.UploadLine_CancelClick();
                //PRtest.UploadLine_GO();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | Clicked on Clear Button and the Lines are Cleard");

                TestcaseNumber = "TC240";
                PRtest.UploadFile();
                PRtest.UploadLine_SubmitEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Apply Button is Enabled");

                TestcaseNumber = "TC241";
                PRtest.UploadLine_SubmitClick_WithoutData();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Error Messages are Displayed when Clicked on Submit Button Without Providing Data");

                TestcaseNumber = "TC242";
                PRtest.UploadLineDeleteEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Delete Icon is Enabled");

                TestcaseNumber = "TC243";
                PRtest.UploadDeleteClickCancel();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line is Not Deleted When Clicked on Cancel");

                TestcaseNumber = "TC244";
                PRtest.UploadDeleteClickOk();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Uploaded Line Deleted Successfully When Clicked on OK");

                TestcaseNumber = "TC245";
                PRtest.UploadDeleteToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Detaled Toast is Displayed");

                TestcaseNumber = "TC246";
                PRtest.CancelClick();
                PRtest.UploadLine_GO();
                PRtest.UploadFile();
                PRtest.ChangeLineType_Goods();
                PRtest.UploadLine_GoodsLineEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | User is Allowed to Edit the Goods line Fields");

                TestcaseNumber = "TC247";
                PRtest.LineItemEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | User is Allowed to Edit the Fixed Services line Fields");

                TestcaseNumber = "TC248";
                PRtest.UploadLineQuantityAbove9();
                _test.Log(Status.Pass, $"{TestcaseNumber} | System Not allowing to Enter the Quantity Above 9 Digits");

                TestcaseNumber = "TC249";
                PRtest.UL_NeedByDateEnable();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line NeedByDate Field is Enabled");

                TestcaseNumber = "TC250";
                PRtest.UL_NeedByDateDropdownSelect();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line NeedByDate is Selected From Dropdown");

                TestcaseNumber = "TC251";
                PRtest.CurrentUL_NeedByDate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line NeedByDate Date is updated to Next Date of the Current Date");

                TestcaseNumber = "TC252";
                PRtest.UL_NeedByDateMonthandYear();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line NeedByDate Year and Month Select Dropdown is Displayed");

                TestcaseNumber = "TC253";
                PRtest.UL_NeedByDate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Valid NeedByDate Date is Selected");

                TestcaseNumber = "TC254";
                PRtest.UL_PreferredBrandEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Enabled");

                TestcaseNumber = "TC255";
                PRtest.UL_PreferredBrandPopupate();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand is Populated as per the Item Selected");

                TestcaseNumber = "TC256";
                PRtest.UL_PreferredBrandSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Not Accepting Space and Special Chars in Beginning");

                TestcaseNumber = "TC257";
                PRtest.UL_PreferredBrandUpto100();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Brand Upto 100 Characters");

                TestcaseNumber = "TC258";
                PRtest.UL_PreferredBrandAbove100();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Brand Above 100 Characters");

                TestcaseNumber = "TC259";
                PRtest.UL_PreferredBrandEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Edit Function is Verified");

                TestcaseNumber = "TC260";
                PRtest.UL_Preferred_Brand();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Preferred Brand Field is Verified");

                TestcaseNumber = "TC261";
                PRtest.ChangeLineType_FPS();
                PRtest.Ul_DescriptionEnabled();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Item Description is Enabled");

                TestcaseNumber = "TC262";
                PRtest.Ul_DescriptionSpace();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Item Description is not taking Space in the beginning");

                TestcaseNumber = "TC263";
                PRtest.Ul_DescriptionUpto240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Allowewd to Enter the Upload Line Item Description Upto 240 Characters");

                TestcaseNumber = "TC264";
                PRtest.Ul_DescriptionAbove240();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Not Allowewd to Enter the Upload Line Item Description Above 240 Characters");

                TestcaseNumber = "TC265";
                PRtest.Ul_DescriptionEdit();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Item Description Field Allowed to Edit the Text in the Middle");

                TestcaseNumber = "TC266";
                PRtest.Ul_Description();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line Item Description is Verified");

                TestcaseNumber = "TC267";
                PRtest.CancelClick();
                PRtest.UploadLine_GO();
                PRtest.UploadFile();
                PRtest.Ul_Apply();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Upload Line is Submitted");

                TestcaseNumber = "TC268";
                PRtest.Ul_SubmitToast();
                _test.Log(Status.Pass, $"{TestcaseNumber} | Successfully Processed Toast is Displayed");









                //PRtest.LOGOUT();
                //_test.Log(Status.Pass, $"{TestcaseNumber} | User Logged Out");
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
                PRtest.CloseBrowser();
            }
        }
    }
}
