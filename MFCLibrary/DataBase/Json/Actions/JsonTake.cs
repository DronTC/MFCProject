using Newtonsoft.Json;

namespace MFCLibrary.DataBase.Json.Actions
{
    internal class JsonTake
    {
        internal static string Take(string path, string nameData)
        {
            string jsonString = File.ReadAllText(path);
            
            JsonData data = JsonConvert.DeserializeObject<JsonData>(jsonString);

            if (nameData == "themeId")
                return Convert.ToString(data.themeId);
            else if (nameData == "accountId")
                return Convert.ToString(data.accountId);
            else if (nameData == "language")
                return data.language;

            throw new Exception("Ошибка доступа к json файлу");
        }
    }
}
