using System;

namespace RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFactorial(n));
        }

        private static int CalcFactorial(int n)
        {
            if (n == 0)
                return 1;

            return n * CalcFactorial(n - 1);
        }
    }
}
