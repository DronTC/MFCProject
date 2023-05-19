using MFCLibrary.Data.Models;
using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal static class AddAccount
    {
        static Account account;
        static AccountSql accountSql = new AccountSql();

        internal static int Add()
        {
            string login, password;

            Console.Write($"{Language.SelectLanguage()[ResourceId.login]}: ");
            login = Console.ReadLine();
            Console.Write($"{Language.SelectLanguage()[ResourceId.password]}: ");
            password = Console.ReadLine();

            account = new Account(login, password);
            accountSql.AddAccount(account);
            Console.WriteLine(Language.SelectLanguage()[ResourceId.createNewAccount]);
            Console.ReadLine();
            Console.Clear();
            return Convert.ToInt32(accountSql.TakeValueAccount("id", "login", login));
        }
    }
}
