using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.IR
{
    public class A_IR_ExcelGeneration
    {
        [Test]
        public static void Generate_IR_Excel()
        {
            string basePath = @"D:\1.ELIT_AutomationFramework\Excel\IR_ExcelSheets\IRTestData.xlsx";
            string pathsFilePath = @"D:\1.ELIT_AutomationFramework\Excel\IR_ExcelSheets\AllIRExcelPaths.txt";

            ExcelUtility excelUtility = new ExcelUtility();
            string newExcelPath = excelUtility.GenerateIRExcelTemplate(basePath);

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
