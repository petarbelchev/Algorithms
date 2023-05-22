using System;
using System.Collections.Generic;

namespace _8QueensPuzzle
{
	internal class Program
	{
		private static bool[,] board;
		private static int queensCounter = 0;
		private static int combinationsCounter = 0;
		private static int n;
		
		private static HashSet<int> attackedRows = new HashSet<int>();
		private static HashSet<int> attackedCols = new HashSet<int>();
		private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
		private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

		static void Main(string[] args)
		{
			n = int.Parse(Console.ReadLine());
			DrawBoard(n, n);
			SetQueen();
		}

		private static void SetQueen(int row = 0, int col = 0)
		{
			if (IsRowOutOfRange(row))
			{
				if (queensCounter == n)
					PrintBoard();

				return;
			}

			if (IsColOutOfRange(col))
			{
				SetQueen(row + 1, 0);
			}
			else if (IsCellAttacked(row, col))
			{
				SetQueen(row, col + 1);
			}
			else
			{
				MarkQueen(row, col);
				SetQueen(row + 1, 0);

				UnmarkQueen(row, col);
				SetQueen(row, col + 1);
			}
		}

		private static void MarkQueen(int row, int col)
		{
			board[row, col] = true;
			queensCounter++;
			attackedRows.Add(row);
			attackedCols.Add(col);
			attackedLeftDiagonals.Add(row - col);
			attackedRightDiagonals.Add(row + col);
		}

		private static void UnmarkQueen(int row, int col)
		{
			board[row, col] = false;
			queensCounter--;
			attackedRows.Remove(row);
			attackedCols.Remove(col);
			attackedLeftDiagonals.Remove(row - col);
			attackedRightDiagonals.Remove(row + col);
		}

		private static bool IsColOutOfRange(int col)
			=> col >= board.GetLength(1);

		private static void PrintBoard()
		{
			Console.WriteLine(++combinationsCounter);

			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					if (board[row, col])
						Console.Write("* ");
					else
						Console.Write("- ");
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		private static bool IsRowOutOfRange(int row)
			=> row >= board.GetLength(0);

		private static bool IsCellAttacked(int row, int col)
		{
			return
				attackedRows.Contains(row)
				|| attackedCols.Contains(col)
				|| attackedLeftDiagonals.Contains(row - col)
				|| attackedRightDiagonals.Contains(row + col);
		}

		private static void DrawBoard(int rows, int cols)
		{
			board = new bool[rows, cols];

			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
					board[row, col] = false;
			}
		}
	}
}
