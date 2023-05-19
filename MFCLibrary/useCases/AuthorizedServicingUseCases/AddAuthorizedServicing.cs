using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.AuthorizedServicingUseCases
{
    internal static class AddAuthorizedServicing
    {
        static AuthorizedServicingSql authorizedServicingSql = new AuthorizedServicingSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ServiceSql serviceSql = new ServiceSql();
        static ClientSql clientSql = new ClientSql();

        internal static void Add()
        {
            int employeeId;
            string windowNumber;
            DateOnly date;
            TimeOnly time;
            string serviceName;
            int serviceId;
            int clientId;

            while (true)
            {
                //Получение номера окна обслуживания
                windowNumber = ReceiveWindowNumber();
                if (windowNumber == "")
                    return;

                //Получение ID сотрудника
                employeeId = Convert.ToInt32(employeeSql.TakeValueEmployee("id", "windowNumber", windowNumber));

                //Получение текущих даты и времени
                date = ReceiveDate();
                Console.WriteLine(date);
                if (date == new DateOnly())
                    return;
                time = ReceiveTime();
                if (Convert.ToString(time) == "0:00")
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
                break;
            }
            AuthorizedServicing authorizedServicing = new AuthorizedServicing(employeeId, windowNumber, DateTime.Parse($"{date} {time}"), serviceName, clientId);
            authorizedServicingSql.AddAuthorizedServicing(authorizedServicing);
            serviceSql.UpdateService("isUse", true, serviceId);
            Console.WriteLine(Language.SelectLanguage()[ResourceId.addOperationServicing]);
        }


        //Получение номера окна обслуживания
        private static string ReceiveWindowNumber()
        {
            string windowNumber;

            while (true)
            {
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeWindowNumber]}: ");
                windowNumber = Console.ReadLine();
                try
                {
                    if (char.IsDigit(windowNumber[0]))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return "";
                        Console.Clear();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return "";
                    Console.Clear();
                    continue;
                }
                if (!employeeSql.CheckEmployee("windowNumber", windowNumber))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.foundEmployeeError]);
                    if (Console.ReadLine() == "...")
                        return "";
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return windowNumber;
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
        //Получение ID клиента
        private static int ReceiveClientId()
        {
            int clientId;

            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.clients]}: ");
                PrintClient.PrintSpecial(clientSql.TakeDataClient());
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
                if (!Convert.ToBoolean(clientSql.TakeValueClient("isAuthorized", "id", clientId)))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.erorTypeClient]);
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return clientId;
            }
        }
        private static DateOnly ReceiveDate()
        {
            DateOnly date;
            string check;

            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.solutationTypeDate]);
                check = Console.ReadLine();
                if(check == "1")
                    date = DateOnly.FromDateTime(DateTime.Now);
                else if(check == "2")
                {
                    try
                    {
                        Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takeDate]}: ");
                        date = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return new DateOnly();
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.actionErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return new DateOnly();
                    Console.Clear();
                    continue;
                }
                if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.dateError]);
                    if (Console.ReadLine() == "...")
                        return new DateOnly();
                    Console.Clear();
                    continue;
                }
                return date;
            }
        }
        private static TimeOnly ReceiveTime()
        {
            TimeOnly time;

            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takeTime]}: ");
                Console.Write("Время: ");
                try
                {
                    time = TimeOnly.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;

                }
                if (time.Hour < 9 || time.Hour > 19)
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;
                }
                if (time.Minute % 15 != 0)
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;
                }
                if(authorizedServicingSql.CheckAuthorizedServicing("date", Convert.ToString(DateOnly.FromDateTime(DateTime.Now))))
                {
                    if(authorizedServicingSql.CheckAuthorizedServicing("time", Convert.ToString(time)))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.errorTakeTime]);
                        if (Console.ReadLine() == "...")
                            return TimeOnly.Parse("0:00");
                        Console.Clear();
                        continue;
                    }
                }
                Console.Clear();
                return time;
            }
        }
    }
}
