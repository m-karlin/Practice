namespace App.Problems;

// Дан массив nums, содержащий n различных чисел в диапазоне [0, n]. 
// Необходимо вернуть единственное число из диапазона, которого не хватает в массиве;

public static class MissingNumber
{
	public static int Find(int[] nums)
	{
		var n = nums.Length;
		var expectedSum = n * (n + 1) / 2;
		var actualSum = nums.Sum();
		return expectedSum - actualSum;
	}
}