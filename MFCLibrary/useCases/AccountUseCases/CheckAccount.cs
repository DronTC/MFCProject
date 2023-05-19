using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.Json;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal class CheckAccount
    {
        internal static AccountSql accountSql= new AccountSql();
        static JsonActions json = new JsonActions();
        internal static int Check()
        {
            string login, password;
            int lastId = Convert.ToInt32(json.Take("accountId"));

            while (true)
            {
                if (lastId != -1)
                {
                    login = accountSql.TakeValueAccount("login", "id", lastId);
                    Console.WriteLine($"{Language.SelectLanguage()[ResourceId.login]}: {login}");
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.questionAboutAccount]);
                    string temp = Console.ReadLine();
                    if (temp == "2")
                    {
                        Console.Clear();
                        Console.WriteLine($"{Language.SelectLanguage()[ResourceId.login]}: ");
                        login = Console.ReadLine();
                    }
                    else if (temp != "1")
                    {
                        Console.WriteLine(Language.SelectLanguage()[ResourceId.actionError]);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Write($"{Language.SelectLanguage()[ResourceId.login]}: ");
                    login = Console.ReadLine();
                }
                Console.Write($"{Language.SelectLanguage()[ResourceId.password]}: ");
                password = Console.ReadLine();

                if (accountSql.CheckAccount(login, password))
                {
                    Console.Clear();
                    return Convert.ToInt32(accountSql.TakeValueAccount("id", "login", login));
                }
                else
                {
                    Console.WriteLine(Language.SelectLanguage()[ResourceId.inputError]);
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
