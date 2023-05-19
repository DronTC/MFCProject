using MFCLibrary.Data.resourse;
using MFCLibrary.Menu.Second;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu
{
    internal static class SettingMenu
    {
        static string? temp;
        internal static void Settings()
        {
            Console.WriteLine(Language.SelectLanguage()[ResourceId.titleSetting]);
            while (true)
            {
                Console.WriteLine(Language.SelectLanguage()[ResourceId.salutationSettings]);
                Console.Write($"{Language.SelectLanguage()[ResourceId.choosenAnAction]}: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "0":
                        Console.Clear();
                        MainMenu.Menu();
                        break;
                    case "1":
                        Console.Clear();
                        MenuSettingsThemes.ChangeThemes();
                        break;
                    case "4":
                        Console.Clear();
                        MenuSettingLanguages.settingLanguages();
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }            
        }
    }
}
