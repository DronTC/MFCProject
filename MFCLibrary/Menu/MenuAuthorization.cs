using MFCLibrary.Data;
using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
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
                json.Change(1, -1, "ru");
            }

            string language = json.Take("language");

            

            int theme = Convert.ToInt32(json.Take("themeId"));

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
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.firstEntry]);
                    json.Change("accountId", Convert.ToString(AddAccount.Add()));
                }
                json.Change("accountId", Convert.ToString(CheckAccount.Check()));
                MainMenu.Menu();
            }
        }
    }
}
