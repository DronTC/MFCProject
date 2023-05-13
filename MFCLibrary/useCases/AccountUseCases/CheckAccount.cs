using MFCLibrary.DataBase.SqlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal class CheckAccount
    {
        internal static AccountSql accountSql= new AccountSql();
        internal static void Check()
        {
            string login, password;
            while(true)
            {
                Console.WriteLine("Логин: ");
                login = Console.ReadLine();
                Console.WriteLine("Пароль: ");
                password = Console.ReadLine();

                if (accountSql.CheckAccount(login, password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль. Попробуйте ввести снова.");
                    continue;
                }
                break;
            }
        }
    }
}
