﻿

using MFCLibrary.DataBase.SqlActions;

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
            DateOnly dateOne;
            DateOnly dateTwo;

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine("Варианты поиска:\n1.Дата\n2.Диапазон дат\n3.Вся статистика");
                    Console.Write("\nВыберите критерий: ");
                    criteria = Console.ReadLine();
                }
                if (criteria == "1")
                {
                    Console.Write("\nВведите дату (формат ДД.ММ.ГГГГ): ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания обычных пользователей:\n");
                    PrintByDate(servicingSql.TakeDataServicing(), dateOne);
                    Console.WriteLine("Статистика обслуживания верифицированных пользователей (ГосУслуги):\n");
                    PrintByDate(authorizedServicingSql.TakeDataAuthorizedServicing(), dateOne);

                }
                if (criteria == "2")
                {
                    Console.WriteLine("\nВведите даты (формат ДД.ММ.ГГГГ): ");
                    Console.Write("От: ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Write("До: ");
                    try
                    {
                        dateTwo = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания обычных пользователей:\n");
                    PrintByRangeDate(servicingSql.TakeDataServicing(), dateOne, dateTwo);
                    Console.WriteLine("Статистика обслуживания верифицированных пользователей (ГосУслуги):\n");
                    PrintByRangeDate(authorizedServicingSql.TakeDataAuthorizedServicing(), dateOne, dateTwo);
                }
                if (criteria == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания обычных пользователей:\n");
                    PrintAllServicing(servicingSql.TakeDataServicing());
                    Console.WriteLine("Статистика обслуживания верифицированных пользователей (ГосУслуги):\n");
                    PrintAllServicing(authorizedServicingSql.TakeDataAuthorizedServicing());
                }
                break;
            }
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
                        Console.WriteLine($"{list[3]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if(list.Length == 8)
                {
                    if (DateOnly.Parse(list[2]) == date)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
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
                        Console.WriteLine($"{list[2]} {list[3]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if (list.Length == 8)
                {
                    if (DateOnly.Parse(list[2]) >= dateOne && DateOnly.Parse(list[2]) <= dateTwo)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
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
                    Console.WriteLine($"{list[2]} {list[3]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                    count++;
                }
                else if (list.Length == 8)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                    count++;
                }
            }
            Console.WriteLine($"Всего: {count}\n");
        }
    }
}
