using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.AccountUseCases;

namespace MFCLibrary.Menu.Second
{
    internal static class MenuAuthorization
    {
        static AccountSql accountSql = new AccountSql();
        internal static void Menu()
        {

            while (true)
            {
                if (accountSql.TakeDataAccount().Count == 0)
                {
                    Console.WriteLine("Это ваш первый заход в приложение. Необходимо создать аккаунт.");
                    AddAccount.Add();
                }
                CheckAccount.Check();
                break;
            }
        }
    }
}
