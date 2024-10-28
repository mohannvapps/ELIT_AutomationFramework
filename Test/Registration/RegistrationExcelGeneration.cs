using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.Registration
{
    public class A_RegistrationExcelGeneration
    {
        [Test]
        public static void GenerateExcel()
        {
            string basePath = @"D:\1.ELIT_AutomationFramework\Excel\Registration_ExcelSheets\RegistrationTestData.xlsx";
            string pathsFilePath = @"D:\1.ELIT_AutomationFramework\Excel\Registration_ExcelSheets\AllRegistrationExcelPaths.txt";

            ExcelUtility excelUtility = new ExcelUtility();
            string newExcelPath = excelUtility.GenerateRegistrationExcelTemplate(basePath);

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