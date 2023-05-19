using MFCLibrary.Data.resourse;
using MFCLibrary.useCases.AuthorizedServicingUseCases;
using MFCLibrary.useCases.ClientUseCases;
using MFCLibrary.useCases.ServicesUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu.Second
{
    internal class MenuAddServicing
    {
        internal static void Menu()
        {
            string temp = "";

            Console.WriteLine(Language.SelectLanguage()[ResourceId.solutationTypeClient]);
            while (true)
            {
                Console.Write("Выберите тип: ");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Clear();
                    AddServicing.Add();
                }
                else if (temp == "2")
                {
                    Console.Clear();
                    AddAuthorizedServicing.Add();
                }
                else
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
        }
    }
}
