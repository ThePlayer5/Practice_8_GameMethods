using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Random random = new Random();
            int[] dungeonMap = new int[10];
            int[] inventory = new int[5];
            //string[] dungeonMap = { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната", "Босс" };
            //string rnd = random.Next(dungeonMap[0], dungeonMap[]);
            int potion = 0;
            int golds = 0;
            var answer1 = "x^3 / 3 + C";
            var pGetHit = 0;
            int mHP = 0;

            string diff = null;
            int diffNum = random.Next(3);
            if (diffNum == 1)
            {
                mHP = random.Next(20, 50);
                diff = "Лёгкий";
            }
            else if (diffNum == 2)
            {
                mHP = random.Next(50, 100);
                diff = "Средний";
            }
            else if (diffNum == 3)
            {
                mHP = random.Next(100, 150);
                diff = "Высокий";
            }

            int pHP = 100;
            int arrows = 0;
            Console.Write("Добро пожаловать странник! Подземелье опасное место... Тебе лучше запастись стрелами для лука!\n Сколько хочешь взять с собой?: ");
            arrows += Convert.ToInt32(Console.ReadLine());
            if (arrows <= 0)
            {
                Console.WriteLine("Твой выбор... Имей ввиду: лук использовать теперь не полуится!");
            }
            else Console.WriteLine($"Теперь у вас {arrows} стрел. Удачи!");

            for (int i = 0; i < dungeonMap.Length; i++)
            {
                Console.Write("\nВведите комнату, в которую хотите попасть: ");
                var room = Convert.ToInt32(Console.ReadLine());
                switch (room)
                {
                    case 1:
                        Console.WriteLine("Монстр!");
                        Console.WriteLine($"Сложность монстра: {diff}");
                        while (mHP > 0 && pHP > 0)
                        {
                            Console.WriteLine($"У монстра {mHP} HP");
                            Console.Write("Выберите оружие: 'меч' или 'лук': ");
                            var weapon = Console.ReadLine();
                            if (weapon == "меч")
                            {
                                mHP -= random.Next(10, 20);
                                pGetHit = random.Next(5, 15);
                                pHP -= pGetHit;
                            }
                            else if (weapon == "лук")
                            {
                                if (arrows <= 0)
                                {
                                    Console.WriteLine("В колчане нет стрел! Лук использовать нельзя!");
                                }
                                else
                                {
                                    arrows--;
                                    mHP -= random.Next(5, 15);
                                    pGetHit = random.Next(5, 15);
                                    pHP -= pGetHit;
                                }
                            }
                            Console.WriteLine($"Монстр наносит ответный удар: {pGetHit}");
                            Console.WriteLine($"\nУ играка {pHP} HP");
                        }
                        if (pHP > 0)
                            Console.WriteLine("Победа! Монстр повержен!");
                        break;
                    case 2:
                        Console.WriteLine("Ловушка!");
                        var fall = random.Next(2);
                        if (fall == 1)
                        {
                            Console.WriteLine("Вы попали в ловушку!");
                            pHP -= random.Next(10, 20);
                        }
                        else Console.WriteLine("Фух! Ловушка давно устарела и не работает.");
                        Console.WriteLine($"У играка {pHP} HP");
                        break;
                    case 3:
                        Console.WriteLine("Сундук!");
                        Console.WriteLine("Чтобы открыть сундук, игрок должен решить математическую загадку: Интеграл ( x^2 * dx )");
                        Console.Write("Ваш ответ: ");
                        var answer = Console.ReadLine();
                        for (int j = 0; j < inventory.Length; j++)
                        {
                            if (answer == answer1)
                            {
                                int value = random.Next(0, inventory.Length);
                                var item = inventory[value];
                                //if ()
                            }
                            
                        }
                        
                        Console.WriteLine($"Зелий: {potion}\nЗолото: {golds}\nСтрелы: {arrows}");
                        break;
                    case 4:
                        Console.WriteLine("Торговец!");
                        Console.WriteLine("Можно купить зелье за золото.");
                        break;
                    case 5:
                        Console.WriteLine("Пустая комната!");
                        Console.WriteLine("Ничего не происходит.");
                        break;
                    case 6:
                        Console.WriteLine("Монстр!");
                        while (mHP > 0 && pHP > 0)
                        {
                            Console.WriteLine($"У монстра {mHP} HP");
                            Console.Write("Выберите оружие: 'меч' или 'лук': ");
                            var weapon = Console.ReadLine();
                            if (weapon == "меч")
                            {
                                mHP -= random.Next(10, 20);
                                pGetHit = random.Next(5, 15);
                                pHP -= pGetHit;
                            }
                            else if (weapon == "лук")
                            {
                                if (arrows <= 0)
                                {
                                    Console.WriteLine("В колчане нет стрел! Лук использовать нельзя!");
                                }
                                else
                                {
                                    arrows--;
                                    mHP -= random.Next(5, 15);
                                    pGetHit = random.Next(5, 15);
                                    pHP -= pGetHit;
                                }
                            }
                            Console.WriteLine($"Монстр наносит ответный удар: {pGetHit}");
                            Console.WriteLine($"\nУ играка {pHP} HP");
                        }
                        if (pHP > 0)
                            Console.WriteLine("Победа! Монстр повержен!");
                        break;
                    case 7:
                        Console.WriteLine("Сундук!");
                        Console.WriteLine("Чтобы открыть сундук, игрок должен решить математическую загадку: Интеграл ( x^2 * dx )");
                        Console.Write("Ваш ответ: ");
                        answer = Console.ReadLine();
                        for (int j = 0; j < inventory.Length; j++)
                        {
                            if (answer == answer1)
                            {
                                int value = random.Next(0, inventory.Length);
                                var item = inventory[value];
                                //if ()
                            }

                        }
                        break;
                    case 8:
                        Console.WriteLine("Торговец!");
                        Console.WriteLine("Можно купить зелье за золото.");
                        break;
                    case 9:
                        Console.WriteLine("Монстр!");
                        while (mHP > 0 && pHP > 0)
                        {
                            Console.WriteLine($"У монстра {mHP} HP");
                            Console.Write("Выберите оружие: 'меч' или 'лук': ");
                            var weapon = Console.ReadLine();
                            if (weapon == "меч")
                            {
                                mHP -= random.Next(10, 20);
                                pGetHit = random.Next(5, 15);
                                pHP -= pGetHit;
                            }
                            else if (weapon == "лук")
                            {
                                if (arrows <= 0)
                                {
                                    Console.WriteLine("В колчане нет стрел! Лук использовать нельзя!");
                                }
                                else
                                {
                                    arrows--;
                                    mHP -= random.Next(5, 15);
                                    pGetHit = random.Next(5, 15);
                                    pHP -= pGetHit;
                                }
                            }
                            Console.WriteLine($"Монстр наносит ответный удар: {pGetHit}");
                            Console.WriteLine($"\nУ играка {pHP} HP");
                        }
                        if (pHP > 0)
                            Console.WriteLine("Победа! Монстр повержен!");
                        break;
                }
                if (pHP <= 0)
                {
                    Console.WriteLine("\nВас убили. Конец.");
                    break;
                }
                if (room > 10 || room <= 0)
                {
                    Console.WriteLine("Такой комнаты нет!");
                    Console.WriteLine("Вы упали и, вдруг, прошли сквозь пол. Вы провалились в закулисье.\n Теперь вы обречены блуждать по коридорам протижонностью 25000000000000 км^2 ");
                    break;
                }
                else if (room == 10)
                {
                    Console.WriteLine("\nБосс!");
                    Console.WriteLine("Финальный противник.");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
