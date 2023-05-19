using Newtonsoft.Json;


namespace MFCLibrary.DataBase.Json
{
    internal class JsonData
    {
        [JsonRequired]
        internal int themeId { get; set; }
        [JsonRequired]
        internal int accountId { get; set; }
        [JsonRequired]
        internal string language { get; set; }
    }
}
