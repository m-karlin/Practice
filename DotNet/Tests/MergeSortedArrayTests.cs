using App.Algorithms;
using App.Problems;

namespace App.Tests;

public class MergeSortedArrayTests
{
    [Fact]
    public void Merge_CorrectlyMergesTwoSortedArrays()
    {
        
        var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new int[] { 2, 5, 6 };
        var n = 3;
        var expected = new int[] { 1, 2, 2, 3, 5, 6 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWhenFirstArrayIsEmpty()
    {
        
        var nums1 = new int[] { 0 };
        var m = 0;
        var nums2 = new int[] { 1 };
        var n = 1;
        var expected = new int[] { 1 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWhenSecondArrayIsEmpty()
    {
        
        var nums1 = new int[] { 1, 2, 3 };
        var m = 3;
        var nums2 = new int[] { };
        var n = 0;
        var expected = new int[] { 1, 2, 3 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWhenBothArraysHaveOneElement()
    {
        
        var nums1 = new int[] { 1, 0 };
        var m = 1;
        var nums2 = new int[] { 2 };
        var n = 1;
        var expected = new int[] { 1, 2 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWhenFirstArrayElementsAreAllSmaller()
    {
        
        var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new int[] { 4, 5, 6 };
        var n = 3;
        var expected = new int[] { 1, 2, 3, 4, 5, 6 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWhenSecondArrayElementsAreAllSmaller()
    {
        
        var nums1 = new int[] { 4, 5, 6, 0, 0, 0 };
        var m = 3;
        var nums2 = new int[] { 1, 2, 3 };
        var n = 3;
        var expected = new int[] { 1, 2, 3, 4, 5, 6 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_CorrectlyMergesWithDuplicateElements()
    {
        
        var nums1 = new int[] { 1, 3, 5, 0, 0, 0 };
        var m = 3;
        var nums2 = new int[] { 1, 3, 5 };
        var n = 3;
        var expected = new int[] { 1, 1, 3, 3, 5, 5 };

        
        MergeSortedArray.Merge(nums1, m, nums2, n);

        
        Assert.Equal(expected, nums1);
    }
}