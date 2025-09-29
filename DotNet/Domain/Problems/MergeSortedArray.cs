namespace App.Problems;

// https://leetcode.com/problems/merge-sorted-array?envType=problem-list-v2&envId=aqw21527
public static class MergeSortedArray
{
	public static void Merge(int[] nums1, int m, int[] nums2, int n)
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
}