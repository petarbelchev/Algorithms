using System;
using System.Linq;

namespace MergeSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] sorted = MergeSort(numbers);
			Console.WriteLine(string.Join(' ', sorted));
		}

		private static int[] MergeSort(int[] arr)
		{
			if (arr.Length == 1)
				return arr;

			int[] leftArr = arr.Take(arr.Length / 2).ToArray();
			int[] rightArr = arr.Skip(arr.Length / 2).ToArray();

			return Merge(MergeSort(leftArr), MergeSort(rightArr));
		}

		private static int[] Merge(int[] leftArr, int[] rightArr)
		{
			int[] resultArr = new int[leftArr.Length + rightArr.Length];

			int resultArrIdx = 0;
			int leftArrIdx = 0;
			int rightArrIdx = 0;

			while (leftArrIdx < leftArr.Length && rightArrIdx < rightArr.Length)
			{
				if (leftArr[leftArrIdx] <= rightArr[rightArrIdx])
					resultArr[resultArrIdx++] = leftArr[leftArrIdx++];
				else
					resultArr[resultArrIdx++] = rightArr[rightArrIdx++];
			}

			while (leftArrIdx < leftArr.Length)
				resultArr[resultArrIdx++] = leftArr[leftArrIdx++];

			while (rightArrIdx < rightArr.Length)
				resultArr[resultArrIdx++] = rightArr[rightArrIdx++];

			return resultArr;
		}
	}
}
