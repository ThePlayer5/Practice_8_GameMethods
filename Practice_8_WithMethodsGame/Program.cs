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
        static int pHP = 100;
        static void Main(string[] args)
        {
            int roomNumber = 0;

            StartGame();
            ProcessRoom(roomNumber);


            Console.ReadKey();

        }
        public static int PlayerHP()
        {
            int pHP = 100;
            return pHP;
        }
        public static int MaxPlayerHP()
        {
            int maxHP = 100;
            return maxHP;
        }
        public static int Gold()
        {
            int gold = 10;
            return gold;
        }
        public static int Potion()
        {
            int potion = 2;
            return potion;
        }
        public static int Arrows()
        {
            int arrows = 5;
            return arrows;
        }
        public static void StartGame()
        {
            Console.WriteLine("Добро пожаловать странник!");
        }
        public static void ProcessRoom(int roomNumber)
        {
            int monsterHP = 0;
            int monsterAttack = 0;
            Console.WriteLine("Странник попадает в комнату с...");
            string[] dungeonMap = { "Монстр", "Ловушка", "Обычный сундук", "Проклятый сундук", "Торговец", "Алтарь усиления", "Темный маг", "Событие", "Финальная комната" };
            for (int i = 0; i < 15; i++)
            {
                roomNumber = random.Next(0, 2); // dungeonMap.Length
                string room = dungeonMap[roomNumber];
                switch (room)
                {
                    case "Монстр":
                        FightMonster(monsterHP, monsterAttack);
                        break;
                    case "Ловушка":
                        Trap();
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
            }
        }
        public static int FightMonster(int monsterHP, int monsterAttack)
        {
            monsterHP = random.Next(20, 51);
            //int pHP = PlayerHP();
            int arrows = Arrows();
            Dictionary<string, int> weapon = new Dictionary<string, int>()
    {
        { "меч", random.Next(10, 21) },
        { "лук", random.Next(5, 16) }
    };
            Console.WriteLine("\nС монстром!");
            while (monsterHP > 0 && pHP > 0)
            {
                Console.WriteLine($"\nУ играка {pHP} HP");
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
        public static void Trap()
        {
            int monsterHP = 0;
            int monsterAttack = 0;
            //int pHP = FightMonster(monsterHP, monsterAttack);
            Console.WriteLine("\nС ловушкой!");
            int fall = random.Next(2);
            if (fall == 1)
            {
                Console.WriteLine("Вы попали в ловушку!");
                pHP -= random.Next(5, 21);
            }
            else Console.WriteLine("Фух! Ловушка давно устарела и не работает.");
            Console.WriteLine($"У играка {pHP} HP");
            if (pHP < 0)
            {
                Console.WriteLine("Вы погибли.");
                int i = 100;
            }
        }
    }
}
