using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal static class AddAccount
    {
        static Account account;
        static AccountSql accountSql = new AccountSql();

        internal static int Add()
        {
            string login, password;

            Console.Write("Логин: ");
            login = Console.ReadLine();
            Console.Write("Пароль: ");
            password = Console.ReadLine();

            account = new Account(login, password);
            accountSql.AddAccount(account);
            Console.WriteLine("Создан новый аккаунт");
            Console.ReadLine();
            Console.Clear();
            return Convert.ToInt32(accountSql.TakeValueAccount("id", "login", login));
        }
    }
}
