using MFCLibrary.Data;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.Json;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using MFCLibrary.useCases.AccountUseCases;
using Newtonsoft.Json.Linq;

namespace MFCLibrary.Menu
{
    public static class MenuAuthorization
    {
        static AccountSql accountSql = new AccountSql();
        static JsonActions json = new JsonActions();
        public static void Menu()
        {
            if (!File.Exists(json.JsonFileName))
            {
                json.Change(1, -1);
            }

            int theme = json.Take("themeId");

            switch (theme)
            {
                case 1:
                    Console.Clear();
                    ChangeTheme.Theme(Themes.theme1);
                    break;
                case 2:
                    Console.Clear();
                    ChangeTheme.Theme(Themes.theme2);
                    break;
                case 3:
                    Console.Clear();
                    ChangeTheme.Theme(Themes.theme3);
                    break;
                case 4:
                    Console.Clear();
                    ChangeTheme.Theme(Themes.theme4);
                    break;
            }
            while (true)
            {
                if (accountSql.TakeDataAccount().Count == 0)
                {
                    Console.WriteLine("Это ваш первый заход в приложение. Необходимо создать аккаунт.");
                    json.Change("accountId", AddAccount.Add());
                }
                json.Change("accountId", CheckAccount.Check());
                MainMenu.Menu();
            }
        }
    }
}
