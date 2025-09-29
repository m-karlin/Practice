using App.Algorithms;

namespace App.Tests;

public class QuickSortTests
{
    [Fact]
    public void Sort_OrdersArrayElements_InAscendingOrder()
    {
        
        var array = new[] { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_OrdersAlreadySortedArray_Correctly()
    {
        
        var array = new[] { 1, 2, 3, 4, 5 };
        var expected = new[] { 1, 2, 3, 4, 5 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_OrdersReverseSortedArray_Correctly()
    {
        
        var array = new[] { 5, 4, 3, 2, 1 };
        var expected = new[] { 1, 2, 3, 4, 5 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_OrdersArrayWithDuplicates_Correctly()
    {
        
        var array = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
        var expected = new[] { 1, 1, 2, 3, 3, 4, 5, 5, 6, 9 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_EmptyArray_DoesNotThrowException()
    {
        
        var array = new int[0];

        var exception = Record.Exception(() => QuickSort.Sort(array));
        Assert.Null(exception);
    }

    [Fact]
    public void Sort_SingleElementArray_DoesNotChangeArray()
    {
        
        var array = new[] { 42 };
        var expected = new[] { 42 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_ArrayWithNegativeNumbers_OrdersCorrectly()
    {
        
        var array = new[] { -3, 1, -4, 1, 5, -9, 2, 6, -5, 3 };
        var expected = new[] { -9, -5, -4, -3, 1, 1, 2, 3, 5, 6 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }

    [Fact]
    public void Sort_ArrayWithAllElementsSame_DoesNotChangeOrder()
    {
        
        var array = new[] { 7, 7, 7, 7, 7 };
        var expected = new[] { 7, 7, 7, 7, 7 };

        
        QuickSort.Sort(array);

        
        Assert.Equal(expected, array);
    }
}