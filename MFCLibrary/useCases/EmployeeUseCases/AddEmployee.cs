using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class AddEmployee
    {
        static private EmployeeSql employeeSql = new EmployeeSql();
        static private Employee? employee;

        internal static void Add()
        {
            string fullnameEmployee = "";
            int windowNumber = 0;
            DateOnly birthday = new DateOnly();

            while (true)
            {
                if (fullnameEmployee == "")
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeFullname]}: ");
                    fullnameEmployee = Console.ReadLine();
                    continue;
                }

                if (birthday == DateOnly.Parse("01.01.0001"))
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeBirthday]}: ");
                    try
                    {
                        birthday = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                if (windowNumber == 0)
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeWindow]}: ");
                    try
                    {
                        windowNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (windowNumber < 1 || windowNumber > 23)
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (employeeSql.CheckEmployee("windowNumber", Convert.ToString(windowNumber)))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.errorTakeWindow]);
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                break;
            }
            if(windowNumber >= 21 && windowNumber <= 23)
                employee = new Employee(fullnameEmployee, birthday, "Г" + Convert.ToString(windowNumber));
            else
                employee = new Employee(fullnameEmployee, birthday, Convert.ToString(windowNumber));
            employeeSql.AddEmployee(employee);
            Console.WriteLine(Language.SelectLanguage()[ResourceId.addEmployee]);
        }
    }
}
