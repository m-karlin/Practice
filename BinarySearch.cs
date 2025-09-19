namespace Practice.Algorithms;

public class BinarySearchTests
{
	private static int BinarySearch(int[] array, int value)
	{
		return BinarySearch(array, value, 0, array.Length - 1);
	}

	private static int BinarySearch(int[] array, int value,  int start, int end)
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

	[Fact]
	public void Test1()
	{
		var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var index = BinarySearch(numbers, 7);
		Assert.Equal(6, index);
	}

	[Fact]
	public void Test2()
	{
		var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		var index = BinarySearch(numbers, 10);
		Assert.Equal(-1, index);
	}
}