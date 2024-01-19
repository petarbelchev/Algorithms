using System;
using System.Linq;

namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(Sum(nums, 0));
        }

        private static int Sum(int[] nums, int index)
        {
            if (index == nums.Length - 1)
                return nums[index];

            return nums[index] + Sum(nums, index + 1);
        }
    }
}
