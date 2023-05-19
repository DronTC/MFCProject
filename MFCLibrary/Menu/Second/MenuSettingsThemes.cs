using MFCLibrary.Data;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.Json;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu.Second
{
    internal class MenuSettingsThemes
    {
        static JsonActions json = new JsonActions();
        static string? temp;

        internal static void ChangeThemes()
        {
            Console.WriteLine(Language.SelectLanguage()[ResourceId.titleSettingThemes]);
            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.salutationThemes]);
                Console.Write($"{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "0":
                        Console.Clear();
                        SettingMenu.Settings();
                        break;
                    case "1":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme1);
                        json.Change("themeId", Convert.ToString(1));
                        break;
                    case "2":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme2);
                        json.Change("themeId", Convert.ToString(2));
                        break;
                    case "3":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme3);
                        json.Change("themeId", Convert.ToString(3));
                        break;
                    case "4":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme4);
                        json.Change("themeId", Convert.ToString(4));
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
