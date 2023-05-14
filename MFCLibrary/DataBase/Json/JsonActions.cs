using MFCLibrary.Data;
using MFCLibrary.DataBase.Json.Actions;
using System;
using System.IO;
using System.Text.Json;

namespace MFCLibrary.DataBase.Json
{
    public class JsonActions
    {
        internal string JsonFileName = Environment.ExpandEnvironmentVariables("%Appdata%\\AppDefaultSettings.json");

        public void Change(string nameData, int value)
        {
            JsonChange.Change(JsonFileName, nameData, value);
        }
        public void Change(int themeId, int accountId)
        {
            JsonChange.Change(JsonFileName, themeId, accountId);
        }
        public int Take(string nameData)
        {
            return JsonTake.Take(JsonFileName, nameData);
        }
    }
}
