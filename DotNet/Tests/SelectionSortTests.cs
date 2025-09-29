using App.Algorithms;

namespace App.Tests;

public class SelectionSortTests
{
    [Fact]
    public void Sort_OrdersArrayElements_InAscendingOrder()
    {
        
        var array = new[] { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_OrdersAlreadySortedArray_Correctly()
    {
        
        var array = new[] { 1, 2, 3, 4, 5 };
        var expected = new[] { 1, 2, 3, 4, 5 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_OrdersReverseSortedArray_Correctly()
    {
        
        var array = new[] { 5, 4, 3, 2, 1 };
        var expected = new[] { 1, 2, 3, 4, 5 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_OrdersArrayWithDuplicates_Correctly()
    {
        
        var array = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
        var expected = new[] { 1, 1, 2, 3, 3, 4, 5, 5, 6, 9 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_EmptyArray_ReturnsEmptyArray()
    {
        
        var array = new int[0];
        var expected = new int[0];

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_SingleElementArray_ReturnsSameArray()
    {
        
        var array = new[] { 42 };
        var expected = new[] { 42 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_ArrayWithNegativeNumbers_OrdersCorrectly()
    {
        
        var array = new[] { -3, 1, -4, 1, 5, -9, 2, 6, -5, 3 };
        var expected = new[] { -9, -5, -4, -3, 1, 1, 2, 3, 5, 6 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_ArrayWithAllElementsSame_ReturnsSameArray()
    {
        
        var array = new[] { 7, 7, 7, 7, 7 };
        var expected = new[] { 7, 7, 7, 7, 7 };

        
        var result = SelectionSort.Sort(array);

        
        Assert.Equal(expected, result);
    }
}