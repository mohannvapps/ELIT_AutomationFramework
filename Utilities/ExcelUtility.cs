using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;

namespace ELIT_AutomationFramework.Utilities
{
    public class ExcelUtility
    {
        public Dictionary<string, string> logintestData;
        public Dictionary<string, string> registrationtestData;
        public Dictionary<string, string> profiletestData;
        public Dictionary<string, string> irtestData;
        public Dictionary<string, string> prtestData;
        public ExcelUtility()
        {
            logintestData   = new Dictionary<string, string>();
            registrationtestData = new Dictionary<string, string>();
            profiletestData = new Dictionary<string, string>();
            irtestData      = new Dictionary<string, string>();
            prtestData      = new Dictionary<string, string>();
        }
        public string GenerateLoginExcelTemplate(string loginfilePath)
        {
            // Ensure the directory exists
            string logindirectory = Path.GetDirectoryName(loginfilePath);
            if (!Directory.Exists(logindirectory))
            {
                Directory.CreateDirectory(logindirectory);
                Console.WriteLine($"Directory created: {logindirectory}");
            }
            var workbook = new XSSFWorkbook(); // Create an instance of XSSFWorkbook (NPOI workbook)
            try
            {
                ISheet sheet = workbook.CreateSheet("TestData");
                // Create the data rows
                string[] keys = { "URL", "Username", "Password" };

                for (int i = 0; i < keys.Length; i++)
                {
                    IRow row = sheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(keys[i]);        // Set the key in column 'A'
                    row.CreateCell(1).SetCellValue(string.Empty);   // Leave the value empty for user input
                }
                // Append a timestamp and version number to the filename for version control
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                string fileName = Path.GetFileNameWithoutExtension(loginfilePath);
                string extension = Path.GetExtension(loginfilePath);

                // Determine the new version number
                string version = LoginGetNextVersion(logindirectory, fileName);

                string newFilePath = Path.Combine(logindirectory, $"{fileName}_{timestamp}_Version{version}{extension}");

                // Save the Excel template with a unique name
                using (FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
                return newFilePath; // Return the full path of the newly created file
            }
            finally
            {
                workbook.Close(); // Explicitly close the workbook
            }
        }
        private string LoginGetNextVersion(string logindirectory, string loginbaseFileName)
        {
            string[] files = Directory.GetFiles(logindirectory, $"{loginbaseFileName}_*_Version*.xlsx");
            int maxVersion = 0;

            Regex regex = new Regex(@"_Version(\d+)\.xlsx$");

            foreach (string file in files)
            {
                Match match = regex.Match(Path.GetFileName(file));
                if (match.Success && int.TryParse(match.Groups[1].Value, out int version))
                {
                    maxVersion = Math.Max(maxVersion, version);
                }
            }
            return (maxVersion + 1).ToString();
        }
        public void LoginLoadData(string loginfilePath, string sheetName)
        {
            using (FileStream file = new FileStream(loginfilePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        // Read the key from the first cell
                        string key = currentRow.GetCell(0)?.ToString()?.Trim();

                        // Read the value from the second cell and convert it to a string
                        ICell valueCell = currentRow.GetCell(1);
                        string value = valueCell != null ? ConvertCellToString(valueCell) : string.Empty;

                        if (!string.IsNullOrEmpty(key))
                        {
                            logintestData[key] = value;
                        }
                    }
                }
                workbook.Close(); // Explicitly close the workbook
            }
        }
//************************************************************************************************************************
        public string GenerateRegistrationExcelTemplate(string regfilePath)
        {
            // Ensure the directory exists
            string regdirectory = Path.GetDirectoryName(regfilePath);
            if (!Directory.Exists(regdirectory))
            {
                Directory.CreateDirectory(regdirectory);
            }

            var workbook = new XSSFWorkbook(); // Create an instance of XSSFWorkbook (NPOI workbook)
            try
            {
                ISheet sheet = workbook.CreateSheet("TestData");
                string[] keys = { "URL","Company Name", "License Number", "Establishment Date", "Attach Title", "Document Type", "Document Category", 
                                  "Description", "CI Title", "First Name", "Middle Name", "Last Name", "Email Address", "Phone Number", "Approver Username",
                                  "Approver Password"};

                for (int i = 0; i < keys.Length; i++)
                {
                    IRow row = sheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(keys[i]);    
                    row.CreateCell(1).SetCellValue(string.Empty); 
                }
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                string fileName = Path.GetFileNameWithoutExtension(regfilePath);
                string extension = Path.GetExtension(regfilePath);

                string version = RegistrationGetNextVersion(regdirectory, fileName);

                string newFilePath = Path.Combine(regdirectory, $"{fileName}_{timestamp}_Version{version}{extension}");

                using (FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
                return newFilePath;
            }
            finally
            {
                workbook.Close();
            }
        }

        private string RegistrationGetNextVersion(string regdirectory, string regbaseFileName)
        {
            string[] files = Directory.GetFiles(regdirectory, $"{regbaseFileName}_*_Version*.xlsx");
            int maxVersion = 0;

            Regex regex = new Regex(@"_Version(\d+)\.xlsx$");

            foreach (string file in files)
            {
                Match match = regex.Match(Path.GetFileName(file));
                if (match.Success && int.TryParse(match.Groups[1].Value, out int version))
                {
                    maxVersion = Math.Max(maxVersion, version);
                }
            }

            return (maxVersion + 1).ToString();
        }
        public void RegistrationLoadData(string regfilePath, string sheetName)
        {
            using (FileStream file = new FileStream(regfilePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        // Read the key from the first cell
                        string key = currentRow.GetCell(0)?.ToString()?.Trim();

                        // Read the value from the second cell and convert it to a string
                        ICell valueCell = currentRow.GetCell(1);
                        string value = valueCell != null ? ConvertCellToString(valueCell) : string.Empty;

                        if (!string.IsNullOrEmpty(key))
                        {
                            registrationtestData[key] = value;
                        }
                    }
                }
                workbook.Close(); // Explicitly close the workbook
            }
        }
//************************************************************************************************************************
        public string GenerateIRExcelTemplate(string ir_filePath)
        {
            // Ensure the directory exists
            string ir_directory = Path.GetDirectoryName(ir_filePath);
            if (!Directory.Exists(ir_directory))
            {
                Directory.CreateDirectory(ir_directory);
            }

            var workbook = new XSSFWorkbook(); // Create an instance of XSSFWorkbook (NPOI workbook)
            try
            {
                ISheet sheet = workbook.CreateSheet("TestData");
                string[] keys = { "URL", "username", "password", "project", "IR Title", "Ship To Location","Approver Note", "Description",
                    "Attachment path", "IR Cancel Comments","linetype", "lineitem", "line Qty", "Need By Date", "upload line path",
                    "Approver UserName","IR Approve Comments","IR Reject Comments"};

                for (int i = 0; i < keys.Length; i++)
                {
                    IRow row = sheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(keys[i]);
                    row.CreateCell(1).SetCellValue(string.Empty);
                }
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                string fileName = Path.GetFileNameWithoutExtension(ir_filePath);
                string extension = Path.GetExtension(ir_filePath);

                string version = ProfileGetNextVersion(ir_directory, fileName);

                string newFilePath = Path.Combine(ir_directory, $"{fileName}_{timestamp}_Version{version}{extension}");

                using (FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
                return newFilePath;
            }
            finally
            {
                workbook.Close();
            }
        }
        private string IRGetNextVersion(string ir_directory, string ir_baseFileName)
        {
            string[] files = Directory.GetFiles(ir_directory, $"{ir_baseFileName}_*_Version*.xlsx");
            int maxVersion = 0;

            Regex regex = new Regex(@"_Version(\d+)\.xlsx$");

            foreach (string file in files)
            {
                Match match = regex.Match(Path.GetFileName(file));
                if (match.Success && int.TryParse(match.Groups[1].Value, out int version))
                {
                    maxVersion = Math.Max(maxVersion, version);
                }
            }

            return (maxVersion + 1).ToString();
        }
        public void IRLoadData(string ir_filePath, string sheetName)
        {
            using (FileStream file = new FileStream(ir_filePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        // Read the key from the first cell
                        string key = currentRow.GetCell(0)?.ToString()?.Trim();

                        // Read the value from the second cell and convert it to a string
                        ICell valueCell = currentRow.GetCell(1);
                        string value = valueCell != null ? ConvertCellToString(valueCell) : string.Empty;

                        if (!string.IsNullOrEmpty(key))
                        {
                            irtestData[key] = value;
                        }
                    }
                }
                workbook.Close(); // Explicitly close the workbook
            }
        }
        //***************************************************************************************************************************
        public string GeneratePRExcelTemplate(string pr_filePath)
        {
            // Ensure the directory exists
            string pr_directory = Path.GetDirectoryName(pr_filePath);
            if (!Directory.Exists(pr_directory))
            {
                Directory.CreateDirectory(pr_directory);
                Console.WriteLine($"Directory created: {pr_directory}");
            }
            var workbook = new XSSFWorkbook(); // Create an instance of XSSFWorkbook (NPOI workbook)
            try
            {
                ISheet sheet = workbook.CreateSheet("TestData");
                // Create the data rows
                string[] keys = {"url", "username", "password", "PR Title", "Description","Attachment path", "PR Cancel Comments",
                    "linetype", "lineitem", "line Qty", "Need By Date", "Line Supplier" ,"upload line path"};

                for (int i = 0; i < keys.Length; i++)
                {
                    IRow row = sheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(keys[i]);        // Set the key in column 'A'
                    row.CreateCell(1).SetCellValue(string.Empty);   // Leave the value empty for user input
                }
                // Append a timestamp and version number to the filename for version control
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                string fileName = Path.GetFileNameWithoutExtension(pr_filePath);
                string extension = Path.GetExtension(pr_filePath);

                // Determine the new version number
                string version = PRGetNextVersion(pr_directory, fileName);

                string newFilePath = Path.Combine(pr_directory, $"{fileName}_{timestamp}_Version{version}{extension}");

                // Save the Excel template with a unique name
                using (FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
                return newFilePath; // Return the full path of the newly created file
            }
            finally
            {
                workbook.Close(); // Explicitly close the workbook
            }
        }
        public string PRGetNextVersion(string pr_directory, string pr_baseFileName)
        {
            string[] files = Directory.GetFiles(pr_directory, $"{pr_baseFileName}_*_Version*.xlsx");
            int maxVersion = 0;

            Regex regex = new Regex(@"_Version(\d+)\.xlsx$");

            foreach (string file in files)
            {
                Match match = regex.Match(Path.GetFileName(file));
                if (match.Success && int.TryParse(match.Groups[1].Value, out int version))
                {
                    maxVersion = Math.Max(maxVersion, version);
                }
            }
            return (maxVersion + 1).ToString();
        }
        public void PRLoadData(string pr_filePath, string sheetName)
        {
            using (FileStream file = new FileStream(pr_filePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        // Read the key from the first cell
                        string key = currentRow.GetCell(0)?.ToString()?.Trim();

                        // Read the value from the second cell and convert it to a string
                        ICell valueCell = currentRow.GetCell(1);
                        string value = valueCell != null ? ConvertCellToString(valueCell) : string.Empty;

                        if (!string.IsNullOrEmpty(key))
                        {
                            prtestData[key] = value;
                        }
                    }
                }
                workbook.Close(); // Explicitly close the workbook
            }
        }
        //***************************************************************************************************************************
        public string GenerateProfileExcelTemplate(string profilefilePath)
        {
            // Ensure the directory exists
            string profiledirectory = Path.GetDirectoryName(profilefilePath);
            if (!Directory.Exists(profiledirectory))
            {
                Directory.CreateDirectory(profiledirectory);
            }

            var workbook = new XSSFWorkbook(); // Create an instance of XSSFWorkbook (NPOI workbook)
            try
            {
                ISheet sheet = workbook.CreateSheet("TestData");
                string[] keys = { "URL", "Username", "Password" , "Alternate Name" , "Parent Company Name", "Supplier URL", "Country",
                                    "VAT","note to Approver","CI First name","CI Middle name","CI Last name","Address Line 1","Address Line 2","Address Line 3",
                                    "Pin Code","Phone Number","Fax Number","Address Book Name","Address Book Alternate Name","addrcountry","Address Book Address Line 1",
                                    "Address Book Address Line 2","Address Book Address Line 3","Address Book Address Line 4","Address Book Pin Code","Address Book Email Address",
                                    "Address Book Phone Number","Bank Details Bank Name","Bank Address","Benificiary Name","Account Number","IBAN Number",
                                    "Swift Code","Questionnaires Answer1","Questionnaires Answer2","Questionnaires Answer3","References Referee's Name",
                                    "References Contact Name","References Address","References Type","References Location","References Email Address","References Phone Number",
                                    "ApprovalProfileEnterUsername","Profile_Search"};

                for (int i = 0; i < keys.Length; i++)
                {
                    IRow row = sheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(keys[i]);
                    row.CreateCell(1).SetCellValue(string.Empty);
                }
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                string fileName = Path.GetFileNameWithoutExtension(profilefilePath);
                string extension = Path.GetExtension(profilefilePath);

                string version = ProfileGetNextVersion(profiledirectory, fileName);

                string newFilePath = Path.Combine(profiledirectory, $"{fileName}_{timestamp}_Version{version}{extension}");

                using (FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
                return newFilePath;
            }
            finally
            {
                workbook.Close();
            }
        }
        private string ProfileGetNextVersion(string profiledirectory, string profilebaseFileName)
        {
            string[] files = Directory.GetFiles(profiledirectory, $"{profilebaseFileName}_*_Version*.xlsx");
            int maxVersion = 0;

            Regex regex = new Regex(@"_Version(\d+)\.xlsx$");

            foreach (string file in files)
            {
                Match match = regex.Match(Path.GetFileName(file));
                if (match.Success && int.TryParse(match.Groups[1].Value, out int version))
                {
                    maxVersion = Math.Max(maxVersion, version);
                }
            }

            return (maxVersion + 1).ToString();
        }
        public void ProfileLoadData(string profilefilePath, string sheetName)
        {
            using (FileStream file = new FileStream(profilefilePath, FileMode.Open, FileAccess.Read))
            {
                var workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow currentRow = sheet.GetRow(rowIndex);
                    if (currentRow != null)
                    {
                        // Read the key from the first cell
                        string key = currentRow.GetCell(0)?.ToString()?.Trim();

                        // Read the value from the second cell and convert it to a string
                        ICell valueCell = currentRow.GetCell(1);
                        string value = valueCell != null ? ConvertCellToString(valueCell) : string.Empty;

                        if (!string.IsNullOrEmpty(key))
                        {
                            irtestData[key] = value;
                        }
                    }
                }
                workbook.Close(); // Explicitly close the workbook
            }
        }
//************************************************************************************************************************
        public string ConvertCellToString(ICell cell)
        {
            if (cell == null)
                return string.Empty;

            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.StringCellValue.Trim();
                case CellType.Numeric:
                    // Check if the numeric cell contains a date
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        return cell.DateCellValue.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        return cell.NumericCellValue.ToString();
                    }
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Formula:
                    // Use the evaluator to get the formula result as a string
                    return cell.ToString().Trim();
                case CellType.Blank:
                    return string.Empty;
                default:
                    return cell.ToString().Trim();
            }
        }
        public static string GetExcelFilePathWithTimestampAndVersion(string directoryPath, string fileNamePattern)
        {
            // Get all files matching the pattern
            var files = Directory.GetFiles(directoryPath, fileNamePattern);
            if (files.Length == 0)
            {
                throw new FileNotFoundException($"No files found in the directory matching '{fileNamePattern}'.");
            }

            // Sort files by name to get the latest version (assuming versions are formatted sequentially)
            Array.Sort(files, (x, y) => string.Compare(y, x, StringComparison.Ordinal));
            return files[0];
        }
    }
}