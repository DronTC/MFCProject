using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.Unique
{
    internal static class PrintServicing
    {
        static EmployeeSql employeeSql = new EmployeeSql();
        static ClientSql clientSql = new ClientSql();

        static string fullnameEmployee = "";
        static string fullnameClient = "";
        internal static void Print(List<string[]> lists, string row, int id)
        {
            foreach (string[] list in lists)
            {
                if (row == "employeeId")
                {
                    if (Convert.ToInt32(list[0]) == id)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if (row == "clientId")
                {
                    if (Convert.ToInt32(list[5]) == id)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
            }
        }
        internal static void Print(string[] list)
        {
            fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
            fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
            Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
            Console.WriteLine("==========================================");
        }
    }
}
