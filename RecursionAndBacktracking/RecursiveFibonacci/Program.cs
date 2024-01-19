using System;

namespace RecursiveFibonacci
{
    internal class Program
    {
        private static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {
            if (n <= 1)
                return 1;

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
