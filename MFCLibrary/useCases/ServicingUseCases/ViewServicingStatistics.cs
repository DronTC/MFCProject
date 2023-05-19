using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;
using System;

namespace MFCLibrary.useCases.ServicingUseCases
{
    internal static class ViewServicingStatistics
    {
        static AuthorizedServicingSql authorizedServicingSql = new AuthorizedServicingSql();
        static ServicingSql servicingSql = new ServicingSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ClientSql clientSql = new ClientSql();

        public static void ServicingStatistics()
        {
            string criteria = "";
            string windowNumber = "";
            DateOnly dateOne;
            DateOnly dateTwo;
           

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.variantsSearchServicing]);
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                    criteria = Console.ReadLine();
                }
                if (criteria == "1")
                {
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.takeDate]}: ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticUsualClients]}:\n");
                    PrintByDate(servicingSql.TakeDataServicing(), dateOne);
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticAuthorizedClients]}:\n");
                    PrintByDate(authorizedServicingSql.TakeDataAuthorizedServicing(), dateOne);

                }
                if (criteria == "2")
                {
                    Console.WriteLine($"\n{Language.SelectLanguage()[ResourceId.takeDate]}: ");
                    Console.Write($"{Language.SelectLanguage()[ResourceId.from]}: ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Write($"{Language.SelectLanguage()[ResourceId.before]}: ");
                    try
                    {
                        dateTwo = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticUsualClients]}:\n");
                    PrintByRangeDate(servicingSql.TakeDataServicing(), dateOne, dateTwo);
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticAuthorizedClients]}:\n");
                    PrintByRangeDate(authorizedServicingSql.TakeDataAuthorizedServicing(), dateOne, dateTwo);
                }
                if (criteria == "3")
                {
                    Console.Clear();
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeWindow]}: ");
                    windowNumber = Console.ReadLine();

                    if(!employeeSql.CheckEmployee("windowNumber", windowNumber))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    int employeeId = Convert.ToInt32(employeeSql.TakeValueEmployee("id", "windowNumber", windowNumber));
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticWindow]} {windowNumber}:\n");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "employeeId", employeeId);
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.averageLoad]}: ");
                    PrintWindowStatistic(windowNumber);
                }
                if (criteria == "4")
                {
                    Console.Clear();
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticUsualClients]}:\n");
                    PrintAllServicing(servicingSql.TakeDataServicing());
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.statisticAuthorizedClients]}:\n");
                    PrintAllServicing(authorizedServicingSql.TakeDataAuthorizedServicing());
                }
                break;
            }
        }

        private static void PrintWindowStatistic(string windowNumber)
        {
            List<DateTime> dateTimes = TakeDateTime(windowNumber);

            var avgPerHour = AverageLoadPerInterval(dateTimes, TimeSpan.FromHours(1));
            var avgPerDay = AverageLoadPerInterval(dateTimes, TimeSpan.FromDays(1));
            var avgPerWeek = AverageLoadPerInterval(dateTimes, TimeSpan.FromDays(7));
            var avgPerMonth = AverageLoadPerInterval(dateTimes, TimeSpan.FromDays(30));
            var avgPerYear = AverageLoadPerInterval(dateTimes, TimeSpan.FromDays(365));

            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.perHour]}: {Math.Round(avgPerHour, 3)}");
            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.perDay]}: {Math.Round(avgPerDay, 3)}");
            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.perWeek]}: {Math.Round(avgPerWeek, 3)}");
            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.perMonth]}: {Math.Round(avgPerMonth, 3)}");
            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.perYear]}: {Math.Round(avgPerYear, 3)}");

        }
        static double AverageLoadPerInterval(List<DateTime> serviceTimes, TimeSpan interval)
        {
            var groups = serviceTimes.GroupBy(dt => RoundDown(dt, interval));
            var loads = groups.Select(g => g.Count());
            var avgLoad = loads.Average();
            return avgLoad;
        }
        static DateTime RoundDown(DateTime dt, TimeSpan interval)
        {
            return new DateTime(dt.Ticks / interval.Ticks * interval.Ticks, dt.Kind);
        }
        private static List<DateTime> TakeDateTime(string windowNumber)
        {
            List<string[]> lists = new List<string[]>(); 
            List<DateTime> dateTimes = new List<DateTime>();

            if (!windowNumber.Contains("Г"))
                lists = servicingSql.TakeDataServicing();

            else
                lists = authorizedServicingSql.TakeDataAuthorizedServicing();

            foreach (var list in lists)
            {
                dateTimes.Add(DateTime.Parse($"{list[2]} {list[3]}"));
            }
            return dateTimes;
        }
        private static void PrintByDate(List<string[]> lists, DateOnly date)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (list.Length == 7)
                {
                    if (DateOnly.Parse(list[2]) == date)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[3]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if(list.Length == 8)
                {
                    if (DateOnly.Parse(list[2]) == date)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
            }
        }
        private static void PrintByRangeDate(List<string[]> lists, DateOnly dateOne, DateOnly dateTwo)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (list.Length == 7)
                {
                    if (DateOnly.Parse(list[2]) >= dateOne && DateOnly.Parse(list[2]) <= dateTwo)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if (list.Length == 8)
                {
                    if (DateOnly.Parse(list[2]) >= dateOne && DateOnly.Parse(list[2]) <= dateTwo)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
            }
        }
        private static void PrintAllServicing(List<string[]> lists)
        {
            string fullnameEmployee;
            string fullnameClient;
            int count = 0;
            foreach (string[] list in lists)
            {
                if(list.Length == 7)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                    count++;
                }
                else if (list.Length == 8)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| {Language.SelectLanguage()[ResourceId.ticket]}: {list[6]}| {Language.SelectLanguage()[ResourceId.service]}: {list[4]}| {Language.SelectLanguage()[ResourceId.window]}: {list[1]}| {Language.SelectLanguage()[ResourceId.employee]}: {fullnameEmployee}({list[0]})| {Language.SelectLanguage()[ResourceId.client]}: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                    count++;
                }
            }
            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.inTotal]}: {count}\n");
        }
    }
}
