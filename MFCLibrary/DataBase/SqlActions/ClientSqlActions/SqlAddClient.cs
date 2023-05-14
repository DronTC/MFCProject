using DataBase;
using MFCLibrary.Data.Models;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlAddClient
    {
        internal static void AddClient(MFCDataBase db, Client client, bool isAuthorized )
        {
            db.command.CommandText = $"INSERT INTO {db.ClientTableName} (fullnameClient, passport, email, isAuthorized ) VALUES (\"{client.fullnameClient}\",\"{client.passport}\", \"{client.email}\", {isAuthorized})";
            db.command.ExecuteNonQuery();
        }
    }
}
