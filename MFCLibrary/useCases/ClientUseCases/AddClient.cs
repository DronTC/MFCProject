using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;

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
            Console.WriteLine(Language.SelectLanguage()[ResourceId.addClient]);
        }

        private static string ReceiveFullName()
        {
            Console.Write($"{Language.SelectLanguage()[ResourceId.takeFullname]}: ");
            string fullnameClient = Console.ReadLine();
            return fullnameClient;
        }
        private static string ReceivePassport()
        {
            while (true)
            {
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.takePassport]}: ");
                Console.Write("Паспорт: ");
                string passport = Console.ReadLine();
                if (passport.Length != 11)
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                if (passport[4] != ' ')
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
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
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        if (Console.ReadLine() == "...")
                            return "";
                        continue;
                    }
                }
                if (clientSql.CheckClient("passport", passport))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.errorAddClient]);
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
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeEmail]}: ");
                string email = Console.ReadLine();

                if (!email.Contains("@"))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                if (!email.Contains("."))
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return "";
                    continue;
                }
                return email;
            }
        }
    }
}
