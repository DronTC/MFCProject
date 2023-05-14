using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class AddClient
    {
        static private ClientSql clientSql = new ClientSql();
        internal static Client client;

        internal static void Add(bool isAuthorized)
        {
            string fullnameClient = "";
            string passport = "";
            string email = "";

            while (true)
            {
                if (fullnameClient == "")
                {
                    fullnameClient = ReceiveFullName();
                    continue;
                }

                passport = ReceivePassport();
                if (passport == "")
                    return;

                email = ReceiveEmail();
                if (email == "")
                    return;

                break;
            }
            client = new Client(fullnameClient, passport, email);
            clientSql.AddClient(client, isAuthorized);
            Console.WriteLine("Клиент добавлен в базу данных\n");
        }

        private static string ReceiveFullName()
        {
            Console.Write("Введите ФИО клиента: ");
            string fullnameClient = Console.ReadLine();
            return fullnameClient;
        }
        private static string ReceivePassport()
        {
            while (true)
            {
                Console.WriteLine("Введите паспортные данные (формат СССС НННННН, где С – цифры серии, Н – цифры номера паспорта): ");
                Console.Write("Паспорт: ");
                string passport = Console.ReadLine();
                if (passport.Length != 11)
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                if (passport[4] != ' ')
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (i != 3)
                            Convert.ToInt32(passport[i]);
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return "";
                        continue;
                    }
                }
                if (clientSql.CheckClient("passport", passport))
                {
                    Console.WriteLine("Клиент с данными паспортными данными уже числится в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    passport = "";
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                return passport;
            }
        }
        private static string ReceiveEmail()
        {
            while (true)
            {
                Console.Write("Введите адрес электронной почты (формат «username@host.domain»): ");
                string email = Console.ReadLine();

                if (!email.Contains("@"))
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                if (!email.Contains("."))
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                return email;
            }
        }
    }
}
