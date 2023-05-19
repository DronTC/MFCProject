

using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class ChangeEmployee
    {
        static EmployeeSql employeeSql = new EmployeeSql();

        public static void Change()
        {
            int changeId = 0;
            string newWindowNumber = "";

            PrintEmployee.PrintAll(employeeSql.TakeDataEmployee());
            while (true)
            {
                if (changeId == 0)
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeEmployeeId]}: ");
                    try
                    {
                        changeId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            break;
                        Console.Clear();
                        continue;
                    }
                    if (!employeeSql.CheckEmployee("id", changeId))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                if (newWindowNumber == "")
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeWindow]}: ");
                    newWindowNumber = Console.ReadLine();
                    if (Convert.ToInt32(newWindowNumber) < 1 || Convert.ToInt32(newWindowNumber) > 23)
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            break;
                        newWindowNumber = "";
                        Console.Clear();
                        continue;
                    }
                    if (employeeSql.CheckEmployee("windowNumber", newWindowNumber))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.errorTakeWindow]);
                        newWindowNumber = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                }
                if (Convert.ToInt32(newWindowNumber) >= 21 && Convert.ToInt32(newWindowNumber) <= 23)
                    newWindowNumber = "Г" + newWindowNumber;
                employeeSql.UpdateEmployee("windowNumber", newWindowNumber, changeId);
                Console.WriteLine(Language.SelectLanguage()[ResourceId.changeEmployeeCompleate]);
                break;
            }
        }
    }
}
