using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ServicesUseCases
{
    internal static class SearchServicing
    {
        static ClientSql clientSql = new ClientSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ServicingSql servicingSql = new ServicingSql();

        public static void Search()
        {
            string criteria = "";
            string search = "";
            string numberQueue = "";
            int id = 0;
            DateOnly date;

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.searchCriteriaServicing]}: ");
                    Console.Write($"{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                    criteria = Console.ReadLine();
                }
                if (criteria == "1")
                {
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.takeFullname]}: ");
                    search = Console.ReadLine();

                    if (!clientSql.CheckClient("fullnameClient", search))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundClientError]);
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    id = Convert.ToInt32(clientSql.TakeValueClient("id", "fullnameClient", search));
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.services]}:\n");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", id);
                }
                if (criteria == "2")
                {
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.takeFullname]}: ");
                    search = Console.ReadLine();

                    if (!employeeSql.CheckEmployee("fullnameEmployee", search))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    id = Convert.ToInt32(employeeSql.TakeValueEmployee("id", "fullnameEmployee", search));
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.services]}:\n");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "employeeId", id);
                }
                if (criteria == "3")
                {
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.takeDate]}: ");
                    try
                    {
                        date = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takeTicket]}: ");
                    numberQueue = Console.ReadLine();
                    if (numberQueue == "")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (!char.IsLetter(numberQueue[0]))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    for (int i = 1; i < 4; i++)
                    {
                        if (!char.IsDigit(numberQueue[i]))
                        {
                            Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                            if (Console.ReadLine() == "...")
                                return;
                            continue;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.services]}:\n");
                    Print(servicingSql.TakeDataServicing(), Convert.ToString(date), numberQueue);
                }
                if (criteria == "")
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return;
                    Console.Clear();
                    continue;
                }
                break;
            }
        }

        private static void Print(List<string[]> lists, string date, string numberQueue)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (list[2] == date && list[6] == numberQueue)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                }
            }
        }
    }
}
