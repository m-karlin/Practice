namespace App.Problems;

// https://leetcode.com/problems/max-consecutive-ones?envType=problem-list-v2&envId=aqw21527
public class MaxConsecutiveOnes
{
	private static int Calculate(int[] nums)
	{
		var max = 0;
		var current = 0;

		foreach (var num in nums)
		{
			if (num == 1)
			{
				current++;
				max = Math.Max(max, current);
			}
			else
			{
				current = 0;
			}
		}

		return max;
	}

	public static void Run()
	{
		var nums = new[] { 1, 1, 0, 1, 1, 1 };
		// 3 
		Console.WriteLine(Calculate(nums));

		nums = [1, 0, 1, 1, 0, 1];
		// 2
		Console.WriteLine(Calculate(nums));
	}
}