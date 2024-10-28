using ELIT_AutomationFramework.Utilities;
using NUnit.Framework;

namespace ELIT_AutomationFramework.Test.PR
{
    public class A_PR_ExcelGeneration
    {
        [Test]
        public static void Generate_PR_Excel()
        {
            string basePath = @"D:\1.ELIT_AutomationFramework\Excel\PR_ExcelSheets\PRTestData.xlsx";
            string pathsFilePath = @"D:\1.ELIT_AutomationFramework\Excel\PR_ExcelSheets\AllPRExcelPaths.txt";

            ExcelUtility excelUtility = new ExcelUtility();
            string newExcelPath = excelUtility.GeneratePRExcelTemplate(basePath);

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
