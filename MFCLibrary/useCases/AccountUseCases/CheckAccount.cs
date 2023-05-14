using MFCLibrary.DataBase.Json;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.AccountUseCases
{
    internal class CheckAccount
    {
        internal static AccountSql accountSql= new AccountSql();
        static JsonActions json = new JsonActions();
        internal static int Check()
        {
            string login, password;
            int lastId = json.Take("accountId");

            while (true)
            {
                if (lastId != -1)
                {
                    login = accountSql.TakeValueAccount("login", "id", lastId);
                    Console.WriteLine($"Логин: {login}");
                    Console.WriteLine($"Хотите зайти под этим аккаунтом?\n1.Да\n2.Нет");
                    string temp = Console.ReadLine();
                    if (temp == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Логин: ");
                        login = Console.ReadLine();
                    }
                    else if (temp != "1")
                    {
                        Console.WriteLine("Необходимо выбрать действие");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Write("Логин: ");
                    login = Console.ReadLine();
                }
                Console.Write("Пароль: ");
                password = Console.ReadLine();

                if (accountSql.CheckAccount(login, password))
                {
                    Console.Clear();
                    return Convert.ToInt32(accountSql.TakeValueAccount("id", "login", login));
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль. Попробуйте ввести снова.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
