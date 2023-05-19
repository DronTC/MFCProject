using MFCLibrary.Data.resourse;
using MFCLibrary.Menu.Second;
using MFCLibrary.useCases.ClientUseCases;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.ServicesUseCases;
using MFCLibrary.useCases.ServiceUseCases;
using MFCLibrary.useCases.ServicingUseCases;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu
{
    internal static class MainMenu
    {
        static string? temp;
        internal static void Menu()
        {
            Console.WriteLine(Language.SelectLanguage()[ResourceId.welcome]);
            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.salutation]);
                Console.Write($"{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        Console.Clear();
                        AddEmployee.Add();
                        break;
                    case "2":
                        Console.Clear();
                        MenuAddClient.Menu();
                        break;
                    case "3":
                        Console.Clear();
                        AddService.Add();
                        break;
                    case "4":
                        Console.Clear();
                        MenuAddServicing.Menu();
                        break;
                    case "5":
                        Console.Clear();
                        ChangeEmployee.Change();
                        break;
                    case "6":
                        Console.Clear();
                        ChangeClient.Change();
                        break;
                    case "7":
                        Console.Clear();
                        SearchClient.Search();
                        break;
                    case "8":
                        Console.Clear();
                        SearchServicing.Search();
                        break;
                    case "9":
                        Console.Clear();
                        ViewServicingStatistics.ServicingStatistics();
                        break;
                    case "10":
                        Console.Clear();
                        DeleteEmployee.Delete();
                        break;
                    case "11":
                        Console.Clear();
                        DeleteService.Delete();
                        break;
                    case "12":
                        Console.Clear();
                        SettingMenu.Settings();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
