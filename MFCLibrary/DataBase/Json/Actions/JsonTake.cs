using Newtonsoft.Json;

namespace MFCLibrary.DataBase.Json.Actions
{
    internal class JsonTake
    {
        internal static int Take(string path, string nameData)
        {
            string jsonString = File.ReadAllText(path);
            
            JsonData data = JsonConvert.DeserializeObject<JsonData>(jsonString);
            
            if (nameData == "themeId")
                return data.themeId;
            else if (nameData == "accountId")
                return data.accountId;

            throw new Exception("Ошибка доступа к json файлу");
        }
    }
}
