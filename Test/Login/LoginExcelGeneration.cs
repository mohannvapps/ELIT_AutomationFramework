using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.Login
{
    public class LoginExcelGeneration
    {
        [Test]
        public static void GenerateExcelFileTest()
        {
            string basePath = @"D:\1.ELIT_AutomationFramework\Excel\Login_ExcelSheets\LoginTestData.xlsx";
            string pathsFilePath = @"D:\1.ELIT_AutomationFramework\Excel\Login_ExcelSheets\AllLoginExcelPaths.txt";

            ExcelUtility excelUtility = new ExcelUtility();
            string newExcelPath = excelUtility.GenerateLoginExcelTemplate(basePath);

            List<string> paths = new List<string>();
            if (File.Exists(pathsFilePath))
            {
                paths.AddRange(File.ReadAllLines(pathsFilePath));
            }

            paths.Add(newExcelPath);
            File.WriteAllLines(pathsFilePath, paths);

            Console.WriteLine($"Generated Excel file path: {newExcelPath}");
            Console.WriteLine($"Path saved in file: {newExcelPath}");
        }
    }
}
