using System;

namespace NestedLoopsToRecursion
{
    internal class Program
    {
        private static int[] elements;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            elements = new int[n];

            Generate(0);
        }

        private static void Generate(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[idx] = i;
                Generate(idx + 1);
            }
        }
    }
}
