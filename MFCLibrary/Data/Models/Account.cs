
namespace MFCLibrary.Data.Models
{
    internal class Account
    {
        internal string login { get; private set; } = "";
        internal string password { get; private set; } = "";

        internal Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
