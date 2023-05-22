using System;
using System.Collections.Generic;

namespace FindAllPathsInALabyrinth
{
	internal class Program
	{
		private static List<char?> path = new List<char?>();
		private static char[,] board;

		static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());
			int cols = int.Parse(Console.ReadLine());
			DrawLabyrinth(rows, cols);
			FindPath(0, 0);
		}

		private static void DrawLabyrinth(int rows, int cols)
		{
			board = new char[rows, cols];

			for (int row = 0; row < board.GetLength(0); row++)
			{
				char[] rowData = Console.ReadLine().ToCharArray();

				for (int col = 0; col < board.GetLength(1); col++)
					board[row, col] = rowData[col];
			}
		}

		private static void FindPath(int row, int col, char? direction = null)
		{
			if (IsIndexOutOfRange(row, col) || IsMarked(row, col))
				return;

			path.Add(direction);

			if (IsPath(row, col))
			{
				PrintPath();
				return;
			}

			Mark(row, col);

			FindPath(row - 1, col, 'U'); // UP
			FindPath(row + 1, col, 'D'); // DOWN
			FindPath(row, col - 1, 'L'); // LEFT
			FindPath(row, col + 1, 'R'); // RIGHT

			Unmark(row, col);
		}

		private static bool IsIndexOutOfRange(int row, int col)
		{
			return
				row < 0
				|| row >= board.GetLength(0)
				|| col < 0
				|| col >= board.GetLength(1);
		}

		private static bool IsMarked(int row, int col)
			=> board[row, col] == '*' || board[row, col] == 'V';

		private static bool IsPath(int row, int col)
			=> board[row, col] == 'e';

		private static void PrintPath()
		{
			Console.WriteLine(string.Join(string.Empty, path));
			path.RemoveAt(path.Count - 1);
		}

		private static void Mark(int row, int col)
			=> board[row, col] = 'V';

		private static void Unmark(int row, int col)
		{
			path.RemoveAt(path.Count - 1);
			board[row, col] = '-';
		}
	}
}
