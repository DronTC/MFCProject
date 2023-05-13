using System.Text.Json;

namespace MFCLibrary.DataBase.Json.Actions
{
    internal static class JsonAdd
    {
        internal static void Add(JsonActions JsonAct)
        {
            using (JsonAct.fs = new FileStream(JsonAct.JsonFileName, FileMode.OpenOrCreate))
            {
                
            }
        }
    }
}
