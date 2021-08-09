using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGamers_v01
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Creator
    {
        private static Random _random;

        static Creator()
        {
            _random = new Random();
        }

        public Creator() { }

        public Player CreateNewPlayer()
        {
            return new Player(CreateNewName(), CreateNewLevel(), CreateNewStrength());
        }

        private string CreateNewName()
        {
            string name = "";
            string[] names = new string[] 
            {"Альв", "Арнульв", "Атли", "Бёдмод", "Бернард", "Берси", "Бо", 
                "Вальгард", "Вегейр", "Винсент", "Гарольд", "Гуннар", "Зигрид",
                "Кнуд", "Колль", "Магни", "Моди", "Олав", "Рауд", "Регин",
                "Сван", "Снор", "Стейн", "Томас", "Тород", "Ульв", "Финр"
            };

            name = names[_random.Next(names.Length)];

            return name;
        }

        private int CreateNewLevel()
        {
            int minlevel = 1;
            int maxLevel = 10;

            return _random.Next(minlevel, maxLevel);
        }

        private int CreateNewStrength()
        {
            int minStrength = 10;
            int maxStrength = 50;

            return _random.Next(minStrength, maxStrength);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, уровень {Level}, сила {Strength}");
        }
    }
}
