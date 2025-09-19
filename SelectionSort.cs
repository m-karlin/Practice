namespace Practice;

public class SelectionSortTests
{
	private static int[] Sort(int[] array)
	{
		var n = array.Length;
		for (int i = 0; i < n - 1; i++)
		{
			int minIndex = i;
			for (int j = i + 1; j < n; j++)
			{
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}
			if (minIndex != i)
			{
				(array[i], array[minIndex]) = (array[minIndex], array[i]);
			}
		}
		return array;
	}

	[Fact]
	public void Test1()
	{
		var numbers = new[] { 1, 3, 6, 4, 5, 2, 9, 8, 7 };
		var sortedNumbers = Sort(numbers);
		Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sortedNumbers);
	}
}