using Newtonsoft.Json;

namespace MFCLibrary.DataBase.Json.Actions
{
    internal static class JsonChange
    {
        internal static void Change(string path, string nameData, string value)
        {
            string jsonString = File.ReadAllText(path);
            JsonData data = JsonConvert.DeserializeObject<JsonData>(jsonString);

            if (nameData == "themeId")
                data.themeId = Convert.ToInt32(value);
            else if (nameData == "accountId")
                data.accountId = Convert.ToInt32(value);
            else if (nameData == "language")
                data.language = value;

            jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
        internal static void Change(string path, int themeId, int accountId, string language)
        {
            var data = new { themeId, accountId, language };
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}
