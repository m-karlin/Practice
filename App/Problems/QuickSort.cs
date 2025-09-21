namespace App.Problems;

public class QuickSort
{
	private static readonly Random Random = new();

	private static int[] Sort(int[] array)
	{
		if (array.Length < 2)
		{
			return array;
		}

		var pivotIndex = Random.Next(array.Length);
		var pivot = array[pivotIndex];

		var less = new List<int>(array.Length);
		var greater = new List<int>(array.Length);

		for (var i = 0; i < array.Length; i++)
		{
			if (i == pivotIndex) continue;

			if (array[i] <= pivot)
			{
				less.Add(array[i]);
			}
			else
			{
				greater.Add(array[i]);
			}
		}

		var result = new List<int>();
		result.AddRange(Sort(less.ToArray()));
		result.Add(pivot);
		result.AddRange(Sort(greater.ToArray()));
		return result.ToArray();
	}

	public static void Run()
	{
		var numbers = new[] { 1, 3, 6, 4, 5, 2, 9, 8, 7 };
		var sortedNumbers = Sort(numbers);
		// 1,2,3,4,5,6,7,8,9
		Console.WriteLine(string.Join(",", sortedNumbers));
	}
}