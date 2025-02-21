using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8_WithMethodsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] dungeonMap = { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната", "Босс" };

            InitializeGame();
            StartGame();


            Console.ReadKey();
            
        }
        public static void InitializeGame()
        {
            Random random = new Random();
            int pHP = 100;
            int maxHP = 100;
            int gold = 10;
            int potion = 2;
            int arrow = 5;
            Dictionary<string, int> weapon = new Dictionary<string, int>()
            {
                { "меч", random.Next(10, 21) },
                { "лук", random.Next(5, 16) }
            };
        }
        public static void StartGame()
        {
            Console.Write("Добро пожаловать странник!");
        }
        public static void ProcessRoom(int roomNumber)
        {
            Random random = new Random();
            string[] dungeonMap = { "Монстр", "Ловушка", "Обычный сундук", "Проклятый сундук", "Торговец", "Алтарь усиления", "Темный маг", "Событие", "Финальная комната" };
            for (int i = 0; i < 15; i++)
            {
                int randomRoom = random.Next(0, dungeonMap.Length);
                string room = dungeonMap[randomRoom];
                switch(room)
                {
                    case "Монстр":
                        Console.WriteLine("Code is working");
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
            }
        }
    }
}
