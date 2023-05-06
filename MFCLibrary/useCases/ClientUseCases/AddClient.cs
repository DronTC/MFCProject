﻿using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class AddClient
    {
        static ClientSql clientSql { get; } = new ClientSql();
        static Client? client;

        static internal string? fullnameClient { get; private set; } = "";
        static internal string? passport { get; private set; } = "";

        internal static void Add()
        {
            while (true)
            {
                if (fullnameClient == "")
                {
                    Console.Write("Введите ФИО клиента: ");
                    fullnameClient = Console.ReadLine();
                    continue;
                }

                Console.Write("Введите паспортные данные: ");
                passport = Console.ReadLine();
                if (passport.Length != 11)
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                if (passport[4] != ' ')
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (i != 3)
                            Convert.ToInt32(passport[i]);
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                if (clientSql.CheckClient(passport))
                {
                    Console.WriteLine("Клиент с данными паспортными данными уже числится в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    passport = "";
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
            client = new Client(fullnameClient, passport);
            clientSql.AddClient(client);
            Console.WriteLine("Клиент добавлен в базу данных\n");
        }
    }
}
