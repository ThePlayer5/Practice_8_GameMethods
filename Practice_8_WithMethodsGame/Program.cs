using System;
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
            int pHP = 100;
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
        public static void ProcessRoom()
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
                        //pHP = FightMonster(monsterHP, monsterAttack);
                        break;
                    case "Ловушка":
                        Console.WriteLine("\nС ловушкой!");
                        pHP = Trap();
                        Console.WriteLine($"У играка {pHP} HP");
                        break;
                    case "Обычный сундук":
                        Console.WriteLine("\nС сундуком!");

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
        }
        public static int FightMonster(int monsterHP, int monsterAttack)
        {
            monsterHP = random.Next(20, 51);
            int pHP = InitializeGame();
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
        public static int Trap()
        {
            int pHP = InitializeGame();
            pHP -= random.Next(5, 21);
            return pHP;
        }
        public static void Chest()
        {
            string answer1 = "4";
            bool corranswer = true;
            Console.WriteLine("Чтобы открыть сундук, игрок должен решить математическую загадку: 2 + 2");
            while (corranswer)
            {
                Console.Write("Ваш ответ: ");
                var answer = Console.ReadLine();
                if (answer == answer1)
                {
                    Console.WriteLine("Аааааайй, ТИГР! Лови лут!");
                    int value = random.Next(0, loot.Length - 1);
                    string item = loot[value];
                    if (item == "Зелье")
                    {
                        Console.WriteLine(inventory.Length);
                        Console.WriteLine(potion);
                        if (inventory.Length <= 0)
                        {
                            Console.WriteLine("Ваш инвентарь переполнен!");
                        }
                        else
                        {
                            inventory[potion] = 1;
                            potion--;
                        }
                    }
                    else if (item == "Золото")
                    {
                        golds += random.Next(10, 26);
                    }
                    else arrows += 3;
                    corranswer = false;
                }
                else Console.WriteLine("Неправильно, попробуй ещё раз!");
            }
            Console.WriteLine($"Зелий: {potion}\nЗолото: {golds}\nСтрелы: {arrows}");
        }
    }
}
