using MFCLibrary.DataBase.Json;

namespace MFCLibrary.Settings
{
    internal class ChangeLanguage
    {
        internal static void IntToLanguageState(int value)
        {
            JsonActions json = new JsonActions();

            if (value == 1)
                json.Change("language", "ru");
            else
                json.Change("language", "en");

        }
    }
}
