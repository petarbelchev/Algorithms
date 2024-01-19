using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    internal class Program
    {
        private class Area
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }
        }

        private static char[,] matrix;

        static void Main(string[] args)
        {
            DrawMatrix();

            List<Area> areas = FindAreas();

            PrintResult(areas);
        }

        private static void DrawMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = rowData[col];
            }
        }

        private static List<Area> FindAreas()
        {
            var areas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var area = new Area() { Row = row, Col = col };
                    ExploreMatrix(row, col, area);

                    if (area.Size > 0)
                        areas.Add(area);
                }
            }

            return areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();
        }

        private static void ExploreMatrix(int row, int col, Area area)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
                return;

            matrix[row, col] = 'V';
            area.Size++;

            ExploreMatrix(row - 1, col, area); // UP
            ExploreMatrix(row + 1, col, area); // DOWN
            ExploreMatrix(row, col - 1, area); // LEFT
            ExploreMatrix(row, col + 1, area); // RIGHT
        }

        private static bool IsOutside(int row, int col)
            => row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);

        private static bool IsWall(int row, int col)
            => matrix[row, col] == '*';

        private static bool IsVisited(int row, int col)
            => matrix[row, col] == 'V';

        private static void PrintResult(List<Area> areas)
        {
            Console.WriteLine($"Total areas found: {areas.Count()}");

            for (int i = 0; i < areas.Count(); i++)
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
        }
    }
}
