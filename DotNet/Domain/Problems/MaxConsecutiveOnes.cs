namespace App.Problems;

// https://leetcode.com/problems/max-consecutive-ones?envType=problem-list-v2&envId=aqw21527
public static class MaxConsecutiveOnes
{
	public static int Calculate(int[] nums)
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
}