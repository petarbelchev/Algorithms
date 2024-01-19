using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema
{
    internal class Program
    {
        private static List<string> people;
        private static string[] distribution;
        private static bool[] seats;

        static void Main(string[] args)
        {
            SetUpInput();

            Arrange(0);
        }

        private static void Arrange(int index)
        {
            if (index >= people.Count)
            {
                PrintDistribution();
                return;
            }

            Arrange(index + 1);

            for (int i = index + 1; i < people.Count; i++)
            {
                Swap(index, i);
                Arrange(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
            => (people[first], people[second]) = (people[second], people[first]);

        private static void SetUpInput()
        {
            people = Console.ReadLine().Split(", ").ToList();
            distribution = new string[people.Count];
            seats = new bool[people.Count];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "generate")
                    break;

                string[] personData = input.Split(" - ");
                string name = personData[0];
                int seatIdx = int.Parse(personData[1]) - 1;
                people.Remove(name);
                distribution[seatIdx] = name;
                seats[seatIdx] = true;
            }
        }

        private static void PrintDistribution()
        {
            int counter = 0;

            for (int i = 0; i < distribution.Length; i++)
            {
                if (!seats[i])
                    distribution[i] = people[counter++];
            }

            Console.WriteLine(string.Join(' ', distribution));
        }
    }
}
