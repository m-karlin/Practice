namespace App.Problems;

public class UniqueChar
{
	private static class UniqueCharFinder
	{
		public static int FindIndex(string input)
		{
			var uniqueChars = new Dictionary<char, int>();
			foreach (var letter in input)
			{
				if (uniqueChars.TryGetValue(letter, out var value))
					uniqueChars[letter] = ++value;
				else
					uniqueChars[letter] = 1;
			}

			for (var i = 0; i < input.Length; i++)
			{
				if (uniqueChars[input[i]] == 1)
					return i;
			}

			return -1;
		}
	}

	public static void Run()
	{
		// 0
		Console.WriteLine(UniqueCharFinder.FindIndex("job"));
		// -1
		Console.WriteLine(UniqueCharFinder.FindIndex("aabb"));
		// 2
		Console.WriteLine(UniqueCharFinder.FindIndex("aacbbd"));
	}
}