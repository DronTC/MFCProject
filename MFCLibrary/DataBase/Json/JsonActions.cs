using System;
using System.Text.Json;

namespace MFCLibrary.DataBase.Json
{
    internal static class JsonActions
    {
        private static string JsonFileName = "ApplicationDefaultSettings.json";
        internal async static void RecordingData()
        {
            using (FileStream fs = new FileStream(JsonFileName, FileMode.OpenOrCreate))
            {
                //await JsonSerializer.SerializeAsync(fs);
                //Console.WriteLine("Data has been saved to file");
            }
        }
    }
}
