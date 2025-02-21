using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWorkGAME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] dungeonMap = new int[10];
            //string[] dungeonMap = { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната", "Босс" };
            //string rnd = random.Next(dungeonMap[0], dungeonMap[]);
            for (int i = 0; i < dungeonMap.Length; i++)
            {
                //Console.Write("Введите комнату, в которую хотите попасть: ");
                //var room = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Хотите идти дальше?");
                string ans = Console.ReadLine();
                if (ans == "Да" || ans == "да")
                {
                    int rnd = random.Next(10);
                    switch (rnd)
                    {
                        case 1:
                            Console.WriteLine("Монстр!");
                            Console.WriteLine("Игрок вступает в бой.");
                            break;
                        case 2:
                            Console.WriteLine("Ловушка!");
                            Console.WriteLine("Игрок теряет часть здоровья.");
                            break;
                        case 3:
                            Console.WriteLine("Сундук!");
                            Console.WriteLine("Для открытия нужно решить загадку.");
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
                            Console.WriteLine("Игрок вступает в бой.");
                            break;
                        case 7:
                            Console.WriteLine("Сундук!");
                            Console.WriteLine("Для открытия нужно решить загадку.");
                            break;
                        case 8:
                            Console.WriteLine("Торговец!");
                            Console.WriteLine("Можно купить зелье за золото.");
                            break;
                        case 9:
                            Console.WriteLine("Монстр!");
                            Console.WriteLine("Игрок вступает в бой.");
                            break;
                        case 10:
                            //Console.WriteLine("Босс!");
                            //Console.WriteLine("Финальный противник.");
                            Console.WriteLine("Сундук!");
                            Console.WriteLine("Для открытия нужно решить загадку.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ну ладно");
                    break;
                }
                //if (room > 10 || room < 0)
                //{
                //    Console.WriteLine("Такой комнаты нет!");
                //    Console.WriteLine("Вы упали и, вдруг, прошли сквозь пол. Вы провалились в закулисье.\n Теперь вы обречены блуждать по комнатам протижонностью ;?№92*;2?! км^2 ");
                //    break;
                //}
            }
            Console.WriteLine("Босс!");
            Console.WriteLine("Финальный противник.");







            Console.ReadKey();
        }
    }
}
