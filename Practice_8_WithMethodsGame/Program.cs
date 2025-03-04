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
        static int pHP = PlayerHP();
        static int maxHP = MaxPlayerHP();
        static int gold = Gold();
        static int potion = Potion();
        static int arrows = Arrows();
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
                roomNumber = random.Next(0, 4); // dungeonMap.Length
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
                        Chest();
                        break;
                    case "Проклятый сундук":
                        CursedChest();
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
                if (pHP <= 0)
                {
                    Console.WriteLine("Вы погибли");
                    i = 100;
                }
            }
        }
        public static void FightMonster(int monsterHP, int monsterAttack)
        {
            Console.WriteLine("\nС монстром!");
            monsterHP = random.Next(20, 51);
            Dictionary<string, int> weapon = new Dictionary<string, int>()
            {
                { "меч", random.Next(10, 21) },
                { "лук", random.Next(5, 16) }
            };
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
        }
        public static void Trap()
        {
            Console.WriteLine("\nС ловушкой!");
            int fall = random.Next(2);
            if (fall == 1)
            {
                Console.WriteLine("Вы попали в ловушку!");
                pHP -= random.Next(5, 21);
            }
            else Console.WriteLine("Фух! Ловушка давно устарела и не работает.");
            Console.WriteLine($"У играка {pHP} HP");
        }
        public static void Chest()
        {
            Console.WriteLine("\nС сундуком!");
            var correctAnswer = "20";
            bool cycleAnswer = true;
            Console.WriteLine("Чтобы открыть сундук, игрок должен решить математическую загадку: 10 * 2");
            while (cycleAnswer)
            {
                Console.Write("Ваш ответ: ");
                var userAnswer = Console.ReadLine();
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Аааааайй, ТИГР! Лови лут!");
                    int value = random.Next(0, 3);
                    if (value == 0)
                    {
                        gold += random.Next(10, 26);
                    }
                    else if (value == 1)
                    {
                        potion += random.Next(1, 3);
                    }
                    else arrows += random.Next(3, 6);
                    cycleAnswer = false;
                }
                else Console.WriteLine("Неправильно, попробуй ещё раз!");
            }
            Console.WriteLine($"Золото: {gold}\nЗелий: {potion}\nСтрелы: {arrows}");
        }
        public static void CursedChest()
        {
            Console.WriteLine("\nС проклятым сундуком!");
            gold += random.Next(10, 26);
            Console.WriteLine($"У игрока {gold} золота");
            int fallChance = random.Next(0, 2);
            if (fallChance == 1)
            {
                maxHP -= 10;
                if (pHP % 10 == 0) pHP = maxHP;
                Console.WriteLine($"Но, сундук наносит {10} урона и у игрока теперь {maxHP} максимального HP");
            }
            else Console.WriteLine("Сундук - лох и ничего не смог сделать");
        }
        public static void Trader()
        {
            Console.WriteLine("\nС торговецем!");
            Console.WriteLine("Добро пожаловать странник, купи зелье для регенерации! Пж");
            Console.WriteLine("Что хотите купить?\nЗелье - 10 золота\n3 Стрелы - 5 золота: ");
            string item = Console.ReadLine();
            if (item == "Зелье")
            {
                if (gold < 10) Console.WriteLine("У вас недостаточно золота");
                gold -= 10;
                potion += 1;
            }
            if (item == "Стрелы")
            {
                gold -= 5;
                arrows += 3;
            }

            //if (golds == 30)
            //{
            //    if (inventory.Length > 5)
            //    {
            //        Console.WriteLine("Ваш инвентарь переполнен!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Спасибо, странник, что купил мой товар, удачного пути!");
            //        potion++;
            //        golds -= 30;
            //    }
            //    Console.WriteLine($"Зелий: {potion}\nЗолото: {golds}\nСтрелы: {arrows}");
            //}
            else Console.WriteLine("Ууууу, у тебя даже денег нету... Иди отсюда, БОМЖАРА!");
        }
    }
}
