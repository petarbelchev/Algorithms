using System;

namespace NChooseKCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int binomCoef = CalcBinomCoef(n, k);
            Console.WriteLine(binomCoef);
        }

        private static int CalcBinomCoef(int row, int col)
        {
            if (row <= 1 || col == 0 || row == col)
                return 1;

            return CalcBinomCoef(row - 1, col) + CalcBinomCoef(row - 1, col - 1);
        }
    }
}
