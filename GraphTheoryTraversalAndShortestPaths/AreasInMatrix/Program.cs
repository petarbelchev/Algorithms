using System;
using System.Collections.Generic;
using System.Linq;

namespace AreasInMatrix
{
	internal class Program
	{
		private static char[,] matrix;
		private static bool[,] visited;

		static void Main(string[] args)
		{
			DrawMatrix();
			SortedDictionary<char, int> areas = FindAreas();
			PrintAreas(areas);
		}

		private static void DrawMatrix()
		{
			int rows = int.Parse(Console.ReadLine());
			int cols = int.Parse(Console.ReadLine());
			matrix = new char[rows, cols];
			visited = new bool[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				char[] cells = Console.ReadLine().ToCharArray();

				for (int col = 0; col < cols; col++)
					matrix[row, col] = cells[col];
			}
		}

		private static SortedDictionary<char, int> FindAreas()
		{
			var areas = new SortedDictionary<char, int>();

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (visited[row, col])
						continue;

					FindArea(row, col);

					if (!areas.ContainsKey(matrix[row, col]))
						areas[matrix[row, col]] = 0;

					areas[matrix[row, col]]++;
				}
			}

			return areas;
		}

		private static void FindArea(int row, int col)
		{
			if (visited[row, col])
				return;

			visited[row, col] = true;

			if (IsValidCell(row - 1, col) && matrix[row, col] == matrix[row - 1, col])
				FindArea(row - 1, col); // UP

			if (IsValidCell(row + 1, col) && matrix[row, col] == matrix[row + 1, col])
				FindArea(row + 1, col); // DOWN

			if (IsValidCell(row, col - 1) && matrix[row, col] == matrix[row, col - 1])
				FindArea(row, col - 1); // LEFT

			if (IsValidCell(row, col + 1) && matrix[row, col] == matrix[row, col + 1])
				FindArea(row, col + 1); // RIGHT
		}

		private static bool IsValidCell(int row, int col)
			=> row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

		private static void PrintAreas(SortedDictionary<char, int> areas)
		{
			Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");

			foreach (var (area, count) in areas)
				Console.WriteLine($"Letter '{area}' -> {count}");
		}
	}
}
