using DataBase;
using MFCLibrary.DataBase.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.AccountSqlActions
{
    internal class SqlUpdateAccount
    {
        internal static void UpdateAccount(MFCDataBase db, string updateRow, object newValue)
        {
            JsonActions json = new JsonActions();

            db.command = new SQLiteCommand($"UPDATE {db.AccountTableName} SET {updateRow}=\"{newValue}\" WHERE id={json.Take("accountId")}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
