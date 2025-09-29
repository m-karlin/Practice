namespace App.Algorithms;

public static class BinarySearch
{
	public static int Search(int[] array, int value)
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
}