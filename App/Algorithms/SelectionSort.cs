namespace App.Algorithms;

public class SelectionSort
{
	private static int[] Sort(int[] array)
	{
		var n = array.Length;
		for (var i = 0; i < n - 1; i++)
		{
			var minIndex = i;
			for (var j = i + 1; j < n; j++)
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

	public static void Run()
	{
		var numbers = new[] { 1, 3, 6, 4, 5, 2, 9, 8, 7 };
		var sortedNumbers = Sort(numbers);
		
		// 1,2,3,4,5,6,7,8,9
		Console.WriteLine(string.Join(",", sortedNumbers));
	}
}