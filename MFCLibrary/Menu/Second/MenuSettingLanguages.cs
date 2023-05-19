using MFCLibrary.Data.resourse;
using MFCLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Menu.Second
{
    internal class MenuSettingLanguages
    {
        internal static void settingLanguages()
        {
            string temp;
            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.salutationLanguage]);
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        ChangeLanguage.IntToLanguageState(1);
                        Console.Clear();
                        return;
                    case "2":
                        ChangeLanguage.IntToLanguageState(2);
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.inputErrorTwo]);
                        break;
                }

                temp = Console.ReadLine();
                if (temp == "...")
                    break;
                Console.Clear();
            }
        }
    }
}
