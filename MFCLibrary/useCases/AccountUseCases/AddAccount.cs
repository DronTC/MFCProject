using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal static class AddAccount
    {
        static Account account;
        static AccountSql accountSql = new AccountSql();

        internal static void Add()
        {
            string login, password;

            Console.WriteLine("Логин: ");
            login = Console.ReadLine();
            Console.WriteLine("Пароль: ");
            password = Console.ReadLine();

            account = new Account(login, password);
            accountSql.AddAccount(account);
            Console.WriteLine("Создан новый аккаунт");
        }
    }
}
