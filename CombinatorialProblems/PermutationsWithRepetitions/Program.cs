using System;
using System.Collections.Generic;

namespace PermutationsWithRepetitions
{
    internal class Program
    {
        private static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            Permute(index + 1);
            var swapper = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!swapper.Contains(elements[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    swapper.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            (elements[first], elements[second]) = (elements[second], elements[first]);
        }
    }
}
