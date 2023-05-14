namespace MFCLibrary.Data.Models
{
    internal class Client
    {
        internal string fullnameClient { get; private set; } = "";
        internal string passport { get; private set; } = "";
        internal string email { get; private set; } = "";
        internal Client(string fullnameClient, string passport, string email)
        {
            this.fullnameClient = fullnameClient;
            this.passport = passport;
            this.email = email;
        }
    }
}
