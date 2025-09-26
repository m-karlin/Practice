namespace App.Algorithms;

public static class QuickSort
{
	private static readonly Random Random = new();

	public static void Sort(int[] array)
	{
		Sort(array, 0, array.Length - 1);
	}

	private static void Sort(int[] array, int low, int high)
	{
		if (low < high)
		{
			var pivotIndex = Partition(array, low, high);
			Sort(array, low, pivotIndex - 1);
			Sort(array, pivotIndex + 1, high);
		}
	}

	private static int Partition(int[] array, int low, int high)
	{
		var pivotIndex = low + Random.Next(high - low + 1);
		var pivot = array[pivotIndex];

		Swap(array, pivotIndex, high);

		var i = low - 1;

		for (var j = low; j < high; j++)
		{
			if (array[j] <= pivot)
			{
				i++;
				Swap(array, i, j);
			}
		}

		Swap(array, i + 1, high);
		return i + 1;
	}

	private static void Swap(int[] array, int i, int j)
	{
		(array[i], array[j]) = (array[j], array[i]);
	}
}