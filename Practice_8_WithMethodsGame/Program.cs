﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_WithMethodsGame
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            //int roomNumber = 0;

            //InitializeGame();
            StartGame();
            ProcessRoom();


            Console.ReadKey();
            
        }
        public static int InitializeGame()
        {
            int pHP = 10;
            int maxHP = 100;
            int gold = 10;
            int potion = 2;
            int arrows = 5;
            Dictionary<string, int> weapon = new Dictionary<string, int>()
            {
                { "меч", random.Next(10, 21) },
                { "лук", random.Next(5, 16) }
            };
            return pHP;
        }
        public static void StartGame()
        {
            Console.WriteLine("Добро пожаловать странник!");
        }
        public static int ProcessRoom()
        {
            int pHP = InitializeGame();
            int monsterHP = 0;
            int monsterAttack = 0;
            Console.WriteLine("Странник попадает в комнату с...");
            string[] dungeonMap = { "Монстр", "Ловушка", "Обычный сундук", "Проклятый сундук", "Торговец", "Алтарь усиления", "Темный маг", "Событие", "Финальная комната" };
            for (int i = 0; i < 15; i++)
            {
                int roomNumber = random.Next(0, dungeonMap.Length);
                string room = dungeonMap[roomNumber];
                switch(room)
                {
                    case "Монстр":
                        FightMonster(monsterHP, monsterAttack);
                        pHP = FightMonster(monsterHP, monsterAttack);
                        break;
                    case "Ловушка":
                        break;
                    case "Обычный сундук":
                        break;
                    case "Проклятый сундук":
                        break;
                    case "Торговец":
                        break;
                    case "Алтарь усиления":
                        break;
                    case "Темный маг":
                        break;
                    case "Событие":
                        break;
                }
                //maxHP = pHP;
            }
            return pHP;
        }
        public static int FightMonster(int monsterHP, int monsterAttack)
        {
            monsterHP = random.Next(20, 51);
            int pHP = ProcessRoom();
            int arrows = 5;
            Dictionary<string, int> weapon = new Dictionary<string, int>()
            {
                { "меч", random.Next(10, 21) },
                { "лук", random.Next(5, 16) }
            };
            Console.WriteLine("\nС монстром!");
            while (monsterHP > 0 && pHP > 0)
            {
                Console.WriteLine($"У монстра {monsterHP} HP");
                Console.Write("Выберите оружие: 'меч' или 'лук': ");
                var chooseWeapon = Console.ReadLine();
                if (chooseWeapon == "меч")
                {
                    monsterHP -= weapon["меч"];
                    monsterAttack = random.Next(5, 16);
                    pHP -= monsterAttack;
                }
                else if (chooseWeapon == "лук")
                {
                    if (arrows <= 0)
                    {
                        Console.WriteLine("В колчане нет стрел! Лук использовать нельзя!");
                    }
                    else
                    {
                        arrows--;
                        monsterHP -= weapon["лук"];
                        monsterAttack = random.Next(5, 16);
                        pHP -= monsterAttack;
                    }
                }
                else Console.WriteLine("Такого оружия у вас нет!");
                Console.WriteLine($"Монстр наносит ответный удар: {monsterAttack}");
                Console.WriteLine($"\nУ играка {pHP} HP");
            }
            if (pHP > 0)
                Console.WriteLine("Победа! Монстр повержен!");
            else
            {
                Console.WriteLine("Вы погибли.");
                int i = 100;
            }
            return pHP;
        }
    }
}
