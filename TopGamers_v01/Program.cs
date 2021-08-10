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
            Creator creator = new Creator();
            List<Player> players = new List<Player>();
            List<Player> filtered = new List<Player>();
            Filter filter = new Filter();
            int playersQuantity = 20;

            for (int i = 0; i < playersQuantity; i++)
            {
                players.Add(creator.CreateNewPlayer());
            }

            for (int i = 0; i < players.Count; i++)
            {
                Console.Write($"{i + 1:d2}. ");
                players[i].ShowInfo();
            }

            Console.WriteLine($"--------------------------------");

            filtered = filter.TopLevel(players, 3);

            for (int i = 0; i < filtered.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                filtered[i].ShowInfo();
            }
        }
    }

    class Filter
    {
        private List<int> _numbers;

        public Filter()
        {
            _numbers = new List<int>();
        }

        public List<Player> TopLevel(List<Player> players, int depth)
        {
            _numbers.Clear();

            for (int i = 0; i < players.Count; i++)
            {
                _numbers.Add(players[i].Level);
            }

            CalculateUpperLimits(players, 3, out int topUpperLimit, out int topLowerLimit);

            var topLevel = players.Where(player => player.Level <= topUpperLimit && player.Level >= topLowerLimit).OrderByDescending(player => player.Level).ToList();

            return topLevel;
        }

        private void CalculateUpperLimits(List<Player> players, int depth, out int topUpperLimit, out int topLowerLimit)
        {
            
            
            var cutLevels = _numbers.Distinct().ToList();

            topUpperLimit = cutLevels.Max();
            int lowerLimit = topUpperLimit;

            for (int i = 0; i < depth; i++)
            {
                var temporaryCutLevels = cutLevels.Where(number => number != lowerLimit);
                lowerLimit = temporaryCutLevels.Max();
                cutLevels = temporaryCutLevels.ToList();
            }
            topLowerLimit = lowerLimit;

            Console.WriteLine($"диапазон TOP уровней {topUpperLimit}-{topLowerLimit}");
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
            string name;// = "";
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

