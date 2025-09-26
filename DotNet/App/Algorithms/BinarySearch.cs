namespace App.Algorithms;

public class BinarySearch
{
	private static int Search(int[] array, int value)
	{
		return Search(array, value, 0, array.Length - 1);
	}

	private static int Search(int[] array, int value, int start, int end)
	{
		while (true)
		{
			if (start > end) return -1;

			var middle = start + (end - start) / 2;

			if (array[middle] == value) return middle;

			if (array[middle] < value)
			{
				start = middle + 1;
				continue;
			}

			if (array[middle] > value)
			{
				end = middle - 1;
				continue;
			}

			return -1;
		}
	}

	public static void Run()
	{
		var numbers1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var index1 = Search(numbers1, 7);
		// 6
		Console.WriteLine(index1);

		var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var index2 = Search(numbers, 10);
		// -1
		Console.WriteLine(index2);
	}
}