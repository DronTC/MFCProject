using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal static class ChangeClient
    {
        static ClientSql clientSql = new ClientSql();

        public static void Change()
        {
            int changeId = 0;
            string newPassport = "";

            while (true)
            {
                if (changeId == 0)
                {
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.clients]}: ");
                    PrintClient.PrintAll(clientSql.TakeDataClient());
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeClientId]}: ");
                    try
                    {
                        changeId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (!clientSql.CheckClient("id", changeId))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundClientError]);
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                if(newPassport == "")
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeNewPassport]}: ");
                    newPassport = Console.ReadLine();
                    if (newPassport.Length != 11)
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (newPassport[4] != ' ')
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (i != 3)
                                Convert.ToInt32(newPassport[i]);
                        }
                        catch
                        {
                            Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                            newPassport = "";
                            if (Console.ReadLine() == "...")
                                return;
                            Console.Clear();
                            continue;
                        }
                    }
                    if (clientSql.CheckClient("passport", newPassport))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.errorAddClient]);
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                }
                clientSql.UpdateClient("passport", newPassport, changeId);
                Console.WriteLine(Language.SelectLanguage()[ResourceId.changeClientCompleate]);
                break;
            }
        }
    }
}
