using Newtonsoft.Json;

namespace MFCLibrary.DataBase.Json.Actions
{
    internal static class JsonChange
    {
        internal static void Change(string path, string nameData, int value)
        {
            string jsonString = File.ReadAllText(path);
            JsonData data = JsonConvert.DeserializeObject<JsonData>(jsonString);

            if (nameData == "themeId")
                data.themeId = value;
            else if (nameData == "accountId")
                data.accountId = value;

            jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
        internal static void Change(string path, int themeId, int accountId)
        {
            var data = new { themeId, accountId };
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}
