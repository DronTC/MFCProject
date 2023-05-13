using DataBase;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions.AccountSqlActions
{
    internal static class SqlCheckAccount
    {
        internal static bool CheckAccount(MFCDataBase db, string login, string password)
        {
            db.command.CommandText = $"SELECT * FROM {db.AccountTableName} WHERE login=\"{login}\" AND password=\"{password}\"";
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                return true;
            }
            reader.Close();
            return false;
        }
    }
}
