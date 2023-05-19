using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ServiceUseCases
{
    internal static class DeleteService
    {
        static private ServiceSql serviceSql = new ServiceSql();

        internal static void Delete()
        {
            int deleteId = 0;

            PrintService.Print(serviceSql.TakeDataService());
            while (true)
            {
                if (deleteId == 0)
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.takeServiceId]}: ");
                    try
                    {
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (!serviceSql.CheckService("id", deleteId))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.foundServiceError]);
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (Convert.ToBoolean(serviceSql.TakeValueService("isUse", "id", deleteId)))
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.deleteServiceError]);
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                serviceSql.DeleteService(deleteId);
                Console.WriteLine(Language.SelectLanguage()[ResourceId.deleteServiceCompleate]);
                break;
            }
        }
    }
}
