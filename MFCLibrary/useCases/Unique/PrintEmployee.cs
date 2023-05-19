﻿using MFCLibrary.Data.resourse;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.Unique
{
    internal static class PrintEmployee
    {
        internal static void PrintAll(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.birthday]}: {list[2]}| {Language.SelectLanguage()[ResourceId.window]}: {list[3]}");
                Console.WriteLine("==========================================");
            }
        }
        //Вывод окон 1-20
        internal static void PrintOrdinary(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (char.IsDigit(list[3][0]))
                {
                    Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.birthday]}: {list[2]}| {Language.SelectLanguage()[ResourceId.window]}: {list[3]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
        //Вывод окон Г21-Г23
        internal static void PrintSpecial(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (!char.IsDigit(list[3][0]))
                {
                    Console.WriteLine($"ID: {list[0]}| {Language.SelectLanguage()[ResourceId.fullName]}: {list[1]}| {Language.SelectLanguage()[ResourceId.birthday]}: {list[2]}| {Language.SelectLanguage()[ResourceId.window]}: {list[3]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
    }
}
