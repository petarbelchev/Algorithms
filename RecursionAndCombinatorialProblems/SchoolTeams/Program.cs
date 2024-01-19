using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsCombs = new List<string[]>();
            string[] girlsComb = new string[3];
            GenCombinations(0, 0, girls, girlsComb, girlsCombs);

            var boysCombs = new List<string[]>();
            string[] boysComb = new string[2];
            GenCombinations(0, 0, boys, boysComb, boysCombs);

            for (int i = 0; i < girlsCombs.Count; i++)
            {
                for (int j = 0; j < boysCombs.Count; j++)
                    Console.WriteLine($"{string.Join(", ", girlsCombs[i])}, {string.Join(", ", boysCombs[j])}");
            }
        }

        private static void GenCombinations(int index, int startPosition, string[] elements, string[] comb, List<string[]> combs)
        {
            if (index >= comb.Length)
            {
                combs.Add(comb.ToArray());
                return;
            }

            for (int i = startPosition; i < elements.Length; i++)
            {
                comb[index] = elements[i];
                GenCombinations(index + 1, i + 1, elements, comb, combs);
            }
        }
    }
}
