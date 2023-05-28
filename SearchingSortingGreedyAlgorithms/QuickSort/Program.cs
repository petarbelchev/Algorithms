using System;
using System.Linq;

namespace QuickSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			QuickSort(numbers, 0, numbers.Length - 1);
			Console.WriteLine(string.Join(' ', numbers));
		}

		private static void QuickSort(int[] numbers, int startIdx, int endIdx)
		{
			if (startIdx >= endIdx)
				return;

			int pivot = startIdx;
			int leftIdx = pivot + 1;
			int rightIdx = endIdx;

			while (leftIdx <= rightIdx)
			{
				if (numbers[leftIdx] > numbers[pivot] && numbers[rightIdx] <= numbers[pivot])
					Swap(numbers, leftIdx, rightIdx);

				if (numbers[leftIdx] <= numbers[pivot])
					leftIdx++;

				if (numbers[rightIdx] > numbers[pivot])
					rightIdx--;
			}

			Swap(numbers, pivot, rightIdx);

			QuickSort(numbers, startIdx, rightIdx - 1);
			QuickSort(numbers, leftIdx, endIdx);
		}

		private static void Swap(int[] arr, int first, int second)
		{
			int temp = arr[first];
			arr[first] = arr[second];
			arr[second] = temp;
		}
	}
}
