using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal static class ChangeAccount
    {
        internal static void Change()
        {
            AccountSql accountSql = new AccountSql();

            Console.WriteLine($"{Language.SelectLanguage()[ResourceId.newPassword]}: ");
            string password = Console.ReadLine();

            accountSql.UpdateAccount("password", password);
        }
    }
}
