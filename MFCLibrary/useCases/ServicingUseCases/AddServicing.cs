using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;
using System;

namespace MFCLibrary.useCases.ServicesUseCases
{
    internal class AddServicing
    {
        static private ServicingSql servicingSql = new ServicingSql();
        static private ClientSql clientSql = new ClientSql();
        static private EmployeeSql employeeSql = new EmployeeSql();
        static private ServiceSql serviceSql = new ServiceSql();
        static private Servicing? servicing;

        internal static void Add()
        {
            int employeeId;
            int windowNumber;
            DateTime dateTime;
            string serviceName;
            int serviceId;
            int clientId;
            string numberQueue;

            //Получение Id сотрудника
            employeeId = ReceiveEmployeeId();
            if (employeeId == 0)
                return;

            //Получение номера окна
            windowNumber = Convert.ToInt32(employeeSql.TakeValueEmployee("windowNumber", "id", employeeId));

            //Получение текущих даты и времени
            dateTime = ReceiveDateTime();
            if (dateTime == new DateTime())
                return;

            //Получение ID услуги
            serviceId = ReceiveServiceId();
            if (serviceId == 0)
                return;
            serviceName = serviceSql.TakeValueService("name", "id", serviceId);

            //Получение Id клиента
            clientId = ReceiveClientId();
            if (clientId == 0)
                return;

            //Создание номера талона
            numberQueue = CreateNumberQueue(serviceName);

            servicing = new Servicing(employeeId, Convert.ToString(windowNumber), dateTime, serviceName, clientId, numberQueue);
            servicingSql.AddServicing(servicing);
            serviceSql.UpdateService("isUse", true, serviceId);
            Console.WriteLine(Language.SelectLanguage()[ResourceId.addServicingCompleate]);
        }
        //Получение ID сотрудника
        private static int ReceiveEmployeeId()
        {
            int employeeId;

            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.employees]}:");
                PrintEmployee.PrintOrdinary(employeeSql.TakeDataEmployee());
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeEmployeeId]}: ");
                try
                {
                    employeeId = Convert.ToInt32(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!employeeSql.CheckEmployee("id", employeeId))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return employeeId;
            }
        }
        //Получение ID услуги
        private static int ReceiveServiceId()
        {
            int serviceId;

            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.services]}: ");
                PrintService.Print(serviceSql.TakeDataService());
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeServiceId]}: ");
                try
                {
                    serviceId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!serviceSql.CheckService("id", serviceId))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.foundServiceError]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return serviceId;
            }
        }
        private static DateTime ReceiveDateTime()
        {
            DateOnly date;
            TimeOnly time;
            string check;
            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.salutationDateTime]);
                check = Console.ReadLine();
                if (check == "1")
                {
                    date = DateOnly.FromDateTime(DateTime.Now);
                    time = TimeOnly.FromDateTime(DateTime.Now);
                }
                else if(check == "2")
                {
                    try
                    {
                        Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takeDate]}: ");
                        date = DateOnly.Parse(Console.ReadLine());
                        Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takeUsualTime]}: ");
                        time = TimeOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return new DateTime();
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.actionErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return new DateTime();
                    Console.Clear();
                    continue;
                }
                if((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.dateError]);
                    if (Console.ReadLine() == "...")
                        return new DateTime();
                    Console.Clear();
                    continue;

                }
                if (time.Hour < 9 || time.Hour > 19)
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.timeError]);
                    if (Console.ReadLine() == "...")
                        return new DateTime();
                    Console.Clear();
                    continue;
                }
                return DateTime.Parse($"{date} {time}");
            }
        }
        //Получение ID клиента
        private static int ReceiveClientId()
        {
            int clientId;

            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.clients]}: ");
                PrintClient.PrintOrdinary(clientSql.TakeDataClient());
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeClientId]}: ");
                try
                {
                    clientId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!clientSql.CheckClient("id", clientId))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.foundClientError]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return clientId;
            }
        }
        //Создание номера талона
        private static string CreateNumberQueue(string serviceName)
        {
            string numberQueue = "";
            int num = 1;
            
            foreach (string date in servicingSql.TakeRowServicing("date"))
            {
                if (DateOnly.Parse(date) == DateOnly.FromDateTime(DateTime.Now))
                    num++;
            }
            numberQueue += serviceName[0];
            numberQueue += string.Format("{0:000}", num);
            return numberQueue;
        }
    }
}
