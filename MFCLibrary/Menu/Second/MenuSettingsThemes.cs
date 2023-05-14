using MFCLibrary.Data;
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
            Console.WriteLine("Настройки, выбор темы.");
            while (true)
            {
                Console.WriteLine("1. Стандартная(Ч/Б)\n" +
                "2. Токсичная(З/Б)\n" +
                "3. Токсичная2(ТЗ/С)\n" +
                "4. Жёлтая(ТЖ/ТС)\n" +
                "0. Назад");
                Console.Write("Выбор действия: ");
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
                        json.Change("themeId", 1);
                        break;
                    case "2":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme2);
                        json.Change("themeId", 2);
                        break;
                    case "3":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme3);
                        json.Change("themeId", 3);
                        break;
                    case "4":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme4);
                        json.Change("themeId", 4);
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
