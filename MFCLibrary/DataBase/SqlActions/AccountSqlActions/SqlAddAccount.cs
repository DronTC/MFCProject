using DataBase;
using MFCLibrary.Data.Models;

namespace MFCLibrary.DataBase.SqlActions.AccountSqlActions
{
    internal static class SqlAddAccount
    {
        internal static void AddAccount(MFCDataBase db, Account account)
        {
            db.command.CommandText = $"INSERT INTO {db.AccountTableName} (login, password) VALUES (\"{account.login}\",\"{account.password}\")";
            db.command.ExecuteNonQuery();
        }
    }
}
