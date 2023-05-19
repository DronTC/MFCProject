
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class SearchClient
    {
        static ClientSql clientSql = new ClientSql();
        static AuthorizedServicingSql authorizedServicingSql = new AuthorizedServicingSql();
        static ServicingSql servicingSql = new ServicingSql();

        public static void Search()
        {
            string criteria = "";
            string search = "";
            int clientId = 0;

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.searchCriteria]}: ");
                    Console.Write($"\n{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                    criteria = Console.ReadLine();
                    Console.Clear();
                }
                if (criteria == "1")
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeFullname]}: ");
                    search = Console.ReadLine();

                    if (!clientSql.CheckClient("fullnameClient", search))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundClientError]);
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputError]);
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "fullnameClient", search));
                }
                if (criteria == "2")
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takePassport]}: ");
                    search = Console.ReadLine();
                    if (!clientSql.CheckClient("passport", search))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundClientError]);
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputError]);
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "passport", search));
                    Console.Clear();
                }
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.clientData]}:");
                PrintClient.PrintById(clientSql.TakeDataClient(), clientId);
                Console.WriteLine($"{Language.SelectLanguage()[ResourceId.renderedServices]}: ");
                if (!Convert.ToBoolean(clientSql.TakeValueClient("isAuthorized", "id", clientId)))
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", clientId);
                else
                    PrintAutorizedServicing.Print(authorizedServicingSql.TakeDataAuthorizedServicing(), "clientId", clientId);
                break;
            }
        }
    }
}
