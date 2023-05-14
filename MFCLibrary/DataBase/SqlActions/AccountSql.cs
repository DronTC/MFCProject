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
        internal bool CheckAccount(string login, string password)
        {
            return SqlCheckAccount.CheckAccount(db, login, password);
        }
        internal List<string[]> TakeDataAccount()
        {
            return SqlTakeDataAccount.TakeDataAccount(db);
        }
        internal string TakeValueAccount(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueAccount.TakeValueAccount(db, row, checkRow, checkValue);
        }
    }
}
