namespace App.Algorithms;

// https://leetcode.com/problems/merge-sorted-array?envType=problem-list-v2&envId=aqw21527
public class MergeSortedArray
{
	private static void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		var i = m - 1;
		var j = n - 1;
		var k = m + n - 1;

		while (i >= 0 && j >= 0)
		{
			if (nums1[i] > nums2[j])
			{
				nums1[k] = nums1[i];
				i--;
			}
			else
			{
				nums1[k] = nums2[j];
				j--;
			}

			k--;
		}

		while (j >= 0)
		{
			nums1[k] = nums2[j];
			j--;
			k--;
		}
	}

	public static void Run()
	{
		var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
		var m = 3;
		var nums2 = new[] { 2, 5, 6 };
		var n = 3;
		Merge(nums1, m, nums2, n);
		// 1,2,2,3,5,6
		Console.WriteLine(string.Join(",", nums1));

		nums1 = [1];
		m = 1;
		nums2 = [];
		n = 0;
		Merge(nums1, m, nums2, n);
		// 1
		Console.WriteLine(string.Join(",", nums1));

		nums1 = [0];
		m = 0;
		nums2 = [1];
		n = 1;
		Merge(nums1, m, nums2, n);
		// 1
		Console.WriteLine(string.Join(",", nums1));
	}
}