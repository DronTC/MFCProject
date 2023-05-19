using MFCLibrary.Data.resourse;
using MFCLibrary.useCases.ClientUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu.Second
{
    internal static class MenuAddClient
    {
        internal static void Menu()
        {
            string temp = "";

            Console.WriteLine(Language.SelectLanguage()[ResourceId.solutationTypeClient]);
            while (true)
            {
                Console.Write(Language.SelectLanguage()[ResourceId.choosenAnAction]);
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Clear();
                    AddClient.Add(false);
                }
                else if (temp == "2")
                {
                    Console.Clear();
                    AddClient.Add(true);
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
