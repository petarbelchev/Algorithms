using System;
using System.Linq;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSort(numbers);
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            int sortedCount = 0;
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < numbers.Length - 1 - sortedCount; i++)
                {
                    int j = i + 1;

                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
