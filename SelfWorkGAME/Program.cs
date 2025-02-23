using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfWorkGAME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Random random = new Random();
            //int[] dungeonMap = new int[10];
            //int[] inventory = new int[5];
            int[] inventory = new int[5] { 0, 0, 0, 0, 0 };
            string[] loot = { "Зелье", "Золото", "Стрелы" };
            string[] dungeonMap = { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната", "Босс" };

            int rndroom = 0;
            string choseRoom = null;

            int potion = 0;
            int golds = 0;
            var answer1 = "x^3 / 3 + C";
            var pGetHit = 0;
            int pHP = 100;
            int arrows = 0;
            string diff = null;
            int diffNum = 0;

            // Стрелы возьмёшь?
            Console.Write("Добро пожаловать странник! Подземелье опасное место... Тебе лучше запастись стрелами для лука!\n Сколько хочешь взять с собой?: ");
            arrows += Convert.ToInt32(Console.ReadLine());
            if (arrows <= 0)
            {
                Console.WriteLine("Твой выбор... Имей ввиду: лук использовать теперь не полуится!");
            }
            else Console.WriteLine($"Теперь у вас {arrows} стрел. Удачи!");
            Console.WriteLine("\nСтранник входит в подземелье...");

            // Комнаты
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\nПроходит по тёмным корридорам и натыкается на комнату...");
                rndroom = random.Next(2, 3);
                choseRoom = dungeonMap[rndroom];
                Thread.Sleep(4000);
                //Console.Write("\nВведите комнату, в которую хотите попасть: ");
                //var room = Convert.ToInt32(Console.ReadLine());
                switch (choseRoom)
                {
                    case "Монстр":
                        int mHP = 0;
                        diffNum = random.Next(1, 4);
                        if (diffNum == 1)
                        {
                            mHP = random.Next(20, 51);
                            diff = "Лёгкий";
                        }
                        else if (diffNum == 2)
                        {
                            mHP = random.Next(50, 101);
                            diff = "Средний";
                        }
                        else
                        {
                            mHP = random.Next(100, 151);
                            diff = "Высокий";
                        }
                        Console.WriteLine("\nС монстром!");
                        Console.WriteLine($"Сложность монстра: {diff}");
                        while (mHP > 0 && pHP > 0)
                        {
                            Console.WriteLine($"У монстра {mHP} HP");
                            Console.Write("Выберите оружие: 'меч' или 'лук': ");
                            var weapon = Console.ReadLine();
                            if (weapon == "меч")
                            {
                                mHP -= random.Next(10, 21);
                                pGetHit = random.Next(5, 16);
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
                                    mHP -= random.Next(5, 16);
                                    pGetHit = random.Next(5, 16);
                                    pHP -= pGetHit;
                                }
                            }
                            Console.WriteLine($"Монстр наносит ответный удар: {pGetHit}");
                            Console.WriteLine($"\nУ играка {pHP} HP");
                        }
                        if (pHP > 0)
                            Console.WriteLine("Победа! Монстр повержен!");
                        break;
                    case "Ловушка":
                        Console.WriteLine("\nС ловушкой!");
                        var fall = random.Next(2);
                        if (fall == 1)
                        {
                            Console.WriteLine("Вы попали в ловушку!");
                            pHP -= random.Next(10, 21);
                        }
                        else Console.WriteLine("Фух! Ловушка давно устарела и не работает.");
                        Console.WriteLine($"У играка {pHP} HP");
                        break;
                    case "Сундук":
                        Console.WriteLine("\nС сундуком!");
                        bool corranswer = true;
                        Console.WriteLine("Чтобы открыть сундук, игрок должен решить математическую загадку: Интеграл ( x^2 * dx )");
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
                        break;
                    case "Торговец":
                        Console.WriteLine("\nС торговецем!");
                        Console.WriteLine("Добро пожаловать странник, купи зелье для регенерации! Пж");
                        if (golds == 30)
                        {
                            if (inventory.Length > 5)
                            {
                                Console.WriteLine("Ваш инвентарь переполнен!");
                            }
                            else
                            {
                                Console.WriteLine("Спасибо, странник, что купил мой товар, удачного пути!");
                                potion++;
                                golds -= 30;
                            }
                            Console.WriteLine($"Зелий: {potion}\nЗолото: {golds}\nСтрелы: {arrows}");
                        }
                        else Console.WriteLine("Ууууу, у тебя даже денег нету... Иди отсюда, БОМЖАРА!");
                        break;
                    case "Пустая комната":
                        Console.WriteLine("\nС пустой комнатой.");
                        Console.WriteLine("Ничего не происходит.");
                        break;
                        //default:
                        //    Console.WriteLine("\nСо... странной комнатой...");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("- 'В ней вообще ничего нет... снова обычная пустая комната?'");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("- 'Ну лад...' [Звук подения]");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("Вы... обернулись... и захотели выйти, но...");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("Вы провалились СКВОЗЬ пол...");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("Вы оказались в Закулисье... [Разблокирована №оВ?я л(ка;%Ия] ?");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("Теперь вы обречены блуждать по коридорам протижонностью 25000000000000 км^2.");
                        //    Thread.Sleep(3000);
                        //    Console.WriteLine("Конец игры...  ?");
                        //    i = 11;
                        //    pHP = 0;
                        //    break;
                }
                if (i == 9)
                {
                    Console.WriteLine("\nБосс!");
                }
                if (pHP <= 0)
                {
                    Console.WriteLine("\nВы погибли. Конец.");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
