using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class DeleteEmployee
    {
        static EmployeeSql employeeSql = new EmployeeSql();
        static DelEmployeeSql delEmployeeSql = new DelEmployeeSql();

        internal static void Delete()
        {
            int deleteId = 0;

            PrintEmployee.PrintAll(employeeSql.TakeDataEmployee());
            while (true)
            {
                if (deleteId == 0)
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeEmployeeId]}: ");
                    try
                    {
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            break;
                        deleteId = 0;
                        continue;
                    }
                    if (!employeeSql.CheckEmployee("id", deleteId))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                delEmployeeSql.TransferDelEmployee(deleteId);
                employeeSql.DeleteEmployee(deleteId);
                Console.WriteLine(Language.SelectLanguage()[ResourceId.deleteEmployeeCompleate]);
                break;
            }
        }
    }
}
