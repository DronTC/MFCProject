using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Settings
{
    internal static class Language
    {
        internal static Dictionary<ResourceId, string> SelectLanguage()
        {
            JsonActions json = new JsonActions();
            string language = json.Take("language");

            if (language == "ru")
                return Ru.resourcesRu;
            else
                return En.resourcesEn;
        }
    }
}
