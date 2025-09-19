namespace Practice.Problems;

// https://leetcode.com/problems/merge-sorted-array?envType=problem-list-v2&envId=aqw21527
public class MergeSortedArrayTests
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

	[Fact]
	public void Test1()
	{
		var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
		const int m = 3;
		var nums2 = new[] { 2, 5, 6 };
		const int n = 3;
		Merge(nums1, m, nums2, n);
		Assert.Equal(new[] { 1, 2, 2, 3, 5, 6 }, nums1);
	}

	[Fact]
	public void Test2()
	{
		var nums1 = new[] { 1 };
		const int m = 1;
		var nums2 = Array.Empty<int>();
		const int n = 0;
		Merge(nums1, m, nums2, n);
		Assert.Equal(new[] { 1 }, nums1);
	}

	[Fact]
	public void Test3()
	{
		var nums1 = new int[1];
		const int m = 0;
		var nums2 = new[] { 1 };
		const int n = 1;
		Merge(nums1, m, nums2, n);
		Assert.Equal(new[] { 1 }, nums1);
	}
}