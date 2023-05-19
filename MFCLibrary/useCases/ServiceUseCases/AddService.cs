using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.DataBase;
using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.ServiceUseCases
{
    internal class AddService
    {
        static private ServiceSql serviceSql { get; } = new ServiceSql();
        static private Service? service;

        internal static void Add()
        {
            string name = "";

            while (true)
            {
                Console.Write($"{Language.SelectLanguage()[ResourceId.takeNameService]}: ");
                name = Console.ReadLine();
                if (name is null || name == "")
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
            service = new Service(name);
            serviceSql.AddService(service);
            Console.WriteLine(Language.SelectLanguage()[ResourceId.addServiceCompleate]);
            
        }
    }
}
