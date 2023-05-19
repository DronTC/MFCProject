using MFCLibrary.Data.resourse;
using MFCLibrary.Settings;

namespace MFCLibrary.useCases.Unique
{
    internal static class PrintClient
    {
        internal static void PrintAll(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.passport]}: {list[2]}| Электронная почта: {list[3]}");
                Console.WriteLine("==========================================");
            }
        }
        internal static void PrintOrdinary(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (!Convert.ToBoolean(list[4]))
                {
                    Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.passport]}: {list[2]}| Электронная почта: {list[3]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
        internal static void PrintSpecial(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (Convert.ToBoolean(list[4]))
                {
                    Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.passport]}: {list[2]}| Электронная почта: {list[3]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
        internal static void PrintById(List<string[]> lists, int id)
        {
            foreach (string[] list in lists)
            {
                if (Convert.ToInt32(list[0]) == id)
                {
                    Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.passport]}: {list[2]}| Электронная почта: {list[3]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
    }
}
