using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.Menu.Second
{
    internal class MenuAuthorization
    {
        internal static void Menu()
        {
            AccountSql accountSql = new AccountSql();
            Account account = new Account(0, "MasterAccount", "1234");
            accountSql.AddAccount(account);

            while (true)
            {

            }
        }
    }
}
