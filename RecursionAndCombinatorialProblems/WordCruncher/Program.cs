using System;
using System.Collections.Generic;

namespace WordCruncher
{
	internal class Program
	{
		private static string finalWord;
		private static Dictionary<string, int> partsWithCount;
		private static Dictionary<int, List<string>> partsByIndex;
		private static LinkedList<string> wordCtor;

		static void Main(string[] args)
		{
			SetUp();

			wordCtor = new LinkedList<string>();

			FindCombinations(0);
		}

		private static void SetUp()
		{
			string[] parts = Console.ReadLine().Split(", ");
			finalWord = Console.ReadLine();

			partsWithCount = new Dictionary<string, int>();

			Array.ForEach(parts, part =>
			{
				if (!partsWithCount.ContainsKey(part))
					partsWithCount[part] = 0;
				
				partsWithCount[part]++;
			});

			partsByIndex = new Dictionary<int, List<string>>();

			foreach (var (part, count) in partsWithCount)
			{
				int index = finalWord.IndexOf(part);

				if (index == -1)
					continue;

				while (index != -1)
				{
					if (!partsByIndex.ContainsKey(index))
						partsByIndex[index] = new List<string>();

					partsByIndex[index].Add(part);

					index = finalWord.IndexOf(part, index + part.Length);
				}
			}
		}

		private static void FindCombinations(int index)
		{
			if (index == finalWord.Length && string.Join(string.Empty, wordCtor) == finalWord)
			{
				Console.WriteLine(string.Join(' ', wordCtor));
				return;
			}

			if (!partsByIndex.ContainsKey(index))
				return;

			for (int i = 0; i < partsByIndex[index].Count; i++)
			{
				string word = partsByIndex[index][i];
				
				if (partsWithCount[word] == 0)
					continue;

				wordCtor.AddLast(word);
				partsWithCount[word]--;

				FindCombinations(index + word.Length);

				wordCtor.RemoveLast();
				partsWithCount[word]++;
			}
		}
	}
}
