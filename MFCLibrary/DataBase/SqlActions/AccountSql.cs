using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase;
using MFCLibrary.DataBase.SqlActions.AccountSqlActions;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class AccountSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        
        internal void AddAccount(Account account)
        {
            SqlAddAccount.AddAccount(db, account);
        }
        internal bool CheckAccount(string checkRow, object checkValue)
        {
            return SqlCheckAccount.CheckAccount(db, checkRow, checkValue);
        }
    }
}
